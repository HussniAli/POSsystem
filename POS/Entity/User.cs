using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace POS.Entity
{
    public class User
    {
        public int Id{ get; set; }
        public string UserName{ get; set; }
        public string Pssword{ get; set; }
        public string Email{ get; set; }
    }
}