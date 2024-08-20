using System.Collections.Generic;

public class digiAssessmentTimerLoop
{
    public int totalTime;
    public static void Main(string[] args)
    {
        digiAssessmentTimerLoop timerLoop = new digiAssessmentTimerLoop(0, 10);// creates a new instance of the digiAssessmentTimerLoop constructor
        System.Console.WriteLine(" ");
        timerLoop.Countdown();// calls the countdown for loop on the newly created timer instance
    }

    public digiAssessmentTimerLoop(int minutes, int seconds)
    {
        totalTime = minutes * 60 + seconds; // converts the minutes and second format to seconds only format
        System.Console.WriteLine($"a new timer of {totalTime} seconds has been initiated");
    }

    public void Countdown()
    {
        for (int i = totalTime; i >= 1; i--) // loops through the total time variable and prints all numbers below it till 1
        {
            System.Console.WriteLine(i);
        }
        System.Console.WriteLine("game has ended. now the scene should change to the lose screen in unity");
    }
}