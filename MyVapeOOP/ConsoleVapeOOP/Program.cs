﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLVape;

namespace ConsoleVapeOOP
{
    public class Program
    {
        // lavet et interface med helle navet bare så jeg har et interface med i min opgave??
        static void Main()
        {
            CLVape.SqlConn.openConnection();
            //SqlConn.openConnection();
            
            Console.ReadKey();
        }
    }
}
