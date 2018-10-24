
using DgtWebApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace DgtWebAPI2
{
    public class APIDBContext: DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options): base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintType> ComplaintTypes { get; set; }
    }
}
