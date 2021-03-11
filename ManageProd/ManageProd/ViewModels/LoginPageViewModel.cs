using ManageProd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageProd.ViewModels
{
    public class LoginPageViewModel
    {
        public UserModel User { get; set; }
        public bool RememberUser { get; set; }
    }
}
