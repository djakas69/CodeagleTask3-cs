﻿using System.Net;

namespace Csharp_Task_3.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }
    }
}
