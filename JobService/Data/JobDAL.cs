using JobService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace JobService.Data
{
    public class JobDAL
    {
        private readonly JobDBContext _dbContext;

        private const string connectionstring =
            "server=localhost;port=3306;user=root;password=I5@yvQ9L;database=job_db";
        private readonly MySqlConnection _connection = new MySqlConnection(connectionstring);

        public JobDAL(JobDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Job> GetAllJobs()
        {
            List<Job> jobs = new List<Job>
            {
                new Job(Guid.NewGuid(), "Grasmaaien", "Voor en achtertuin grasmaaien", "https://www.makita.nl/data/ab/public/tuincentrum/Keuzehulp/plm4631n2_4-takt_grasmaaier-5.jpg", "5673PS", "Nuenen"),
                new Job(Guid.NewGuid(), "Schoonmaken", "Keuken en badkamer schoonmaken", "https://schoonmakenmetmarja.nl/wp-content/uploads/2020/09/Efficient-schoonmaken.jpg", "4814HT", "Breda"),
                new Job(Guid.NewGuid(), "Meterkast", "Elektriciteitsdraden leggen in de meterkast", "https://elektricienaanhuis.nl/wp-content/uploads/2017/10/close-up-elektricien.jpg", "5623EK", "Eindhoven"),
                new Job(Guid.NewGuid(), "Oppas", "Oppas gezocht voor dochter en zoon", "https://www.babybytes.nl/assets/images/Blogs/0/05/053f772179da8165a5456c19b364fc5b.jpg", "5282VG", "Boxtel")
            };
            return jobs;
        }

        public async Task<List<string>> GetDatabaseData()
        {
            await _connection.OpenAsync();
            List<string> data = new List<string>();

            using var command = new MySqlCommand("SELECT * FROM job_db.test;", _connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetString(0);
                data.Add(value);
            }

            return data;
        }

        public async Task AddJob(Job job)
        {
            await _dbContext.Jobs.AddAsync(job);
            _dbContext.SaveChanges();
        }
    }
}
