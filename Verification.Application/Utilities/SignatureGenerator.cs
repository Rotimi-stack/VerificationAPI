using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Verification.Application.Utilities
{
   
    public class SignatureGenerator
    {

        IConfiguration _config;

        public SignatureGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateSignature()
        {
            var apiKey = _config.GetSection("ApiKey").Value.ToString();
            var partnerID = _config.GetSection("PartnerId");


            string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", System.Globalization.CultureInfo.InvariantCulture);
            string data = timeStamp + partnerID + "sid_request";
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] key = utf8.GetBytes(apiKey);
            Byte[] message = utf8.GetBytes(data);
            HMACSHA256 hash = new HMACSHA256(key);
            var signature = hash.ComputeHash(message);
            return signature.ToString();
        }
       
    }
}
