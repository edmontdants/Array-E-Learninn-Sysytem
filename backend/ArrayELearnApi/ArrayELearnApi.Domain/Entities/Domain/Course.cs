using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstructorId { get; set; }
        public ApplicationUser Instructor { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
