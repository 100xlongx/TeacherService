using System.Collections.Generic;

namespace App.Models
{
    public class ScheduleInfo
    {
        public long Id { get; set; }
        public StudentsInfo student { get; set; }
        public List<ClassInfo> classes { get; set; }
    }
}