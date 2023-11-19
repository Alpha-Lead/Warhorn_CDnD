namespace Warhorn.API.Types
{
    public class SessionRole //: Node
    {
        public string? id;

        public EventRole? parent;
        public List<Permission> permissions;
        public Session? session;
    }
}