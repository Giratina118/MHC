using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int i = 1;
            Console.WriteLine(i);

            aaa(ref i);
            Console.WriteLine(i);

            bbb bb = new bbb();
            bb.ccc(ref i);
            Console.WriteLine(i);

            bbb[] b = new bbb[3];
            b[0] = new bbb();
            b[0].ccc(ref i);
            Console.WriteLine(i);
        }

        static void aaa(ref int i)
        {
            i += 5;
        }


    }
    class bbb
    {
        public void ccc(ref int i)
        {
            i += 5;
        }
    }

}
