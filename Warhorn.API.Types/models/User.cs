namespace Warhorn.API.Types
{
    public class User //: Node
    {
        public string? id;

        public UserActivationState? activationState;
        public List<ClientApplication>? applications;
        public List<ClientAuthorization>? authorizations;
        public UserAvatar? avatar;
        public List<CampaignStaffMembership> campaignStaffMemberships;
        public List<Character>? characters;
        public DateTime? confirmedAt;
        public DateTime? createdAt;
        public DateTime deactivatedAt;
        public string email;
        public List<Identity>? identities;
        public bool? isAdmin;
        public bool? isConfirmed;
        public DateTime lastSignedInAt;
        public string name;
        public List<OrganizedPlayNetworkMembership>? organizedPlayNetworkMemberships;
        public List<Registration>? registrations;
        public string? timezone;
    }
}