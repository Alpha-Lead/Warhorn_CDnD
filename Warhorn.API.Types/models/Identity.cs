namespace Warhorn.API.Types
{
    public class Identity //: Node
    {
        public string? id;

        public string? accessToken;
        public DateTime? createdAt;
        public List<string>? permissions;
        public IdentityProvider? provider;
        public string? uid;
    }
}