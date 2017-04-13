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

        public void Update(clsUser_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[4];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID", obj.ID);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@HOTEN", obj.HOTEN);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@USERNAME", obj.USERNAME);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@PASS", obj.PASS);
               

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Update_USER", ref prms, 4, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
    }
}