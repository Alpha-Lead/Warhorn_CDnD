namespace Warhorn.API.Types
{
    public class CampaignFaction//: Node
    {
        public string? id;

        public CampaignFactionActivationState? activationState;
        public Campaign? campaign;
        public string description;
        public string? name;
        public DateTime retiredAt;
        public string url;
    }
}