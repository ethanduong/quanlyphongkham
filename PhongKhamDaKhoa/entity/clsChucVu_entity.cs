using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsChucVu_entity
    {
        private int _MACV;
        private string _TEN;

        public int MACV
        {
            get { return _MACV; }
            set { _MACV = value; }
        }
        public string TEN
        {
            get { return _TEN; }
            set { _TEN = value; }
        }
        public clsChucVu_entity()
        {
            _MACV = 0;
            _TEN = string.Empty;
        }
    }
  
}