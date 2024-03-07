using AzureFunctionExample.Domain.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AzureFunctionExample
{
    public class ManagedPatientFunction
    {
        private readonly ILogger _logger;
        private readonly IPatientService patientService;

        public ManagedPatientFunction(ILoggerFactory loggerFactory, IPatientService patientService)
        {
            _logger = loggerFactory.CreateLogger<ManagedPatientFunction>();
            this.patientService = patientService;
        }

        [Function("ManagedPatientFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            try
            {
                _logger.LogInformation("C# HTTP trigger function processing a request.");
                _logger.LogInformation($"ManagedPatientFunction Begin {DateTime.Now}");

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");                

                var result = await patientService.ManagePatient();

                if (result)
                {
                    _logger.LogInformation("ManagedPatientFunction ran successfully.");
                    return response;
                }
                else
                {
                    _logger.LogInformation("ManagedPatientFunction failed");
                    return req.CreateResponse(HttpStatusCode.UnprocessableContent);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ManagedPatientFunction - {ex.Message} - {ex.StackTrace}");
                throw;
            }
        }
    }
}
