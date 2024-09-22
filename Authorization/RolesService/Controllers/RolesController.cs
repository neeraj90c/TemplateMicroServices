using Common.Authorization;
using Common.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RolesService.Command;
using RolesService.DTO;

namespace RolesService.Controllers
{
    [EnableCors("systel")]
    public class RolesController : BaseApiController
    {
        APISettings _settings;

        public RolesController(IOptions<APISettings> settings)
        {
            _settings = settings.Value;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Roles API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("RolesCRUD")]
        public async Task<IActionResult> ManageRoles([FromBody] RolesDTO rolesDTO)
        {

            RolesList response = new RolesList();
            response = await mediator.Send(new RolesCRUDCommand
            {
                rolesDTO = rolesDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("SubRolesMapping")]
        public async Task<IActionResult> SubRolesMapping([FromBody] SubRolesDTO subRolesDTO)
        {

            SubRolesList response = new SubRolesList();
            response = await mediator.Send(new SubRolesCommand
            {
                subRolesDTO = subRolesDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("UserGroupCRUD")]
        public async Task<IActionResult> ManageUserGroup([FromBody] UserGroupDTO userGroupDTO)
        {

            UserGroupList response = new UserGroupList();
            response = await mediator.Send(new UserGroupCRUDCommand
            {
                userGroupDTO = userGroupDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("UserGroupCRUDPaginated")]
        public async Task<IActionResult> UserGroupCRUDPaginated([FromBody] UserGroupDTO userGroupDTO)
        {

            UserGroupList response = new UserGroupList();
            response = await mediator.Send(new UserGroupCRUDPaginatedCommand
            {
                userGroupDTO = userGroupDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("UserRoleCRUD")]
        public async Task<IActionResult> UserRoleCRUD([FromBody] UserRoleDTO userRoleDTO)
        {
            UserList response = new UserList();
            response = await mediator.Send(new UserRoleCRUDCommand
            {
                userRoleDTO = userRoleDTO
            });
            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("PaginatedUserRoleCRUD")]
        public async Task<IActionResult> PaginatedUserRoleCRUD([FromBody] UserRoleDTO userRoleDTO)
        {
            UserList response = new UserList();
            response = await mediator.Send(new PaginatedUserRoleCRUDCommand
            {
                userRoleDTO = userRoleDTO
            });
            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpGet("GetRolesDictionary")]
        public async Task<IActionResult> GetRolesDictionary()
        {
            DropDownList response = new DropDownList();
            response = await mediator.Send(new RolesGetDictionaryCommand
            {
            });
            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
