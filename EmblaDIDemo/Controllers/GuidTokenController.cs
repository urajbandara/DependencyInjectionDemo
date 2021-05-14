using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDIAPI.Configuration;
using TestDIAPI.Services;

namespace TestDIAPI.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class GuidTokenController : ControllerBase
    {
        private readonly GuidTokenConfiguration _guidTokenConfiguration;
        //private readonly GuidService _guidService;
        private readonly ILogger<GuidTokenController> _logger;
        private readonly IPaymentService _paymentService;
        public GuidTokenController(IOptions<GuidTokenConfiguration> options,
            //GuidService guidService,
            ILogger<GuidTokenController> logger,IPaymentService paymentService)
        {
            _guidTokenConfiguration = options.Value;
            //_guidService = guidService;
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet("")]
        public IActionResult GetToken([FromServices]GuidService guidService)
        {
            var guid = guidService.GetGuid();

            var logMessage = $"Controller: The GUID from the GuidService is {guid}";

            _logger.LogInformation(logMessage);
            if (_guidTokenConfiguration.CanSaveToken)
            {
                // save logic
            }

            return Ok();
        }

    }
}
