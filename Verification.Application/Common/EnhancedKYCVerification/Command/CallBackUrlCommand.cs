using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verification.Application.Common.Model;

namespace Verification.Application.Common.EnhancedKYCVerification.Command
{
    public class CallBackUrlCommand : IRequest<EnhancedKYCResponse>
    {
        public bool success { get; set; }
    }
}
