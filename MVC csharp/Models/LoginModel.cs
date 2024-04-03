using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace MVC_csharp.Models
{
    public class LoginModel
    {
        public string? User_id {get; set;}

        public string? Password {get; set;}
    }
}