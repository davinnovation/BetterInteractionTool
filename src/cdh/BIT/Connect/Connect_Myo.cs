using System;

using BIT_Functions;

using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Poses;
using MyoSharp.Exceptions;

namespace BIT.Connect
{
    public class Connect_Myo
    {
        public const int GESTURES = 4;
        
        public static int[] gesture_connnect = new int[GESTURES];

        internal static void UserInputLoop(IHub hub)
        {
            string userInput;
            while (!string.IsNullOrEmpty((userInput = Console.ReadLine())))
            {
                if (userInput.Equals("pose", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var myo in hub.Myos)
                    {
                        Console.WriteLine("Myo {0} in pose {1}.", myo.Handle, myo.Pose);
                    }
                }
                else if (userInput.Equals("arm", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var myo in hub.Myos)
                    {
                        Console.WriteLine("Myo {0} is on {1} arm.", myo.Handle, myo.Arm.ToString().ToLower());
                    }
                }
                else if (userInput.Equals("count", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("There are {0} Myo(s) connected.", hub.Myos.Count);
                }
            }
        }

        public static void Pose_Triggered(object sender, PoseEventArgs e)
        {
            if(e.Pose == Pose.WaveIn)
                new Windows_function() { }.call_function(gesture_connnect[0]);
            else if (e.Pose == Pose.WaveOut)
                new Windows_function() { }.call_function(gesture_connnect[1]);
            else if (e.Pose == Pose.Fist)
                new Windows_function() { }.call_function(gesture_connnect[2]);
            else if (e.Pose == Pose.FingersSpread)
                new Windows_function() { }.call_function(gesture_connnect[3]);
            Console.WriteLine("{0} arm Myo is holding pose {1}!", e.Myo.Arm, e.Pose);
        }
    }
}