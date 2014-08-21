using System.Globalization;
using System.Web.Security;
using IdentitySample.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using PMS.Implementation.Identity;
using PMS.Interfaces.IServices;
using PMS.Models.DomainModels;
using PMS.Models.IdentityModels;
using PMS.Models.IdentityModels.ViewModels;
using PMS.Models.MenuModels;
using PMS.Models.RequestModels;
using PMS.Web.Controllers;
using PMS.Web.ModelMappers;
using PMS.Web.ViewModels.Domain;
using PMS.Web.ViewModels.Common;

namespace IdentitySample.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        #region Private

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IMenuRightsService menuRightService;
        private IDomainKeyService domainKeyService;


        /// <summary>
        /// Set User Permission
        /// </summary>
        private void SetUserPermissions(string userEmail)
        {
            //ClaimsIdentity userIdentity = (ClaimsIdentity) User.Identity;
            //IEnumerable<Claim> claims = userIdentity.Claims;
            //string roleClaimType = userIdentity.RoleClaimType;
            //IEnumerable<Claim> roles = claims.Where(c => c.Type == roleClaimType).ToList();

            ApplicationUser userResult = UserManager.FindByEmail(userEmail);
            IList<IdentityUserRole> aspUserroles = userResult.Roles.ToList();
            IEnumerable<MenuRight> permissionSet = menuRightService.FindMenuItemsByRoleId(aspUserroles[0].RoleId).ToList();

            Session["UserMenu"] = permissionSet;
            Session["UserPermissionSet"] = permissionSet.Select(menuRight => menuRight.Menu.PermissionKey).ToList();
        }

        private void CreateRoles()
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));
            if (!roleManager.RoleExists("Landlord"))
                roleManager.Create(new IdentityRole("Landlord"));
        }

        private void SetUserRoles(ApplicationUser applicationUser, String UserId, RegisterViewModel model)
        {
            //check if User is "SuperAdmin", create New user with Role "Admin"
            if (Session["RoleName"].ToString().Equals("SuperAdmin"))
            {
                UserManager.AddToRole(applicationUser.Id, "Admin");
                DomainKeys domainKeys = new DomainKeys
                                        {
                                            DomainKey = model.DomainKey,
                                            //ExpiryDate = (DateTime)model.ExpiryDate,
                                            ExpiryDate = Convert.ToDateTime(model.ExpiryDate),
                                            UserId = UserId,
                                            CreatedDate = (DateTime.Now),
                                            UpdatedDate = DateTime.Now,
                                            UpdatedBy = Session["LoginID"] as string,
                                            CreatedBy = Session["LoginID"] as string
                                        };
                domainKeyService.AddDomainKey(domainKeys);
            }
            //else is Manadatory that Current user is "Admin", and Always Creates new user with Role As "Admin"
            else
            {
                UserManager.AddToRole(applicationUser.Id, "Landlord");
                DomainKeys adminDomainKeys = domainKeyService.GetDomainKeyByUserId(Session["LoginID"] as string);
                DomainKeys domainKeys = new DomainKeys
                {
                    DomainKey = adminDomainKeys.DomainKey,
                    //ExpiryDate = (DateTime)model.ExpiryDate,
                    ExpiryDate = Convert.ToDateTime(adminDomainKeys.ExpiryDate),
                    UserId = UserId,
                    CreatedDate = (DateTime.Now),
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = Session["LoginID"] as string,
                    CreatedBy = Session["LoginID"] as string
                };
                domainKeyService.AddDomainKey(domainKeys);

            }
        }

        #endregion

        #region Constructor

        public AccountController(IMenuRightsService menuRightService, IDomainKeyService domainKeyService)
        {
            this.menuRightService = menuRightService;
            this.domainKeyService = domainKeyService;
        }

        #endregion

        #region Public

        public ActionResult Manage()
        {
            return View();
        }
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                //return RedirectToAction("Index", new { Message = IdentitySample.Controllers.ManageController.ManageMessageId.ChangePasswordSuccess });
                //return RedirectToAction("Index", "Dashboard");
                ViewBag.MessageVM = new MessageViewModel { Message = "Password has been updated.", IsUpdated = true };
         
                return View();
            }
            AddErrors(result);
            return View(model);
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        private ApplicationRoleManager _roleManager;

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.MessageVM = TempData["message"] as MessageViewModel;
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    ModelState.AddModelError("", "Please confirm your email");
                    return View();
                }
                ApplicationUser resultUser = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(model.Email);
                string role = HttpContext.GetOwinContext().Get<ApplicationRoleManager>().FindById(resultUser.Roles.ToList()[0].RoleId).Name;
                if (!role.ToLower().Contains("superadmin"))
                {
                    DomainKeys resultDomainKey = domainKeyService.GetDomainKeyByUserId(user.Id);
                    if (resultDomainKey == null || resultDomainKey.ExpiryDate < DateTime.Now)
                    {
                        ModelState.AddModelError("", "Please renew your license");
                        return View();
                    }
                }


            }
            var result =
                await
                    SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                        shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                {
                    SetUserPermissions(model.Email);
                    return RedirectToAction("Index", "Dashboard");                    
                    //TODO: Redirect to return Url 
                    //return RedirectToLocal(returnUrl);
                }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new {ReturnUrl = returnUrl});
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(await SignInManager.GetVerifiedUserIdAsync());
            if (user != null)
            {
                ViewBag.Status = "For DEMO purposes the current " + provider + " code is: " +
                                 await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            }
            return View(new VerifyCodeViewModel {Provider = provider, ReturnUrl = returnUrl});
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await
                    SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: false,
                        rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string email)
        {
            if (email != null && email != string.Empty)
            {
                var userToEdit = UserManager.FindByName(email);
                var userDomainKey = domainKeyService.GetDomainKeyByUserId(userToEdit.Id.ToString());
                return View(userToEdit.CreateFrom(userDomainKey));
            }
            return View(new RegisterViewModel());
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserId))
            {
                //means update case
                DomainKeys domainKey=domainKeyService.GetDomainKeyByUserId(model.UserId);
                domainKey.ExpiryDate = Convert.ToDateTime(model.ExpiryDate);
                domainKey.UpdatedDate = DateTime.Now;
                domainKeyService.UpdateDomainKey(domainKey);
                TempData["message"] = new MessageViewModel { Message = "User has been updated.", IsUpdated = true };
         
                return RedirectToAction("Users");
            }
            else if (ModelState.IsValid)
            {

                CreateRoles();

                var user = new ApplicationUser {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email, 
                    Email = model.Email, 
                    CompanyName = model.CompanyName,
                    IsPrimary = model.IsPrimary
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var currentUser = UserManager.FindByName(user.UserName);
                    SetUserRoles(user, user.Id, model);
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new {userId = user.Id, code = code},
                        protocol: Request.Url.Scheme);
                    await
                        UserManager.SendEmailAsync(model.Email, "Confirm your account",
                            "Please confirm your account by clicking this link: <a href=\"" + callbackUrl +
                            "\">link</a><br>Your Password is:"+model.Password);
                    ViewBag.Link = callbackUrl;
                    TempData["message"] = new MessageViewModel{Message="Registeration Confirmation email send to the user.",IsSaved = true};
                    return RedirectToAction("Users");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
           
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);

                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    ModelState.AddModelError("", "Email not found.");
                    // Don't reveal that the user does not exist or is not confirmed
                    return View(model);
                }

                var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new {userId = user.Id, code = code},
                    protocol: Request.Url.Scheme);
                await
                    UserManager.SendEmailAsync(user.Email, "Reset Password",
                        "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                ViewBag.Link = callbackUrl;
                TempData["message"] = new MessageViewModel { Message = "An email with Password link has been sent.", IsUpdated = true };
                return RedirectToAction("Login");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("Login", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider,
                Url.Action("ExternalLoginCallback", "Account", new {ReturnUrl = returnUrl}));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions =
                userFactors.Select(purpose => new SelectListItem {Text = purpose, Value = purpose}).ToList();
            return View(new SendCodeViewModel {Providers = factorOptions, ReturnUrl = returnUrl});
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new {Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl});
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new {ReturnUrl = returnUrl});
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation",
                        new ExternalLoginConfirmationViewModel {Email = loginInfo.Email});
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model,
            string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser {UserName = model.Email, Email = model.Email};
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [Authorize]
        public ActionResult Profile()
        {
                ApplicationUser result = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);
                var ProfileViewModel = new ProfileViewModel
                                       {
                                           Address = (result.Address!= null && result.Address != string.Empty)?result.Address: string.Empty,
                                           Email = result.Email,
                                           FirstName = result.FirstName,
                                           LastName = result.LastName,
                                           PhoneNumber = (result.PhoneNumber != null && result.PhoneNumber != null)?result.PhoneNumber: string.Empty
                                       };
             return View(ProfileViewModel); 
        }

        [HttpPost]
        [Authorize]
        public ActionResult Profile(ProfileViewModel profileViewModel)
        {
            ApplicationUser result = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);
            //Updating Data
            result.FirstName = profileViewModel.FirstName;
            result.LastName = profileViewModel.LastName;
            result.PhoneNumber = profileViewModel.PhoneNumber;
            result.Address = profileViewModel.Address;

            var updationResult = UserManager.UpdateAsync(result);

            return RedirectToAction("Index", "Dashboard");
        }

        [Authorize]
        public ActionResult Users()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Users(UserSearchRequest userSearchRequest)
        {
           
            //var users = domainKeyService.GetAllUsersByUserId(Session["LoginId"].ToString());
            userSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var users = domainKeyService.GetAllUsersByUserId(userSearchRequest);
            IEnumerable<PMS.Web.Models.Users> usersList = users.Users.Select(x => x.CreateFrom(Session["RoleName"].ToString())).ToList();
            UserAjaxViewModel userAjaxViewModel = new UserAjaxViewModel
                                                  {
                                                      data = usersList,
                                                      recordsTotal = users.TotalCount,
                                                      recordsFiltered = users.TotalCount
                                                  };
            return Json(userAjaxViewModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties {RedirectUri = RedirectUri};
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
    }
}
