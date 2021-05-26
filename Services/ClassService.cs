using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.Data;

namespace App.Services
{
    public class ClassService 
    {
        private readonly DataContext _db;
        public ClassService(DataContext db)
        {
            _db = db;
        }

        public List<ClassInfo> GetClasses() {
            return _db.classInfos.ToList();
        }

        public void addClass(ClassInfo classInfo) {
            _db.classInfos.Add(classInfo);
            _db.SaveChanges();
        }

        public ClassInfo GetClassById(int id) {
            return _db.classInfos.FirstOrDefault(d => d.Id == id);
        }

        public void removeClass(ClassInfo classInfo) {
            _db.Remove(classInfo);
            _db.SaveChanges();
        }

        public void updateClass(ClassInfo classInfo) {
            _db.Update(classInfo);
            _db.SaveChanges();
        }
    }
}