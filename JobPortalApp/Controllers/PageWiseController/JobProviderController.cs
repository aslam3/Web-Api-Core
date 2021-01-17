using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models;
using JobPortalApp.Model.db_models.JobProviderAreas;
using JobPortalApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApp.Controllers.PageWiseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobProviderController : ControllerBase
    {
        private readonly jobdbcontext _context;
        private readonly UserManager<User> _userManager;
        public JobProviderController(jobdbcontext context, UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        // Save Post and Create Invoice
        // Shaheen
        // api/jobprovider
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostJob(JobPost postData, string postType)
        {
            // ModelState Error
            if (!ModelState.IsValid)
            {
                var error = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var err in state.Value.Errors)
                    {
                        error.Add(err.ToString());
                    }
                }
                return BadRequest(error);
            }
            // Get Login user Id
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    JobPost post = postData;
                    post.userId = Guid.Parse(user); // Convert string to Guid
                    // Save as Draft 
                    if (postType == "draft")
                    {
                        // Enum postStatus 0==Draft
                        post.PostStatus = Enum.Parse<JobPostStatus>("Draft"); // Convert string to Enum

                        if (postData.Id == 0)
                        {
                            // Save First Time
                            await _context.jobPosts.AddAsync(post);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            // IF exist Update
                            _context.Entry<JobPost>(post).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }

                        await transaction.CommitAsync();
                        return Created("", post);
                    }
                    // Save as Published
                    else if (postType == "Published")
                    {
                        // Enum postStatus 1==Published
                        post.PostStatus = JobPostStatus.Published;

                        // Exists or Not
                        var package = await _context.servicePackages.FindAsync(post.PackageId);
                        Invoice checkInvoice = _context.invoices.Where(i => i.JobPostId == post.Id).AsNoTracking().FirstOrDefault();
                        PostModerator checkPostModeretor = _context.postModerators.Where(p => p.jobPostId == post.Id).AsNoTracking().FirstOrDefault();
                        // .......

                        int invoiceId = 0;
                        if (checkInvoice!=null)
                        {
                            invoiceId = checkInvoice.Id;
                        }
                        Invoice invoice = new Invoice
                        {
                            Id=invoiceId,
                            JobPostId = post.Id,
                            PackagesId = package.Id,
                            Quantity = 1,
                            UnitPrice=package.Price,
                            PaymentStatus = false,
                            TotalAmount = package.Price,
                            UserId = Guid.Parse(user),
                            Date=DateTime.Now
                        };

                        PostModerator postModerate = new PostModerator
                        {
                            
                            UserId = Guid.Parse(user),
                            jobPostId=post.Id,
                            Date=DateTime.Now,
                            Status= PostStatus.Active
                        };

                        if (post.Id == 0)
                        {
                            await _context.jobPosts.AddAsync(post);
                            await _context.SaveChangesAsync();
                            invoice.JobPostId = post.Id;
                            postModerate.jobPostId = post.Id;

                            await _context.invoices.AddAsync(invoice);
                            await _context.SaveChangesAsync();
                            // If not exists then create
                            if (checkPostModeretor==null)
                            {
                                await _context.postModerators.AddAsync(postModerate);
                                await _context.SaveChangesAsync();
                            }
                            
                            
                            await transaction.CommitAsync();
                            return Created("", post);
                        }
                        else
                        {
                            _context.Entry<JobPost>(post).State = EntityState.Modified;

                            // If not exists then create
                            if (checkPostModeretor == null)
                            {
                                await _context.postModerators.AddAsync(postModerate);
                                await _context.SaveChangesAsync();
                            }

                            await _context.SaveChangesAsync();                            
                            if (checkInvoice==null)
                            {
                                await _context.invoices.AddAsync(invoice);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {                               
                                _context.Entry<Invoice>(invoice).State = EntityState.Modified;
                            }                            
                            await transaction.CommitAsync();
                            return Ok();
                        }
                    }              
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }

            }
            return BadRequest();
        }

        // api/jobprovider/BuyResume
        [HttpPost("BuyResume")]
        [Authorize]

        public  async Task<ActionResult> BuyResume(BuyResumeVM data)
        {

            

            //Get Login user Id
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var d = _context.invoices.Where(i => i.CvBuyInfoId == data.Id && i.PaymentStatus == false).FirstOrDefault();

            Packages package = await _context.servicePackages.FindAsync(data.PackagesId);
            Invoice checkInvoice = null;
            if (data.Id != 0)
            {
                checkInvoice = _context.invoices.Where(i => i.CvBuyInfoId == data.Id).AsNoTracking().FirstOrDefault();
            }

            int invoiceId = 0;

            if (checkInvoice != null)
            {
                invoiceId = checkInvoice.Id;
            }

            CvBankQuery resume = new CvBankQuery
            {
                Id = data.Id,
                UserId = Guid.Parse(user),
                PackagesId = data.PackagesId,
                BusinessCategoryId = data.BusinessCategoryId,
                Date = DateTime.Now
            };

            Invoice invoice = new Invoice
            {
                Id = invoiceId,
                PackagesId = data.PackagesId,
                CvBuyInfoId = resume.Id,
                Quantity = 1,
                UnitPrice=data.PackagesId,
                TotalAmount = package.Price,
                PaymentStatus = false,
                UserId = Guid.Parse(user),
                Date = DateTime.Now

            };


            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (resume.Id == 0)
                    {
                        await _context.cvBuyInfos.AddAsync(resume);
                        await _context.SaveChangesAsync();
                        invoice.CvBuyInfoId = resume.Id;


                        await _context.invoices.AddAsync(invoice);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        return Created("", resume);
                    }
                    else
                    {
                        _context.Entry(resume).State = EntityState.Modified;
                        _context.Entry(invoice).State = EntityState.Modified;

                        await transaction.CommitAsync();

                        return Created("", resume);
                    }


                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }



        }


    }
}