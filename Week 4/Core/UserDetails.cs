using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class UserDetails
    {
        [UserValidation]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
