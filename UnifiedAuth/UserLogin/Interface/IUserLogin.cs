using UserLogin.DTO;

namespace UserLogin.Interface
{
    public interface IUserLogin
    {
        Task<UserLoginDTO> Create(UserLoginCreateRequestDTO reqDTO);
        Task<UserLoginDTO> Update(UserLoginUpdateRequestDTO reqDTO);
        Task Delete(UserLoginDeleteRequestDTO reqDTO);
        Task<UserLoginDTO> ReadByUserId(UserLoginReadByUserIdRequestDTO reqDTO);
        Task<ValidationResponse> ValidateUserName(UserLoginValidateUserNameRequestDTO reqDTO);
        public Task<UserDTO> Authenticate(string companyCode, string userName, string password);
        public Task<UserDTO> AuthenticateAzure(string FirstName, string LastName, string AzureUserId, string AzureEmailId, DateTime ExpiresOn);
    }
}
