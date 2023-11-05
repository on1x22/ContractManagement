using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics.Contracts;
using CMBackend.DAL.ContextModels;
using CMBackend.Domain;

namespace CMBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly IImportService service;
        public ImportController(IImportService service)
        {
            this.service = service;
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile fileExcel)
        {
            if (fileExcel.Length <= 0)
            {
                return BadRequest(error: "Не выбран файл для загрузки");
            }

            List<Contract> contracts = new List<Contract>();
            List<ContractStage> contractStages = new List<ContractStage>();

            using var ms = new MemoryStream();
            await fileExcel.CopyToAsync(ms);
            using XLWorkbook workbook = new XLWorkbook(ms);
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Договор")
                {
                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        try
                        {
                            var contract = new Contract()
                            {
                                ContractCode = row.Cell(1).Value.ToString(),
                                ContractName = row.Cell(2).Value.ToString(),
                                Client = row.Cell(3).Value.ToString()
                            };
                            contracts.Add(contract);
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
                    }
                }
                if (worksheet.Name == "Этап договора")
                {
                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        var startDateTime = DateTime.Parse(row.Cell(2).Value.ToString());
                        var endDateTime = DateTime.Parse(row.Cell(3).Value.ToString());

                        try
                        {
                            var contractStage = new ContractStage()
                            {
                                StageName = row.Cell(1).Value.ToString(),
                                StartDate = DateOnly.FromDateTime(startDateTime),
                                EndDate = DateOnly.FromDateTime(endDateTime)
                            };
                            contractStages.Add(contractStage);
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
                    }

                }
            }
            bool result = false;

            if (contracts != null && contractStages != null)
            {
                result = await service.UploadFileAsync(contracts, contractStages);

            }

            if (!result)
                return BadRequest("Имеются проблемы с загрузкой файлов");

            return Ok("Данные загружены в БД");
        }
    }
}
