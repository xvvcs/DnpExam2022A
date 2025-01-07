﻿// <auto-generated />
using EfcRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfcRepositories.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Entities.GradeInCourse", b =>
                {
                    b.Property<int>("GradeInCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("studentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GradeInCourseId");

                    b.HasIndex("studentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("Programme")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("studentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.GradeInCourse", b =>
                {
                    b.HasOne("Entities.Student", null)
                        .WithMany("Grades")
                        .HasForeignKey("studentId");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
