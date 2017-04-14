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
        private string _URL_IMAGE;
        private string _FILE_NAME;

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
        public string URL_IMAGE
        {
            get { return _URL_IMAGE; }
            set { _URL_IMAGE = value; }
        }
        public string FILE_NAME
        {
            get { return _FILE_NAME; }
            set { _FILE_NAME = value; }
        }
        public clsUser_entity()
        {
            _ID = 0;
            _USERNAME = string.Empty;
            _PASS = string.Empty;
            _HOTEN = string.Empty;
            _URL_IMAGE = string.Empty;
            _FILE_NAME = string.Empty;
        }
    }
}