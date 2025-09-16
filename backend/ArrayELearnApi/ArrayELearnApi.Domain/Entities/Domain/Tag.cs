using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Tag : EntityBase
    {
        public string Name { get; set; } // e.g., "Programming", "Web Development"
        public string Description { get; set; } // e.g., "Courses related to programming languages"

        // Navigation property for many-to-many relationship with Course
        public virtual ICollection<CourseTag> CourseTags { get; set; }

        // Override ToString() for better readability
        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }
}
