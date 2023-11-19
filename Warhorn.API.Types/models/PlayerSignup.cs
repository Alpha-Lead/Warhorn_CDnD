namespace Warhorn.API.Types
{
    public class PlayerSignup //: Node, Signup
    {
        public string? id;

        public SignupRole role;
        public Session? session;
        public User user;

        public Character character;
        public CharacterClass characterClass;
        public CombatRole combatRole;
    }
}