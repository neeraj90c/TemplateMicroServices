using AuthenticationService.DTO;

namespace AuthenticationService.Interface
{
    public interface IUserContract
    {
        public Task<UserDTO> Authenticate(string companyCode, string userName, string password);
        public Task<UserDTO> AuthenticateAzure(string FirstName, string LastName, string AzureUserId, string AzureEmailId, DateTime ExpiresOn);
    }
}
