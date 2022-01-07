using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProj3
{
    public class User
    {
        public bool IsAdmin;
        public User(bool IsAdmin_) { this.IsAdmin = IsAdmin_; }
        public User() { this.IsAdmin = true; }
    }
}
