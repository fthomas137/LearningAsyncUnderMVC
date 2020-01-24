using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningAsyncUnderMVC.Models
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }

    }
}