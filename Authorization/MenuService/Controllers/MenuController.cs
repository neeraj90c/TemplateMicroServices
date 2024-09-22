using MenuService.Command;
using MenuService.DTO;
using Common.Authorization;
using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;

namespace MenuService.Controllers
{
    [EnableCors("systel")]
    public class MenuController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;

        public MenuController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt)
        {
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Menus API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }

        [HttpPost("GetMenuForUser")]
        //[AuthorizeUser]
        public async Task<IActionResult> GetMenuForUser([FromBody] MenuMasterDTO menuMasterDTO)//, [FromHeader] string Authorization
        {

            MenuMasterList response = await mediator.Send(new MenuMasterCommand
            {
                UserId = menuMasterDTO.UserId,
                ProjectId = menuMasterDTO.ProjectId
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("MenuMasterCRUD")]
        //[AuthorizeUser]
        public async Task<IActionResult> ManageMenu([FromBody] MenuManageDTO menuManageDTO)
        {

            MenuManageList response = new MenuManageList();
            response = await mediator.Send(new MenuManageCRUDCommand
            {
                menuManageDTO = menuManageDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }


        [HttpPost("AdminDashboardGet")]
        //[AuthorizeUser]
        public async Task<IActionResult> AdminDashboardGet([FromBody] int ActionUser)
        {
            AdminDashboardList response = new AdminDashboardList();
            response = await mediator.Send(new AdminDashboardCommand
            {
                ActionUser = ActionUser
            });
            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
