using ChatAppFinal.Interfaces;
using ChatAppFinal.Models;

namespace ChatAppFinal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IGenericRepository<ApplicationUser> _ApplicationUser;
        private IGenericRepository<Message> _Message;
        private IGenericRepository<Room> _Room;

        public IGenericRepository<ApplicationUser> ApplicationUser
        {
            get
            {
                if (_ApplicationUser == null)
                {
                    _ApplicationUser = new GenericRepository<ApplicationUser>(_dbContext);
                }
                return _ApplicationUser;
            }
        }
        public IGenericRepository<Message> Message
        {
            get
            {
                if (_Message == null)
                {
                    _Message = new GenericRepository<Message>(_dbContext);
                }
                return _Message;
            }
        }

        public IGenericRepository<Room> Room
        {
            get
            {
                if (_Room == null)
                {
                    _Room = new GenericRepository<Room>(_dbContext);
                }
                return _Room;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
