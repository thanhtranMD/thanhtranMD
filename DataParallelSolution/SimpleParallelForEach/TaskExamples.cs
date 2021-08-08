using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    public class TaskExamples
    {
        public static void Example1()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming

            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
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
    }

    public class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }
}
