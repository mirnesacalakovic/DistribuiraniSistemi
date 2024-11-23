using Microsoft.EntityFrameworkCore;
using StudentiBackup_BGJobs.Models;

namespace StudentiBackup_BGJobs
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsBackup> Students_Backup { get; set; }

        
    }
}
