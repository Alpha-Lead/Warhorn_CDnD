namespace Warhorn.API.Types
{
    public class Session
    {
        public int? availableGmSeats;
        public int? availablePlayerSeats;
        public CampaignMode campaignMode;
        public DateTime endsAt;
        public List<GmSignup>? gmSignups;
        public int? gmSignupsCount;
        public List<GmWaitlistEntry>? gmWaitlistEntries;
        public int? gmWaitlistEntriesCount;
        public bool? isLocationPublic;
        public bool? isOnline;
        public bool? isVisible;
        public string language;
        public List<SessionLink>? links;
        public string location;
        public int? maxGms;
        public int? maxPlayers;
        public string? name;
        public string notes;
        public List<PlayerSignup>? playerSignups;
        public int? playerSignupsCount;
        public List<PlayerWaitlistEntry> playerWaitlistEntries;
        public int? playerWaitlistEntriesCount;
        public List<SessionRole>? roles;
        public Scenario? scenario;
        public DateTime startsAt;
        public SessionStatus? status;
        public int? tableCount;
        public int? tableSize;
        public string? timezone;
        public bool? useGms;
        public int? useWaitlist;
        public string? uuid;
        public List<VirtualTableTop>? virtualTableTops;
        public List<VoiceChatService>? voiceChatServices;
    }
}
