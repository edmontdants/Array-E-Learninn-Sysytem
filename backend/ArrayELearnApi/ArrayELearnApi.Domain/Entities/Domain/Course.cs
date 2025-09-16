using ArrayELearnApi.Domain.Entities.Base;

namespace ArrayELearnApi.Domain.Entities.Domain
{
    public class Course : EntityBase
    {
        public string Title { get; set; }
        public string Code { get; set; } // e.g., Pro#005, CS101, MATH202
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public decimal Fee { get; set; }
        public string Level { get; set; } // e.g., Beginner, Intermediate, Advanced
        public string Duration { get; set; } // e.g., 3 months, 6 weeks, etc.
        public string Prerequisites { get; set; } // e.g., Basic knowledge of programming
        public string TargetAudience { get; set; } // e.g., Beginners, Professionals, etc.
        public string Syllabus { get; set; } // e.g., Course topics and structure
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public int EnrolledStudentsCount { get; set; } = 0;
        public int CurrentEnrollment { get; set; }
        public int MaxStudents { get; set; } = 100; // Default maximum students
        public int RatingCount { get; set; } = 0; // Number of ratings received
        public double AverageRating { get; set; } = 0.0; // Average rating out of 5
        public string CourseUrl { get; set; } // URL for the course page
        public bool IsActive { get; set; } = true;

        // Foreign keys
        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }

        public int LanguageID { get; set; } // e.g., English, Spanish, French
        public virtual Language Language { get; set; }

        // Nav props
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<CourseTag> CourseTags { get; set; }
    }
}
