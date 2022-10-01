using MediatR;
using Microsoft.AspNetCore.Mvc;
using Verification.Application.Common.EnhancedKYCVerification.Command;
using Verification.Application.Common.Model;

namespace VerificationAPI.Controllers
{
    public class EnhancedKYCVerificationController : BaseController
    {
        [HttpPost("api/create/dynamic/virtualaccount")]
        public async Task<ActionResult<EnhancedKYCResponse>> GetEnhancedKYCVerification(EnhancedKYCVerificationCommand kyc)
        {
            return await Mediator.Send(kyc);
        }
    }
}
