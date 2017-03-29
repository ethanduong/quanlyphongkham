using CSKHHANOI;
using PhongKhamDaKhoa.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsPhongBan_controller
    {
          public clsPhongBan_entity GetData(string sMAPB, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM dbo.PHONGBAN WHERE MAPB = " + sMAPB  ;
                IDataReader dr = CSKHHANOI.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsPhongBan_entity obj = new clsPhongBan_entity();
                obj = (clsPhongBan_entity)CBO.FillObject(dr, typeof(clsPhongBan_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Insert(clsPhongBan_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[1];
             
                prms[i] = new System.Data.SqlClient.SqlParameter("@TENPHONG", obj.TENPHONG);
              
                CSKHHANOI.clsSQLExecute.ExcuteSP("dbo.sp_Insert_PHONGBAN", ref prms, 1, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }

        public void Update(clsPhongBan_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[2];
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TENPHONG", obj.TENPHONG);
          
             
                CSKHHANOI.clsSQLExecute.ExcuteSP("dbo.sp_Update_PHONGBAN", ref prms, 2, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
          
        }

        public void Delete(string sIDPB, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM dbo.PHONGBAN WHERE MAPB=" + sIDPB;
            CSKHHANOI.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);
        }
    }
    
}