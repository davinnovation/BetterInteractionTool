/*
 * Program for manipulation of BIT_match.txt
 * Consists two functions
 *      add_to_file
 *          search for the input in file,
 *          and if there is no match appends to the end of the text file
 *          
 *      delete_from_file
 *          search for the input in file,
 *          and if there is a match, overwrites the file w/o the 
 *          line containing the input
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            /*test_function*/
            int Dev = 0, Ges = 1, Fun = 1;
            string datapath="data.txt";
            delete_from_file(Dev, Ges, Fun, datapath);
        }

        static int add_to_file(int Dev, int Ges, int Fun, string datapath)
        {
            string path = datapath; //get datapath

            string d = Dev.ToString();
            string g = Ges.ToString();
            string f = Fun.ToString();
            string dgf =d +"\t"+ g +"\t"+ f;//convert integers to string
            Console.WriteLine(dgf);
            Console.WriteLine(path);
            string item;
            bool findflag=false;

            StreamReader file = new StreamReader(path);
            while((item=file.ReadLine())!=null)//read until EOF
            {
                Console.WriteLine("NOERROR\n");
                if (item.Contains(dgf))
                {
                    findflag = true;
                }
            }
            file.Close();
            if (File.Exists(path)&&!findflag)//If There is no line that matches dgf
            {
                string appendText = dgf + Environment.NewLine;
                File.AppendAllText(path, appendText);//Append at end of the file
              
            }
            return 0;
        }

        static int delete_from_file(int Dev, int Ges, int Fun, string datapath)
        {
            string path = datapath;
            string d = Dev.ToString();
            string g = Ges.ToString();
            string f = Fun.ToString();
            string dgf = d + "\t" + g + "\t" + f;
            string oldtext;
            string newtext="";//Inital newtext is null.


            StreamReader reader = File.OpenText(path);
            while((oldtext=reader.ReadLine())!=null){
                if(!oldtext.Contains(dgf)){
                    Console.WriteLine("This does not Contain\n");
                    newtext+=oldtext+Environment.NewLine;//Add all line in the file except dgf to 'newtext'.
                }
            }
            reader.Close();
            File.WriteAllText(path,newtext);//Overwrite the file with newtext
            return 0;
        }
    }
}
