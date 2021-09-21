using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineInternshipPortal.Migrations
{
    public partial class New_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

           

            migrationBuilder.CreateTable(
                name: "CompanyLogo",
                schema: "dbo",
                columns: table => new
                {
                    CompanyImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLogo", x => x.CompanyImageId)
                        .Annotation("SqlServer:Clustered", false);
                });

           
            migrationBuilder.CreateTable(
                name: "CV",
                schema: "dbo",
                columns: table => new
                {
                    CV_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.CV_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                schema: "dbo",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationId)
                        .Annotation("SqlServer:Clustered", false);
                });

          
            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "dbo",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "GuardianCategory",
                schema: "dbo",
                columns: table => new
                {
                    GuardianCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianCategory", x => x.GuardianCategoryId)
                        .Annotation("SqlServer:Clustered", false);
                });

          
            migrationBuilder.CreateTable(
                name: "Industry",
                schema: "dbo",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    industryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.IndustryId)
                        .Annotation("SqlServer:Clustered", false);
                });

          

            migrationBuilder.CreateTable(
                name: "InternshipApproval",
                schema: "dbo",
                columns: table => new
                {
                    ApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipApproval", x => x.ApprovalId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "InternshipStatus",
                schema: "dbo",
                columns: table => new
                {
                    InternshipStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipStatus", x => x.InternshipStatusId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "MsgReadStatus",
                schema: "dbo",
                columns: table => new
                {
                    MsgReadStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgReadStatusName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgReadStatus", x => x.MsgReadStatusId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Publicize",
                schema: "dbo",
                columns: table => new
                {
                    PublicizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicize", x => x.PublicizeId)
                        .Annotation("SqlServer:Clustered", false);
                });

           

            migrationBuilder.CreateTable(
                name: "RecievedStatus",
                schema: "dbo",
                columns: table => new
                {
                    ReceivedStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiveStatusName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecievedStatus", x => x.ReceivedStatusId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "dbo",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Remote",
                schema: "dbo",
                columns: table => new
                {
                    RemoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remote", x => x.RemoteId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "School",
                schema: "dbo",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                schema: "dbo",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "SentStatus",
                schema: "dbo",
                columns: table => new
                {
                    SentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentStatus", x => x.SentStatusId)
                        .Annotation("SqlServer:Clustered", false);
                });

          

           
            migrationBuilder.CreateTable(
                name: "verifyCategory",
                schema: "dbo",
                columns: table => new
                {
                    VerifyCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerifyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verifyCategory", x => x.VerifyCategoryId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Guardian",
                schema: "dbo",
                columns: table => new
                {
                    GuardianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardian", x => x.GuardianId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_GuardianCategory_Guardian",
                        column: x => x.GuardianCategoryId,
                        principalSchema: "dbo",
                        principalTable: "GuardianCategory",
                        principalColumn: "GuardianCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    HomeTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Users_Gender_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dbo",
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Region_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dbo",
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interns",
                schema: "dbo",
                columns: table => new
                {
                    InternId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    HomeTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Student_Id_Card_Number = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Course = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GuardianId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CV_Id = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.InternId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CV_Interns",
                        column: x => x.CV_Id,
                        principalSchema: "dbo",
                        principalTable: "CV",
                        principalColumn: "CV_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genders_Interns",
                        column: x => x.GenderId,
                        principalSchema: "dbo",
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guardian_Interns",
                        column: x => x.GuardianId,
                        principalSchema: "dbo",
                        principalTable: "Guardian",
                        principalColumn: "GuardianId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_Inte15",
                        column: x => x.RegionId,
                        principalSchema: "dbo",
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Interns",
                        column: x => x.SchoolId,
                        principalSchema: "dbo",
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyRegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Companywebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyVideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    OtherIndustry = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    CompanyImageId = table.Column<int>(type: "int", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyLogo_Company",
                        column: x => x.CompanyImageId,
                        principalSchema: "dbo",
                        principalTable: "CompanyLogo",
                        principalColumn: "CompanyImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Designation_Company",
                        column: x => x.DesignationId,
                        principalSchema: "dbo",
                        principalTable: "Designation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Industry_Company",
                        column: x => x.IndustryId,
                        principalSchema: "dbo",
                        principalTable: "Industry",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_Company",
                        column: x => x.RegionId,
                        principalSchema: "dbo",
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sector_Company",
                        column: x => x.SectorId,
                        principalSchema: "dbo",
                        principalTable: "Sector",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.LoginProvider)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.LoginProvider)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hired",
                schema: "dbo",
                columns: table => new
                {
                    HireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    InternId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hired", x => x.HireId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_Hired",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interns_Hired",
                        column: x => x.InternId,
                        principalSchema: "dbo",
                        principalTable: "Interns",
                        principalColumn: "InternId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Internship",
                schema: "dbo",
                columns: table => new
                {
                    InternshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillsRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Additional_Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeadLineDate = table.Column<DateTime>(type: "date", nullable: false),
                    WhoCanApply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "date", nullable: false),
                    PostedTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InternshipStatusId = table.Column<int>(type: "int", nullable: false),
                    RemoteId = table.Column<int>(type: "int", nullable: false),
                    CompanyImageId = table.Column<int>(type: "int", nullable: true),
                    PublicizeId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internship", x => x.InternshipId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_Internship",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyLogo_Internship",
                        column: x => x.CompanyImageId,
                        principalSchema: "dbo",
                        principalTable: "CompanyLogo",
                        principalColumn: "CompanyImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Industry_Internship",
                        column: x => x.IndustryId,
                        principalSchema: "dbo",
                        principalTable: "Industry",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternshipStatus_Internship",
                        column: x => x.InternshipStatusId,
                        principalSchema: "dbo",
                        principalTable: "InternshipStatus",
                        principalColumn: "InternshipStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicize_Internship",
                        column: x => x.PublicizeId,
                        principalSchema: "dbo",
                        principalTable: "Publicize",
                        principalColumn: "PublicizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remote_Internship",
                        column: x => x.RemoteId,
                        principalSchema: "dbo",
                        principalTable: "Remote",
                        principalColumn: "RemoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecievedMsgFromCompany",
                schema: "dbo",
                columns: table => new
                {
                    RecieveId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Messagebody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReceivedTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ReceivedStatusId = table.Column<int>(type: "int", nullable: false),
                    MsgReadStatusId = table.Column<int>(type: "int", nullable: false),
                    InternId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecievedMsgFromCompany", x => x.RecieveId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_RecievedMsgFromCompany",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interns_RecievedMsgFromCompany",
                        column: x => x.InternId,
                        principalSchema: "dbo",
                        principalTable: "Interns",
                        principalColumn: "InternId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MsgReadStatus_RecievedMsgFromCompany",
                        column: x => x.MsgReadStatusId,
                        principalSchema: "dbo",
                        principalTable: "MsgReadStatus",
                        principalColumn: "MsgReadStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecievedStatus_RecievedMsgFromCompany",
                        column: x => x.ReceivedStatusId,
                        principalSchema: "dbo",
                        principalTable: "RecievedStatus",
                        principalColumn: "ReceivedStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SentMsgToHiredInterns",
                schema: "dbo",
                columns: table => new
                {
                    SentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Messagebody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SentDate = table.Column<DateTime>(type: "date", nullable: false),
                    SentTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    SentStatusId = table.Column<int>(type: "int", nullable: false),
                    InternId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMsgToHiredInterns", x => x.SentId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_SentMsgToHiredInterns",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interns_SentMsgToHiredInterns",
                        column: x => x.InternId,
                        principalSchema: "dbo",
                        principalTable: "Interns",
                        principalColumn: "InternId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SentStatus_SentMsgToHiredInterns",
                        column: x => x.SentStatusId,
                        principalSchema: "dbo",
                        principalTable: "SentStatus",
                        principalColumn: "SentStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VerifyCompany",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VerifyCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyCompany", x => new { x.CompanyId, x.VerifyCategoryId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_VerifyCompany",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_verifyCategory_VerifyCompany",
                        column: x => x.VerifyCategoryId,
                        principalSchema: "dbo",
                        principalTable: "verifyCategory",
                        principalColumn: "VerifyCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "date", nullable: false),
                    InternId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    InternshipId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CV_Id = table.Column<int>(type: "int", nullable: false),
                    ApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Company_Application",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CV_Application",
                        column: x => x.CV_Id,
                        principalSchema: "dbo",
                        principalTable: "CV",
                        principalColumn: "CV_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interns_Application",
                        column: x => x.InternId,
                        principalSchema: "dbo",
                        principalTable: "Interns",
                        principalColumn: "InternId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internship_Application",
                        column: x => x.InternshipId,
                        principalSchema: "dbo",
                        principalTable: "Internship",
                        principalColumn: "InternshipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternshipApproval_Application",
                        column: x => x.ApprovalId,
                        principalSchema: "dbo",
                        principalTable: "InternshipApproval",
                        principalColumn: "ApprovalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApprovalId",
                schema: "dbo",
                table: "Application",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_CompanyId",
                schema: "dbo",
                table: "Application",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_CV_Id",
                schema: "dbo",
                table: "Application",
                column: "CV_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Application_InternId",
                schema: "dbo",
                table: "Application",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_InternshipId",
                schema: "dbo",
                table: "Application",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyImageId",
                schema: "dbo",
                table: "Company",
                column: "CompanyImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_DesignationId",
                schema: "dbo",
                table: "Company",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_IndustryId",
                schema: "dbo",
                table: "Company",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_RegionId",
                schema: "dbo",
                table: "Company",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_SectorId",
                schema: "dbo",
                table: "Company",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                schema: "dbo",
                table: "Company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardian_GuardianCategoryId",
                schema: "dbo",
                table: "Guardian",
                column: "GuardianCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hired_CompanyId",
                schema: "dbo",
                table: "Hired",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hired_InternId",
                schema: "dbo",
                table: "Hired",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_CV_Id",
                schema: "dbo",
                table: "Interns",
                column: "CV_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_GenderId",
                schema: "dbo",
                table: "Interns",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_GuardianId",
                schema: "dbo",
                table: "Interns",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_RegionId",
                schema: "dbo",
                table: "Interns",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_SchoolId",
                schema: "dbo",
                table: "Interns",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_CompanyId",
                schema: "dbo",
                table: "Internship",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_CompanyImageId",
                schema: "dbo",
                table: "Internship",
                column: "CompanyImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_IndustryId",
                schema: "dbo",
                table: "Internship",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_InternshipStatusId",
                schema: "dbo",
                table: "Internship",
                column: "InternshipStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_PublicizeId",
                schema: "dbo",
                table: "Internship",
                column: "PublicizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_RemoteId",
                schema: "dbo",
                table: "Internship",
                column: "RemoteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecievedMsgFromCompany_CompanyId",
                schema: "dbo",
                table: "RecievedMsgFromCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RecievedMsgFromCompany_InternId",
                schema: "dbo",
                table: "RecievedMsgFromCompany",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_RecievedMsgFromCompany_MsgReadStatusId",
                schema: "dbo",
                table: "RecievedMsgFromCompany",
                column: "MsgReadStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RecievedMsgFromCompany_ReceivedStatusId",
                schema: "dbo",
                table: "RecievedMsgFromCompany",
                column: "ReceivedStatusId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMsgToHiredInterns_CompanyId",
                schema: "dbo",
                table: "SentMsgToHiredInterns",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMsgToHiredInterns_InternId",
                schema: "dbo",
                table: "SentMsgToHiredInterns",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMsgToHiredInterns_SentStatusId",
                schema: "dbo",
                table: "SentMsgToHiredInterns",
                column: "SentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "dbo",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                schema: "dbo",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegionId",
                schema: "dbo",
                table: "Users",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                schema: "dbo",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifyCompany_VerifyCategoryId",
                schema: "dbo",
                table: "VerifyCompany",
                column: "VerifyCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application",
                schema: "dbo");

          

          
            migrationBuilder.DropTable(
                name: "RecievedMsgFromCompany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SentMsgToHiredInterns",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

          

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VerifyCompany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Internship",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InternshipApproval",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MsgReadStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecievedStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Interns",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SentStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "verifyCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InternshipStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Publicize",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Remote",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CV",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Guardian",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "School",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CompanyLogo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Industry",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sector",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GuardianCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "dbo");
        }
    }
}
