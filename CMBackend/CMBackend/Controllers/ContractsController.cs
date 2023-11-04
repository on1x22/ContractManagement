using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CMBackend.Domain;

namespace CMBackend.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private IContractsService service;
        public ContractsController(IContractsService service)
        {
            this.service = service;
        }

        [HttpGet("GetContracts")]
        public async Task<IActionResult> GetContracts()
        {
            var contracts = await service.GetContractsAsync();

            if (contracts == null)
                return BadRequest("Данные по договорам отсутствуют");

            return Ok(contracts);
        }

        [HttpGet("GetContractStages")]
        public async Task<IActionResult> GetContractStages()
        {
            var contractStages = await service.GetContractStagesAsync();

            if (contractStages == null)
                return BadRequest("Данные по этапам договоров отсутствуют");

            return Ok(contractStages);
        }
    }
}
