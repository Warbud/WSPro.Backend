﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.Migrations
{
    [DbContext(typeof(WSProContext))]
    [Migration("20211021130623_change_delay3")]
    partial class change_delay3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CrewSummaryWorker", b =>
                {
                    b.Property<int>("CrewSummariesId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkersId")
                        .HasColumnType("integer");

                    b.HasKey("CrewSummariesId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("CrewSummaryWorker");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Crane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(3485));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(3667));

                    b.HasKey("Id");

                    b.ToTable("Cranes");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CrewType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CrewWorkType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProjectId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId1");

                    b.HasIndex("UserId1");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.CrewSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CrewId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("CrewSummary");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Delay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commentary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CraneId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(4038));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("LevelId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(4284));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CraneId");

                    b.HasIndex("LevelId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Delay");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.DelayCause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(5370));

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(5673));

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("DelayCauses");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Delay_DelayCause", b =>
                {
                    b.Property<int>("CauseId")
                        .HasColumnType("integer");

                    b.Property<int>("DelayId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(7986));

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8207));

                    b.HasKey("CauseId", "DelayId");

                    b.HasIndex("DelayId");

                    b.ToTable("Delay_DelayCauses");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal?>("Area")
                        .HasColumnType("numeric");

                    b.Property<int?>("CraneId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8620));

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<int?>("GroupTermId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPrefabricated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int?>("LevelId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("RealisationMode")
                        .HasColumnType("text");

                    b.Property<int>("RevitID")
                        .HasColumnType("integer");

                    b.Property<int?>("RotationDay")
                        .HasColumnType("integer");

                    b.Property<decimal?>("RunningMetre")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 784, DateTimeKind.Local).AddTicks(8826));

                    b.Property<string>("Vertical")
                        .HasColumnType("text");

                    b.Property<decimal?>("Volume")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CraneId");

                    b.HasIndex("GroupTermId");

                    b.HasIndex("LevelId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.ElementStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(355));

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<int>("ElementId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("SetById")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(577));

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SetById");

                    b.ToTable("ElementStatuses");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.ElementTerm", b =>
                {
                    b.Property<int>("ElementId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GroupTermId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PlannedFinish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PlannedFinishBP")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PlannedStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PlannedStartBP")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("RealFinish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("RealStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ElementId");

                    b.HasIndex("GroupTermId");

                    b.ToTable("ElementTerms");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.GroupTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CraneId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(1591));

                    b.Property<int?>("LevelId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PlannedFinish")
                        .HasColumnType("date");

                    b.Property<DateTime?>("PlannedFinishBP")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("PlannedStart")
                        .HasColumnType("date");

                    b.Property<DateTime?>("PlannedStartBP")
                        .HasColumnType("Date");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RealFinish")
                        .HasColumnType("date");

                    b.Property<DateTime?>("RealStart")
                        .HasColumnType("date");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(1808));

                    b.Property<string>("Vertical")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CraneId");

                    b.HasIndex("LevelId");

                    b.HasIndex("ProjectId");

                    b.ToTable("GroupTerms");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3255));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3454));

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("CentralScheduleSync")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(3955));

                    b.Property<string>("MetodologyCode")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 10, 21, 15, 6, 22, 785, DateTimeKind.Local).AddTicks(4177));

                    b.Property<string>("WebconCode")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AddedById1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CrewWorkType")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AddedById1");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("CrewSummaryWorker", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.CrewSummary", null)
                        .WithMany()
                        .HasForeignKey("CrewSummariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Crew", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId1");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.CrewSummary", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crew");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Delay", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Crane", "Crane")
                        .WithMany()
                        .HasForeignKey("CraneId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crane");

                    b.Navigation("Level");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.DelayCause", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.DelayCause", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Delay_DelayCause", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.DelayCause", "Cause")
                        .WithMany()
                        .HasForeignKey("CauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Delay", "Delay")
                        .WithMany("DelayCauses")
                        .HasForeignKey("DelayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cause");

                    b.Navigation("Delay");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Element", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Crane", "Crane")
                        .WithMany()
                        .HasForeignKey("CraneId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.GroupTerm", "GroupTerm")
                        .WithMany("Elements")
                        .HasForeignKey("GroupTermId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crane");

                    b.Navigation("GroupTerm");

                    b.Navigation("Level");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.ElementStatus", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Element", "Element")
                        .WithMany("ElementStatuses")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.User", "SetBy")
                        .WithMany()
                        .HasForeignKey("SetById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("Project");

                    b.Navigation("SetBy");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.ElementTerm", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Element", "Element")
                        .WithOne("ElementTerm")
                        .HasForeignKey("WSPro.Backend.Domain.Model.V1.ElementTerm", "ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSPro.Backend.Domain.Model.V1.GroupTerm", null)
                        .WithMany("Terms")
                        .HasForeignKey("GroupTermId");

                    b.Navigation("Element");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.GroupTerm", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.Crane", "Crane")
                        .WithMany()
                        .HasForeignKey("CraneId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("WSPro.Backend.Domain.Model.V1.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crane");

                    b.Navigation("Level");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Worker", b =>
                {
                    b.HasOne("WSPro.Backend.Domain.Model.V1.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById1");

                    b.Navigation("AddedBy");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Delay", b =>
                {
                    b.Navigation("DelayCauses");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.Element", b =>
                {
                    b.Navigation("ElementStatuses");

                    b.Navigation("ElementTerm");
                });

            modelBuilder.Entity("WSPro.Backend.Domain.Model.V1.GroupTerm", b =>
                {
                    b.Navigation("Elements");

                    b.Navigation("Terms");
                });
#pragma warning restore 612, 618
        }
    }
}
