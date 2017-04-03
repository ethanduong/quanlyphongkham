using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Web.SessionState;//.HttpSessionState;
//using System.Web.UI.Page;
using System.Text;
using System.IO;
//using System.Web.HttpResponse;

namespace QLPHONGKHAM
{
    public class CommonHTTP : System.Web.UI.Page
	{

		/// <summary>
		/// Tra ve ID User dang nhap
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		public int GetCurrent_UserID_Login()
		{
			try {

				int sCrr_UserID_Login = QLPHONGKHAM.Common.ConvertObj2Int(Session[QLPHONGKHAM.Constant.SESSION_NAMES.ID_UserLogin].ToString());
				return sCrr_UserID_Login;
				//----------

			} catch (Exception ex) {
				return -1;
			}

		}

		//Public Function getUserName_LogOn() As String
		//    Try
		//        'User_Name_Login
		//        Dim userName As String = Session(QLHD.COMMON_CODE.Constant.SESSION_NAMES.User_Name_Login).ToString
		//        Return userName
		//    Catch ex As Exception
		//        Return ""
		//    End Try

		//End Function

		//Public Function getConnection_String() As String
		//    Try
		//        'User_Name_Login
		//        Dim Connection_String As String = Session(QLHD.COMMON_CODE.Constant.SESSION_NAMES.Connection_String).ToString
		//        Return Connection_String
		//    Catch ex As Exception
		//        Return ""
		//    End Try

		//End Function



	}
}