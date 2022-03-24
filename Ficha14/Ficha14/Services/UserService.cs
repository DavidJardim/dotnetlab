using Ficha14.Models;
using Ficha14.Services;
using Microsoft.EntityFrameworkCore;

namespace Ficha14.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext context;

        public UserService(UserContext context)
        {
            this.context = context;
        }

        public UserModel Create(UserModel user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel? FindByName(string userName)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public UserModel? Get(string userName, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            return user;
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }


        public void Update(int id, UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
