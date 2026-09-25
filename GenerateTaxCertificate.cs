using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace GiftOfTheGivers.Functions
{
    public class GenerateTaxCertificate
    {
        private readonly ILogger<GenerateTaxCertificate> _logger;

        public GenerateTaxCertificate(ILogger<GenerateTaxCertificate> logger)
        {
            _logger = logger;
        }

        [Function("GenerateTaxCertificate")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("Generating a dummy tax certificate.");

            string certNumber = $"TAX-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}";

            return new OkObjectResult(new { CertificateNumber = certNumber, Status = "Success" });
        }
    }
}