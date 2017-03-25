using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace CSKHHANOI.Entities
{
    public class NhanVien_entity : object
    {
        private int _UserID;
        private string _UserName;
        private string _FullName;
        private string _PasswordEncode;
        private string _ChucVu;
        private int _ID_PB;
        private bool _IsAdmin;
        private bool _IsSupperAdmin;
        private bool _IsEnable;
        private string _MaDV;       
        //********************************
        public int UserID
        {
            get { return _UserID; }

            set { _UserID = value; }
        }       
        public string UserName
        {
            get { return _UserName; }

            set { _UserName = value; }
        }

        public string FullName
        {
            get { return _FullName; }

            set { _FullName = value; }
        }

        public string PasswordEncode
        {
            get { return _PasswordEncode; }

            set { _PasswordEncode = value; }
        }

        public string ChucVu
        {
            get { return _ChucVu; }

            set { _ChucVu = value; }
        }

        public int ID_PB
        {
            get { return _ID_PB; }

            set { _ID_PB = value; }
        }

        public bool IsAdmin
        {
            get { return _IsAdmin; }

            set { _IsAdmin = value; }
        }

        public bool IsSupperAdmin
        {
            get { return _IsSupperAdmin; }

            set { _IsSupperAdmin = value; }
        }

        public bool IsEnable
        {
            get { return _IsEnable; }

            set { _IsEnable = value; }
        }

        public string MaDV
        {
            get { return _MaDV; }

            set { _MaDV = value; }
        }




        public NhanVien_entity()
        {
            //constructor
            _UserID = -1;
            _UserName = string.Empty;
            _FullName = string.Empty;
            _PasswordEncode = string.Empty;
            _ChucVu = string.Empty;
            _ID_PB = -1;
            _IsAdmin = false;
            _IsSupperAdmin = false;
            _IsEnable = false;
            _MaDV = string.Empty;
        }
    }
}