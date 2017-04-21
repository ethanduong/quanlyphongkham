using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsPhieuKhamBenh_controller
    {
        public clsPhieuKhamBenh_entity GetData(int MAPHIEU, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM PHIEUKHAMBENH WHERE MAPHIEU=" + MAPHIEU;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsPhieuKhamBenh_entity obj = new clsPhieuKhamBenh_entity();
                obj = (clsPhieuKhamBenh_entity)CBO.FillObject(dr, typeof(clsPhieuKhamBenh_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Insert(clsPhieuKhamBenh_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[4];
              
                prms[i] = new System.Data.SqlClient.SqlParameter("@MABN", obj.MABN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYKHAM", obj.NGAYKHAM);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@LYDO", obj.LYDO);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);               

                QLPHONGKHAM.clsSQLExecute.ExecuteSP("sp_Insert_PHIEUKHAMBENH", ref prms, 4, ref errMsg);

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
        public void Update(clsPhieuKhamBenh_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[5];

                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPHIEU", obj.MAPHIEU);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MABN", obj.MABN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@NGAYKHAM", obj.NGAYKHAM);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@LYDO", obj.LYDO);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);          

                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Update_PHIEUKHAMBENH", ref prms, 5, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
        public void Delete(int MAPHIEU, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM PHIEUKHAMBENH WHERE ID=" + MAPHIEU;
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