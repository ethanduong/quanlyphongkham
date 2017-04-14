using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Web.UI.WebControls;
using System.Configuration;

namespace QLPHONGKHAM
{
    public class Common
    {
        private static IWebProxy _proxy;
        /// <summary>
        /// return ID max for insert
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNameID"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetID_MaxForInsert(string tableName, string colNameID, string strWhere)
        {

            string errMsg = string.Empty;
            DataTable dtID_max = default(DataTable);



            if (strWhere.Trim() == string.Empty)
            {
                dtID_max = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB("select max(" + colNameID + " ) as max_ID   from " + tableName, "temTB", ref errMsg);

            }
            else
            {
                dtID_max = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB("select max(" + colNameID + " ) as max_ID   from " + tableName + " where " + strWhere, "temTB", ref errMsg);

            }

            if (Convert.IsDBNull(dtID_max.Rows[0][0]))
            {
                return 1;

            }
            else
            {
                return Convert.ToInt32(dtID_max.Rows[0][0]) + 1;

            }
        }

        public static long GetID_MaxForInsertInt64(string tableName, string colNameID, string strWhere)
        {

            string errMsg = string.Empty;
            DataTable dtID_max = default(DataTable);



            if (strWhere.Trim() == string.Empty)
            {
                dtID_max = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB("select max(" + colNameID + " ) as max_ID   from " + tableName, "temTB", ref errMsg);

            }
            else
            {
                dtID_max = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB("select max(" + colNameID + " ) as max_ID   from " + tableName + " where " + strWhere, "temTB", ref errMsg);

            }

            if (Convert.IsDBNull(dtID_max.Rows[0][0]))
            {
                return 1;

            }
            else
            {
                return Convert.ToInt64(dtID_max.Rows[0][0]) + 1;

            }
        }


        /// <summary>
        /// Nguyen Quyet Dinh
        /// Convet object to Integer
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns></returns>
        /// <remarks></remarks>
        public static int ConvertObj2Int(object obj)
        {


            try
            {
                return Convert.ToInt32(obj.ToString());


            }
            catch (Exception ex)
            {
                return 0;

            }

        }



        /// <summary>
        /// Create by : Nguyen Quyet Dinh
        /// For: fill data to dropdown list
        /// exampale :
        /// drp is drpDM_BoPhan
        /// table_nameInput : tblDM_BoPhan
        /// data_field : ID_BoPhan
        /// display_field : Ten_BoPhan
        /// call example : FillDataToDropdownList( drpDM_BoPhan, "tblDM_BoPhan","ID_BoPhan","Ten_BoPhan",errMsg)
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="table_nameInput"></param>
        /// <param name="data_field"></param>
        /// <param name="display_field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool FillDataToDropdownList_StringDataField_WithEmptyItem(ref DropDownList drp, string table_nameInput, string data_field, string display_field, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT '' as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput;

                drp.DataSource = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public static bool FillDataToDropdownList_StringDataField_WithEmptyItem_Where(ref DropDownList drp, string table_nameInput, string data_field, string display_field, string whereColumn, string whereclause, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT '' as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + whereColumn + "='" + whereclause + "'";

                drp.DataSource = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }

        }
        public static bool FillDataToDropdownList_StringDataField_WithEmptyItem_Where(ref DropDownList drp, string table_nameInput, string data_field, string display_field, string whereColumn, int whereclause, ref string errMsg)
        {

            try
            {
                errMsg = "";
                string sqlStr = null;
                sqlStr = "SELECT '' as " + data_field + ",'' as " + display_field + " FROM " + table_nameInput + " Union SELECT " + data_field + "," + display_field + " FROM " + table_nameInput + " WHERE " + whereColumn + "=" + whereclause;

                drp.DataSource = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(sqlStr, "tem_table", ref errMsg);

                drp.DataValueField = data_field;
                drp.DataTextField = display_field;
                drp.DataBind();
                drp.SelectedIndex = 0;
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public static void TextBox_SetNormalBorder(ref TextBox textBox)
        {
            textBox.BorderColor = System.Drawing.Color.White;

        }


        /// <summary>
        /// Check do dai cua textbox va hien thi message voi dialog
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="sTextboxName"></param>
        /// <param name="isRequire_data"></param>
        /// <param name="max_lengAllow"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool CheckTextBoxAnd_GerError(ref TextBox textBox, string sTextboxName, bool isRequire_data, int max_lengAllow, ref string out_errMsg)
        {
            out_errMsg = string.Empty;
            if (isRequire_data)
            {
                if (textBox.Text.Trim() == string.Empty)
                {
                    out_errMsg = sTextboxName + " không nhập dữ liệu!";
                    return false;
                }

            }


            if (textBox.Text.Length > max_lengAllow)
            {
                out_errMsg = sTextboxName + " vượt quá độ dài cho phép " + max_lengAllow + " ký tự.";


                return false;
            }

            return true;

        }


        public static void ShowError_Label(ref Label lblErr, string sErr)
        {
            lblErr.Text = sErr;
            lblErr.ForeColor = System.Drawing.Color.Red;
        }



        /// <summary>
        /// Nguyen Quyet Dinh
        /// Convet string to Integer
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool ConvertString2Boolean(string str)
        {


            try
            {
                return Convert.ToBoolean(str);


            }
            catch (Exception ex)
            {
                return false;

            }

        }

        /// <summary>
        /// lam viec voi iso_certificate login
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetURLAddress_WS_CMIS_EVNHN(string ws_type)
        {
            try
            {
                if (ws_type == QLPHONGKHAM.Constant.WEB_SERVICE_TYPE.WS_WebReference)
                {
                    return ConfigurationManager.AppSettings[QLPHONGKHAM.Constant.VARIABLES.WebAdress_WS_CMIS_EVNHN].ToString();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// get proxy address
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetProxyAddress()
        {

            try
            {
                return ConfigurationManager.AppSettings["PROXY_ADDRESS"].ToString();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// get proxy port
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetProxyPort()
        {

            try
            {
                return ConfigurationManager.AppSettings["PROXY_PORT"].ToString();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// get  isUseProxy
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool isUseProxy()
        {

            try
            {
                return QLPHONGKHAM.Common.ConvertString2Boolean(ConfigurationManager.AppSettings["IsUseProxy"].ToString());

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// get  IS_SPECIFY_USER
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IS_SPECIFY_USER_FOR_PROXY()
        {

            try
            {
                return QLPHONGKHAM.Common.ConvertString2Boolean(ConfigurationManager.AppSettings["IS_SPECIFY_USER"].ToString());

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// get  IS_SPECIFY_USER
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GET_USERNAME_FOR_PROXY()
        {

            try
            {
                return ConfigurationManager.AppSettings["USER_NAME_PROXY"].ToString();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// get  IS_SPECIFY_USER
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GET_PASSWORD_FOR_PROXY()
        {

            try
            {
                return ConfigurationManager.AppSettings["PASS_PROXY"].ToString();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// khoi tao web service
        /// </summary>
        /// <param name="objWs"></param>
        /// <param name="ws_type"></param>
        /// <remarks></remarks>

        //public static void InitForWebService(ref WebCSKHMOBI.WS_WebReference.Service objWs, string ws_type)
        //{
        //    bool is_use_proxy = isUseProxy();
        //    if (ws_type == QLPHONGKHAM.Constant.WEB_SERVICE_TYPE.WS_WebReference)
        //    {
        //        WebCSKHMOBI.WS_WebReference.Service obj_tem = objWs as WebCSKHMOBI.WS_WebReference.Service;

        //        obj_tem.Url = GetURLAddress_WS_CMIS_EVNHN(QLPHONGKHAM.Constant.WEB_SERVICE_TYPE.WS_WebReference);
        //        // 
        //        if (is_use_proxy)
        //        {
        //            obj_tem.Proxy = GetProxy();
        //        }
        //        else
        //        {
        //            obj_tem.Proxy = null;
        //        }
        //    }
        //}


        public static IWebProxy GetProxy()
        {


            if (_proxy == null)
            {
                string proxyAddress = null;
                string HTTP_proxty = null;
                string proxy_port = null;
                HTTP_proxty = GetProxyAddress();
                proxy_port = GetProxyPort();

                if (HTTP_proxty.Contains("http://"))
                {
                    proxyAddress = HTTP_proxty + ":" + proxy_port;
                    //        Console.ReadLine()

                }
                else
                {
                    proxyAddress = "http://" + HTTP_proxty + ":" + proxy_port;
                    //        Console.ReadLine()

                }

                bool is_specify_user_proxy = IS_SPECIFY_USER_FOR_PROXY();

                if (is_specify_user_proxy == false)
                {
                    // Create a new request to the mentioned  .                
                    //Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create(mdl_GlobalVariables.WEB_ADDRESS), HttpWebRequest)
                    WebProxy myProxy = new WebProxy(proxyAddress);

                    _proxy = (IWebProxy)myProxy;
                    return _proxy;


                }
                else
                {
                    // Create a new request to the mentioned  .                
                    //Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create(mdl_GlobalVariables.WEB_ADDRESS), HttpWebRequest)
                    WebProxy myProxy = new WebProxy(proxyAddress);

                    // proxyCredential
                    string user_proxy = GET_USERNAME_FOR_PROXY();
                    string pass_proxy = GET_PASSWORD_FOR_PROXY();

                    NetworkCredential proxyCredential = new NetworkCredential(user_proxy, pass_proxy);

                    myProxy.Credentials = proxyCredential;

                    _proxy = (IWebProxy)myProxy;
                    return _proxy;


                }



            }
            else
            {
                return _proxy;
            }



        }


        /// <summary>
        /// Create by : Nguyen QUyet Dinh
        /// Convert strign to integer
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool isInt(string strValue)
        {

            try
            {
                int i = 0;
                i = Convert.ToInt32(strValue);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static string StandalizeString(string strInput, int len)
        {


            try
            {
                int count = 0;
                string result = "";
                for (count = 1; count <= len; count += 1)
                {
                    if ((count <= strInput.Length))
                    {
                        result = result + strInput.Substring(count - 1, 1);
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                return strInput;

            }

        }

        /// <summary>
        /// Get string lam Key cho Table in SQL
        /// </summary>
        /// <param name="sID_User"></param>
        /// <param name="sSeparate"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetStringMakeKeyForTable_CurrentDate_And_Time_FromServer_yyyyMMDDHHmmSSMiliSecond_WithUserID(int sID_User, string sSeparate)
        {
            string strSQL = null;
            string errMsg = null;

            strSQL = "select datepart( dd,getdate()) as crrDay , datepart( mm,getdate()) as crrMonth,datepart( yyyy,getdate()) as crrYear" + " , datepart( hh,getdate()) as crrHour , datepart( mi,getdate()) as crrMinute,datepart( ss,getdate()) as crrSecond ,   datepart( ms,getdate()) as crrMiliSecond  ";
            int crrDay = 0;
            int crrMonth = 0;
            int crrYear = 0;

            DataTable dtDate = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "temTB", ref errMsg);
            crrDay = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrDay"].ToString());

            crrMonth = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrMonth"].ToString());
            crrYear = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrYear"].ToString());

            int crrHour = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrHour"].ToString());
            int crrMinute = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrMinute"].ToString());
            int crrSecond = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrSecond"].ToString());
            int crrMiliSecond = QLPHONGKHAM.Common.ConvertObj2Int(dtDate.Rows[0]["crrMiliSecond"].ToString());

            int numRandom = QLPHONGKHAM.Common.GetRandom(1, 9999);
            System.Threading.Thread.Sleep(10);
            // dung de dam bao 2 lan goi bao gio cung khac nhau

            return QLPHONGKHAM.Common.StandalizeString(crrYear.ToString(), 4) + sSeparate + QLPHONGKHAM.Common.StandalizeString(crrMonth.ToString(), 2) + sSeparate + QLPHONGKHAM.Common.StandalizeString(crrDay.ToString(), 2) + sSeparate + QLPHONGKHAM.Common.StandalizeString(crrHour.ToString(), 2) + sSeparate + QLPHONGKHAM.Common.StandalizeString(crrMinute.ToString(), 2) + sSeparate + QLPHONGKHAM.Common.StandalizeString(crrSecond.ToString(), 2) + sSeparate + QLPHONGKHAM.Common.StandalizeString(crrMiliSecond.ToString(), 4) + QLPHONGKHAM.Common.StandalizeString(numRandom.ToString(), 4) + "_" + sID_User.ToString();

            //Return Now()
        }



        /// <summary>
        /// Convert 1 so nguyen int64 ra so duoi dang chuoi co ngan cach
        /// </summary>
        /// <param name="value_int"></param>
        /// <param name="charSeparate"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ConvertInt64_2StringWithCharSeparate(Nullable<Int64> value_int, string charSeparate)
        {
            try
            {
                if (value_int.HasValue == false)
                {
                    return string.Empty;
                }

                string strValue_tem = value_int.Value.ToString();

                int index = 0;
                string strResult = string.Empty;
                for (index = strValue_tem.Length - 1; index >= 0; index += -1)
                {
                    int index_new = strValue_tem.Length - 1 - index;
                    if (Math.IEEERemainder(index_new, 3) == 0 & index_new > 0)
                    {
                        strResult = strValue_tem.Substring(index, 1) + charSeparate + strResult;
                    }
                    else
                    {
                        strResult = strValue_tem.Substring(index, 1) + strResult;

                    }

                }

                return strResult;


            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }


        /// <summary>
        /// Nguyen Quyet Dinh
        /// Convet object to Integer
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns></returns>
        /// <remarks></remarks>
        public static Int64 ConvertObj2Int64(object obj)
        {


            try
            {
                return Convert.ToInt32(obj.ToString());


            }
            catch (Exception ex)
            {
                return 0;

            }

        }


        /// <summary>
        /// Chuyen 1 chuoi voi dau ngan cach thanh list of string
        /// </summary>
        /// <param name="sArrString"></param>
        /// <param name="sSeparateChar"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> ConvertStringWithSeparate_ToListItems(string sArrString, string sSeparateChar)
        {
            try
            {
                List<string> sResult = new List<string>();
                string[] arrkeyword = sArrString.Split(new Char[] { sSeparateChar[0] });
                // phan thanh cac chuoi cach nhau boi dau +

                string strItem = null;

                foreach (string strItem_loopVariable in arrkeyword)
                {
                    strItem = strItem_loopVariable;
                    if (strItem.Trim() != string.Empty)
                    {
                        sResult.Add(strItem);

                    }

                }

                return sResult;
            }
            catch (Exception ex)
            {
                return null;
            }


        }


        public static string ConvertObj2String(object obj)
        {


            try
            {
                return obj.ToString();


            }
            catch (Exception ex)
            {
                return string.Empty;

            }

        }



        /// <summary>
        /// Ham ma hoa
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Ham giai ma
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Decode(string sInput)
        {


            try
            {
                return sInput;


            }
            catch (Exception ex)
            {
                return string.Empty;

            }

        }

        /// <summary>
        /// DINHNQ
        /// return true neu chuoi chi gom cac ky tu a ..z va cac chu so 0 .. 9
        /// else return false
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool StringContainA_Zora_zor0_9(string strIn)
        {
            bool functionReturnValue = false;
            functionReturnValue = true;
            int i = 0;
            int j = 0;
            bool absent = false;
            for (i = 0; i < strIn.Length; i++)
            {
                absent = false;
                for (j = 1; j <= 26; j++)
                {
                    if (strIn.Substring(i, 1)[0] == Convert.ToChar(64 + j))
                    {
                        absent = true;
                    }
                    if (strIn.Substring(i, 1)[0] == Convert.ToChar(Convert.ToInt32('a') + j - 1))
                    {
                        absent = true;
                    }
                }
                for (j = 0; j <= 9; j++)
                {
                    if (strIn.Substring(i, 1)[0] == Convert.ToChar(Convert.ToInt32('0') + j))
                    {
                        absent = true;
                    }
                }
                if (absent == false)
                {
                    functionReturnValue = false;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return functionReturnValue;

        }

        /// <summary>
        ///  thay the tat ca chuoi chua str_replace bang str_replace_by As String)
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="str_replace"></param>
        /// <param name="str_replace_by"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object ReplaceAll_ForString(string strInput, string str_replace, string str_replace_by)
        {
            string strInput_tem = strInput;
            while (strInput_tem.Contains(str_replace))
            {
                strInput_tem = strInput_tem.Replace(str_replace, str_replace_by);


            }
            return strInput_tem;

        }


        /// <summary>
        /// Kiem tra 1 user co quyen lap 1 loai thong bao ko
        /// return true: neu co quyen
        /// else return false
        /// </summary>
        /// <param name="sUserID"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        //public static bool KiemTraUser_CoQuyenLap1LoaiTB(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_LapChucMungNamMoi | objPhanQuyen.Quyen_LapTB_NoTienDien | objPhanQuyen.Quyen_LapThongBaoGhiChiSo | objPhanQuyen.Quyen_LapTriAnKH)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}


        /// <summary>
        /// Kiem tra 1 user co quyen duyet 1 loai thong bao ko
        /// return true: neu co quyen
        /// else return false
        /// </summary>
        /// <param name="sUserID"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        //public static bool KiemTraUser_CoQuyenDuyet1LoaiTB(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_DuyetChucMungNamMoi | objPhanQuyen.Quyen_Duyet_NoTienDien | objPhanQuyen.Quyen_DuyetThongBaoGhiChiSo | objPhanQuyen.Quyen_DuyetTriAnKH)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}

        /// <summary>
        /// Kiem tra 1 user co quyen duyet 1 loai thong bao ko
        /// return true: neu co quyen
        /// else return false
        /// </summary>
        /// <param name="sUserID"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        //public static bool KiemTraUser_isAdmin(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_NGUOISUDUNG objNguoiSD = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_NGUOISUDUNG();
        //        string sqlstr = "SELECT  *  FROM EVNHN_CSKH_NGUOISUDUNG WHERE IsAdmin = 1 and UserID=" + sUserID.ToString();
        //        IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref ErrMsg);
        //        objNguoiSD = (QLPHONGKHAM.Entities.clsEVNHN_CSKH_NGUOISUDUNG)CBO.FillObject(dr, typeof(QLPHONGKHAM.Entities.clsEVNHN_CSKH_NGUOISUDUNG));
        //        if (objNguoiSD == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objNguoiSD.IsAdmin)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}

        public static int GetRandom(int Min, int Max)
        {
            System.Random Generator = new System.Random();
            return Generator.Next(Min, Max);
        }


        /// <summary>
        /// hàm bỏ dấu
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        public static string String_RemoveMarkVietnames(string sInput)
        {

            string sResult = string.Empty;
            for (int index = 0; index <= sInput.Length - 1; index++)
            {
                string sChar = sInput.Substring(index, 1);
                string sChar_Out;

                switch (sChar)
                {
                    case "à":
                        sChar_Out = "a";
                        break;
                    case "À":
                        sChar_Out = "A";
                        break;
                    case "á":
                        sChar_Out = "a";
                        break;
                    case "Á":
                        sChar_Out = "A";
                        break;
                    case "ả":
                        sChar_Out = "a";
                        break;
                    case "Ả":
                        sChar_Out = "A";
                        break;
                    case "ã":
                        sChar_Out = "a";
                        break;
                    case "Ã":
                        sChar_Out = "A";
                        break;
                    case "ạ":
                        sChar_Out = "a";
                        break;
                    case "Ạ":
                        sChar_Out = "A";
                        break;

                    case "ă":
                        sChar_Out = "a";
                        break;
                    case "Ă":
                        sChar_Out = "A";
                        break;
                    case "ằ":
                        sChar_Out = "a";
                        break;
                    case "Ằ":
                        sChar_Out = "A";
                        break;
                    case "ắ":
                        sChar_Out = "a";
                        break;
                    case "Ắ":
                        sChar_Out = "A";
                        break;
                    case "ẳ":
                        sChar_Out = "a";
                        break;
                    case "Ẳ":
                        sChar_Out = "A";
                        break;
                    case "ẵ":
                        sChar_Out = "a";
                        break;
                    case "Ẵ":
                        sChar_Out = "A";
                        break;
                    case "ặ":
                        sChar_Out = "a";
                        break;
                    case "Ặ":
                        sChar_Out = "A";
                        break;

                    case "â":
                        sChar_Out = "a";
                        break;
                    case "Â":
                        sChar_Out = "A";
                        break;
                    case "ầ":
                        sChar_Out = "a";
                        break;
                    case "Ầ":
                        sChar_Out = "A";
                        break;
                    case "ấ":
                        sChar_Out = "a";
                        break;
                    case "Ấ":
                        sChar_Out = "A";
                        break;
                    case "ẩ":
                        sChar_Out = "a";
                        break;
                    case "Ẩ":
                        sChar_Out = "A";
                        break;
                    case "ẫ":
                        sChar_Out = "a";
                        break;
                    case "Ẫ":
                        sChar_Out = "A";
                        break;
                    case "ậ":
                        sChar_Out = "a";
                        break;
                    case "Ậ":
                        sChar_Out = "A";
                        break;

                    case "đ":
                        sChar_Out = "d";
                        break;
                    case "Đ":
                        sChar_Out = "D";
                        break;

                    case "è":
                        sChar_Out = "e";
                        break;
                    case "È":
                        sChar_Out = "E";
                        break;
                    case "é":
                        sChar_Out = "e";
                        break;
                    case "É":
                        sChar_Out = "E";
                        break;
                    case "ẻ":
                        sChar_Out = "e";
                        break;
                    case "Ẻ":
                        sChar_Out = "E";
                        break;
                    case "ẽ":
                        sChar_Out = "e";
                        break;
                    case "Ẽ":
                        sChar_Out = "E";
                        break;
                    case "ẹ":
                        sChar_Out = "e";
                        break;
                    case "Ẹ":
                        sChar_Out = "E";
                        break;

                    case "ê":
                        sChar_Out = "e";
                        break;
                    case "Ê":
                        sChar_Out = "E";
                        break;
                    case "ề":
                        sChar_Out = "e";
                        break;
                    case "Ề":
                        sChar_Out = "E";
                        break;
                    case "ế":
                        sChar_Out = "e";
                        break;
                    case "Ế":
                        sChar_Out = "E";
                        break;
                    case "ể":
                        sChar_Out = "e";
                        break;
                    case "Ể":
                        sChar_Out = "E";
                        break;
                    case "ễ":
                        sChar_Out = "e";
                        break;
                    case "Ễ":
                        sChar_Out = "E";
                        break;
                    case "ệ":
                        sChar_Out = "e";
                        break;
                    case "Ệ":
                        sChar_Out = "E";
                        break;

                    case "ì":
                        sChar_Out = "i";
                        break;
                    case "Ì":
                        sChar_Out = "I";
                        break;
                    case "í":
                        sChar_Out = "i";
                        break;
                    case "Í":
                        sChar_Out = "I";
                        break;
                    case "ỉ":
                        sChar_Out = "i";
                        break;
                    case "Ỉ":
                        sChar_Out = "I";
                        break;
                    case "ĩ":
                        sChar_Out = "i";
                        break;
                    case "Ĩ":
                        sChar_Out = "I";
                        break;
                    case "ị":
                        sChar_Out = "i";
                        break;
                    case "Ị":
                        sChar_Out = "I";
                        break;

                    case "ò":
                        sChar_Out = "o";
                        break;
                    case "Ò":
                        sChar_Out = "O";
                        break;
                    case "ó":
                        sChar_Out = "o";
                        break;
                    case "Ó":
                        sChar_Out = "O";
                        break;
                    case "ỏ":
                        sChar_Out = "o";
                        break;
                    case "Ỏ":
                        sChar_Out = "O";
                        break;
                    case "õ":
                        sChar_Out = "o";
                        break;
                    case "Õ":
                        sChar_Out = "O";
                        break;
                    case "ọ":
                        sChar_Out = "o";
                        break;
                    case "Ọ":
                        sChar_Out = "O";
                        break;

                    case "ô":
                        sChar_Out = "o";
                        break;
                    case "Ô":
                        sChar_Out = "o";
                        break;
                    case "ồ":
                        sChar_Out = "o";
                        break;
                    case "Ồ":
                        sChar_Out = "O";
                        break;
                    case "ố":
                        sChar_Out = "o";
                        break;
                    case "Ố":
                        sChar_Out = "O";
                        break;
                    case "ổ":
                        sChar_Out = "o";
                        break;
                    case "Ổ":
                        sChar_Out = "O";
                        break;
                    case "ỗ":
                        sChar_Out = "o";
                        break;
                    case "Ỗ":
                        sChar_Out = "O";
                        break;
                    case "ộ":
                        sChar_Out = "o";
                        break;
                    case "Ộ":
                        sChar_Out = "O";
                        break;

                    case "ơ":
                        sChar_Out = "o";
                        break;
                    case "Ơ":
                        sChar_Out = "o";
                        break;
                    case "ờ":
                        sChar_Out = "o";
                        break;
                    case "Ờ":
                        sChar_Out = "O";
                        break;
                    case "ớ":
                        sChar_Out = "o";
                        break;
                    case "Ớ":
                        sChar_Out = "O";
                        break;
                    case "ở":
                        sChar_Out = "o";
                        break;
                    case "Ở":
                        sChar_Out = "O";
                        break;
                    case "ỡ":
                        sChar_Out = "o";
                        break;
                    case "Ỡ":
                        sChar_Out = "O";
                        break;
                    case "ợ":
                        sChar_Out = "o";
                        break;
                    case "Ợ":
                        sChar_Out = "O";
                        break;

                    case "ù":
                        sChar_Out = "u";
                        break;
                    case "Ù":
                        sChar_Out = "U";
                        break;
                    case "ú":
                        sChar_Out = "u";
                        break;
                    case "Ú":
                        sChar_Out = "U";
                        break;
                    case "ủ":
                        sChar_Out = "u";
                        break;
                    case "Ủ":
                        sChar_Out = "U";
                        break;
                    case "ũ":
                        sChar_Out = "u";
                        break;
                    case "Ũ":
                        sChar_Out = "U";
                        break;
                    case "ụ":
                        sChar_Out = "u";
                        break;
                    case "Ụ":
                        sChar_Out = "U";
                        break;

                    case "ư":
                        sChar_Out = "u";
                        break;
                    case "Ư":
                        sChar_Out = "U";
                        break;
                    case "ừ":
                        sChar_Out = "u";
                        break;
                    case "Ừ":
                        sChar_Out = "U";
                        break;
                    case "ứ":
                        sChar_Out = "u";
                        break;
                    case "Ứ":
                        sChar_Out = "U";
                        break;
                    case "ử":
                        sChar_Out = "u";
                        break;
                    case "Ử":
                        sChar_Out = "U";
                        break;
                    case "ữ":
                        sChar_Out = "u";
                        break;
                    case "Ữ":
                        sChar_Out = "U";
                        break;
                    case "ự":
                        sChar_Out = "u";
                        break;
                    case "Ự":
                        sChar_Out = "U";
                        break;

                    case "ỳ":
                        sChar_Out = "y";
                        break;
                    case "Ỳ":
                        sChar_Out = "Y";
                        break;
                    case "ý":
                        sChar_Out = "y";
                        break;
                    case "Ý":
                        sChar_Out = "Y";
                        break;
                    case "ỷ":
                        sChar_Out = "y";
                        break;
                    case "Ỷ":
                        sChar_Out = "Y";
                        break;
                    case "ỹ":
                        sChar_Out = "y";
                        break;
                    case "Ỹ":
                        sChar_Out = "Y";
                        break;
                    case "ỵ":
                        sChar_Out = "y";
                        break;
                    case "Ỵ":
                        sChar_Out = "Y";
                        break;
                    default:
                        sChar_Out = sChar;
                        break;
                }
                sResult = sResult + sChar_Out;

            };
            return sResult;
        }


        ///
        //Check phân quyền

        //public static bool CheckQuyen_LapThongBaoGhiChiSo(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_LapThongBaoGhiChiSo)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_DuyetThongBaoGhiChiSo(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_DuyetThongBaoGhiChiSo)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_LapTB_NoTienDien(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_LapTB_NoTienDien)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_Duyet_NoTienDien(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_Duyet_NoTienDien)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_LapChucMungNamMoi(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_LapChucMungNamMoi)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_DuyetChucMungNamMoi(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_DuyetChucMungNamMoi)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_LapTriAnKH(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_LapTriAnKH)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_DuyetTriAnKH(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_DuyetTriAnKH)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTDiemThu(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTDiemThu)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTNguoiThu(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTNguoiThu)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTDonVi(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTDonVi)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTMauTB(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTMauTB)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTMauCB(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTMauCB)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTGiaDien(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTGiaDien)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool CheckQuyen_QLTTHuongDan(int sUserID)
        //{
        //    try
        //    {
        //        string ErrMsg = null;

        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN objPhanQuyen = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN();
        //        QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller objPhanQuyen_Ctl = new QLPHONGKHAM.Entities.clsEVNHN_CSKH_PHANQUYEN_Controller();

        //        objPhanQuyen = objPhanQuyen_Ctl.GetData(sUserID, ref ErrMsg);
        //        if (objPhanQuyen == null)
        //        {
        //            return false;
        //        }
        //        //--------
        //        if (objPhanQuyen.Quyen_QLTTHuongDan)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        ///
        // get userid
        public static int GetUserID()
        {
            try
            {
                QLPHONGKHAM.CommonHTTP objCommmonHTTP = new QLPHONGKHAM.CommonHTTP();

                return objCommmonHTTP.GetCurrent_UserID_Login();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        protected void Upload_()
        {
            //if (Page.IsValid && FileUpload1.HasFile && CheckFileType(FileUpload1.FileName))
            //{
            //    ViewState["fileName"] = "../UPLOAD_FILE/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + FileUpload1.FileName;
            //    ViewState["filePath"] = MapPath(ViewState["fileName"].ToString());
            //    FileUpload1.SaveAs(ViewState["filePath"].ToString());
            //    Img_NguoiThu.ImageUrl = ViewState["fileName"].ToString();
            //}
        }
    }

}