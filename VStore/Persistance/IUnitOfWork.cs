using System.Threading.Tasks;


namespace VStore.Persistance
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        Task ChangeVideo(int id);
    }
}
