namespace Warhorn.API.Types
{
    public class Permission //: Node
    {
        public string? id;

        public bool? allow;
        public DateTime? createdAt;
        public Operation? operation;
    }
}