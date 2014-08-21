using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.Common;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;
using PMS.Repository.BaseRepository;

namespace PMS.Repository.Repositories
{
    public sealed class DomainKeyRepository : BaseRepository<DomainKeys>, IDomainKeyRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public DomainKeyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DomainKeys> DbSet
        {
            get { return db.DomainKeys; }
        }
        private readonly Dictionary<UserByColumn, Func<DomainKeys, object>> userClause =
             new Dictionary<UserByColumn, Func<DomainKeys, object>>
                    {
                        { UserByColumn.Name, c => c.User.FirstName  },
                        { UserByColumn.Email, c => c.User.Email},
                        { UserByColumn.CreatedDate, c => c.CreatedDate},
                        { UserByColumn.UpdatedBy, c => c.UpdatedBy},
                        { UserByColumn.UpdatedDate, c => c.UpdatedDate},
                        { UserByColumn.RoleName, c => c.User.Roles},
                        { UserByColumn.ExpiryDate, c => c.ExpiryDate},
                        { UserByColumn.CompanyName, c => c.User.CompanyName},
                        { UserByColumn.IsPrimary, c => c.User.IsPrimary}
                    };

        public DomainKeyResponse GetAllUsersByUserId(UserSearchRequest userSearchRequest)
        {
            int fromRow = (userSearchRequest.PageNo - 1) * userSearchRequest.PageSize;
            int toRow = userSearchRequest.PageSize;
            Expression<Func<DomainKeys, bool>> query =
                s => (s.CreatedBy == (userSearchRequest.UserId.ToString())) &&
                    (string.IsNullOrEmpty(userSearchRequest.Email) || s.User.Email.Contains(userSearchRequest.Email)) &&
                    (string.IsNullOrEmpty(userSearchRequest.SearchString) || (s.User.FirstName.Contains(userSearchRequest.SearchString) || s.User.LastName.Contains(userSearchRequest.SearchString)));
            var users = userSearchRequest.IsAsc ? DbSet.Where(query).OrderBy(userClause[userSearchRequest.BuildingOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                           : DbSet.Where(query).OrderByDescending(userClause[userSearchRequest.BuildingOrderBy]).Skip(fromRow).Take(toRow).ToList();
            return new DomainKeyResponse { Users = users, TotalCount = DbSet.Count(query) };
        }

        public DomainKeys GetUserByUserId(string userId)
        {
            DomainKeys user = DbSet.FirstOrDefault(x => x.UserId.Equals(userId));
            return user;
        }
        #endregion


        public DomainKeys GetDomainKeyByUserId(string userId)
        {
            return DbSet.SingleOrDefault(x=>x.UserId==userId);
        }

        /// <summary>
        /// All Users for Admin
        /// </summary>
        public IEnumerable<DomainKeys> GetAllUserForAdmin(string adminId)
        {
            return DbSet.Where(user => user.UpdatedBy == adminId).ToList();
        }
    }
}
