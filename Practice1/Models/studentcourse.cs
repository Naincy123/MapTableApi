//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practice1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class studentcourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    
        public virtual course course { get; set; }
        public virtual student student { get; set; }
    }
}
