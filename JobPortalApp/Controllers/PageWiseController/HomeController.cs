using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models;
using JobPortalApp.Model.db_models.JobProviderAreas;
using JobPortalApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApp.Controllers.PageWiseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly jobdbcontext _context;
        public HomeController(jobdbcontext context)
        {
            _context = context;
        }

        // api/home/CategoryWiseJobPostCount
        // Category wise JobPost Count
        [HttpGet]
        [Route("[action]")]
        public async Task<List<BusinessCategoryCountVM>> CategoryWiseJobPostCount()
        {
            List<BusinessCategoryCountVM> data = await (from c in _context.businessCategories
                                                  join j in _context.jobPosts on c.Id equals j.BusinessCategoryId
                                                  join m in _context.postModerators on j.Id equals m.jobPostId
                                                  join i in _context.invoices on j.Id equals i.JobPostId
                                                  where m.Status == PostStatus.Active 
                                                        && i.PaymentStatus==true 
                                                        && j.PostStatus == JobPostStatus.Published
                                                  group j by new { c.Id, c.Name, j.BusinessCategoryId } into grp
                                                  select new BusinessCategoryCountVM { Id = grp.Key.Id, Name = grp.Key.Name, Count = grp.Count() }
                        ).ToListAsync();

            return  data;
        }


        // api/home/hotjobs
        // hot job which number of vacancies is >= 50
        [HttpGet]
        [Route("[action]")]
        public async Task<List<BusinessCategoryCountVM>> hotjobs()
        {
            List<BusinessCategoryCountVM> data = await (from c in _context.businessCategories
                                                        join j in _context.jobPosts on c.Id equals j.BusinessCategoryId
                                                        join m in _context.postModerators on j.Id equals m.jobPostId
                                                        join i in _context.invoices on j.Id equals i.JobPostId
                                                        where j.NoOfVacancies >= 50 
                                                            && m.Status == PostStatus.Active 
                                                            && i.PaymentStatus == true 
                                                            && j.PostStatus==JobPostStatus.Published
                                                        group j by new {c.Id, c.Name, j.BusinessCategoryId} into grp
                                                        select new BusinessCategoryCountVM { Id= grp.Key.Id, Name= grp.Key.Name, Count=grp.Count()}
                                                        ).ToListAsync();
            return data;
        }


        // api/home/GetByQueryInfo
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<JobPost>>> GetByQueryInfo(string CatId, string HotJobsId)
        {
            if (CatId != null && HotJobsId == "0")
            {
                // Category wise JobPost
                var data = await (from c in _context.businessCategories
                           join j in _context.jobPosts on c.Id equals j.BusinessCategoryId
                           join m in _context.postModerators on j.Id equals m.jobPostId
                           join i in _context.invoices on j.Id equals i.JobPostId
                           where j.BusinessCategoryId == Convert.ToInt32(CatId) 
                              && m.Status == PostStatus.Active 
                              && i.PaymentStatus == true 
                              && j.PostStatus==JobPostStatus.Published
                           select j).ToListAsync();
                return data;
            }
            else if (CatId == "0" &&  HotJobsId !=null)
            {
                // HotJob List
                var data = await (from c in _context.businessCategories
                            join j in _context.jobPosts on c.Id equals j.BusinessCategoryId
                            join m in _context.postModerators on j.Id equals m.jobPostId
                            join i in _context.invoices on j.Id equals i.JobPostId
                            where   j.NoOfVacancies >= 50 
                                &&  m.Status == PostStatus.Active 
                                &&  i.PaymentStatus == true 
                                &&  j.BusinessCategoryId == Convert.ToInt32(HotJobsId) 
                                &&  j.PostStatus==JobPostStatus.Published
                            select j).ToListAsync();
                return data;
            }
            return BadRequest();            
        }
    }
}