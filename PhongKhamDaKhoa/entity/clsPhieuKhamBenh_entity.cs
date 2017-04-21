using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsPhieuKhamBenh_entity:object
    {
        private int _MAPHIEU;
        private int _MABN;
        private DateTime _NGAYKHAM;
        private string _LYDO;
        private int _MANV;      

        public int MAPHIEU
        {
            get { return _MAPHIEU; }
            set { _MAPHIEU = value; }
        }

        public int MABN
        {
            get { return _MABN; }
            set { _MABN = value; }
        }

        public DateTime NGAYKHAM
        {
            get { return _NGAYKHAM; }
            set { _NGAYKHAM = value; }
        }

        public string LYDO
        {
            get { return _LYDO; }
            set { _LYDO = value; }
        }
        public int MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }
        
        public clsPhieuKhamBenh_entity()
        {
            _MAPHIEU = 0;
            _MABN = 0;
            _NGAYKHAM = DateTime.Now;
            _LYDO = string.Empty;
            _MANV = 0;
           
        }
    }
}