using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotenet7web_api_pratice.models
{
    public class ServicesResponses<T>
    { 
        
        public  T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; }   = string.Empty; 
    }
}