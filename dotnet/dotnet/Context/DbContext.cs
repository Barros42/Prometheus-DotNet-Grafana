using System;
using System.Reflection.Metadata;
using dotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Context
{
	public class DatabaseContext: DbContext
	{

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

