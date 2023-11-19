namespace Warhorn.API.Types
{
    public class Event //: Node
    {
        public string? id;

        public EventActivationState activationState;
        public List<CampaignConnection>? campaigns;
        public DateTime? createdAt;
        public int? followsCount;
        public List<GameSystemConnection>? gameSystems;
        public bool? isInPerson;
        public bool? isOnline;
        public bool? isVisible;
        public string language;
        public List<LanguageFilter>? languages;
        public EventLocation location;
        public User? organizer;
        public EventPeriod period;
        public List<RegistrationConnection>? registrations;
        public int? registrationsCount;
        public List<EventRole> roles;
        public List<SlotConnection>? slots;
        public string? slug;
        public string? timeZone;
        public string? title;
        public string? url;
        public bool? useGms;
        public bool? useWaitlist;
        public List<VenueConnection>? venues;
        public List<string>? virtualTabletopProductTypes;
        public List<string>? voiceChatServiceTypes;

    }
}