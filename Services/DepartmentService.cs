using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.Data;

namespace App.Services
{
    public class DepartmentService 
    {
        private readonly DataContext _db;
        public DepartmentService(DataContext db)
        {
            _db = db;
        }

        public List<DepartmentInfo> GetDepartments() {
            return _db.DepartmentInfos.ToList();
        }

        public void addDepartment(DepartmentInfo department) {
            _db.DepartmentInfos.Add(department);
            _db.SaveChanges();
        }

        public DepartmentInfo GetDepartmentById(int id) {
            return _db.DepartmentInfos.FirstOrDefault(d => d.Id == id);
        }

        public void removeDepartment(DepartmentInfo department) {
            _db.Remove(department);
            _db.SaveChanges();
        }

        public void updateDepartment(DepartmentInfo department) {
            _db.Update(department);
            _db.SaveChanges();
        }
    }
}