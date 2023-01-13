using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using TASK.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TASK.Data.Service
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }


        public void DeleteTask(int id)
        {
            var taskdel =  _context.Tasks.FirstOrDefault(x => x.Id == id);
            if (taskdel != null)
            {
                _context.Tasks.Remove(taskdel);
            }
             _context.SaveChangesAsync();
        }

        public List<Taskk> GetAllTask(string text )
        {
            var listTaskik =  _context.Tasks.Where(x => x.Name.StartsWith(text) || text == null);
            listTaskik = listTaskik.OrderByDescending(x => x.Status);

            return listTaskik.ToList();
        }

        public Taskk GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(n => n.Id == id);

        }

        public Taskk GetTaskByName(string name)
        {
            return _context.Tasks.FirstOrDefault(n => n.Name == name);
        }

        public List<Taskk> GetTaskbyStatus(string status)
        {
            return _context.Tasks.ToList();
        }

        public void UpgradeTask(int id,Taskk taskk)
        {
            EntityEntry entityEntry = _context.Entry(taskk);
            entityEntry.State = EntityState.Modified;
             _context.SaveChangesAsync();
        }

        void   ITaskService.AddtTask(Taskk task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}
