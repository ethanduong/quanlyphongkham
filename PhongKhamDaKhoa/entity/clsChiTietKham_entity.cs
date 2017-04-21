using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsChiTietKham_entity:object
    {
        private long _ID;
        private long _MAPHIEU;
        private int _ID_SP;
        private string _MOTA;
        private string _KETLUAN;
        private DateTime _NGAYKHAM;
        private int _MANV;
        private string _URL_IMAGE;
        private string _FILE_NAME;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public long MAPHIEU
        {
            get { return _MAPHIEU; }
            set { _MAPHIEU = value; }
        }

        public int ID_SP
        {
            get { return _ID_SP; }
            set { _ID_SP = value; }
        }

        public string MOTA
        {
            get { return _MOTA; }
            set { _MOTA = value; }
        }
        public string KETLUAN
        {
            get { return _KETLUAN; }
            set { _KETLUAN = value; }
        }
        public DateTime NGAYKHAM
        {
            get { return _NGAYKHAM; }
            set { _NGAYKHAM = value; }
        }
        public int MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }
        public string URL_IMAGE
        {
            get { return _URL_IMAGE; }
            set { _URL_IMAGE = value; }
        }
        public string FILE_NAME
        {
            get { return _URL_IMAGE; }
            set { _URL_IMAGE = value; }
        }
        public clsChiTietKham_entity()
        {
            _ID = 0;
            _MAPHIEU = 0;
            _ID_SP = 0;
            _MOTA = string.Empty;
            _KETLUAN = string.Empty;
            _NGAYKHAM = DateTime.Now;
            _MANV = 0;
            _URL_IMAGE = string.Empty;
            _FILE_NAME = string.Empty;
        }
    }
}