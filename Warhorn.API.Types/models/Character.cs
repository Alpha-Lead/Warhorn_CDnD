namespace Warhorn.API.Types
{
    public class Character //: Node
    {
        public string? id;

        public CharacterActivationState? activationState;
        public DateTime archivedAt;
        public Campaign? campaign;
        public CampaignMode campaignMode;
        public List<CharacterClassLevel> characterClassLevels;
        public DateTime createdAt;
        public GameSystem? gameSystem;
        public string membershipNumber;
        public string? name;
        public string notes;
        public User player;
        public List<PlayerSignupConnection> signups;
        public string? slug;
    }
}