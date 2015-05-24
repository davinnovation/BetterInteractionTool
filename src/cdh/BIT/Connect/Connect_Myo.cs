using System;

using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Exceptions;

namespace BIT.Connect
{
    public class Connect_Myo
    {
        #region Methods
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

        #endregion

        #region Event Handlers
        public static void Myo_OrientationDataAcquired(object sender, OrientationDataEventArgs e)
        {
            const float PI = (float)System.Math.PI;

            // convert the values to a 0-9 scale (for easier digestion/understanding)
            var roll = (int)((e.Roll + PI) / (PI * 2.0f) * 10);
            var pitch = (int)((e.Pitch + PI) / (PI * 2.0f) * 10);
            var yaw = (int)((e.Yaw + PI) / (PI * 2.0f) * 10);

            Console.Clear();
            Console.WriteLine(@"Roll: {0}", roll);
            Console.WriteLine(@"Pitch: {0}", pitch);
            Console.WriteLine(@"Yaw: {0}", yaw);
        }
        #endregion
    }
}