using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.IO;
using BIT.Connect;


namespace BIT.Views
{
    /// <summary>
    /// Keyboard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Keyboard : UserControl
    {
        public int list1;
        public int list2;

        public string database = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BIT_data.txt";

        public Keyboard()
        {
            InitializeComponent();

            Key_listBox1.Items.Add("Ctrl+F");
            Key_listBox1.Items.Add("Ctrl+C");
            Key_listBox1.Items.Add("Ctrl+V");
            Key_listBox1.Items.Add("Ctrl+B");
            Key_listBox1.Items.Add("Ctrl+N");
            Key_listBox1.Items.Add("Ctrl+H");
            Key_listBox1.Items.Add("Ctrl+T");
            Key_listBox1.Items.Add("Ctrl+G");
            Key_listBox1.Items.Add("Ctrl+V");
            Key_listBox1.Items.Add("Windows+X");
            Key_listBox1.Items.Add("Windows+S");
            Key_listBox1.Items.Add("Windows+M");

            Key_listBox2.Items.Add("Copy the selected item");
            Key_listBox2.Items.Add("Cut the selected item");
            Key_listBox2.Items.Add("Paste the selected item");
            Key_listBox2.Items.Add("Switch between open apps");
            Key_listBox2.Items.Add("Close the active item");
            Key_listBox2.Items.Add("Open the search charm to search files");
            Key_listBox2.Items.Add("Lock screen orientation");
            Key_listBox2.Items.Add("Switch input language");
            Key_listBox2.Items.Add("Switch between open apps");
            Key_listBox2.Items.Add("Delete the selected item");
            Key_listBox2.Items.Add("Open Windows Home");

            int keyborad = 0;
            int gesture = 1;
            int function = 0;

            StreamReader file = new StreamReader(database);
            while (!file.EndOfStream)
            {
                string currentLine = file.ReadLine();
                string[] taps = currentLine.Split('\t'); //
                int device = Convert.ToInt16(taps[0]);
                int ges = Convert.ToInt16(taps[1]);
                int fun = Convert.ToInt16(taps[2]);

                if (device == 0)
                {
                    Key_listBox3.Items.Add(Key_listBox1.Items[ges]);
                    Key_listBox4.Items.Add(Key_listBox2.Items[fun]);
                }
            }
            file.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Key_listBox1.SelectedIndex != -1) && (Key_listBox2.SelectedIndex != -1))
            {
                list1 = Key_listBox1.SelectedIndex;
                list2 = Key_listBox2.SelectedIndex;
                FileDB_Connector.Key_add_to_file(0, list1, list2, database); // select indexs of list  -> add text file 
            }

            Key_listBox3.Items.Add(Key_listBox1.SelectedItem);
            Key_listBox4.Items.Add(Key_listBox2.SelectedItem);
        }
    }
}
