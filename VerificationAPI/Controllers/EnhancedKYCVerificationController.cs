using MediatR;
using Microsoft.AspNetCore.Mvc;
using Verification.Application.Common.EnhancedKYCVerification.Command;
using Verification.Application.Common.Model;

namespace VerificationAPI.Controllers
{
    public class EnhancedKYCVerificationController : BaseController
    {
        [HttpPost("api/enhanced/kyc/verification")]
        public async Task<ActionResult<EnhancedKYCResponse>> GetEnhancedKYCVerification(EnhancedKYCVerificationCommand lyc)
        {
            return await Mediator.Send(lyc);
        }

        [HttpPost("api/callbackUrl")]
        public async Task<ActionResult<EnhancedKYCResponse>> CallBackUrl(CallBackUrlCommand vyc)
        {
            return await Mediator.Send(vyc);
        }
    }
}
