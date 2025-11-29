using ComplianceBuddy.Models;

namespace ComplianceBuddy.Data.Service
{
  public interface IInspectionsService
  {
    Task<IEnumerable<Inspection>> GetAll(string userId);
    Task Add(Inspection inspection);
    Task<Inspection?> GetById(int id);
    Task Update(Inspection inspection);
    Task Delete(Inspection inspection);
  }
}