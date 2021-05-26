using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using App.Models;
using App.Data;

namespace App.Services
{
    public class StudentService 
    {
        private readonly ILogger<StudentService> _logger;
        private readonly DataContext _db;
        public StudentService(ILogger<StudentService> logger, DataContext db)
        {
            _logger = logger;
            _db = db;
        }

        public List<StudentsInfo> GetStudents() {
            return _db.StudentsInfo.ToList();
        }

        public StudentsInfo GetStudentById(long id) {
            return _db.StudentsInfo.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(StudentsInfo student) {
            _db.StudentsInfo.Add(student);
            _db.SaveChanges();
        }

        public void UpdateStudent(StudentsInfo student) {
            _db.StudentsInfo.Update(student);
            _db.SaveChanges();
        }

        public void DeleteStudent(StudentsInfo student) {
            _db.Attach(student);
            _db.StudentsInfo.Remove(student);
            _db.SaveChanges();
        }
    }
}