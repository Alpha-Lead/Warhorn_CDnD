namespace Warhorn.API.Types
{
    public class Registration //: Node
    {
        public string? id;

        public RegistrationActivationState? activationState;
        public Money? amountCharged;
        public Money? amountOwed;
        public Money? amountPaid;
        public DateTime? createdAt;
        public DateTime? canceledAt;
        public Event _event;
        public bool? isClearedForSignup;
        public string notes;
        public User registrant;
        public List<EventRole>? roles;
        public string staffNotes;
    }
}