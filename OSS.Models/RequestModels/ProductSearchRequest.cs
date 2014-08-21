using OSS.Models.Common;

namespace OSS.Models.RequestModels
{
    public class ProductSearchRequest : GetPagedListRequest
    {
        public int? CategoryId { get; set; }
        
        /// <summary>
        /// Product Order By
        /// </summary>
        public ProductByColumn ProductOrderBy
        {
            get
            {
                return (ProductByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
