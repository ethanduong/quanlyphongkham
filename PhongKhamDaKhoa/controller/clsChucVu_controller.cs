using QLPHONGKHAM;
using PhongKhamDaKhoa.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsChucVu_controller
    {
        public clsChucVu_entity GetData(string sMACV, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM dbo.CHUCVU WHERE MACV = " + sMACV  ;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsChucVu_entity obj = new clsChucVu_entity();
                obj = (clsChucVu_entity)CBO.FillObject(dr, typeof(clsChucVu_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Insert(clsChucVu_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[1];
                
                prms[i] = new System.Data.SqlClient.SqlParameter("@TEN", obj.TEN);
              
                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Insert_CHUCVU", ref prms, 1, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }

        public void Update(clsChucVu_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[2];
                prms[i] = new System.Data.SqlClient.SqlParameter("@MACV", obj.MACV);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TEN", obj.TEN);
          
             
                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Update_CHUCVU", ref prms, 2, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
          
        }

        public void Delete(string sIDCV, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM dbo.CHUCVU WHERE MACV=" + sIDCV;
            QLPHONGKHAM.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);
        }
    }
}