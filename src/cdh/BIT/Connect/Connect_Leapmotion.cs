using System;
using System.Threading;
using BIT_Functions;
using Leap;

namespace BIT.Connect
{
    public class Connect_Leapmotion : Listener
    {
        public const int GESTURES = 6;
        /*
         *  0 - clockwise
         *  1 - countercolckwise
         *  2 - swipe right 
         *  3 - swipe left
         *  4 - key tap
         *  5 - screen tap
         */

        private Object thisLock = new Object();

        public int []gesture_connnect = new int[GESTURES];

        private void SafeWriteLine(String line)
        {
            lock (thisLock)
            {
                Console.WriteLine(line);
            }
        }

        public override void OnInit(Controller controller)
        {
            SafeWriteLine("LeapMotion Initialized");
        }

        public override void OnConnect(Controller controller)
        {
            SafeWriteLine("LeapMotion Connected");
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller)
        {
            //Note: not dispatched when running in a debugger.
            SafeWriteLine("LeapMotion Disconnected");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("LeapMotion Exited");
        }

        public override void OnFrame(Controller controller)
        {
            // Get the most recent frame and report some basic information
            Frame frame = controller.Frame();
            
            // Get gestures
            GestureList gestures = frame.Gestures();
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];

                switch (gesture.Type)
                {
                    case Gesture.GestureType.TYPE_CIRCLE:
                        CircleGesture circle = new CircleGesture(gesture);

                        if (circle.Pointable.Direction.AngleTo(circle.Normal) <= Math.PI / 2)
                        {
                            //Clockwise if angle is less than 90 degrees
                            //clockwiseness = "clockwise";
                            new Windows_function() { }.call_function(gesture_connnect[0]);
                        }
                        else
                        {
                            //clockwiseness = "counterclockwise";
                            new Windows_function() { }.call_function(gesture_connnect[1]);
                        }
                        break;
                    case Gesture.GestureType.TYPE_SWIPE:
                        SwipeGesture swipe = new SwipeGesture(gesture);

                        if (swipe.Direction.x > 0.5)
                            new Windows_function() { }.call_function(gesture_connnect[2]);
                        else
                            new Windows_function() { }.call_function(gesture_connnect[3]);
                        break;
                    case Gesture.GestureType.TYPE_KEY_TAP:
                        KeyTapGesture keytap = new KeyTapGesture(gesture);
                        new Windows_function() { }.call_function(gesture_connnect[4]);
                        break;
                    case Gesture.GestureType.TYPE_SCREEN_TAP:
                        ScreenTapGesture screentap = new ScreenTapGesture(gesture);
                        new Windows_function() { }.call_function(gesture_connnect[5]);
                        break;
                    default:
                        SafeWriteLine("  Unknown gesture type.");
                        break;
                }
            }
        }
    }
}
