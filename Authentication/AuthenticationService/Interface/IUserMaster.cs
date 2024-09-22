using AuthenticationService.DTO;
using Common.DTO;

namespace AuthenticationService.Interface
{
    public interface IUserMaster
    {
        public Task<UserList> UserCRUD(UserMasterDTO userMasterDTO);
        public Task<UserList> PaginatedUserCRUD(UserMasterDTO userMasterDTO);
        public Task<UserList> CreateUserCredentials(UserCredDTO userLoginCRUD_DTO);
        public Task<UserWorkCenterList> UserWorkCenterCRUD(UserWorkCenterDTO userWorkCenterDTO);
        public Task<UserDashboardList> UserDashboardGet(UserDashboardDTO userDashboardDTO);
        public Task<UserMasterDTO> UserStatusUpdate(UserMasterDTO userMasterDTO);
        public Task<DropDownList> GetAllUserList();

    }
}
