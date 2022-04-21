using ChatAppFinal.Models;

namespace ChatAppFinal.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<ApplicationUser> ApplicationUser { get; }
        public IGenericRepository<Message> Message { get; }
        public IGenericRepository<Room> Room { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
