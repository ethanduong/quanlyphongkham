using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using QLPHONGKHAM;

namespace PhongKhamDaKhoa
{
    public class passgen
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine(Common.HashPassword("123456"));

        }
    }
}