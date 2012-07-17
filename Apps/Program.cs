using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Data.Communication.Test;
using UnitTest ;


namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester test = new Tester() ;
            test.TestApp("associations");
            //test.TestApp("names");
        }
    }
}
