using JobService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Data;

namespace JobService.Logic
{
    public class JobLogic
    {
        private readonly JobDAL _jobDal;

        public JobLogic(JobDBContext dbContext)
        {
            _jobDal = new JobDAL(dbContext);
        }

        public List<Job> GetAllJobs()
        {
            return _jobDal.GetAllJobs();
        }

        public async Task<List<string>> GetData()
        {
            return await _jobDal.GetDatabaseData();
        }

        public async Task AddJob(Job job)
        {
            await _jobDal.AddJob(job);
        }
    }
}
