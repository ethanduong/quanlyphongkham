using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsUser_controller
    {
        //âsdsaádasdsaa
        public clsUser_entity GetData(int sUserID, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM [dbo].[USER] WHERE ID=" + sUserID;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsUser_entity obj = new clsUser_entity();
                obj = (clsUser_entity)CBO.FillObject(dr, typeof(clsUser_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Insert(clsUser_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[6];
                //prms[i] = new System.Data.SqlClient.SqlParameter("@MABN", obj.MABN);
                //i = i + 1;             
                prms[i] = new System.Data.SqlClient.SqlParameter("@USERNAME", obj.USERNAME);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@PASS", obj.PASS);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@URL_IMAGE", obj.URL_IMAGE);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", obj.FILE_NAME);

                QLPHONGKHAM.clsSQLExecute.ExecuteSP("sp_Insert_USER", ref prms, 6, ref errMsg);

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
        public void Update(clsUser_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[7];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID", obj.ID);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@USERNAME", obj.USERNAME);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@PASS", obj.PASS);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@URL_IMAGE", obj.URL_IMAGE);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", obj.FILE_NAME);
               

                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Update_USER", ref prms, 7, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
        public void Delete(int ID, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM [USER] WHERE ID=" + ID;
            QLPHONGKHAM.clsSQLExecute.ExecuteSQL(sqlstr, ref errMsg);
            //if (string.IsNullOrEmpty(errMsg))
            //{
            //    clsEVNHN_CSKH_PHANQUYEN_Controller objPQ_ctrl = new clsEVNHN_CSKH_PHANQUYEN_Controller();
            //    objPQ_ctrl.Delete(sUserID, ref errMsg);

            //    LichSu_NguoiDung.clsEVNHN_CSKH_LICHSU_NGUOIDUNG.Insert("dbo.TT_BENHNHAN", 3, DateTime.Now, sUserID.ToString(), QLPHONGKHAM.Common.GetUserID(), ref errMsg);
            //}
        }
    }
}