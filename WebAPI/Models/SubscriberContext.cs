using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SubscriberContext:DbContext
    {
        public SubscriberContext(DbContextOptions<SubscriberContext> options):base(options)
        {

        }

        public DbSet<Subscriber> Subscriber { get; set; }
    }
}
