using Microsoft.EntityFrameworkCore;
using StudentiBackup_BGJobs.Models;

namespace StudentiBackup_BGJobs.Services
{
    public interface IStudentBackupService
    {
        Task Run();
    }

    public class StudentBackupService : IStudentBackupService
    {
        private readonly StudentDbContext context;

        public StudentBackupService(StudentDbContext context)
        {
            this.context = context;
        }

        public async Task Run()
        {
            var students = await context.Students.ToListAsync();
            var backupStudents = await context.Students_Backup.ToListAsync();

            Console.WriteLine("Background job for backup data has been fired");

            var studentsToBackup = students
                .Where(student => !backupStudents.Any(backup => backup.Index == student.Index))
                .Select(student => new StudentsBackup
                {
                    StudentId = student.Id,    
                    ImePrezime = student.ImePrezime,
                    DatumRodjenja = student.DatumRodjenja,
                    Index = student.Index,
                    Smer = student.Smer
                })
                .ToList();

            foreach (var s in studentsToBackup)
            {
                Console.WriteLine("Data Backup in Progress...");
                context.Students_Backup.Add(s);
                await context.SaveChangesAsync();   
            }


        }

    }
    
}
