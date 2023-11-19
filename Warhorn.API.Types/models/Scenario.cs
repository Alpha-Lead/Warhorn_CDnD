namespace Warhorn.API.Types
{
    public class Scenario //: Node
    {
        public string? id;

        public bool? allowCharacterDetails;
        public string author;
        public string blurb;
        public Campaign campaign;
        public string coverArtUrl;
        public int defaultTableSize;
        public Event _event;
        public string externalUrl;
        public List<CampaignFaction>? factions;
        public GameSystem gameSystem;
        public bool? isCustom;
        public int maxLevel;
        public int minlevel;
        public string? name;
        public string slug;
        public List<CampaignTag>? tags;
    }
}