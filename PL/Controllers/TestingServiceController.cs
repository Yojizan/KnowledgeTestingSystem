using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Interfaces;
using PL.DTO;
using static PL.App_Start.MapperConfig;

namespace PL.Controllers
{
    public class TestingServiceController : ApiController
    {
        private ITestingService _testingService;

        public TestingServiceController(ITestingService testingService)
        {
            _testingService = testingService;
        }

        [Route("api/Testing/Test/Name/{name}")]
        public IEnumerable<TestDTO> GetTestsByName(string name)
        {
            return mapper.Map<IEnumerable<TestDTO>>(_testingService.GetTestsByName(name));
        }
    }
}
