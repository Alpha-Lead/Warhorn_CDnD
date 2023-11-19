using System.Diagnostics.Contracts;

namespace Warhorn.API.Types
{
    public class EventRole //: Node
    {
        public string? id;

        public DateTime? createdAt;
        public bool? isAutomated;
        public string? name;
        public List<Permission> permissions;
    }
}