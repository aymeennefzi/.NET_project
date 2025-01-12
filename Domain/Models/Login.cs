using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Login : BaseEntity
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
