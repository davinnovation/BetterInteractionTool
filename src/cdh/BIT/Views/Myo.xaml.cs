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
    /// Myo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Myo : UserControl
    {
        public int list1;
        public int list2;
        public string database = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BIT_data.txt";

        public Myo()
        {
            InitializeComponent();

            Myo_listBox1.Items.Add("Circle");
            Myo_listBox1.Items.Add("Swipe");
            Myo_listBox1.Items.Add("Key Taps");
            Myo_listBox1.Items.Add("Screen Taps");

            Myo_listBox2.Items.Add("Function1");
            Myo_listBox2.Items.Add("Function2");
            Myo_listBox2.Items.Add("Function3");

            StreamReader file = new StreamReader(database);
            while (!file.EndOfStream)
            {
                string currentLine = file.ReadLine();
                string[] taps = currentLine.Split('\t'); //
                int device = Convert.ToInt16(taps[0]);
                int ges = Convert.ToInt16(taps[1]);
                int fun = Convert.ToInt16(taps[2]);

                if (device == 3)
                {
                    Myo_listBox3.Items.Add(Myo_listBox1.Items[ges]);
                    Myo_listBox4.Items.Add(Myo_listBox2.Items[fun]);
                }
            }
            file.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Myo_listBox1.SelectedIndex != -1) && (Myo_listBox2.SelectedIndex != -1))
            {
                list1 = Myo_listBox1.SelectedIndex;
                list2 = Myo_listBox2.SelectedIndex;
                FileDB_Connector.Key_add_to_file(3, list1, list2,database); // select indexs of list  -> add text file 
            }

            Myo_listBox3.Items.Add(Myo_listBox1.SelectedItem);
            Myo_listBox4.Items.Add(Myo_listBox2.SelectedItem);
        }
    }

}
