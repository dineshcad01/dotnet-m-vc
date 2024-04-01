using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace MVC_csharp.Models
{
    public class RegistrationModel
    {
        public string? Full_Name {get; set;}
        public string? Contact_number {get; set;}

        public string? Address {get; set;}

        public string? Email_id {get; set;}

        public string? User_id {get; set;}

        public string? Password {get; set;}

    }
}