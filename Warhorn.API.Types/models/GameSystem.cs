namespace Warhorn.API.Types
{
    public class GameSystem //: Node
    {
        public string? id;
        public string abbreviation;
        public List<CharacterClassConnection>? characterClasses;
        public string? name;
        public string? slug;
        public int? upcomingSessionsCount;
        public string url;
        public bool? usesCharacterClasses;
    }
}