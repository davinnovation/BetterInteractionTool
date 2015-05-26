using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using BIT.Connect;

namespace BIT.Views
{
    /// <summary>
    /// LeapMotion.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LeapMotion : UserControl
    {
        public int list1;
        public int list2;
        public string database = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BIT_data.txt";

        public LeapMotion()
        {
            InitializeComponent();

            Leap_listBox1.Items.Add("Circle Clock");
            Leap_listBox1.Items.Add("Circle ClockWise");
            Leap_listBox1.Items.Add("Swipe Right");
            Leap_listBox1.Items.Add("Swipe Left");
            Leap_listBox1.Items.Add("Key Taps");
            Leap_listBox1.Items.Add("Screen Taps");

            Leap_listBox2.Items.Add("Copy the selected item");
            Leap_listBox2.Items.Add("Cut the selected item");
            Leap_listBox2.Items.Add("Paste the selected item");
            Leap_listBox2.Items.Add("Switch between open apps");
            Leap_listBox2.Items.Add("Close the active item");
            Leap_listBox2.Items.Add("Open the search charm to search files");
            Leap_listBox2.Items.Add("Switch between open apps (except desktop apps)");
            Leap_listBox2.Items.Add("Delete the selected item and move it to the Recycle Bin");
            Leap_listBox2.Items.Add("Move Left");
            Leap_listBox2.Items.Add("Move Right");
            Leap_listBox2.Items.Add("Move up");
            Leap_listBox2.Items.Add("Move down");
            Leap_listBox2.Items.Add("Windows home");
            Leap_listBox2.Items.Add("Esc");
            Leap_listBox2.Items.Add("Space");
            Leap_listBox2.Items.Add("Mouse click left");
            Leap_listBox2.Items.Add("Mouse click right");

            StreamReader file = new StreamReader(database);
            while (!file.EndOfStream)
            {
                string currentLine = file.ReadLine();
                string[] taps = currentLine.Split('\t'); //
                int device = Convert.ToInt16(taps[0]);
                int ges = Convert.ToInt16(taps[1]);
                int fun = Convert.ToInt16(taps[2]);

                if (device == 2)
                {
                    Leap_listBox3.Items.Add(Leap_listBox1.Items[ges]);
                    Leap_listBox4.Items.Add(Leap_listBox2.Items[fun]);
                }
            }
            file.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Leap_listBox1.SelectedIndex != -1) && (Leap_listBox2.SelectedIndex != -1))
            {
                list1 = Leap_listBox1.SelectedIndex;
                list2 = Leap_listBox2.SelectedIndex;
                FileDB_Connector.Key_add_to_file(2, list1, list2,database); // select indexs of list  -> add text file 
            }

            Leap_listBox3.Items.Add(Leap_listBox1.SelectedItem);
            Leap_listBox4.Items.Add(Leap_listBox2.SelectedItem);
        }
    }
}
