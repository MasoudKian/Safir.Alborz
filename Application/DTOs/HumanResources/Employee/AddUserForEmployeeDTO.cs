﻿
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.HumanResources.Employee
{
    public class AddUserForEmployeeDTO
    {
        public string FirsName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public IFormFile? ImageFile { get; set; } // فایل عکس
        public string Password { get; set; } = string.Empty;
    }
}
