using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using App.Models;
using App.Data;

namespace App.Services
{
    public class TeacherService
    {
        private readonly DataContext _db;
        // private List<TeachersInfo> _teacher = new List<TeachersInfo>();

        public TeacherService(ILogger<TeacherService> logger, DataContext db)
        {
            _db = db;
        }

        public List<TeachersInfo> GetTeachers()
        {
            return _db.TeachersInfos.ToList();
        }

        public TeachersInfo GetTeacherById(long id)
        {
            return _db.TeachersInfos.FirstOrDefault(t => t.Id == id);
        }

        public void AddTeacher(TeachersInfo teacher)
        {
            _db.Add(teacher);
            _db.SaveChanges();
        }

        public void UpdateTeacher(TeachersInfo teacher)
        {
            _db.Update(teacher);
            _db.SaveChanges();
        }

        public void DeleteTeacher(TeachersInfo teacher) 
        {
            _db.Remove(teacher);
            _db.SaveChanges();
        }
    }
}
