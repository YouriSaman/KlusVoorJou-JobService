using System;
using Xunit;
using JobService;
using JobService.Models;

namespace XUnitTestProject
{
    public class JobUnitTest
    {
        [Fact]
        public void JobGuidTest()
        {
            //Arrange
            Job job1 = new Job(Guid.NewGuid(), "Grasmaaien", "Voor en achtertuin grasmaaien",
                "https://www.makita.nl/data/ab/public/tuincentrum/Keuzehulp/plm4631n2_4-takt_grasmaaier-5.jpg",
                "5673PS", "Nuenen");
            Job job2 = new Job(Guid.NewGuid(), "Schoonmaken", "Keuken en badkamer schoonmaken",
                "https://schoonmakenmetmarja.nl/wp-content/uploads/2020/09/Efficient-schoonmaken.jpg", "4814HT",
                "Breda");

            //Act

            //Assert
            Assert.NotEqual(job1.Id, job2.Id);
        }
    }
}
