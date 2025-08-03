using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentUrl { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
