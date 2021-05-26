using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Data
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source=students.db;");
        }
        public DbSet<StudentsInfo> StudentsInfo { get; set; }
        public DbSet<TeachersInfo> TeachersInfos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsInfo>().HasData(
            new StudentsInfo() { Id = 1, stuPrefix = "Ms.", stuFirstName = "Amelia", stuLastName = "Petter", stuGrade = 6, stuAge = 11, stuDayScholar = "Yes", stuOptionalLang = "French" },
            new StudentsInfo() { Id = 2, stuPrefix = "Mr.", stuFirstName = "Richard", stuLastName = "Grey", stuGrade = 7, stuAge = 12, stuDayScholar = "No", stuOptionalLang = "Spanish" }
            );
        }
    }
}