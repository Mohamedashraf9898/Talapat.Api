using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talapat.Repository._Identity
{
    public class TalabatIdentityDbContext : IdentityDbContext
    {
        public TalabatIdentityDbContext(DbContextOptions<TalabatIdentityDbContext> options) 
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable("Addresses");
        }
    }
}
