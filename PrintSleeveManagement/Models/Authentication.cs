using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Authentication
    {
        public static string Username { get; set; }
        public string Password { get; set; }

        public enum AUTHENTICATION_RESULT
        {
            SUCCESS,
            FAIL
        }

        public AUTHENTICATION_RESULT login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                Username = username;
                return AUTHENTICATION_RESULT.SUCCESS;
            }
            return AUTHENTICATION_RESULT.FAIL;
        }
    }
}
