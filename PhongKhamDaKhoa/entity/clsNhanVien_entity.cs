using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace QLPHONGKHAM.Entities
{
    public class clsNhanVien_entity : object
    {
        private int _MANV;
        private string _HOTEN;
        private DateTime _NGAYSINH;
        private bool _GIOITINH;
        private string _DIENTHOAI;
        private int _MACV;
        private int _MAPB;
        private string _URL_IMAGE;
        private string _FILE_NAME;        
        //********************************
        public int MANV
        {
            get { return _MANV; }

            set { _MANV = value; }
        }
        public string HOTEN
        {
            get { return _HOTEN; }

            set { _HOTEN = value; }
        }

        public DateTime NGAYSINH
        {
            get { return _NGAYSINH; }

            set { _NGAYSINH = value; }
        }
        public bool GIOITINH
        {
            get { return _GIOITINH; }

            set { _GIOITINH = value; }
        }

        public string DIENTHOAI
        {
            get { return _DIENTHOAI; }

            set { _DIENTHOAI = value; }
        }

        public int MACV
        {
            get { return _MACV; }

            set { _MACV = value; }
        }

        public int MAPB
        {
            get { return _MAPB; }

            set { _MAPB = value; }
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



        public clsNhanVien_entity()
        {
            //constructor
            _MANV = 0;
            _HOTEN = string.Empty;
            _NGAYSINH = new DateTime();
            _GIOITINH = true;
            _DIENTHOAI = string.Empty;
            _MACV = 0;
            _MAPB = 0;
            _URL_IMAGE = string.Empty;
            _FILE_NAME = string.Empty;
        }
    }
}