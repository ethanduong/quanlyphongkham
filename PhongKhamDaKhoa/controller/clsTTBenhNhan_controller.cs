using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsTTBenhNhan_controller
    {
        public clsTTBenhNhan_entity GetData(int MABN, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM TT_BENHNHAN WHERE MABN=" + MABN;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsTTBenhNhan_entity obj = new clsTTBenhNhan_entity();
                obj = (clsTTBenhNhan_entity)CBO.FillObject(dr, typeof(clsTTBenhNhan_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //-----------------------------insert object to database -------------------
        public void Insert(clsTTBenhNhan_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[7];
                //prms[i] = new System.Data.SqlClient.SqlParameter("@MABN", obj.MABN);
                //i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYSINH", obj.NGAYSINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@GIOITINH", obj.GIOITINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@DIENTHOAI", obj.DIENTHOAI);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@CHIEUCAO", obj.CHIEUCAO);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@CANNANG", obj.CANNANG);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TIENSU", obj.TIENSU);

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("sp_Insert_TT_BENHNHAN", ref prms, 7, ref errMsg);

                //if (string.IsNullOrEmpty(errMsg))
                //{
                //    clsEVNHN_CSKH_PHANQUYEN objPQ = new clsEVNHN_CSKH_PHANQUYEN();
                //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
                //    objPQ.UserID = obj.UserID;
                //    objPQ.ID_PB = obj.ID_PB;
                //    objPQ.UserID_Act = QLPHONGKHAM.Common.GetUserID();
                //    objPQ_ctrl.Insert(objPQ, ref errMsg);

                //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.TT_BENHNHAN", 1, DateTime.Now, obj.UserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
                //}
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
        //-----------------------------update  object to database -------------------
        public void Update(clsTTBenhNhan_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[8];
                prms[i] = new System.Data.SqlClient.SqlParameter("@MABN", obj.MABN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYSINH", obj.NGAYSINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@GIOITINH", obj.GIOITINH);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@DIENTHOAI", obj.DIENTHOAI);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@CHIEUCAO", obj.CHIEUCAO);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@CANNANG", obj.CANNANG);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TIENSU", obj.TIENSU);

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("sp_Update_TT_BENHNHAN", ref prms, 8, ref errMsg);

                //if (string.IsNullOrEmpty(errMsg))
                //{
                //    clsEVNHN_CSKH_PHANQUYEN objPQ = new clsEVNHN_CSKH_PHANQUYEN();
                //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
                //    objPQ = objPQ_ctrl.GetData(obj.UserID, ref errMsg);
                //    objPQ.UserID = obj.UserID;
                //    objPQ.ID_PB = obj.ID_PB;
                //    objPQ.UserID_Act = QLPHONGKHAM.Common.GetUserID();
                //    objPQ_ctrl.Update(objPQ, ref errMsg);

                //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.TT_BENHNHAN", 2, DateTime.Now, obj.UserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
                //}
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
        //-----------------------------delete  object to database  -------------------
        public void Delete(int MABN, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM TT_BENHNHAN WHERE MABN=" + MABN;
            QLPHONGKHAM.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);
            //if (string.IsNullOrEmpty(errMsg))
            //{
            //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
            //    objPQ_ctrl.Delete(sUserID, ref errMsg);

            //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.TT_BENHNHAN", 3, DateTime.Now, sUserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
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
        public List<clsTTBenhNhan_entity> GetList(string strWhereCondition, string sOrderBy, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string sqlstr = null;
                if (strWhereCondition.Trim() == string.Empty)
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  TT_BENHNHAN";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM TT_BENHNHAN order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  TT_BENHNHAN  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM TT_BENHNHAN  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                List<clsTTBenhNhan_entity> objList = new List<clsTTBenhNhan_entity>();
                List<object> objObjectList = new List<object>();
                objObjectList = CBO.FillList(dr, typeof(clsTTBenhNhan_entity));
                int index = 0;
                for (index = 0; index <= objObjectList.Count - 1; index++)
                {
                    objList.Add((clsTTBenhNhan_entity)objObjectList[index]);
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
