using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    public class TaskExamples : IMenuItem
    {
        public static void Example1()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming

            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    if (data == null)
                        return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                }, new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                      data.Name, data.CreationTime, data.ThreadNum);
            }
        }
        public int Index { get; set; }

        public string Name { get { return "Task examples."; } }

        public void Run()
        {
            //int processor_count = Environment.ProcessorCount;
            int lastID = 15090887;
            int record_per_task = lastID / 4;
            int fromVisitId = 0;
            int toVisitId = 0;
            string[] IDs = new string[4];
            Console.WriteLine($"Last Id:{lastID} - Records per task:{record_per_task}");
            for (int i = 0; i < IDs.Length; i++)
            {
                if (i>0)
                    fromVisitId = toVisitId + 1;

                if (i == IDs.Length - 1)
                {
                    toVisitId = lastID;
                }
                else
                {
                    toVisitId += record_per_task;
                }
                IDs[i] = $"{fromVisitId} - {toVisitId}";
                Console.WriteLine($"{i} - {IDs[i]}");
            }
        }

        public class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }
    }
}
