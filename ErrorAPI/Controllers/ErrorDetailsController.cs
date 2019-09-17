using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ErrorAPI.Repositories;
using ErrorAPI.Services;
using ErrorDetails = ErrorAPI.DTO.ErrorDetails;

namespace ErrorAPI.Controllers
{
    [RoutePrefix("api/error-details")]
    public class ErrorDetailsController : ApiController
    {
        private readonly ErrorRepository _errorRepository = new ErrorRepository();
        private readonly ProgramRepository _programRepository = new ProgramRepository();
        private readonly MailService _mailService = new MailService();

        [Route]
        [HttpPost]
        public async Task<IHttpActionResult> PostErrorDetails([FromBody] ErrorDetails errorDetails)
        {
            var isNewError = await _errorRepository.AddErrorDetails(errorDetails);
            if (isNewError)
            {
                var contactEmail = await _programRepository.GetContactEmail(errorDetails.ProgramName);

                await _mailService.SendEmail("New error occured",
                    $"{errorDetails.ExceptionDetails.ExceptionType} occured " +
                    $"on {errorDetails.EnvironmentDetails.Version} version " +
                    $"at {errorDetails.EnvironmentDetails.DateUtc}", contactEmail);
            }

            return StatusCode(HttpStatusCode.Created);
        }
        
    }
}