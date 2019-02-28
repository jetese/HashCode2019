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
                pics.Add(new Picture(i, or, line));
            }

            List<Picture> hPics = (from Picture p in pics
                                   where p.orientation == 'H'
                                   select p).ToList();
            List<Picture> vPics = (from Picture p in pics
                                   where p.orientation == 'V'
                                   select p).ToList();

            Console.ReadLine();
        }

        static void GroupVerticals(List<Picture> vPics)
        {
            
        }
    }


    class Picture
    {
        int index;
        public char orientation;
        public List<string> tags;

        public Picture(int index, char o, List<string> t)
        {
            this.index = index;
            orientation = o;
            tags = t;
        }
    }

    class Slide
    {
        char orientation;
        Picture first;
        Picture second;
    }
}
