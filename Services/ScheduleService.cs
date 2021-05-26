using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.Data;

namespace App.Services
{
    public class ScheduleService 
    {
        private readonly DataContext _db;
        public ScheduleService(DataContext db)
        {
            _db = db;
        }

        public List<ScheduleInfo> GetSchedules() {
            return _db.scheduleInfos.ToList();
        }

        public void addSchedule(ScheduleInfo schedule) {
            _db.scheduleInfos.Add(schedule);
            _db.SaveChanges();
        }

        public ScheduleInfo GetScheduleById(int id) {
            return _db.scheduleInfos.FirstOrDefault(d => d.Id == id);
        }

        public void removeSchedule(ScheduleInfo schedule) {
            _db.Remove(schedule);
            _db.SaveChanges();
        }

        public void updateSchedule(ScheduleInfo schedule) {
            _db.Update(schedule);
            _db.SaveChanges();
        }
    }
}