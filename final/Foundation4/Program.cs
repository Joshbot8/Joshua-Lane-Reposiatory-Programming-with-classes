using System;

class Program
{
    static void Main(string[] args)
    {


        // Create instances of each activity
        Running running = new Running("Nov 2022", 30, 3.0);
        Biking biking = new Biking("Nov 2022", 45, 15.0);
        Swimming swimming = new Swimming("Nov 2022", 60, 30);

        List<Activity> activityList = new List<Activity>();
        activityList.Add(running);
        activityList.Add(biking);
        activityList.Add(swimming);

        //Loop through list
        // Display activity details
        foreach (var currentActivity in activityList)
        {
            Console.WriteLine(currentActivity.GetSummary());
        }
    }
}

