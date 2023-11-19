using System.Reflection.Metadata;

namespace Warhorn.API.Types
{
    public class GmSignup //: Node, Signup
    {
        public string? id;

        public SignupRole role;
        public Session? session;
        public User user;
    }
}