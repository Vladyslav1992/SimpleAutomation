namespace SimpleAutomationCommon.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class TaskManager
    {
        private static TaskFactory TaskFactory { get; } = new TaskFactory();

        private static Dictionary<string, Task> Tasks { get; } = new Dictionary<string, Task>();

        public static void Run(string id, Action action)
        {
            if (Tasks.Keys.Contains(id))
                WaitForComplete(id);
            Tasks.Add(id, TaskFactory.StartNew(action));
            Console.WriteLine($"Task {id} is started at {DateTime.UtcNow:G}");
        }

        public static void WaitForComplete(string id)
        {
            if (Tasks.Keys.Contains(id))
            {
                try
                {
                    Tasks[id].Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Task {id} was not completed with message: {ex.Message}");
                    throw;
                }
                finally
                {
                    Tasks[id].Dispose();
                    Tasks.Remove(id);
                }
                Console.WriteLine($"Task {id} is completed at {DateTime.UtcNow:G}");
            }
            else
                Console.WriteLine($"There is no such Task {id} or it is already complete");
        }
    }
}
