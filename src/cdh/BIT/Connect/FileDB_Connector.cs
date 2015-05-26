using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BIT.Connect
{
    public class FileDB_Connector
    {
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
                    
                    _hotkeyBinder.Bind(Modifiers.Control, Keys.E).To();
                }
                else if (device == 1) // Mouse
                {
                    
                }
                else if (device == 2) // LeapMotion
                {
                    
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
