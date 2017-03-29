using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsTTBenhNhan_entity : object
    {
        private int _MABN;
        private string _HOTEN;
        private DateTime _NGAYSINH;
        private string _DIENTHOAI;
        private bool _GIOITINH;
        private string _CHIEUCAO;
        private string _CANNANG;
        private string _TIENSU;
        //********************************
        public int MABN
        {
            get { return _MABN; }

            set { _MABN = value; }
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

        public string DIENTHOAI
        {
            get { return _DIENTHOAI; }

            set { _DIENTHOAI = value; }
        }

        public bool GIOITINH
        {
            get { return _GIOITINH; }

            set { _GIOITINH = value; }
        }

        public string CHIEUCAO
        {
            get { return _CHIEUCAO; }

            set { _CHIEUCAO = value; }
        }

        public string CANNANG
        {
            get { return _CANNANG; }

            set { _CANNANG = value; }
        }

        public string TIENSU
        {
            get { return _TIENSU; }

            set { _TIENSU = value; }
        }


        public clsTTBenhNhan_entity()
        {
            //constructor
            _MABN = 0;
            _HOTEN = string.Empty;
            _NGAYSINH = new DateTime();
            _DIENTHOAI = string.Empty;
            _GIOITINH = true;
            _CHIEUCAO = string.Empty;
            _CANNANG = string.Empty;
            _TIENSU = string.Empty;
        }
    }
    }
}