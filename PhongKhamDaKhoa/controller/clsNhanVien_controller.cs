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
    public class clsNhanVien_entity_Controller
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// gets an object from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public clsNhanVien_entity GetData(int MANV, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM EVNHN_CSKH_NGUOISUDUNG WHERE MANV=" + MANV;
                IDataReader dr = CSKHHANOI.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsNhanVien_entity obj = new clsNhanVien_entity();
                obj = (clsNhanVien_entity)CBO.FillObject(dr, typeof(clsNhanVien_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //-----------------------------insert object to database -------------------
        public void Insert(clsNhanVien_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[5];
                //prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                //i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYSINH", obj.NGAYSINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@DIENTHOAI", obj.DIENTHOAI);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MACV", obj.MACV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);

                CSKHHANOI.clsSQLExecute.ExcuteSP("sp_Insert_NhanVien", ref prms, 5, ref errMsg);

                //if (string.IsNullOrEmpty(errMsg))
                //{
                //    clsEVNHN_CSKH_PHANQUYEN objPQ = new clsEVNHN_CSKH_PHANQUYEN();
                //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
                //    objPQ.UserID = obj.UserID;
                //    objPQ.ID_PB = obj.ID_PB;
                //    objPQ.UserID_Act = CSKHHANOI.Common.GetUserID();
                //    objPQ_ctrl.Insert(objPQ, ref errMsg);

                //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.EVNHN_CSKH_NGUOISUDUNG", 1, DateTime.Now, obj.UserID.ToString(), CSKHHANOI.Common.GetUserID(), ref errMsg);
                //}
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
        //-----------------------------update  object to database -------------------
        public void Update(clsNhanVien_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[6];
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYSINH", obj.NGAYSINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@DIENTHOAI", obj.DIENTHOAI);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MACV", obj.MACV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);

                CSKHHANOI.clsSQLExecute.ExcuteSP("sp_Insert_NhanVien", ref prms, 6, ref errMsg);

                //if (string.IsNullOrEmpty(errMsg))
                //{
                //    clsEVNHN_CSKH_PHANQUYEN objPQ = new clsEVNHN_CSKH_PHANQUYEN();
                //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
                //    objPQ = objPQ_ctrl.GetData(obj.UserID, ref errMsg);
                //    objPQ.UserID = obj.UserID;
                //    objPQ.ID_PB = obj.ID_PB;
                //    objPQ.UserID_Act = CSKHHANOI.Common.GetUserID();
                //    objPQ_ctrl.Update(objPQ, ref errMsg);

                //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.EVNHN_CSKH_NGUOISUDUNG", 2, DateTime.Now, obj.UserID.ToString(), CSKHHANOI.Common.GetUserID(), ref errMsg);
                //}
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
        //-----------------------------delete  object to database  -------------------
        public void Delete(int sUserID, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM EVNHN_CSKH_NGUOISUDUNG WHERE UserID=" + sUserID.ToString() +
                            "DELETE  FROM dbo.EVNHN_CSKH_PHANQUYEN WHERE UserID=" + sUserID.ToString();
            CSKHHANOI.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);
            //if (string.IsNullOrEmpty(errMsg))
            //{
            //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
            //    objPQ_ctrl.Delete(sUserID, ref errMsg);

            //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.EVNHN_CSKH_NGUOISUDUNG", 3, DateTime.Now, sUserID.ToString(), CSKHHANOI.Common.GetUserID(), ref errMsg);
            //}
        }


        /// <summary>
        /// Get list objects
        /// </summary> 
        /// <param name="strWhereCondition"></param> 
        /// <param name="sOrderBy"></param> 
        /// <param name="errMsg"></param> 
        /// <returns></returns> 
        /// <remarks></remarks>
        public List<clsNhanVien_entity> GetList(string strWhereCondition, string sOrderBy, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string sqlstr = null;
                if (strWhereCondition.Trim() == string.Empty)
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  EVNHN_CSKH_NGUOISUDUNG";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM EVNHN_CSKH_NGUOISUDUNG order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  EVNHN_CSKH_NGUOISUDUNG  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM EVNHN_CSKH_NGUOISUDUNG  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = CSKHHANOI.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                List<clsNhanVien_entity> objList = new List<clsNhanVien_entity>();
                List<object> objObjectList = new List<object>();
                objObjectList = CBO.FillList(dr, typeof(clsNhanVien_entity));
                int index = 0;
                for (index = 0; index <= objObjectList.Count - 1; index++)
                {
                    objList.Add((clsNhanVien_entity)objObjectList[index]);
                }
                return objList;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }
    }
}