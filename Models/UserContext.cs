using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserItem> UserItems { get; set; }
    }
}


public class UserContextTests
{
    [Fact]
    public void CanCreateDatabase()
    {
        var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Create the context
        using var context = new UserContext(options);

        // Verify the database is created
        Assert.True(context.Database.EnsureCreated());
    }
}


