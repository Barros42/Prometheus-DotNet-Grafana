using System;
using System.Linq;
using dotnet.Context;
using dotnet.Domain;

namespace dotnet.Repositories
{
	public class UserRepository: IUserRepository
	{
        private readonly DatabaseContext _context;

		public UserRepository(DatabaseContext context)
		{
            _context = context;
		}

        public void CreateUser(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string Email)
        {
            return _context.Users.Where(x => x.Email == Email).FirstOrDefault();
        }

        public List<User> ListUsers()
        {
            return _context.Users.ToList();
        }
    }
}

