namespace Warhorn.API.Types
{
    public class Campaign //: Node
    {
        public string? id;
        public string cardImageUrl;
        public string? code;
        public int defaultTableSize;
        public GameSystem? gameSystem;
        public string? name;
        public OrganizedPlayNetwork network;
        public string? slug;
        public int? upcomingSessionsCount;
        public string url;
        public bool? usesMemberNumbers;
    }
}