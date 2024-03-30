using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verification.Application.Common.Model;

namespace Verification.Application.Common.Interface
{
    public interface EnhancedKYCVerificationInterface
    {
        Task<EnhancedKYCResponse> GetEnhancedKYCVerification(EnhancedKYCVerificationResource kyc);
        Task<EnhancedKYCResponse> CallBackUrl(CallBackUrlResource kyc);
    }
}
