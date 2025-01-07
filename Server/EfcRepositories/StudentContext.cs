using Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcRepositories;

public class StudentContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<GradeInCourse> Grades => Set<GradeInCourse>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/Users/maciej/RiderProjects/DnpExam2022A/Server/EfcRepositories/students.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(s => s.studentId);
        modelBuilder.Entity<GradeInCourse>().HasKey(g => g.GradeInCourseId);
        
        modelBuilder.Entity<Student>().Property(s => s.Name).HasMaxLength(25);
        modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired();
        modelBuilder.Entity<Student>().Property(s => s.Programme).IsRequired();
        
        modelBuilder.Entity<GradeInCourse>().Property(g => g.CourseCode).HasMaxLength(4);
        modelBuilder.Entity<GradeInCourse>().Property(g => g.CourseCode).IsRequired();
        modelBuilder.Entity<GradeInCourse>().Property(g => g.Grade).IsRequired();
    }
}