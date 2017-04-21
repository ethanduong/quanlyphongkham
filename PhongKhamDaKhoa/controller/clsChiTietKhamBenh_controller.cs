using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsChiTietKhamBenh_controller
    {
        public clsChiTietKham_entity GetData(int sID, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM CHITIETKHAM WHERE ID=" + sID;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsChiTietKham_entity obj = new clsChiTietKham_entity();
                obj = (clsChiTietKham_entity)CBO.FillObject(dr, typeof(clsChiTietKham_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Insert(clsChiTietKham_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[7];
                             
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPHIEU", obj.MAPHIEU);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_SP", obj.ID_SP);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MOTA", obj.MOTA);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@KETLUAN", obj.KETLUAN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@URL_IMAGE", obj.URL_IMAGE);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", obj.FILE_NAME);

                QLPHONGKHAM.clsSQLExecute.ExecuteSP("sp_Insert_CHITIETKHAM", ref prms, 7, ref errMsg);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
        public void Update(clsChiTietKham_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[8];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID", obj.ID);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPHIEU", obj.MAPHIEU);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_SP", obj.ID_SP);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MOTA", obj.MOTA);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@KETLUAN", obj.KETLUAN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MANV", obj.MANV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@URL_IMAGE", obj.URL_IMAGE);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@FILE_NAME", obj.FILE_NAME);


                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Update_CHITIETKHAM", ref prms, 8, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
        public void Delete(int ID, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM CHITIETKHAM WHERE ID=" + ID;
            QLPHONGKHAM.clsSQLExecute.ExecuteSQL(sqlstr, ref errMsg);
           
        }
    }
}