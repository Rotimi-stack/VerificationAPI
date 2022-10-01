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
    public class EnhancedKYCVerificationCommandHandler : IRequestHandler<EnhancedKYCVerificationCommand, EnhancedKYCResponse>
    {
        private readonly EnhancedKYCVerificationInterface _kyc;
        public EnhancedKYCVerificationCommandHandler(EnhancedKYCVerificationInterface kyc)
        {
            _kyc = kyc; 
        }

        public async Task<EnhancedKYCResponse> Handle(EnhancedKYCVerificationCommand request, CancellationToken cancellationToken)
        {
            var data = new EnhancedKYCVerificationResource
            {
                callback_url = request.callback_url,
                country = request.country,
                dob = request.dob,
                first_name = request.first_name,
                gender = request.gender,
                id_number = request.id_number,
                id_type = request.id_type,
                last_name = request.last_name,
                middle_name = request.middle_name,
                partner_id = request.partner_id,
                partner_params = request.partner_params,
                phone_number = request.phone_number,
                signature = request.signature ,
                source_sdk = request.source_sdk,
                source_sdk_version = request.source_sdk_version,
                timestamp = request.timestamp,
            };
            return await _kyc.GetEnhancedKYCVerification(data);
        }
    }
}
