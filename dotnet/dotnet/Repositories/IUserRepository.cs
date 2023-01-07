using System;
using dotnet.Domain;

namespace dotnet.Repositories
{
	public interface IUserRepository
	{
		void CreateUser(User User);
		List<User> ListUsers();
		User? GetUserByEmail(string Email);
	}
}

