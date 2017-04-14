using QLPHONGKHAM;
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
          public clsPhongBan_entity GetData(int sMAPB, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM dbo.PHONGBAN WHERE MAPB = " + sMAPB  ;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
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
              
                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Insert_PHONGBAN", ref prms, 1, ref errMsg);
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
          
             
                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Update_PHONGBAN", ref prms, 2, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
          
        }

        public void Delete(int sIDPB, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM dbo.PHONGBAN WHERE MAPB=" + sIDPB;
            QLPHONGKHAM.clsSQLExecute.ExecuteSQL(sqlstr, ref errMsg);
        }

        public List<clsPhongBan_entity> GetList(string strWhereCondition, string sOrderBy, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string sqlstr = null;
                if (strWhereCondition.Trim() == string.Empty)
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  PHONGBAN";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM PHONGBAN order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  PHONGBAN  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM PHONGBAN  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                List<clsPhongBan_entity> objList = new List<clsPhongBan_entity>();
                List<object> objObjectList = new List<object>();
                objObjectList = CBO.FillList(dr, typeof(clsPhongBan_entity));
                int index = 0;
                for (index = 0; index <= objObjectList.Count - 1; index++)
                {
                    objList.Add((clsPhongBan_entity)objObjectList[index]);
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