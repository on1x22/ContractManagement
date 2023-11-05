using CMBackend.DAL.ContextModels;

namespace CMBackend.Domain
{
    public interface IImportService
    {
        Task<bool> UploadFileAsync(List<Contract> contracts, List<ContractStage> contractStages);
    }
}
