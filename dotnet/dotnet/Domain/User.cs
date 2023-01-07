using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Domain
{
    public class User
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
	}
}

