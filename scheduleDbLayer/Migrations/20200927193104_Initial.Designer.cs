﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleTelegramBotDb.EF;

namespace ScheduleTelegramBotDb.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20200927193104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.GroupSubjects", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("GroupSubjects");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupsId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupsId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupsId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupsId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeacherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.TeacherSubjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.GroupSubjects", b =>
                {
                    b.HasOne("ScheduleTelegramBotDb.Models.Group", "Group")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleTelegramBotDb.Models.Subject", "Subject")
                        .WithMany("GroupSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleTelegramBotDb.Models.Teacher", null)
                        .WithMany("GroupSubjects")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.Student", b =>
                {
                    b.HasOne("ScheduleTelegramBotDb.Models.Group", "Groups")
                        .WithMany("Students")
                        .HasForeignKey("GroupsId");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.Subject", b =>
                {
                    b.HasOne("ScheduleTelegramBotDb.Models.Group", "Groups")
                        .WithMany()
                        .HasForeignKey("GroupsId");
                });

            modelBuilder.Entity("ScheduleTelegramBotDb.Models.TeacherSubjects", b =>
                {
                    b.HasOne("ScheduleTelegramBotDb.Models.Group", null)
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("GroupId");

                    b.HasOne("ScheduleTelegramBotDb.Models.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleTelegramBotDb.Models.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
