using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class cls_SanPhamDichVu_entity :object
    {
        private int _IDSP;
        private int _MAPB;
        private string _TENDV;
        private string _MOTA;

        public int IDSP
        {
            get { return _IDSP; }

            set { _IDSP = value; }
        }

        public int MAPB
        {
            get { return _MAPB; }
            set { _MAPB = value; }
        }

        public string TENDV
        {
            get { return _TENDV; }
            set { _TENDV = value; }
        }

        public string MOTA
        {
            get { return _MOTA; }
            set { _MOTA = value; }
        }

        public cls_SanPhamDichVu_entity()
        {
            _IDSP = 0;
            _MAPB = 0;
            _TENDV = string.Empty;
            _MOTA = string.Empty;
        }
    }
}