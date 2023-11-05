using Microsoft.AspNetCore.Mvc;
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

            if (fileExcel.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                return BadRequest(error: "Не корректное расширение файла");

            List<Contract> contracts;
            List<ContractStage> contractStages;

            try
            {
                (contracts, contractStages) = await ExcelHandler.ReadDataFromExcel(fileExcel);
            }
            catch (Exception)
            {
                return BadRequest(error: "Файл содержит некорректные данные или неверную разметку");
            }

            bool isFileSuccessfullyUploaded = false;

            if (contracts != null && contractStages != null)
            {
                isFileSuccessfullyUploaded = await service.UploadFileAsync(contracts, contractStages);

            }

            if (!isFileSuccessfullyUploaded)
                return BadRequest("Имеются проблемы с загрузкой файлов");

            return Ok();
        }
    }
}
