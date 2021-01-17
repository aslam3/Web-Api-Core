using JobPortalApp.Model.db_models;
using JobPortalApp.Model.db_models.AddressManagement;
using JobPortalApp.Model.db_models.JobProviderAreas;
using JobPortalApp.Model.db_models.JobSeekerInfo;
using JobPortalApp.Model.db_models.AppUser;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalApp.Controllers;
using System.Security.Policy;

namespace JobPortalApp.Model
{
    public class jobdbcontext:IdentityDbContext<User,Role,Guid>
    {
        
        public jobdbcontext(DbContextOptions<jobdbcontext> db) : base(db)
        {
           
        }

        //------
        public DbSet<JobSeekerUser> jobSeekerUsers { get; set; }
        public DbSet<JobProviderUser> jobProviderCompanies { get; set; }
        public DbSet<AdminUser> adminUsers { get; set; }
        //-----
        
        
        public DbSet<District> districts { get; set; }
        public DbSet<PoliceStation> policeStations { get; set; }
        //------
        public DbSet<ApplyJob> applyJobs { get; set; }
        public DbSet<InterviewInvitation> interviewInvitations { get; set; }
        public DbSet<JobPost> jobPosts { get; set; }
        //-------
        public DbSet<AcademicInformation> academicInformation  { get; set; }
        public DbSet<CareerInformation> careerInformation { get; set; }
        public DbSet<DegreeInfo> degreeInfos { get; set; }
        public DbSet<EducationLevel> educationLevels { get; set; }
        public DbSet<EmploymentHistory> employmentHistories { get; set; }
        public DbSet<ResultType> resultType { get; set; }
        //------

        public DbSet<CvBankQuery>  cvBuyInfos { get; set; }
        public DbSet<ViewResumeList> viewResumeLists { get; set; }


        public DbSet<BusinessCategory> businessCategories { get; set; }
        public DbSet<PostModerator> postModerators { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Packages> servicePackages { get; set; }
        public DbSet<Report> reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // User Id
            var uid_1 = Guid.NewGuid();
            var uid_2 = Guid.NewGuid();
            var uid_3 = Guid.NewGuid();
            var uid_4 = Guid.NewGuid();
            var uid_5 = Guid.NewGuid();
            var uid_6 = Guid.NewGuid();
            var uid_7 = Guid.NewGuid();
            var uid_8 = Guid.NewGuid();
            // Role Id
            var roleId_1 = Guid.NewGuid();
            var roleId_2 = Guid.NewGuid();
            var roleId_3 = Guid.NewGuid();
            var roleId_4 = Guid.NewGuid();
            // UserRole Id
            var userRoleId_1 = Guid.NewGuid();
            var userRoleId_2 = Guid.NewGuid();
            var userRoleId_3 = Guid.NewGuid();
            var userRoleId_4 = Guid.NewGuid();
            var userRoleId_5 = Guid.NewGuid();
            var userRoleId_6 = Guid.NewGuid();
            var userRoleId_7 = Guid.NewGuid();
            var userRoleId_8 = Guid.NewGuid();

            // Password 

            var hasher = new PasswordHasher<IdentityUser>();
            var password = "@Test1234";

            // User
            modelBuilder.Entity<User>().HasData(
                
                    new User
                    {
                        Id= uid_1,
                        Email="user1@superadmin.com",               
                        UserName="shaheen",
                        PasswordHash=hasher.HashPassword(null,password)
                              
                    },
                    new User
                    {
                        Id = uid_2,
                        Email = "user2@admin.com",
                        UserName = "alex99",
                        PasswordHash = hasher.HashPassword(null, password)

                    },
                    new User
                    {
                        Id = uid_3,
                        Email = "user3@employee.com",
                        UserName = "max99",
                        PasswordHash = hasher.HashPassword(null, password)

                    },
                    new User
                    {
                        Id = uid_4,
                        Email = "user4@employer.com",
                        UserName = "mario99",
                        PasswordHash = hasher.HashPassword(null, password)

                    },
                    new User
                    {
                        Id = uid_5,
                        Email = "user5@employer.com",
                        UserName = "mark99",
                        PasswordHash = hasher.HashPassword(null, password)

                    },
                    new User
                    {
                        Id = uid_6,
                        Email = "user6@employee.com",
                        UserName = "antonio99",
                        PasswordHash = hasher.HashPassword(null, password)

                    },
                    new User
                    {
                        Id = uid_7,
                        Email = "user7@employee.com",
                        UserName = "rio99",
                        PasswordHash = hasher.HashPassword(null, password)

                    },
                    new User
                    {
                        Id = uid_8,
                        Email = "user8@employee.com",
                        UserName = "rinia99",
                        PasswordHash = hasher.HashPassword(null, password)

                    }

                );
            
            // Role
            modelBuilder.Entity<Role>().HasData(
                 new Role
                 {
                      Id=roleId_1,
                      Name="SuperAdmin"
                 },
                 new Role
                 {
                     Id = roleId_2,
                     Name = "Admin"
                 },
                 new Role
                 {
                     Id = roleId_3,
                     Name = "Employee"
                 },
                 new Role
                 {
                     Id = roleId_4,
                     Name = "Employer"
                 }
             );

            // UserRoles
            modelBuilder.Entity<UserRoles>().HasData(
                 new UserRoles
                 {
                     UserId = uid_1,
                     RoleId = roleId_1
                 },
                 new UserRoles
                 {
                     UserId = uid_2,
                     RoleId = roleId_2
                 },
                 new UserRoles
                 {
                     UserId = uid_3,
                     RoleId = roleId_3
                 },
                 new UserRoles
                 {
                     UserId = uid_4,
                     RoleId = roleId_4
                 }
                 ,
                 new UserRoles
                 {
                     UserId = uid_5,
                     RoleId = roleId_4
                 }
                 ,
                 new UserRoles
                 {
                     UserId = uid_6,
                     RoleId = roleId_3
                 }
                 ,
                 new UserRoles
                 {
                     UserId = uid_7,
                     RoleId = roleId_3
                 }
                 ,
                 new UserRoles
                 {
                     UserId = uid_8,
                     RoleId = roleId_3
                 }
             );

            // District
            modelBuilder.Entity<District>().HasData(
                    new District
                    {
                         Id=1,
                         DistrictName="Dhaka"
                    },
                    new District
                    {
                        Id = 2,
                        DistrictName = "Gazipur"
                    },
                    new District
                    {
                        Id = 3,
                        DistrictName = "Manikganj"
                    },
                    new District
                    {
                        Id = 4,
                        DistrictName = "Munshiganj"
                    }
                );
            // PoliceStation
            modelBuilder.Entity<PoliceStation>().HasData(
                    new PoliceStation
                    {
                         Id=1,
                         Name="Pallabi",
                         DistrictId=1
                    }
                );
            // Business Category
            modelBuilder.Entity<BusinessCategory>().HasData(
                  new BusinessCategory
                  {
                       Id=1,
                        Name = "IT & Telecommunication"
                  },
                  new BusinessCategory
                  {
                      Id = 2,
                      Name = " Engineer/Architects"
                  },
                  new BusinessCategory
                  {
                      Id = 3,
                      Name = "HR/Org. Development"
                  }
               );

            // Admin User
            modelBuilder.Entity<AdminUser>().HasData(
                    new AdminUser
                    {
                       Id=1,
                       FirstName="Shaheen",
                       LastName="Hossain",
                       Designation="Office Executive",
                       Date=DateTime.Today,
                       UserId=uid_2
                    }
                );

            // Job Provider

            modelBuilder.Entity<JobProviderUser>().HasData(
                    new JobProviderUser
                    {
                          Id=1,
                          BusinessCategoryId=1,
                          BusinessDescription= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          CompanyName="DotNet IT Solution Ltd.",
                          ContactPersonName="Antonio",
                          ContactPersonEmail="antonio@employer.com",
                          ContactPersonPhoneNo="01911111111",
                          Address= " 55/B, Noakhali Tower,Purana Paltan, Dhaka, Bangladesh 1000",
                          PoliceStationId=1,
                          TradeLicenseNo="T123456789",
                          UserId=uid_4,
                          WebsiteUrl="www.domain.com"
                    }
                    ,
                     new JobProviderUser
                     {
                         Id = 2,
                         BusinessCategoryId = 2,
                         BusinessDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                         CompanyName = "DotNet IT Solution Ltd.",
                         ContactPersonName = "Antonio",
                         ContactPersonEmail = "antonio@employer.com",
                         ContactPersonPhoneNo = "01911111111",
                         Address = " 55/B, Noakhali Tower,Purana Paltan, Dhaka, Bangladesh 1000",
                         PoliceStationId = 1,
                         TradeLicenseNo = "T123456789",
                         UserId = uid_5,
                         WebsiteUrl = "www.domain.com"
                     }
                );

            // Job Seeker

            modelBuilder.Entity<JobSeekerUser>().HasData(
                new JobSeekerUser
                {
                    Id=1,
                     UserId=uid_3,
                     FirstName="Rahim",
                     LastName="Mia",
                     FathersName="Md Rahman",
                     MothersName="Rahima Begum",
                     DateOfBirth= DateTime.Parse("11/10/1990"),
                     Gender=0,
                     Religion=0,
                     MaritalStatus=0,
                     Nationality=0,
                     NidNo="199011112233445566",
                     MobileNo="01912701613",
                     present_PoliceStationId=1,
                     permanent_PoliceStationId=1,
                      PresentAddress="Dhaka",
                      PermanentAddress="Dhaka"
                      
                },
                new JobSeekerUser
                {
                    Id = 2,
                    UserId = uid_6,
                    FirstName = "Rahim",
                    LastName = "Mia",
                    FathersName = "Md Rahman",
                    MothersName = "Rahima Begum",
                    DateOfBirth = DateTime.Parse("11/10/1990"),
                    Gender = 0,
                    Religion = 0,
                    MaritalStatus = 0,
                    Nationality = 0,
                    NidNo = "199011112233445566",
                    MobileNo = "01912701613",
                    present_PoliceStationId = 1,
                    permanent_PoliceStationId = 1,
                    PresentAddress = "Dhaka",
                    PermanentAddress = "Dhaka"

                },
                new JobSeekerUser
                {
                    Id = 3,
                    UserId = uid_7,
                    FirstName = "Rahim",
                    LastName = "Mia",
                    FathersName = "Md Rahman",
                    MothersName = "Rahima Begum",
                    DateOfBirth = DateTime.Parse("11/10/1990"),
                    Gender = 0,
                    Religion = 0,
                    MaritalStatus = 0,
                    Nationality = 0,
                    NidNo = "199011112233445566",
                    MobileNo = "01912701613",
                    present_PoliceStationId = 1,
                    permanent_PoliceStationId = 1,
                    PresentAddress = "Dhaka",
                    PermanentAddress = "Dhaka"

                },
                new JobSeekerUser
                {
                    Id = 4,
                    UserId = uid_8,
                    FirstName = "Rahim",
                    LastName = "Mia",
                    FathersName = "Md Rahman",
                    MothersName = "Rahima Begum",
                    DateOfBirth = DateTime.Parse("11/10/1990"),
                    Gender = 0,
                    Religion = 0,
                    MaritalStatus = 0,
                    Nationality = 0,
                    NidNo = "199011112233445566",
                    MobileNo = "01912701613",
                    present_PoliceStationId = 1,
                    permanent_PoliceStationId = 1,
                    PresentAddress = "Dhaka",
                    PermanentAddress = "Dhaka"

                }
            );

            // Packages
            modelBuilder.Entity<Packages>().HasData(
                    new Packages
                    {
                         Id=1,
                         Name="Basic Listing",
                         Price=500,
                         Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry."           
                    },
                     new Packages
                     {
                         Id = 2,
                         Name = "Standard Listing",
                         Price = 1000,
                         Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                     },
                      new Packages
                      {
                          Id = 3,
                          Name = "Premium Listing",
                          Price = 1500,
                          Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                      }

                );


            // Result
            modelBuilder.Entity<ResultType>().HasData(
                new ResultType
                {
                    Id=1,
                     Title="First Division/Class"
                },
                new ResultType
                {
                    Id = 2,
                    Title = "Second Division/Class"
                },
                new ResultType
                {
                    Id = 3,
                    Title = "Third Division/Class"
                },
                new ResultType
                {
                    Id = 4,
                    Title = "Grade"
                },
                new ResultType
                {
                    Id = 5,
                    Title = "Appeared"
                }
               );

            // Education Level
            modelBuilder.Entity<EducationLevel>().HasData(
                    new EducationLevel
                    {
                         Id=1,
                          Title="PSC/5 PASS"
                    },
                    new EducationLevel
                    {
                         Id=2,
                          Title="JSC/JDC/8 PASS"
                    },
                    new EducationLevel
                    {
                         Id=3,
                          Title="SECONDARY"
                    },
                    new EducationLevel
                    {
                         Id=4,
                          Title="HIGHER SECONDARY"
                    },
                    new EducationLevel
                    {
                         Id=5,
                          Title="DIPLOMA"
                    },
                    new EducationLevel
                    {
                         Id=6,
                          Title="BACHELOR/HONORS"
                    },
                    new EducationLevel
                    {
                         Id=7,
                          Title="MASTERS"
                    },
                    new EducationLevel
                    {
                         Id=8,
                          Title="PhD (Doctor of Philosophy)"
                    }


                );

            // Degree Info
            modelBuilder.Entity<DegreeInfo>().HasData(
                    new DegreeInfo
                    {
                         Id=1,
                          Name="Bachelor of Science (BSc)",
                           educationLevelId=6
                    },
                     new DegreeInfo
                     {
                         Id = 2,
                         Name = "Bachelor of Art (BA)",
                         educationLevelId = 6
                     },
                      new DegreeInfo
                      {
                          Id = 3,
                          Name = "Bachelor of Business Administration (BBA)",
                          educationLevelId = 6
                      }
                );

            //  Academic Information
            modelBuilder.Entity<AcademicInformation>().HasData(
                    new AcademicInformation
                    {
                         Id=1,
                         DegreeId=1,
                         UserId=uid_3,
                         MajorSub="Physics",
                         InstituteName="DU",
                         ResultTypeId=4,
                         MarkScale=4,
                         ObtainMark=Convert.ToDecimal(3.1),
                         PassingYear="2018",
                         Duration="4"
                    },
                     new AcademicInformation
                     {
                         Id = 2,
                         DegreeId = 1,
                         UserId = uid_6,
                         MajorSub = "Physics",
                         InstituteName = "DU",
                         ResultTypeId = 4,
                         MarkScale = 4,
                         ObtainMark = Convert.ToDecimal(3.1),
                         PassingYear = "2018",
                         Duration = "4"
                     },
                      new AcademicInformation
                      {
                          Id = 3,
                          DegreeId = 1,
                          UserId = uid_7,
                          MajorSub = "Physics",
                          InstituteName = "DU",
                          ResultTypeId = 4,
                          MarkScale = 4,
                          ObtainMark = Convert.ToDecimal(3.1),
                          PassingYear = "2018",
                          Duration = "4"
                      },
                       new AcademicInformation
                       {
                           Id = 4,
                           DegreeId = 1,
                           UserId = uid_8,
                           MajorSub = "Physics",
                           InstituteName = "DU",
                           ResultTypeId = 4,
                           MarkScale = 4,
                           ObtainMark = Convert.ToDecimal(3.1),
                           PassingYear = "2018",
                           Duration = "4"
                       }
                );

            // Career Information

            modelBuilder.Entity<CareerInformation>().HasData(
                    new CareerInformation
                    {
                         Id=1,
                         UserId=uid_3,
                         businessCategoryId=1,
                         PresentSalary=25000,
                         ExpectedSalary=35000,
                         CareerObjective= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                         CareerSummary= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,"
                    },
                     new CareerInformation
                     {
                         Id = 2,
                         UserId = uid_6,
                         businessCategoryId = 1,
                         PresentSalary = 25000,
                         ExpectedSalary = 35000,
                         CareerObjective = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                         CareerSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,"
                     },
                      new CareerInformation
                      {
                          Id = 3,
                          UserId = uid_7,
                          businessCategoryId = 1,
                          PresentSalary = 25000,
                          ExpectedSalary = 35000,
                          CareerObjective = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                          CareerSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,"
                      },
                       new CareerInformation
                       {
                           Id = 4,
                           UserId = uid_8,
                           businessCategoryId = 1,
                           PresentSalary = 25000,
                           ExpectedSalary = 35000,
                           CareerObjective = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                           CareerSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,"
                       }
                );

            // Employment History

            modelBuilder.Entity<EmploymentHistory>().HasData(
                    new EmploymentHistory
                    {
                        Id=1,
                         UserId=uid_3,
                         CompanyName="ABC Ltd.",
                         CompanyAddress="Mirpur, Dhaka",
                         Designation="Office Executive",
                         Department="Product",
                         Responsibilities= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                         businessCategoryId=1,
                         JobstartDate=DateTime.Parse("01/01/2019"),
                         JobEndDate=DateTime.Parse("12/31/2019")
                    },
                    new EmploymentHistory
                    {
                        Id = 2,
                        UserId = uid_6,
                        CompanyName = "ABC Ltd.",
                        CompanyAddress = "Mirpur, Dhaka",
                        Designation = "Office Executive",
                        Department = "Product",
                        Responsibilities = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        businessCategoryId = 1,
                        JobstartDate = DateTime.Parse("01/01/2019"),
                        JobEndDate = DateTime.Parse("12/31/2019")
                    },
                    new EmploymentHistory
                    {
                        Id = 3,
                        UserId = uid_7,
                        CompanyName = "ABC Ltd.",
                        CompanyAddress = "Mirpur, Dhaka",
                        Designation = "Office Executive",
                        Department = "Product",
                        Responsibilities = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        businessCategoryId = 1,
                        JobstartDate = DateTime.Parse("01/01/2019"),
                        JobEndDate = DateTime.Parse("12/31/2019")
                    },
                    new EmploymentHistory
                    {
                        Id = 4,
                        UserId = uid_8,
                        CompanyName = "ABC Ltd.",
                        CompanyAddress = "Mirpur, Dhaka",
                        Designation = "Office Executive",
                        Department = "Product",
                        Responsibilities = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        businessCategoryId = 1,
                        JobstartDate = DateTime.Parse("01/01/2019"),
                        JobEndDate = DateTime.Parse("12/31/2019")
                    }
                );

            // Job Post

            modelBuilder.Entity<JobPost>().HasData(
                    new JobPost
                    {
                        Id=1,
                        userId=uid_4,
                        JobTitle="ASP.NET Web Developer Needed",
                        Designation="Sr. Developer",
                        NoOfVacancies=10,
                        CircularStartDate=DateTime.Today,
                        CircularExpiredDate=DateTime.Today.AddDays(30),
                        BusinessCategoryId=1,
                        JobResponsibilities= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        JobLocation="Mirpur DOHS",
                        Salary= "Negotiable",
                        AdditionalInformation= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        Otherbenefits= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        MinimumEducationLevelId=1,
                        Experience="5 Years",
                        gender=Gender.Both,
                        MaxAge=30,
                        PackageId=1,
                        PostStatus= JobPostStatus.Published
                    },
                     new JobPost
                     {
                         Id = 2,
                         userId = uid_5,
                         JobTitle = "ASP.NET Web Developer Needed",
                         Designation = "Sr. Developer",
                         NoOfVacancies = 10,
                         CircularStartDate = DateTime.Today,
                         CircularExpiredDate = DateTime.Today.AddDays(30),
                         BusinessCategoryId = 1,
                         JobResponsibilities = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                         JobLocation = "Mirpur DOHS",
                         Salary = "Negotiable",
                         AdditionalInformation = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                         Otherbenefits = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                         MinimumEducationLevelId = 1,
                         Experience = "5 Years",
                         gender = Gender.Both,
                         MaxAge = 30,
                         PackageId = 1,
                         PostStatus = JobPostStatus.Draft
                     }
                );

            // Invoice
            modelBuilder.Entity<Invoice>().HasData(
                    new Invoice
                    {
                         Id=1,
                         JobPostId=1,
                         PackagesId=1,
                         PaymentStatus=true,
                         Quantity=1,
                         TotalAmount=500,
                         TransactionId="TX5412451XDAE49SFW",
                         UserId=uid_4,
                          UnitPrice=500
                            
                            
                         
                          
                    }
                    ,
                     new Invoice
                     {
                         Id = 2,
                         JobPostId = 2,
                         PackagesId = 1,
                         PaymentStatus = true,
                         Quantity = 1,
                         TotalAmount = 500,
                         TransactionId = "TX5412451XDAESS49SFW",
                         UserId = uid_5,
                         UnitPrice=500
                     }
                );

        


            // Moderator
            modelBuilder.Entity<PostModerator>().HasData(
                    new PostModerator
                    {
                         Id=1,
                         UserId=uid_4,
                         jobPostId=1,
                         Status=PostStatus.Active,
                         Date=DateTime.Today
                         
                    },
                     new PostModerator
                     {
                         Id = 2,
                         UserId = uid_5,
                         jobPostId = 2,
                         Status = PostStatus.Active,
                         Date = DateTime.Today

                     }
                );

            // Apply Job
            modelBuilder.Entity<ApplyJob>().HasData(
                    new ApplyJob
                    {
                         Id=1,
                         AppliedDate=DateTime.Today.AddDays(2),
                         ExpectedSalary=25000,
                         JobCircularId=1,
                         UserId=uid_3
                    }
                );

            // Invitation
            modelBuilder.Entity<InterviewInvitation>().HasData(
                    new InterviewInvitation
                    {
                        Id=1,
                        AppliedJobId=1,
                        InvitationDate=DateTime.Today.AddDays(3),
                        MassageSubject="Interview Invitation",
                        InvitationMassage= "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters"
                    }
                );
        }

    }
}
