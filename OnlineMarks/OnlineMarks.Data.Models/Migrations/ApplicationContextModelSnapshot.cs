﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineMarks.Data.Models.Context;

namespace OnlineMarks.Data.Models.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OnlineMarks.Data.Models.Grade", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("SubjectGradeId")
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectGradeId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Subject", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte[]>("ProfessorId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("StudentId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.SubjectGrade", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("StudentId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("SubjectId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.ToTable("SubjectGrades");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Parent", b =>
                {
                    b.HasBaseType("OnlineMarks.Data.Models.User");

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Professor", b =>
                {
                    b.HasBaseType("OnlineMarks.Data.Models.User");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Student", b =>
                {
                    b.HasBaseType("OnlineMarks.Data.Models.User");

                    b.Property<byte[]>("ParentId")
                        .HasColumnType("varbinary(16)");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Grade", b =>
                {
                    b.HasOne("OnlineMarks.Data.Models.SubjectGrade", null)
                        .WithMany("Grades")
                        .HasForeignKey("SubjectGradeId");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Subject", b =>
                {
                    b.HasOne("OnlineMarks.Data.Models.Professor", null)
                        .WithOne("Subject")
                        .HasForeignKey("OnlineMarks.Data.Models.Subject", "ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMarks.Data.Models.Student", null)
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("OnlineMarks.Data.Models.Student", b =>
                {
                    b.HasOne("OnlineMarks.Data.Models.Parent", null)
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
