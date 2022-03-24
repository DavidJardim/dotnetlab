using Ficha14.Models;

namespace Ficha14.Services
{
    public interface IUserService
    {
        public abstract IEnumerable<UserModel> GetAll();

        public abstract UserModel? Get(string userName, string password);

        public abstract UserModel Create(UserModel user);

        public abstract void Delete(int id);

        public abstract void Update(int id, UserModel user);
        public UserModel? FindByName(string userName);
    }
}
