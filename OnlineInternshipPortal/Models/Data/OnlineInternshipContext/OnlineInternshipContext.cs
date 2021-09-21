using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineInternshipPortal.Models.Data.ViewModel;

#nullable disable

namespace OnlineInternshipPortal.Models.Data.OnlineInternshipContext
{
    public partial class OnlineInternshipContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineInternshipContext()
        {
        }

        public OnlineInternshipContext(DbContextOptions<OnlineInternshipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyLogo> CompanyLogos { get; set; }
        public virtual DbSet<Cv> Cvs { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Guardian> Guardians { get; set; }
        public virtual DbSet<GuardianCategory> GuardianCategories { get; set; }
        public virtual DbSet<Hired> Hireds { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Intern> Interns { get; set; }
        public virtual DbSet<Internship> Internships { get; set; }
        public virtual DbSet<InternshipApproval> InternshipApprovals { get; set; }
        public virtual DbSet<InternshipStatus> InternshipStatuses { get; set; }
        public virtual DbSet<MsgReadStatus> MsgReadStatuses { get; set; }
        public virtual DbSet<Publicize> Publicizes { get; set; }
        public virtual DbSet<RecievedMsgFromCompany> RecievedMsgFromCompanies { get; set; }
        public virtual DbSet<RecievedStatus> RecievedStatuses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Remote> Remotes { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<SentMsgToHiredIntern> SentMsgToHiredInterns { get; set; }
        public virtual DbSet<SentStatus> SentStatuses { get; set; }
        public virtual DbSet<VerifyCategory> VerifyCategories { get; set; }
        public virtual DbSet<VerifyCompany> VerifyCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Conn");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //copy this code here
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable(name: "Users");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId })
                   .IsClustered(false);
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => e.LoginProvider)
                   .IsClustered(false);
                entity.ToTable("UserLogins");

            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => e.LoginProvider)
                   .IsClustered(false);
                entity.ToTable("UserTokens");
            });

            //Ending

            builder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .IsClustered(false);

                entity.ToTable("Application");

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CvId).HasColumnName("CV_Id");

                entity.Property(e => e.DateOfRegistration).HasColumnType("date");

                entity.Property(e => e.InternId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.InternshipId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Approval)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.ApprovalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternshipApproval_Application");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Application");

                entity.HasOne(d => d.Cv)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.CvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CV_Application");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.InternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interns_Application");

                entity.HasOne(d => d.Internship)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.InternshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Internship_Application");
            });

            builder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .IsClustered(false);

                entity.ToTable("Company");

                entity.Property(e => e.CompanyAddress).IsRequired();

                entity.Property(e => e.CompanyDescription).IsRequired();

                entity.Property(e => e.CompanyEmail).IsRequired();

                entity.Property(e => e.CompanyLocation).IsRequired();

                entity.Property(e => e.CompanyName).IsRequired();

                entity.Property(e => e.CompanyRegNo).IsRequired();

                entity.Property(e => e.CompanyVideoLink)
                    .IsRequired()
                    .HasColumnName("companyVideoLink");

                entity.Property(e => e.Companywebsite).IsRequired();

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OtherIndustry)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CompanyImage)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CompanyImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyLogo_Company");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Designation_Company");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Industry_Company");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_Company");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sector_Company");
            });

            builder.Entity<CompanyLogo>(entity =>
            {
                entity.HasKey(e => e.CompanyImageId)
                    .IsClustered(false);

                entity.ToTable("CompanyLogo");

                entity.Property(e => e.Image).IsRequired();
            });

            builder.Entity<Cv>(entity =>
            {
                entity.HasKey(e => e.CvId)
                    .IsClustered(false);

                entity.ToTable("CV");

                entity.Property(e => e.CvId).HasColumnName("CV_Id");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .IsClustered(false);

                entity.ToTable("Designation");

                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .HasName("PK_Genders")
                    .IsClustered(false);

                entity.ToTable("Gender");
            });

            builder.Entity<Guardian>(entity =>
            {
                entity.HasKey(e => e.GuardianId)
                    .IsClustered(false);

                entity.ToTable("Guardian");

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GuardianName).IsRequired();

                entity.Property(e => e.Residence).IsRequired();

                entity.HasOne(d => d.GuardianCategory)
                    .WithMany(p => p.Guardians)
                    .HasForeignKey(d => d.GuardianCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GuardianCategory_Guardian");
            });

            builder.Entity<GuardianCategory>(entity =>
            {
                entity.HasKey(e => e.GuardianCategoryId)
                    .IsClustered(false);

                entity.ToTable("GuardianCategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<Hired>(entity =>
            {
                entity.HasKey(e => e.HireId)
                    .IsClustered(false);

                entity.ToTable("Hired");

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.InternId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Hireds)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Hired");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.Hireds)
                    .HasForeignKey(d => d.InternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interns_Hired");
            });

            builder.Entity<Industry>(entity =>
            {
                entity.HasKey(e => e.IndustryId)
                    .IsClustered(false);

                entity.ToTable("Industry");

                entity.Property(e => e.IndustryName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("industryName");
            });

            builder.Entity<Intern>(entity =>
            {
                entity.HasKey(e => e.InternId)
                    .IsClustered(false);

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CvId).HasColumnName("CV_Id");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.HomeTown).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.MiddleName);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Residence).IsRequired();

                entity.Property(e => e.StudentIdCardNumber)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("Student_Id_Card_Number");

                entity.HasOne(d => d.Cv)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.CvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CV_Interns");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genders_Interns");

                entity.HasOne(d => d.Guardian)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.GuardianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guardian_Interns");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_Inte15");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_Interns");
            });

            builder.Entity<Internship>(entity =>
            {
                entity.HasKey(e => e.InternshipId)
                    .IsClustered(false);

                entity.ToTable("Internship");

                entity.Property(e => e.AdditionalInfo)
                    .IsRequired()
                    .HasColumnName("Additional_Info");

                entity.Property(e => e.DeadLineDate).HasColumnType("date");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.PostedTime).HasMaxLength(20);

                entity.Property(e => e.SkillsRequired).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.WhoCanApply).IsRequired();

                entity.Property(e => e.WorkDescription).IsRequired();

                entity.HasOne(d => d.CompanyImage)
                    .WithMany(p => p.Internships)
                    .HasForeignKey(d => d.CompanyImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyLogo_Internship");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Internships)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Industry_Internship");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Internships)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Internship");


                entity.HasOne(d => d.InternshipStatus)
                    .WithMany(p => p.Internships)
                    .HasForeignKey(d => d.InternshipStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternshipStatus_Internship");

                entity.HasOne(d => d.Publicize)
                    .WithMany(p => p.Internships)
                    .HasForeignKey(d => d.PublicizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicize_Internship");

                entity.HasOne(d => d.Remote)
                    .WithMany(p => p.Internships)
                    .HasForeignKey(d => d.RemoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Remote_Internship");
            });

            builder.Entity<InternshipApproval>(entity =>
            {
                entity.HasKey(e => e.ApprovalId)
                    .IsClustered(false);

                entity.ToTable("InternshipApproval");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<InternshipStatus>(entity =>
            {
                entity.HasKey(e => e.InternshipStatusId)
                    .IsClustered(false);

                entity.ToTable("InternshipStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<MsgReadStatus>(entity =>
            {
                entity.HasKey(e => e.MsgReadStatusId)
                    .IsClustered(false);

                entity.ToTable("MsgReadStatus");

                entity.Property(e => e.MsgReadStatusName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<Publicize>(entity =>
            {
                entity.HasKey(e => e.PublicizeId)
                    .IsClustered(false);

                entity.ToTable("Publicize");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<RecievedMsgFromCompany>(entity =>
            {
                entity.HasKey(e => e.RecieveId)
                    .IsClustered(false);

                entity.ToTable("RecievedMsgFromCompany");

                entity.Property(e => e.Attachments)
                    .IsRequired()
                    .HasMaxLength(256);
                 entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(256);
                 entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(256);

                 entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.InternId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Messagebody).IsRequired();

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.Property(e => e.ReceivedTime).HasMaxLength(20);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("subject");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.RecievedMsgFromCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_RecievedMsgFromCompany");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.RecievedMsgFromCompanies)
                    .HasForeignKey(d => d.InternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interns_RecievedMsgFromCompany");

                entity.HasOne(d => d.MsgReadStatus)
                    .WithMany(p => p.RecievedMsgFromCompanies)
                    .HasForeignKey(d => d.MsgReadStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MsgReadStatus_RecievedMsgFromCompany");

                entity.HasOne(d => d.ReceivedStatus)
                    .WithMany(p => p.RecievedMsgFromCompanies)
                    .HasForeignKey(d => d.ReceivedStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecievedStatus_RecievedMsgFromCompany");
            });

            builder.Entity<RecievedStatus>(entity =>
            {
                entity.HasKey(e => e.ReceivedStatusId)
                    .IsClustered(false);

                entity.ToTable("RecievedStatus");

                entity.Property(e => e.ReceiveStatusName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .IsClustered(false);

                entity.ToTable("Region");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<Remote>(entity =>
            {
                entity.HasKey(e => e.RemoteId)
                    .IsClustered(false);

                entity.ToTable("Remote");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.SchoolId)
                    .IsClustered(false);

                entity.ToTable("School");

                entity.Property(e => e.SchoolName).IsRequired();
            });

            builder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.SectorId)
                    .IsClustered(false);

                entity.ToTable("Sector");

                entity.Property(e => e.SectorName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<SentMsgToHiredIntern>(entity =>
            {
                entity.HasKey(e => e.SentId)
                    .IsClustered(false);

                entity.Property(e => e.Attachments).ValueGeneratedOnAdd();

                entity.Property(e => e.FileType)
                   .IsRequired()
                   .HasMaxLength(256);
                entity.Property(e => e.Extension)
                   .IsRequired()
                   .HasMaxLength(256);

                entity.Property(e => e.FilePath)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.InternId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Messagebody).IsRequired();

                entity.Property(e => e.SentDate).HasColumnType("date");

                entity.Property(e => e.SentTime).HasMaxLength(20);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("subject");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SentMsgToHiredInterns)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_SentMsgToHiredInterns");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.SentMsgToHiredInterns)
                    .HasForeignKey(d => d.InternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interns_SentMsgToHiredInterns");

                entity.HasOne(d => d.SentStatus)
                    .WithMany(p => p.SentMsgToHiredInterns)
                    .HasForeignKey(d => d.SentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SentStatus_SentMsgToHiredInterns");
            });

            builder.Entity<SentStatus>(entity =>
            {
                entity.HasKey(e => e.SentStatusId)
                    .IsClustered(false);

                entity.ToTable("SentStatus");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<VerifyCategory>(entity =>
            {
                entity.HasKey(e => e.VerifyCategoryId)
                    .IsClustered(false);

                entity.ToTable("verifyCategory");

                entity.Property(e => e.VerifyName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.Entity<VerifyCompany>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.VerifyCategoryId })
                    .IsClustered(false);

                entity.ToTable("VerifyCompany");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.VerifyCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_VerifyCompany");

                entity.HasOne(d => d.VerifyCategory)
                    .WithMany(p => p.VerifyCompanies)
                    .HasForeignKey(d => d.VerifyCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_verifyCategory_VerifyCompany");
            });

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.ReceivedMsgFromCompanyViewModel> ReceivedMsgFromCompanyViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.ApplicationViewModel> ApplicationViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.CompanyViewModel> CompanyViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.UserRoleViewModel> UserRoleViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.UsersViewModel> UsersViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.HiredInternsViewModel> HiredInternsViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.DesignationViewModel> DesignationViewModel { get; set; }

        public DbSet<OnlineInternshipPortal.Models.Data.ViewModel.IndustryViewModel> IndustryViewModel { get; set; }

       
       
    }
}
