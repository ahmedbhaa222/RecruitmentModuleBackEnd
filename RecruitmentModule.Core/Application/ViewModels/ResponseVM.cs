using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Application.ViewModels
{
    public class ResponseVM<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
