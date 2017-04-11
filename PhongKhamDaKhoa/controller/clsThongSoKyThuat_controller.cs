using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System.Data;
namespace PhongKhamDaKhoa.controller
{
    public class clsThongSoKyThuat_controller
    {
        public cls_ThongSoKyThuat_entity GetData(int sID, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM dbo.THONGSOKYTHUAT WHERE ID = " + sID;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                cls_ThongSoKyThuat_entity obj = new cls_ThongSoKyThuat_entity();
                obj = (cls_ThongSoKyThuat_entity)CBO.FillObject(dr, typeof(cls_ThongSoKyThuat_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Insert(cls_ThongSoKyThuat_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[2];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_SP", obj.ID_SP);
                i = i + 1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TENTHONGSO", obj.TENTHONGSO);
            

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Insert_THONGSOKYTHUAT", ref prms, 2, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }

        public void Update(cls_ThongSoKyThuat_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[3];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID", obj.ID);
                i = i + 1; 
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_SP", obj.ID_SP);
                i = i + 1;
             
                prms[i] = new System.Data.SqlClient.SqlParameter("@TENTHONGSO", obj.TENTHONGSO);
               

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Update_THONGSOKYTHUAT", ref prms, 3, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }

        public void Delete(int sID, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM dbo.THONGSOKYTHUAT WHERE ID=" + sID;
            QLPHONGKHAM.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);

        }

        public List<cls_ThongSoKyThuat_entity> GetList(string strWhereCondition, string sOrderBy, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string sqlstr = null;
                if (strWhereCondition.Trim() == string.Empty)
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  THONGSOKYTHUAT";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM THONGSOKYTHUAT order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  THONGSOKYTHUAT  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM THONGSOKYTHUAT  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                List<cls_ThongSoKyThuat_entity> objList = new List<cls_ThongSoKyThuat_entity>();
                List<object> objObjectList = new List<object>();
                objObjectList = CBO.FillList(dr, typeof(cls_ThongSoKyThuat_entity));
                int index = 0;
                for (index = 0; index <= objObjectList.Count - 1; index++)
                {
                    objList.Add((cls_ThongSoKyThuat_entity)objObjectList[index]);
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