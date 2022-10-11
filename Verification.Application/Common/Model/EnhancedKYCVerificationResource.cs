using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verification.Application.Common.EnhancedKYCVerification.Command;
using Verification.Domain.Enum.EnhancedKYCVerification;
using static Verification.Application.Common.Model.EnhancedKYCVerificationRequest;

namespace Verification.Application.Common.Model
{
    public class EnhancedKYCVerificationResource
    {
        public string source_sdk { get; set; } = String.Empty;
        public string source_sdk_version { get; set; } = String.Empty;
        public string partner_id { get; set; } = String.Empty;
        public DateTime timestamp { get; set; }
        public Signature signature { get; set; }
        public string country { get; set; } = String.Empty;
        public string id_type { get; set; } = String.Empty;
        public string id_number { get; set; } = String.Empty;
        public string callback_url { get; set; } = String.Empty;
        public string first_name { get; set; } = String.Empty;
        public string middle_name { get; set; } = String.Empty;
        public string last_name { get; set; } = String.Empty;
        public string phone_number { get; set; } = String.Empty;
        public string dob { get; set; } = String.Empty;
        public string gender { get; set; } = String.Empty;
        public PartnerParams? partner_params { get; set; }
    }
}
