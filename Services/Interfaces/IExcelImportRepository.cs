using System.Threading.Tasks;

namespace NewCelsia.Services.Interfaces
{
    public interface IExcelImportRepository 
    {
        Task ImportFromExcelAsync(string filePath);
    }
}
