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

            Leap_listBox1.Items.Add("Circle");
            Leap_listBox1.Items.Add("Swipe");
            Leap_listBox1.Items.Add("Key Taps");
            Leap_listBox1.Items.Add("Screen Taps");

            Leap_listBox2.Items.Add("Function1");
            Leap_listBox2.Items.Add("Function2");
            Leap_listBox2.Items.Add("Function3");

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
