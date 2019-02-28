using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoogleHashCode
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "../../Data/a_example.txt";
            string[] lines =  File.ReadAllLines(path);

            List<Picture> pics = new List<Picture>();
            for(int i = 1; i<lines.Length; i++){
                List<string> line = lines[i].Split(' ').ToList();
                char or = line[0][0];
                line.RemoveAt(0);
                line.RemoveAt(0);
                pics.Add(new Picture(or, line));
            }

            Console.ReadLine();
        }
    }


    class Picture
    {
        char orientation;
        List<string> tags;

        public Picture(char o, List<string> t)
        {
            orientation = o;
            tags = t;
        }
    }
}
