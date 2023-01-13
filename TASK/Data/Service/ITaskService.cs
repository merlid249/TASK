using TASK.Models;

namespace TASK.Data.Service
{
    public interface ITaskService
    {

        public List<Taskk> GetAllTask(string searching);
        public Taskk GetTaskById(int id);
        public Taskk GetTaskByName(string name);
        public List<Taskk> GetTaskbyStatus(string status);
        public void DeleteTask(int id); 
        public void UpgradeTask(int id, Taskk taskk);
        public void AddtTask( Taskk task);   

    }
}
