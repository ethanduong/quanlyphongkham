using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class cls_PhanQuyen_controller
    {
        public clsPhanQuyen_entity GetData(int sID_PQ, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM PHANQUYEN WHERE ID_PQ=" + sID_PQ;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsPhanQuyen_entity obj = new clsPhanQuyen_entity();
                obj = (clsPhanQuyen_entity)CBO.FillObject(dr, typeof(clsPhanQuyen_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Insert(clsPhanQuyen_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[6];
                //prms[i] = new System.Data.SqlClient.SqlParameter("@MABN", obj.MABN);
                //i = i + 1;             
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_USER", obj.ID_USER);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_NDPQ", obj.ID_NDPQ);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@XEM", obj.XEM);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@THEM", obj.THEM);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@SUA", obj.SUA);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@XOA", obj.XOA);

                QLPHONGKHAM.clsSQLExecute.ExecuteSP("sp_Insert_PHANQUYEN", ref prms, 6, ref errMsg);

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
        public void Update(clsPhanQuyen_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[7];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_PQ", obj.ID_PQ);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_USER", obj.ID_USER);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_NDPQ", obj.ID_NDPQ);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@XEM", obj.XEM);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@THEM", obj.THEM);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@SUA", obj.SUA);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@XOA", obj.XOA);


                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Update_PHANQUYEN", ref prms, 7, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
        public void Delete(int ID_PQ, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM PHANQUYEN WHERE ID=" + ID_PQ;
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