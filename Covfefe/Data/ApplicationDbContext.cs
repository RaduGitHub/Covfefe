using Covfefe.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Covfefe.Models.Product> Products { get; set; }
        public DbSet<Covfefe.Models.Cart> Cart { get; set; }
        public DbSet<Covfefe.Models.Comment> Comment { get; set; }
        public DbSet<Covfefe.Models.ProductType> ProductType { get; set; }
        public DbSet<Covfefe.Models.Rating> Rating { get; set; }
        public DbSet<Covfefe.Models.Transaction> Transaction { get; set; }
        public DbSet<Covfefe.Models.User> User { get; set; }

    }
}
