using System.Collections.Generic;

namespace App.Models
{
    public class DepartmentInfo
    {
        public long Id { get; set; }
        public List<TeachersInfo> teachers { get; set; }
    }
}