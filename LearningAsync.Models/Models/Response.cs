using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAsync.Models.Models
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }

    }
}
