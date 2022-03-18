using System.Threading.Tasks;

namespace Dukkantek.Domain.DB
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
