using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using QLPHONGKHAM;
namespace QLPHONGKHAM.Entities
{
    public class clsNhanVien_controller
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
                string sqlstr = "SELECT  *  FROM NHANVIEN WHERE MANV=" + MANV;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
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
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[8];
                //prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                //i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYSINH", obj.NGAYSINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@GIOITINH", obj.GIOITINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@DIENTHOAI", obj.DIENTHOAI);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MACV", obj.MACV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@URL_IMAGE", obj.URL_IMAGE);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", obj.FILE_NAME);

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("sp_Insert_NhanVien", ref prms, 8, ref errMsg);

                //if (string.IsNullOrEmpty(errMsg))
                //{
                //    clsEVNHN_CSKH_PHANQUYEN objPQ = new clsEVNHN_CSKH_PHANQUYEN();
                //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
                //    objPQ.UserID = obj.UserID;
                //    objPQ.ID_PB = obj.ID_PB;
                //    objPQ.UserID_Act = QLPHONGKHAM.Common.GetUserID();
                //    objPQ_ctrl.Insert(objPQ, ref errMsg);

                //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.NHANVIEN", 1, DateTime.Now, obj.UserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
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
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[9];
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYSINH", obj.NGAYSINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@GIOITINH", obj.GIOITINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@DIENTHOAI", obj.DIENTHOAI);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MACV", obj.MACV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@URL_IMAGE", obj.URL_IMAGE);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", obj.FILE_NAME);

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("sp_Update_NhanVien", ref prms, 9, ref errMsg);

                //if (string.IsNullOrEmpty(errMsg))
                //{
                //    clsEVNHN_CSKH_PHANQUYEN objPQ = new clsEVNHN_CSKH_PHANQUYEN();
                //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
                //    objPQ = objPQ_ctrl.GetData(obj.UserID, ref errMsg);
                //    objPQ.UserID = obj.UserID;
                //    objPQ.ID_PB = obj.ID_PB;
                //    objPQ.UserID_Act = QLPHONGKHAM.Common.GetUserID();
                //    objPQ_ctrl.Update(objPQ, ref errMsg);

                //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.NHANVIEN", 2, DateTime.Now, obj.UserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
                //}
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
        //-----------------------------delete  object to database  -------------------
        public void Delete(int MANV, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM NHANVIEN WHERE MANV=" + MANV;
            QLPHONGKHAM.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);
            //if (string.IsNullOrEmpty(errMsg))
            //{
            //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
            //    objPQ_ctrl.Delete(sUserID, ref errMsg);

            //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.NHANVIEN", 3, DateTime.Now, sUserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
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
                        sqlstr = "SELECT  *  FROM  NHANVIEN";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM NHANVIEN order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  NHANVIEN  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM NHANVIEN  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
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