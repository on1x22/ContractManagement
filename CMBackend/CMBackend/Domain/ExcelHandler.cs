using ClosedXML.Excel;
using CMBackend.DAL.ContextModels;

namespace CMBackend.Domain
{
    public class ExcelHandler
    {
        internal static async Task<(List<Contract>, List<ContractStage>)> ReadDataFromExcel(IFormFile excelFile)
        {
            List<Contract> contracts = new List<Contract>();
            List<ContractStage> contractStages = new List<ContractStage>();

            using var ms = new MemoryStream();
            await excelFile.CopyToAsync(ms);

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
                        catch (Exception) { }
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
                        catch (Exception) { }                        
                    }
                }
            }

            return (contracts, contractStages);
        }
    }
}
