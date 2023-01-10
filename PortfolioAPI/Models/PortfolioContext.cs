using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortfolioAPI.Models;

public partial class PortfolioContext : DbContext
{
    public PortfolioContext()
    {
    }

    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.IdEdu);

            entity.ToTable("education");

            entity.Property(e => e.IdEdu).HasColumnName("id_edu");
            entity.Property(e => e.GardeEdu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("garde_edu");
            entity.Property(e => e.NameEdu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_edu");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.IdExp);

            entity.ToTable("experience");

            entity.Property(e => e.IdExp).HasColumnName("id_exp");
            entity.Property(e => e.CompanyExp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company_exp");
            entity.Property(e => e.DescriptionExp)
                .IsUnicode(false)
                .HasColumnName("description_exp");
            entity.Property(e => e.EndDateExp)
                .HasColumnType("date")
                .HasColumnName("end_date_exp");
            entity.Property(e => e.InitDateExp)
                .HasColumnType("date")
                .HasColumnName("init_date_exp");
            entity.Property(e => e.JobTitleExp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title_exp");
            entity.Property(e => e.ProjectExp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("project_exp");
        });

        modelBuilder.Entity<PersonalInfo>(entity =>
        {
            entity.HasKey(e => e.IdPi);

            entity.ToTable("personalInfo");

            entity.Property(e => e.IdPi).HasColumnName("id_pi");
            entity.Property(e => e.EmailPi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_pi");
            entity.Property(e => e.GithubPi)
                .IsUnicode(false)
                .HasColumnName("github_pi");
            entity.Property(e => e.LastNamePi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name_pi");
            entity.Property(e => e.LinkedinPi)
                .IsUnicode(false)
                .HasColumnName("linkedin_pi");
            entity.Property(e => e.NamePi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_pi");
            entity.Property(e => e.PhonePi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_pi");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill).HasName("PK_habilidades");

            entity.ToTable("skills");

            entity.Property(e => e.IdSkill).HasColumnName("id_skill");
            entity.Property(e => e.LevelSkill)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("level_skill");
            entity.Property(e => e.NameSkill)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_skill");
            entity.Property(e => e.TypeSkill)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_skill");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
