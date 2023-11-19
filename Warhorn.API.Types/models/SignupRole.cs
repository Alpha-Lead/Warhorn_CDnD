using System.Security;

namespace Warhorn.API.Types
{
    public class SignupRole //: Node
    {
        public string? id;

        public DateTime? createdAt;
        public List<Permission>? permissions;
        public Signup? signup;
    }
}