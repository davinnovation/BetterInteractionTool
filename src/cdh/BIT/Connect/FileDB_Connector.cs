using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Shortcut;
using BIT_Functions;
using Leap;

namespace BIT.Connect
{
    public class FileDB_Connector
    {
        Windows_function windows_function;

        //keyboard
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        Hotkey []hotkeys;
        // Leap Motion
        Connect_Leapmotion leapmotion_listener = new Connect_Leapmotion();
        Controller controller = new Controller();

        public FileDB_Connector()
        {
            //keyboard
            hotkeys = new Hotkey[9];
            hotkeys[0] = Properties.Settings.Default.Key_0;
            hotkeys[1] = Properties.Settings.Default.Key_1;
            hotkeys[2] = Properties.Settings.Default.Key_2;
            hotkeys[3] = Properties.Settings.Default.Key_3;
            hotkeys[4] = Properties.Settings.Default.Key_4;
            hotkeys[5] = Properties.Settings.Default.Key_5;
            hotkeys[6] = Properties.Settings.Default.Key_6;
            hotkeys[7] = Properties.Settings.Default.Key_7;
            hotkeys[8] = Properties.Settings.Default.Key_8;

            //Leap motion
            controller.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES); // Leap Background
            
            //Myo

            //windows function
            windows_function = new Windows_function();
        }

        public static int Key_add_to_file(int Dev, int Ges, int Fun, string datapath)
        {
            string path = datapath; //get datapath
            string d = Dev.ToString();
            string g = Ges.ToString();
            string f = Fun.ToString();
            string dgf = d + "\t" + g + "\t" + f;//convert integers to string
            Console.WriteLine(dgf);
            Console.WriteLine(path);
            string item;
            bool findflag = false;

            StreamReader file = new StreamReader(path);
            while ((item = file.ReadLine()) != null)//read until EOF
            {
                Console.WriteLine("NOERROR\n");
                if (item.Contains(dgf))
                {
                    findflag = true;
                }
            }
            file.Close();
            if (File.Exists(path) && !findflag)//If There is no line that matches dgf
            {
                string appendText = dgf + Environment.NewLine;
                File.AppendAllText(path, appendText);//Append at end of the file

            }
            return 0;
        }

        static int Key_delete_from_file(int Dev, int Ges, int Fun, string datapath)
        {
            string path = datapath;
            string d = Dev.ToString();
            string g = Ges.ToString();
            string f = Fun.ToString();
            string dgf = d + "\t" + g + "\t" + f;
            string oldtext;
            string newtext = "";//Inital newtext is null.


            StreamReader reader = File.OpenText(path);
            while ((oldtext = reader.ReadLine()) != null)
            {
                if (!oldtext.Contains(dgf))
                {
                    newtext += oldtext + Environment.NewLine;//Add all line in the file except dgf to 'newtext'.
                }
            }
            reader.Close();
            File.WriteAllText(path, newtext);//Overwrite the file with newtext
            return 0;
        }
        
        public void Connect_DB_Func()
        {
            //delete binding
            for (int i = 0; i < hotkeys.Length; i++)
                if(_hotkeyBinder.IsHotkeyAlreadyBound(hotkeys[i]))
                _hotkeyBinder.Unbind(hotkeys[i]);

            for (int i = 0; i < leapmotion_listener.gesture_connnect.Length; i++ )
                leapmotion_listener.gesture_connnect[i] = -1; ;

            controller.AddListener(leapmotion_listener);

            //new binding
            StreamReader file = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BIT_data.txt");
            while (!file.EndOfStream)
            {
                string currentLine = file.ReadLine();
                string[] taps = currentLine.Split('\t');
                int device = Convert.ToInt16(taps[0]);
                int ges = Convert.ToInt16(taps[1]);
                int fun = Convert.ToInt16(taps[2]);
                // 0 : Keyboard
                // 1 : Mouse
                // 2 : LeapMotion
                // 3 : Myo
                
                if (device == 0) // Keyboard
                {
                    switch (fun)
                    {
                        case 0:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Call_Windows);break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                    }
                }
                else if (device == 1) // Mouse
                {
                    
                }
                else if (device == 2) // LeapMotion
                {
                    leapmotion_listener.gesture_connnect[ges] = fun;
                }
                else if (device == 3) // Myo
                {
                }
                else
                {
                    Console.WriteLine("Error Reading DB");
                }
            }
            file.Close();
        }
    }
}
