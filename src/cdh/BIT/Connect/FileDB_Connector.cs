using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

using Shortcut;
using BIT_Functions;
using Leap;
using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Poses;
using MyoSharp.Exceptions;

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
            controller.AddListener(leapmotion_listener);

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
            
            // Keyboard
            for (int i = 0; i < hotkeys.Length; i++)
                if(_hotkeyBinder.IsHotkeyAlreadyBound(hotkeys[i]))
                _hotkeyBinder.Unbind(hotkeys[i]);

            // LeapMotion
            for (int i = 0; i < Connect_Leapmotion.gesture_connnect.Length; i++ )
                Connect_Leapmotion.gesture_connnect[i] = -1;

            // Myo
            for (int i = 0; i < Connect_Myo.gesture_connnect.Length; i++)
                Connect_Myo.gesture_connnect[i] = -1;

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
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Copy_the_selected_item);break;
                        case 1:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Cut_the_selected_item); break;
                        case 2:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Paste_the_selected_item); break;
                        case 3:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Switch_open_apps); break;
                        case 4:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Close_the_active_app); break;
                        case 5:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Open_search_charm); break;
                        case 6:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Switch_open_apps); break;
                        case 7:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_Delete_the_selected_item); break;
                        case 8:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_LeftArrow); break;
                        case 9:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_RightArrow); break;
                        case 10:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_UpArrow); break;
                        case 11:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_DownArrow); break;
                        case 12:
                            Console.WriteLine("ConnectWINDOWS");_hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Call_Windows); break;
                        case 13:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_ESC); break;
                        case 14:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.Keyboard_space); break;
                        case 15:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.MouseClick_left); break;
                        case 16:
                            _hotkeyBinder.Bind(hotkeys[ges]).To(windows_function.MouseClick_right); break;
                    }
                }
                else if (device == 1) // Mouse
                {
                    
                }
                else if (device == 2) // LeapMotion
                {
                    Connect_Leapmotion.gesture_connnect[ges] = fun;
                }
                else if (device == 3) // Myo
                {
                    Connect_Myo.gesture_connnect[ges] = fun;
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
