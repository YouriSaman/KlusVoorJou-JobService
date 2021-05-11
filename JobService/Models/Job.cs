using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Job(Guid id, string title, string description, string imageUrl, string zipCode, string city)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            ZipCode = zipCode;
            City = city;
        }

        public Job()
        {

        }
    }
}
