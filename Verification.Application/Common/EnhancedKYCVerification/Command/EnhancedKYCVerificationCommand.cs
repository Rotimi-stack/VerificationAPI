using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verification.Application.Common.Model;

namespace Verification.Application.Common.EnhancedKYCVerification.Command
{
    public class EnhancedKYCVerificationCommand : IRequest<EnhancedKYCResponse>
    {

        public string source_sdk { get; set; } = String.Empty;
        public string source_sdk_version { get; set; } = String.Empty;
        public string partner_id { get; set; } = String.Empty;
        public DateTime timestamp { get; set; }
        public string signature { get; set; }=String.Empty;
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
