using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortalApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "businessCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "educationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resultType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servicePackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    PackageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicePackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adminUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reports_AspNetUsers_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "careerInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareerSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareerObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentSalary = table.Column<float>(type: "real", nullable: false),
                    ExpectedSalary = table.Column<float>(type: "real", nullable: false),
                    businessCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_careerInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_careerInformation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_careerInformation_businessCategories_businessCategoryId",
                        column: x => x.businessCategoryId,
                        principalTable: "businessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employmentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    businessCategoryId = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobstartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employmentHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employmentHistories_businessCategories_businessCategoryId",
                        column: x => x.businessCategoryId,
                        principalTable: "businessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "policeStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policeStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_policeStations_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "degreeInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    educationLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_degreeInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_degreeInfos_educationLevels_educationLevelId",
                        column: x => x.educationLevelId,
                        principalTable: "educationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cvBuyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessCategoryId = table.Column<int>(type: "int", nullable: false),
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvBuyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cvBuyInfos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cvBuyInfos_businessCategories_BusinessCategoryId",
                        column: x => x.BusinessCategoryId,
                        principalTable: "businessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cvBuyInfos_servicePackages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "servicePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostId = table.Column<int>(type: "int", nullable: false),
                    CvBuyInfoId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_servicePackages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "servicePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfVacancies = table.Column<int>(type: "int", nullable: false),
                    CircularStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CircularExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobResponsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otherbenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumEducationLevelId = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    PostStatus = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobPosts_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobPosts_businessCategories_BusinessCategoryId",
                        column: x => x.BusinessCategoryId,
                        principalTable: "businessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobPosts_educationLevels_MinimumEducationLevelId",
                        column: x => x.MinimumEducationLevelId,
                        principalTable: "educationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobPosts_servicePackages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "servicePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobProviderCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: false),
                    BusinessCategoryId = table.Column<int>(type: "int", nullable: false),
                    BusinessDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeLicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobProviderCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobProviderCompanies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobProviderCompanies_businessCategories_BusinessCategoryId",
                        column: x => x.BusinessCategoryId,
                        principalTable: "businessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobProviderCompanies_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_jobProviderCompanies_policeStations_PoliceStationId",
                        column: x => x.PoliceStationId,
                        principalTable: "policeStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobSeekerUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<int>(type: "int", nullable: false),
                    NidNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    present_PoliceStationId = table.Column<int>(type: "int", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permanent_PoliceStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobSeekerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobSeekerUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobSeekerUsers_policeStations_present_PoliceStationId",
                        column: x => x.present_PoliceStationId,
                        principalTable: "policeStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academicInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    MajorSub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultTypeId = table.Column<int>(type: "int", nullable: false),
                    MarkScale = table.Column<int>(type: "int", nullable: false),
                    ObtainMark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassingYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_academicInformation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicInformation_degreeInfos_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "degreeInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicInformation_resultType_ResultTypeId",
                        column: x => x.ResultTypeId,
                        principalTable: "resultType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "viewResumeLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    JobSeekerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_viewResumeLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_viewResumeLists_AspNetUsers_JobSeekerUserId",
                        column: x => x.JobSeekerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_viewResumeLists_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "postModerators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobPostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postModerators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_postModerators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postModerators_jobPosts_jobPostId",
                        column: x => x.jobPostId,
                        principalTable: "jobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "applyJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCircularId = table.Column<int>(type: "int", nullable: false),
                    ExpectedSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobSeekerUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applyJobs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applyJobs_jobPosts_JobCircularId",
                        column: x => x.JobCircularId,
                        principalTable: "jobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_applyJobs_jobSeekerUsers_JobSeekerUserId",
                        column: x => x.JobSeekerUserId,
                        principalTable: "jobSeekerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "interviewInvitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppliedJobId = table.Column<int>(type: "int", nullable: false),
                    MassageSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitationMassage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interviewInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interviewInvitations_applyJobs_AppliedJobId",
                        column: x => x.AppliedJobId,
                        principalTable: "applyJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("572c5fd0-6e71-44c0-bdc2-3b5c6349290c"), "414c0b3f-4b82-4134-816d-a60ff801212b", "Employer", null },
                    { new Guid("3e7de964-0803-42e6-a53b-57f9677e8e89"), "97490333-5e2d-4bbe-9a1b-b5f94b92577c", "Employee", null },
                    { new Guid("84b24463-4d57-4b6c-8e1a-cc075bdcb8f8"), "d715b0d7-716b-4fbf-b23a-7d65898a4669", "Admin", null },
                    { new Guid("7ea4cb73-320d-43d2-83c2-c781c3e4d859"), "7355621a-5531-432f-b314-3537c7ceb342", "SuperAdmin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8a06a0de-c1b0-4d58-9e2a-cdd63cbeb6f8"), 0, "4a0b29e9-2a07-4f58-9424-eafbac4c05df", "user8@employee.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGuJTszMAfYcvmu2R7o7CgNorN1GOodx9yO2TPC6/h7HP1ka8vanATKUTlpYkxR+0g==", null, false, null, null, false, "rinia99" },
                    { new Guid("857da82f-65f5-4c81-9404-8ab003989aa2"), 0, "e92a2cbf-df0a-403c-97a0-20214638c048", "user6@employee.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJmGoZd6n3VHMlg3y5oNztyVjOUs2ojqq9N4RxZcjihMhk3Ejv1eNtpfcuTZgc1bVw==", null, false, null, null, false, "antonio99" },
                    { new Guid("a68c8c8d-6de6-4671-b833-38053a5ab071"), 0, "e30712ce-f7d5-4b82-817c-cfc204165c8a", "user5@employer.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOxjVEYJ0GYTso2RpUOjIO+8ZLfZ6c9FofoWMeiyadqtvfNn4KYQCh/IQBOANCM44A==", null, false, null, null, false, "mark99" },
                    { new Guid("e4915472-c6a0-4216-ad8c-e529fee2b9b3"), 0, "2ebf5fd3-56d1-4bdd-8f38-faedec720799", "user4@employer.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIO8I4vZeUMSY6bcja9HOvi6GU5NnGEvAtY/eoeRm74rnhUQpWi3913a6GnJ6QIpkQ==", null, false, null, null, false, "mario99" },
                    { new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02"), 0, "ab5f9d24-37aa-487f-8cee-331c3058a52a", "user3@employee.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENKb6TvbJgr/2s0tNEtz/GCad7ds4b9CZIL2ontz7ipSn/pZHwtllT/D0RP9J1/1Qg==", null, false, null, null, false, "max99" },
                    { new Guid("9a312145-99ed-4b25-a8a8-e8207083c164"), 0, "713ea9da-791d-4914-b959-7716ff2b92b4", "user2@admin.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJyOPGGE6llWWPpkS5FWJv1tsVgxBYSCEDyQN8tdQwr1n4jkz0Vpqv+4f/DrZRK2TQ==", null, false, null, null, false, "alex99" },
                    { new Guid("33a1c5df-7a23-44ff-bf41-4c0518a2dac7"), 0, "a70ecd46-b213-4237-aaf4-be616c13622a", "user1@superadmin.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMebPV4Qh0aSKBN1QIkuO4CoEPNpG199pirNwVv7ccMKmdyKfo6ISAlB/sh5x1qOkg==", null, false, null, null, false, "shaheen" },
                    { new Guid("c12b6fa3-2c90-44e4-9b69-084fbf541b77"), 0, "7b257ef1-91b2-4432-b70e-4dc262d2abac", "user7@employee.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEDX3+IeZA+Lq8jW1b+r0WNo1al/imdczm4Cmrf/WNG1VV2aai9pvIku/v97De1q/PQ==", null, false, null, null, false, "rio99" }
                });

            migrationBuilder.InsertData(
                table: "businessCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT & Telecommunication" },
                    { 2, " Engineer/Architects" },
                    { 3, "HR/Org. Development" }
                });

            migrationBuilder.InsertData(
                table: "districts",
                columns: new[] { "Id", "DistrictName" },
                values: new object[,]
                {
                    { 1, "Dhaka" },
                    { 2, "Gazipur" },
                    { 3, "Manikganj" },
                    { 4, "Munshiganj" }
                });

            migrationBuilder.InsertData(
                table: "educationLevels",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 7, "MASTERS" },
                    { 1, "PSC/5 PASS" },
                    { 6, "BACHELOR/HONORS" },
                    { 3, "SECONDARY" },
                    { 2, "JSC/JDC/8 PASS" },
                    { 5, "DIPLOMA" },
                    { 4, "HIGHER SECONDARY" },
                    { 8, "PhD (Doctor of Philosophy)" }
                });

            migrationBuilder.InsertData(
                table: "resultType",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 5, "Appeared" },
                    { 4, "Grade" },
                    { 3, "Third Division/Class" },
                    { 2, "Second Division/Class" },
                    { 1, "First Division/Class" }
                });

            migrationBuilder.InsertData(
                table: "servicePackages",
                columns: new[] { "Id", "Description", "MaxValue", "Name", "PackageType", "Price" },
                values: new object[,]
                {
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 0, "Premium Listing", 0, 1500m },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 0, "Standard Listing", 0, 1000m },
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 0, "Basic Listing", 0, 500m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { new Guid("572c5fd0-6e71-44c0-bdc2-3b5c6349290c"), new Guid("e4915472-c6a0-4216-ad8c-e529fee2b9b3"), "UserRoles" },
                    { new Guid("3e7de964-0803-42e6-a53b-57f9677e8e89"), new Guid("c12b6fa3-2c90-44e4-9b69-084fbf541b77"), "UserRoles" },
                    { new Guid("3e7de964-0803-42e6-a53b-57f9677e8e89"), new Guid("857da82f-65f5-4c81-9404-8ab003989aa2"), "UserRoles" },
                    { new Guid("572c5fd0-6e71-44c0-bdc2-3b5c6349290c"), new Guid("a68c8c8d-6de6-4671-b833-38053a5ab071"), "UserRoles" },
                    { new Guid("3e7de964-0803-42e6-a53b-57f9677e8e89"), new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02"), "UserRoles" },
                    { new Guid("84b24463-4d57-4b6c-8e1a-cc075bdcb8f8"), new Guid("9a312145-99ed-4b25-a8a8-e8207083c164"), "UserRoles" },
                    { new Guid("3e7de964-0803-42e6-a53b-57f9677e8e89"), new Guid("8a06a0de-c1b0-4d58-9e2a-cdd63cbeb6f8"), "UserRoles" },
                    { new Guid("7ea4cb73-320d-43d2-83c2-c781c3e4d859"), new Guid("33a1c5df-7a23-44ff-bf41-4c0518a2dac7"), "UserRoles" }
                });

            migrationBuilder.InsertData(
                table: "adminUsers",
                columns: new[] { "Id", "Date", "Designation", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Office Executive", "Shaheen", "Hossain", new Guid("9a312145-99ed-4b25-a8a8-e8207083c164") });

            migrationBuilder.InsertData(
                table: "careerInformation",
                columns: new[] { "Id", "CareerObjective", "CareerSummary", "ExpectedSalary", "PresentSalary", "UserId", "businessCategoryId" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", 35000f, 25000f, new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02"), 1 },
                    { 4, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", 35000f, 25000f, new Guid("8a06a0de-c1b0-4d58-9e2a-cdd63cbeb6f8"), 1 },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", 35000f, 25000f, new Guid("c12b6fa3-2c90-44e4-9b69-084fbf541b77"), 1 },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", 35000f, 25000f, new Guid("857da82f-65f5-4c81-9404-8ab003989aa2"), 1 }
                });

            migrationBuilder.InsertData(
                table: "degreeInfos",
                columns: new[] { "Id", "Name", "educationLevelId" },
                values: new object[,]
                {
                    { 1, "Bachelor of Science (BSc)", 6 },
                    { 2, "Bachelor of Art (BA)", 6 },
                    { 3, "Bachelor of Business Administration (BBA)", 6 }
                });

            migrationBuilder.InsertData(
                table: "employmentHistories",
                columns: new[] { "Id", "CompanyAddress", "CompanyName", "Department", "Designation", "JobEndDate", "JobstartDate", "Responsibilities", "UserId", "businessCategoryId" },
                values: new object[,]
                {
                    { 2, "Mirpur, Dhaka", "ABC Ltd.", "Product", "Office Executive", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", new Guid("857da82f-65f5-4c81-9404-8ab003989aa2"), 1 },
                    { 4, "Mirpur, Dhaka", "ABC Ltd.", "Product", "Office Executive", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", new Guid("8a06a0de-c1b0-4d58-9e2a-cdd63cbeb6f8"), 1 },
                    { 3, "Mirpur, Dhaka", "ABC Ltd.", "Product", "Office Executive", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", new Guid("c12b6fa3-2c90-44e4-9b69-084fbf541b77"), 1 },
                    { 1, "Mirpur, Dhaka", "ABC Ltd.", "Product", "Office Executive", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02"), 1 }
                });

            migrationBuilder.InsertData(
                table: "invoices",
                columns: new[] { "Id", "CvBuyInfoId", "Date", "JobPostId", "PackagesId", "PaymentStatus", "Quantity", "TotalAmount", "TransactionId", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, true, 1, 500m, "TX5412451XDAESS49SFW", 500, new Guid("a68c8c8d-6de6-4671-b833-38053a5ab071") },
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, true, 1, 500m, "TX5412451XDAE49SFW", 500, new Guid("e4915472-c6a0-4216-ad8c-e529fee2b9b3") }
                });

            migrationBuilder.InsertData(
                table: "jobPosts",
                columns: new[] { "Id", "AdditionalInformation", "BusinessCategoryId", "CircularExpiredDate", "CircularStartDate", "Designation", "EmploymentStatus", "Experience", "JobLocation", "JobResponsibilities", "JobTitle", "MaxAge", "MinimumEducationLevelId", "NoOfVacancies", "Otherbenefits", "PackageId", "PostStatus", "Salary", "gender", "userId" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Sr. Developer", 0, "5 Years", "Mirpur DOHS", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", "ASP.NET Web Developer Needed", 30, 1, 10, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 1, 1, "Negotiable", 2, new Guid("e4915472-c6a0-4216-ad8c-e529fee2b9b3") },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Sr. Developer", 0, "5 Years", "Mirpur DOHS", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", "ASP.NET Web Developer Needed", 30, 1, 10, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 1, 0, "Negotiable", 2, new Guid("a68c8c8d-6de6-4671-b833-38053a5ab071") }
                });

            migrationBuilder.InsertData(
                table: "policeStations",
                columns: new[] { "Id", "DistrictId", "Name" },
                values: new object[] { 1, 1, "Pallabi" });

            migrationBuilder.InsertData(
                table: "academicInformation",
                columns: new[] { "Id", "DegreeId", "Duration", "InstituteName", "MajorSub", "MarkScale", "ObtainMark", "PassingYear", "ResultTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "4", "DU", "Physics", 4, 3.1m, "2018", 4, new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02") },
                    { 2, 1, "4", "DU", "Physics", 4, 3.1m, "2018", 4, new Guid("857da82f-65f5-4c81-9404-8ab003989aa2") },
                    { 3, 1, "4", "DU", "Physics", 4, 3.1m, "2018", 4, new Guid("c12b6fa3-2c90-44e4-9b69-084fbf541b77") },
                    { 4, 1, "4", "DU", "Physics", 4, 3.1m, "2018", 4, new Guid("8a06a0de-c1b0-4d58-9e2a-cdd63cbeb6f8") }
                });

            migrationBuilder.InsertData(
                table: "applyJobs",
                columns: new[] { "Id", "AppliedDate", "ExpectedSalary", "JobCircularId", "JobSeekerUserId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), 25000m, 1, null, new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02") });

            migrationBuilder.InsertData(
                table: "jobProviderCompanies",
                columns: new[] { "Id", "Address", "BusinessCategoryId", "BusinessDescription", "CompanyLogo", "CompanyName", "ContactPersonEmail", "ContactPersonName", "ContactPersonPhoneNo", "DistrictId", "PoliceStationId", "TradeLicenseNo", "UserId", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, " 55/B, Noakhali Tower,Purana Paltan, Dhaka, Bangladesh 1000", 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", null, "DotNet IT Solution Ltd.", "antonio@employer.com", "Antonio", "01911111111", null, 1, "T123456789", new Guid("e4915472-c6a0-4216-ad8c-e529fee2b9b3"), "www.domain.com" },
                    { 2, " 55/B, Noakhali Tower,Purana Paltan, Dhaka, Bangladesh 1000", 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", null, "DotNet IT Solution Ltd.", "antonio@employer.com", "Antonio", "01911111111", null, 1, "T123456789", new Guid("a68c8c8d-6de6-4671-b833-38053a5ab071"), "www.domain.com" }
                });

            migrationBuilder.InsertData(
                table: "jobSeekerUsers",
                columns: new[] { "Id", "DateOfBirth", "FathersName", "FirstName", "Gender", "LastName", "MaritalStatus", "MobileNo", "MothersName", "Nationality", "NidNo", "PermanentAddress", "PresentAddress", "Religion", "ResumeFile", "UserId", "permanent_PoliceStationId", "present_PoliceStationId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Md Rahman", "Rahim", 0, "Mia", 0, "01912701613", "Rahima Begum", 0, "199011112233445566", "Dhaka", "Dhaka", 0, null, new Guid("672481c0-fcc3-41d5-90e2-51c7fc3abf02"), 1, 1 },
                    { 2, new DateTime(1990, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Md Rahman", "Rahim", 0, "Mia", 0, "01912701613", "Rahima Begum", 0, "199011112233445566", "Dhaka", "Dhaka", 0, null, new Guid("857da82f-65f5-4c81-9404-8ab003989aa2"), 1, 1 },
                    { 3, new DateTime(1990, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Md Rahman", "Rahim", 0, "Mia", 0, "01912701613", "Rahima Begum", 0, "199011112233445566", "Dhaka", "Dhaka", 0, null, new Guid("c12b6fa3-2c90-44e4-9b69-084fbf541b77"), 1, 1 },
                    { 4, new DateTime(1990, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Md Rahman", "Rahim", 0, "Mia", 0, "01912701613", "Rahima Begum", 0, "199011112233445566", "Dhaka", "Dhaka", 0, null, new Guid("8a06a0de-c1b0-4d58-9e2a-cdd63cbeb6f8"), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "postModerators",
                columns: new[] { "Id", "Date", "Status", "UserId", "jobPostId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("e4915472-c6a0-4216-ad8c-e529fee2b9b3"), 1 },
                    { 2, new DateTime(2020, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("a68c8c8d-6de6-4671-b833-38053a5ab071"), 2 }
                });

            migrationBuilder.InsertData(
                table: "interviewInvitations",
                columns: new[] { "Id", "AppliedJobId", "InvitationDate", "InvitationMassage", "MassageSubject" },
                values: new object[] { 1, 1, new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters", "Interview Invitation" });

            migrationBuilder.CreateIndex(
                name: "IX_academicInformation_DegreeId",
                table: "academicInformation",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_academicInformation_ResultTypeId",
                table: "academicInformation",
                column: "ResultTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_academicInformation_UserId",
                table: "academicInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_adminUsers_UserId",
                table: "adminUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_applyJobs_JobCircularId",
                table: "applyJobs",
                column: "JobCircularId");

            migrationBuilder.CreateIndex(
                name: "IX_applyJobs_JobSeekerUserId",
                table: "applyJobs",
                column: "JobSeekerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_applyJobs_UserId",
                table: "applyJobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_careerInformation_businessCategoryId",
                table: "careerInformation",
                column: "businessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_careerInformation_UserId",
                table: "careerInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_cvBuyInfos_BusinessCategoryId",
                table: "cvBuyInfos",
                column: "BusinessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_cvBuyInfos_PackagesId",
                table: "cvBuyInfos",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_cvBuyInfos_UserId",
                table: "cvBuyInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_degreeInfos_educationLevelId",
                table: "degreeInfos",
                column: "educationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_employmentHistories_businessCategoryId",
                table: "employmentHistories",
                column: "businessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_employmentHistories_UserId",
                table: "employmentHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_interviewInvitations_AppliedJobId",
                table: "interviewInvitations",
                column: "AppliedJobId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_PackagesId",
                table: "invoices",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_UserId",
                table: "invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_jobPosts_BusinessCategoryId",
                table: "jobPosts",
                column: "BusinessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_jobPosts_MinimumEducationLevelId",
                table: "jobPosts",
                column: "MinimumEducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_jobPosts_PackageId",
                table: "jobPosts",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_jobPosts_userId",
                table: "jobPosts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_jobProviderCompanies_BusinessCategoryId",
                table: "jobProviderCompanies",
                column: "BusinessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_jobProviderCompanies_DistrictId",
                table: "jobProviderCompanies",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_jobProviderCompanies_PoliceStationId",
                table: "jobProviderCompanies",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_jobProviderCompanies_UserId",
                table: "jobProviderCompanies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_jobSeekerUsers_present_PoliceStationId",
                table: "jobSeekerUsers",
                column: "present_PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_jobSeekerUsers_UserId",
                table: "jobSeekerUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_policeStations_DistrictId",
                table: "policeStations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_postModerators_jobPostId",
                table: "postModerators",
                column: "jobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_postModerators_UserId",
                table: "postModerators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_ReportedUserId",
                table: "reports",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_viewResumeLists_InvoiceId",
                table: "viewResumeLists",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_viewResumeLists_JobSeekerUserId",
                table: "viewResumeLists",
                column: "JobSeekerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academicInformation");

            migrationBuilder.DropTable(
                name: "adminUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "careerInformation");

            migrationBuilder.DropTable(
                name: "cvBuyInfos");

            migrationBuilder.DropTable(
                name: "employmentHistories");

            migrationBuilder.DropTable(
                name: "interviewInvitations");

            migrationBuilder.DropTable(
                name: "jobProviderCompanies");

            migrationBuilder.DropTable(
                name: "postModerators");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "viewResumeLists");

            migrationBuilder.DropTable(
                name: "degreeInfos");

            migrationBuilder.DropTable(
                name: "resultType");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "applyJobs");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "jobPosts");

            migrationBuilder.DropTable(
                name: "jobSeekerUsers");

            migrationBuilder.DropTable(
                name: "businessCategories");

            migrationBuilder.DropTable(
                name: "educationLevels");

            migrationBuilder.DropTable(
                name: "servicePackages");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "policeStations");

            migrationBuilder.DropTable(
                name: "districts");
        }
    }
}
