using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Data;
using JobService.Logic;
using JobService.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobLogic _jobLogic;

        public JobController(JobDBContext dbContext)
        {
            _jobLogic = new JobLogic(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<string> data = await _jobLogic.GetData();

            Console.WriteLine(data);

            IActionResult response = NotFound();
            List<Job> jobs = _jobLogic.GetAllJobs();

            if (jobs != null)
            {
                response = Ok(new { jobs = jobs });
            }

            return response;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(Job job)
        {
            job.Id = new Guid();
            await _jobLogic.AddJob(job);
            return Ok();
        }
    }
}
