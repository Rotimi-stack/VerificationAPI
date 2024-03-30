using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verification.Application.Common.EnhancedKYCVerification.Command;
using Verification.Application.Common.Interface;
using Verification.Application.Common.Model;

namespace Verification.Application.Common.EnhancedKYCVerification.CommandHandler
{
    public class CallBackUrlCommandHandler : IRequestHandler<CallBackUrlCommand, EnhancedKYCResponse>
    {
        private readonly EnhancedKYCVerificationInterface _kyc;
        public CallBackUrlCommandHandler(EnhancedKYCVerificationInterface kyc)
        {
            _kyc = kyc;
        }

        public async Task<EnhancedKYCResponse> Handle(CallBackUrlCommand request, CancellationToken cancellationToken)
        {
            var data = new CallBackUrlResource
            {
                success = request.success
            };
            return await _kyc.CallBackUrl(data);
        }
    }
}
