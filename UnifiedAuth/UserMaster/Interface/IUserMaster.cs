using UserMaster.DTO;

namespace UserMaster.Interface
{
    public interface IUserMaster
    {
        Task<UserDTO> Create(UserCreateRequestDTO reqDTO);
        Task<UserDTO> Update(UserUpdateRequestDTO reqDTO);
        Task Delete(UserDeleteRequestDTO reqDTO);
        Task<UserDTO> ReadById(UserReadByUserIdRequestDTO reqDTO);
        Task<UserList> ReadAll();
        Task<UserList> ReadAllPaginated(UserReadAllPaginatedRequestDTO reqDTO);
        Task<UserDTO> UpdateStatus(UserUpdateStatusRequestDTO reqDTO);
    }
}
