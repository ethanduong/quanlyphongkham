using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;

namespace QLPHONGKHAM
{
    public class Constant
    {
        public struct SESSION_NAMES
		{


			public static string ID_UserLogin = "ID_UserLogin";

			public static string ID_LanThongBao = "ID_LanThongBao";

			public static string MsgInfor = "MsgInfor";
			public string s;
		}


		public struct LOAI_THONGBAO
		{

			public static string ChucMungNamMoi = "ChucMungNamMoi";
			public static string LichGhiChiSo = "LichGhiChiSo";
			public static string ThongBaoNhacNo = "ThongBaoNhacNo";

			public static string TriAnKhachHang = "TriAnKhachHang";
			public string s;
		}

		/// <summary>
		/// Luu tru cac bien dung chung
		/// </summary>
		/// <remarks></remarks>
		public struct VARIABLES
		{


			public static string WebAdress_WS_CMIS_EVNHN = "WebService_CMIS_EVNHN";
			public static string Encrypt_string_add = "evnhn";

			public static string Encrypt_KeyCode = "cskh_evnhn";
			//------- danh cho phan Web.config-----

			public static string SPACE_HTML = "&nbsp;";
			public static string SPACE_CHARACTER = " ";
			public static string LINE_SEPARATE = "_";

			public string s;
		}
		/// <summary>
		/// Luu danh sach cac ws service
		/// </summary>
		/// <remarks></remarks>
		public struct WEB_SERVICE_TYPE
		{

            public static string WS_WebReference = "WS_WebReference";

			public string s;
		}


	}

}