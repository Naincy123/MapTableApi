using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice1.DataContracts
{
    public partial class StudentcourseContract
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual CourseContract CourseName { get; set; }
        public virtual StudentContract StudentName { get; set; }
    }
}