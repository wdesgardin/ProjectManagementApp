using System.Threading.Tasks;

namespace ProjectManagementApp.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}