using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warhorn.API.Types
{
    public class Signup
    {
        public SignupRole role;
        public Session? session;
        public User user;
    }
}
