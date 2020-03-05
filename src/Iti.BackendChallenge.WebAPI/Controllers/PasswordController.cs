using Iti.BackendChallenge.WebAPI.ApiModels.Password;
using Iti.BackendChallenge.WebAPI.UseCases;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Validar senha forte:
        /// Nove ou mais caracteres
        /// Ao menos 1 dígito
        /// Ao menos 1 letra minúscula
        /// Ao menos 1 letra maiúscula
        /// Ao menos 1 caractere especial
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/strong-password
        ///     {
        ///        "value": "12345aBc!"
        ///     }
        ///
        /// </remarks>
        /// <param name="apiModel"></param>
        /// <response code="204">Value válido</response>
        /// <response code="400"> 
        /// Caso model for nulo. Response:
        ///     {
        ///        message = "Problems parsing JSON"
        ///     }
        /// </response>
        /// <response code="422">
        /// Caso value for inválido. Response:
        ///     {
        ///        property = "value",
        ///        message = "Invalid"
        ///     }
        /// </response>         
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(422)]
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
