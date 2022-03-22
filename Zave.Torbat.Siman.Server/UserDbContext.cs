using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zave.Torbat.Siman.Server.Model;

namespace Zave.Torbat.Siman.Server
{
    public class UserDbContext: IdentityDbContext<User>
    {
        
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<Truck> Trucks { get; set; }
    }
}
