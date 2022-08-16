using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Application.ViewModels
{
    public class PagedResponseVM<T> :ResponseVM<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public PagedResponseVM(T data, int pageNumber, int pageSize,int TotalRecords)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.IsSuccess = true;
            this.TotalRecords = TotalRecords;
        }
    }
}
