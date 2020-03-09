﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualDeanary.Data.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Data
{
    public class SqlContext : IdentityDbContext<User>
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Groups> Groups { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        public SqlContext() { }
    }
}
