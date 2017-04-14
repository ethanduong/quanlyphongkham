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
        public clsChucVu_entity GetData(int sMACV, ref string errMsg)
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
              
                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Insert_CHUCVU", ref prms, 1, ref errMsg);
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
          
             
                QLPHONGKHAM.clsSQLExecute.ExecuteSP("dbo.sp_Update_CHUCVU", ref prms, 2, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
          
        }

        public void Delete(int sIDCV, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM dbo.CHUCVU WHERE MACV=" + sIDCV;
            QLPHONGKHAM.clsSQLExecute.ExecuteSQL(sqlstr, ref errMsg);
        }

        public List<clsChucVu_entity> GetList(string strWhereCondition, string sOrderBy, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string sqlstr = null;
                if (strWhereCondition.Trim() == string.Empty)
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  CHUCVU";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM CHUCVU order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  CHUCVU  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM CHUCVU  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                List<clsChucVu_entity> objList = new List<clsChucVu_entity>();
                List<object> objObjectList = new List<object>();
                objObjectList = CBO.FillList(dr, typeof(clsChucVu_entity));
                int index = 0;
                for (index = 0; index <= objObjectList.Count - 1; index++)
                {
                    objList.Add((clsChucVu_entity)objObjectList[index]);
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