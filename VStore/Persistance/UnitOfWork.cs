using System.Threading.Tasks;

namespace VStore.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
