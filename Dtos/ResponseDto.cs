using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandlingApi.Dtos
{
    public class ResponseDto
    {
        public string Message { get; set; }

        public bool Status { get; set; }

        public object Data { get; set; }
    }
}
