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
    /// Mouse.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Mouse : UserControl
    {
        public int list1;
        public int list2;
        public string database = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BIT_data.txt";

        public Mouse()
        {
            InitializeComponent();

            Mouse_listBox2.Items.Add("Copy the selected item");
            Mouse_listBox2.Items.Add("Cut the selected item");
            Mouse_listBox2.Items.Add("Paste the selected item");
            Mouse_listBox2.Items.Add("Switch between open apps");
            Mouse_listBox2.Items.Add("Close the active item");
            Mouse_listBox2.Items.Add("Open the search charm to search files");
            Mouse_listBox2.Items.Add("Switch between open apps (except desktop apps)");
            Mouse_listBox2.Items.Add("Delete the selected item and move it to the Recycle Bin");
            Mouse_listBox2.Items.Add("Move Left");
            Mouse_listBox2.Items.Add("Move Right");
            Mouse_listBox2.Items.Add("Move up");
            Mouse_listBox2.Items.Add("Move down");
            Mouse_listBox2.Items.Add("Windows home");
            Mouse_listBox2.Items.Add("Esc");
            Mouse_listBox2.Items.Add("Space");
            Mouse_listBox2.Items.Add("Mouse click left");
            Mouse_listBox2.Items.Add("Mouse click right");

            StreamReader file = new StreamReader(database);
            while (!file.EndOfStream)
            {
                string currentLine = file.ReadLine();
                string[] taps = currentLine.Split('\t'); //
                int device = Convert.ToInt16(taps[0]);
                int ges = Convert.ToInt16(taps[1]);
                int fun = Convert.ToInt16(taps[2]);

                if (device == 1)
                {
                    Mouse_listBox3.Items.Add(Mouse_listBox1.Items[ges]);
                    Mouse_listBox4.Items.Add(Mouse_listBox2.Items[fun]);
                }
            }
            file.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Mouse_listBox1.SelectedIndex != -1) && (Mouse_listBox2.SelectedIndex != -1))
            {
                list1 = Mouse_listBox1.SelectedIndex;
                list2 = Mouse_listBox2.SelectedIndex;
                FileDB_Connector.Key_add_to_file(1, list1, list2,database); // select indexs of list  -> add text file 
            }

            Mouse_listBox3.Items.Add(Mouse_listBox1.SelectedItem);
            Mouse_listBox4.Items.Add(Mouse_listBox2.SelectedItem);
        }
    }
}
