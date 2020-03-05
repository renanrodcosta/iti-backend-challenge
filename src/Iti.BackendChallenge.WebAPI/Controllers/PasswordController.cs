using Iti.BackendChallenge.WebAPI.ApiModels.Password;
using Iti.BackendChallenge.WebAPI.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Iti.BackendChallenge.WebAPI.Controllers
{
    [Route("api/v1")]
    public class PasswordController : ControllerBase
    {
        private ValidateStrongPassword validateStrongPassword;
        public PasswordController(ValidateStrongPassword validateStrongPassword)
        {
            this.validateStrongPassword = validateStrongPassword;
        }

        [Route("strong-password"), HttpPost]
        public IActionResult Validate([FromBody] StrongPasswordApiModel apiModel)
        {
            if (apiModel == null)
            {
                return BadRequest(new { message = "Problems parsing JSON" });
            }

            bool isPasswordStrong = validateStrongPassword.IsValid(apiModel.Value);
            if (isPasswordStrong)
            {
                return NoContent();
            }
            return UnprocessableEntity(new
            {
                property = "value",
                message = "Invalid"
            });
        }
    }
}
