using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    //abcđâsdádasdasd
    public class clsUser_entity
    {
        private int _ID;
        private string _USERNAME;
        private string _PASS;
        private string _HOTEN;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }

        public string PASS
        {
            get { return _PASS; }
            set { _PASS = value; }
        }

        public string HOTEN
        {
            get { return _HOTEN; }
            set { _HOTEN = value; }
        }

        public clsUser_entity()
        {
            _ID = 0;
            _USERNAME = string.Empty;
            _PASS = string.Empty;
            _HOTEN = string.Empty;
        }
    }
}