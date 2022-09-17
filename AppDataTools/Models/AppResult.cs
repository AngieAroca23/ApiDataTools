using System;

namespace AppDataTools.Models
{
    public class AppResult
    {
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; } 
        public string Message { get; set; }
    }
}