using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsChucVu_entity
    {
        private int _MACV;
        private string _TENCV;

        public int MACV
        {
            get { return _MACV; }
            set { _MACV = value; }
        }
        public string TENCV
        {
            get { return _TENCV; }
            set { _TENCV = value; }
        }
        public clsChucVu_entity()
        {
            _MACV = 0;
            _TENCV = string.Empty;
        }
    }
  
}