using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class cls_ThongSoKyThuat_entity:object
    {
        private int _ID;
        private string _TENTHONGSO;
        private int _ID_SP;

        public int ID
        {
            get { return _ID; }

            set { _ID = value; }
        }

        public string TENTHONGSO
        {
            get { return _TENTHONGSO; }
            set { _TENTHONGSO = value; }
        }

        public int ID_SP
        {
            get { return _ID_SP; }
            set { _ID_SP = value; }
        }

        public cls_ThongSoKyThuat_entity()
        {
            _ID_SP = 0;
            _ID = 0;
            _TENTHONGSO = string.Empty;
        }
    }
}