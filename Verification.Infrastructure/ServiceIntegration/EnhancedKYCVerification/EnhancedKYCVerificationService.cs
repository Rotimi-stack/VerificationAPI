using FSDH.Shared.LogService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Verification.Application.Common.Interface;
using Verification.Application.Common.Model;
using Verification.Application.Utilities;
using Verification.Domain.Enum.EnhancedKYCVerification;
using static Verification.Application.Common.EnhancedKYCVerification.Command.EnhancedKYCVerificationCommand;

namespace Verification.Infrastructure.ServiceIntegration.EnhancedBvnVerification
{
    public class EnhancedKYCVerificationService : EnhancedKYCVerificationInterface
    {
        private readonly HttpClient _client;

        private readonly IConfiguration _config;
        private readonly ILogWritter _logger;

        private static Logger log = LogManager.GetCurrentClassLogger();
        public EnhancedKYCVerificationService(IHttpClientFactory httpClientFactory, IConfiguration config, ILogWritter logger)
        {
            _client = httpClientFactory.CreateClient();
            _config = config;
            _logger = logger;
        }

        public async Task<EnhancedKYCResponse> GetEnhancedKYCVerification(EnhancedKYCVerificationResource kyc)
        {
            string generateSignature = new SignatureGenerator(_config).GenerateSignature();
            var data = new EnhancedKYCVerificationRequest
            {
                callback_url = kyc.callback_url,
                country = kyc.country,
                dob = kyc.dob,
                first_name = kyc.first_name,
                gender = kyc.gender,
                id_number = kyc.id_number,
                id_type = kyc.id_type,
                last_name = kyc.last_name,
                middle_name = kyc.middle_name,
                partner_id = kyc.partner_id,
                partner_params = kyc.partner_params,
                phone_number = kyc.phone_number,
                signature = generateSignature,
                source_sdk = kyc.source_sdk,
                source_sdk_version = kyc.source_sdk_version,
                timestamp = kyc.timestamp,
            };
            return await SendAsync<EnhancedKYCVerificationRequest, EnhancedKYCResponse>(
                data, "", EnhancedKYCVerificationHttpMethodType.Post
                );
        }

        public async Task<EnhancedKYCResponse> CallBackUrl(CallBackUrlResource kyc)
        {
            var data = new CallbackUrlRequest
            {
                success= kyc.success,
            };
            return await SendAsync<CallbackUrlRequest, EnhancedKYCResponse>(
                data, "", EnhancedKYCVerificationHttpMethodType.Post);
        }







        public async Task<U> SendAsync<T, U>(T payload, string relativePath, EnhancedKYCVerificationHttpMethodType httpMethod)
        {
            var baseaddress = _config.GetSection("BaseAddress").Value.ToString();
            var testkey = _config.GetSection("TestApiKey").Value.ToString();

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {testkey}");

            var message = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            string content;
            switch (httpMethod)
            {
                case EnhancedKYCVerificationHttpMethodType.Post:
                    var resp = await _client.PostAsync($"{baseaddress}{relativePath}", message);
                    content = await resp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resp.StatusCode == HttpStatusCode.BadGateway || (resp.StatusCode == HttpStatusCode.Unauthorized) || resp.StatusCode == HttpStatusCode.BadRequest || resp.StatusCode == HttpStatusCode.ServiceUnavailable || resp.StatusCode == HttpStatusCode.InternalServerError || resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }
                    return JsonSerializer.Deserialize<U>(content);


                case EnhancedKYCVerificationHttpMethodType.Delete:
                    var resssp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await resssp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resssp.StatusCode == HttpStatusCode.BadGateway || (resssp.StatusCode == HttpStatusCode.Unauthorized) || resssp.StatusCode == HttpStatusCode.BadRequest || resssp.StatusCode == HttpStatusCode.ServiceUnavailable || resssp.StatusCode == HttpStatusCode.InternalServerError || resssp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }
                    return JsonSerializer.Deserialize<U>(content);


                case EnhancedKYCVerificationHttpMethodType.Put:
                    var reesp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await reesp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (reesp.StatusCode == HttpStatusCode.BadGateway || (reesp.StatusCode == HttpStatusCode.Unauthorized) || reesp.StatusCode == HttpStatusCode.BadRequest || reesp.StatusCode == HttpStatusCode.ServiceUnavailable || reesp.StatusCode == HttpStatusCode.InternalServerError || reesp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return JsonSerializer.Deserialize<U>(content);


                default:

                    var ressp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await ressp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);


                    if (ressp.StatusCode == HttpStatusCode.BadGateway || (ressp.StatusCode == HttpStatusCode.Unauthorized) || ressp.StatusCode == HttpStatusCode.BadRequest || ressp.StatusCode == HttpStatusCode.ServiceUnavailable || ressp.StatusCode == HttpStatusCode.InternalServerError || ressp.StatusCode == HttpStatusCode.NotFound)
                    {


                        return JsonSerializer.Deserialize<U>(content);




                    }

                    return JsonSerializer.Deserialize<U>(content);


            }

        }

        
    }
}




//public string GenerateSignature(string PartnerID, string ApiKey)
//{
//    string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", System.Globalization.CultureInfo.InvariantCulture);
//    string apiKey = "d80a5301-ff7d-4458-8074-095001575012";
//    string partnerID = "433";
//    string data = timeStamp + partnerID + "sid_request";
//    UTF8Encoding utf8 = new UTF8Encoding();
//    Byte[] key = utf8.GetBytes(apiKey);
//    Byte[] message = utf8.GetBytes(data);
//    HMACSHA256 hash = new HMACSHA256(key);
//    var signature = hash.ComputeHash(message);
//    return signature.ToString();
//}