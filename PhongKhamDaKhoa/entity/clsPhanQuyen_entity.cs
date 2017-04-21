using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.entity
{
    public class clsPhanQuyen_entity:object
    {
        private int _ID_PQ;
        private int _ID_USER;
        private int _ID_NDPQ;
        private bool _XEM;
        private bool _THEM;
        private bool _SUA;
        private bool _XOA;

        public int ID_PQ
        {
            get { return _ID_PQ; }
            set { _ID_PQ = value; }
        }

        public int ID_USER
        {
            get { return _ID_USER; }
            set { _ID_USER = value; }
        }

        public int ID_NDPQ
        {
            get { return _ID_NDPQ; }
            set { _ID_NDPQ = value; }
        }

        public bool XEM
        {
            get { return _XEM; }
            set { _XEM = value; }
        }
        public bool THEM
        {
            get { return _THEM; }
            set { _THEM = value; }
        }
        public bool SUA
        {
            get { return _SUA; }
            set { _SUA = value; }
        }
        public bool XOA
        {
            get { return _XOA; }
            set { _XOA = value; }
        }
        public clsPhanQuyen_entity()
        {
            _ID_PQ = 0;
            _ID_USER = 0;
            _ID_NDPQ = 0;
            _XEM = false;
            _THEM = false;
            _SUA = false;
            _XOA = false;
        }
    }
}