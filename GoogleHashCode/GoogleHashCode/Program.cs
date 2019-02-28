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
        static int problemLength;

        static void Main(string[] args)
        {

            string path = "../../Data/a_example.txt";
            string[] lines =  File.ReadAllLines(path);
            problemLength = int.Parse(lines[0]);

            List<Picture> pics = new List<Picture>();
            for(int i = 1; i<lines.Length; i++){
                List<string> line = lines[i].Split(' ').ToList();
                char or = line[0][0];
                line.RemoveAt(0);
                line.RemoveAt(0);
                pics.Add(new Picture(i, or, line));
            }

            //Fotos horizontales
            List<Picture> hPics = (from Picture p in pics
                                   where p.orientation == 'H'
                                   select p).ToList();


            //Fotos verticales
            List<Picture> vPics = (from Picture p in pics
                                   where p.orientation == 'V'
                                   select p).ToList();

            List<Picture> common = pics[0].GetAllCommon(pics);
            pics[0].GetValue(common[0]);

            Console.ReadLine();
        }

        static void GroupVerticals(List<Picture> vPics)
        {
            Dictionary<int, List<int>> commons = new Dictionary<int, List<int>>(problemLength);

            for(int i = 0; i < vPics.Count; ++i)
            {

            }
        }

        static void Mejorar(List<Picture> hPics)
        {
            List<Slide> allSlides = new List<Slide>();

            foreach (Picture p in hPics)
            {
                allSlides.Add(new Slide(0, p));
            }
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

        public List<Picture> GetAllCommon(List<Picture> allPics)
        {

            List<Picture> common = (from Picture p in allPics
                                    where p.tags.Intersect(this.tags).Any()
                                    select p).ToList();
            common.Remove(this);

            return common; ;
        }

        public int GetValue(Picture p2)
        {
            int coincidence = this.tags.Intersect(p2.tags).Count();
            int diff1 = this.tags.Count - coincidence;
            int diff2 = p2.tags.Count - coincidence;

            int ret = coincidence;
            if (diff1 < ret)
            {
                ret = diff1;
            }
            if(diff2 < ret)
            {
                ret = diff2;
            }

            return ret;
        }
    }

    class Slide
    {
        int orientation; //0 Horizontal, 1 Vertical
        Picture first;
        Picture second;

        List<string> tags;

        List<Combo> points = new List<Combo>();

        public Slide ( int orientation, Picture a, Picture b = null)
        {
            first = a;
            second = b;
            tags = new List<string>();
            tags.AddRange(a.tags);
            if (b != null)
            {
                tags.AddRange(b.tags);
            }
        }

        public List<Slide> GetCommon(List<Slide> slides)
        {
            List<Slide> common = (from Slide p in slides
                                    where p.tags.Intersect(this.tags).Any()
                                    select p).ToList();
            common.Remove(this);

            return common; ;
        }

        public int GetPunt(Slide s)
        {
            int coincidence = this.tags.Intersect(s.tags).Count();
            int diff1 = this.tags.Count - coincidence;
            int diff2 = s.tags.Count - coincidence;

            int ret = coincidence;
            if (diff1 < ret)
            {
                ret = diff1;
            }
            if (diff2 < ret)
            {
                ret = diff2;
            }

            return ret;
        }

    }

    class Combo
    {
        int id;
        int score;
    }

    

}
