namespace TaskRunner;

public class TaskScheduler
{
    public int LeastInterval(char[] tasks, int n)
    {
        if (n == 0) return tasks.Length;
        
        var tasksCount = new Dictionary<char, int>();
        int maxNumberOfTasks = 0, numberOfTasks = 0;
        
        foreach(var task in tasks)
        {
            var number = tasksCount.GetValueOrDefault(task, 0) + 1;
            tasksCount[task] = number;

            if (number > maxNumberOfTasks)
            {
                maxNumberOfTasks = number;
                numberOfTasks = 1;
            }
            else if (number == maxNumberOfTasks)
            {
                numberOfTasks++;
            }
        }

        return Math.Max(tasks.Length, (n + 1) * maxNumberOfTasks - (n + 1 - numberOfTasks));
    }
}