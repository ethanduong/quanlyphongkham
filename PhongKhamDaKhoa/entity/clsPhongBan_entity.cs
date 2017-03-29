using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsPhongBan_entity
    {
        private int _MAPB;
        private string _TENPB;

        public int MAPB
        {
            get { return _MAPB; }
            set { _MAPB = value; }
        }
        public string TENPHONG
        {
            get { return _TENPB; }
            set { _TENPB = value; }
        }
        public clsPhongBan_entity()
        {
            _MAPB = 0;
            _TENPB = string.Empty;
        }
    }
}