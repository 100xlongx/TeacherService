using System.Collections.Generic;

namespace App.Models
{
    public class ClassInfo
    {
        public long Id { get; set; }
        public TeachersInfo teacher { get; set; }
        public DepartmentInfo department { get; set; }
    }
}