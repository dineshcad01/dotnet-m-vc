using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace MVC_csharp2.Models
{
    public class LoginModel
    {
        public string? user_name {get; set;}

        public string? password {get; set;}
    }
}