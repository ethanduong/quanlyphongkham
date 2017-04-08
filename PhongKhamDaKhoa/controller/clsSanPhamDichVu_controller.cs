using PhongKhamDaKhoa.entity;
using QLPHONGKHAM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhongKhamDaKhoa.controller
{
    public class clsSanPhamDichVu_controller
    {
          public cls_SanPhamDichVu_entity GetData(int sID_SP, ref string errMsg)
        {
            try
            {
                string sqlstr = "SELECT  *  FROM dbo.SANPHAM_DICHVU WHERE ID_SP = " + sID_SP;
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                cls_SanPhamDichVu_entity obj = new cls_SanPhamDichVu_entity();
                obj = (cls_SanPhamDichVu_entity)CBO.FillObject(dr, typeof(cls_SanPhamDichVu_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Insert(cls_SanPhamDichVu_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[3];
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i+1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TENDV", obj.TENDV);
                i = i+1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MOTA", obj.MOTA);

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Insert_SANPHAM_DICHVU", ref prms, 3, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }

        public void Update(cls_SanPhamDichVu_entity obj, ref string errMsg)
        {
            try
            {
                errMsg = "";
                int i = 0;
                System.Data.SqlClient.SqlParameter[] prms = new System.Data.SqlClient.SqlParameter[4];
                prms[i] = new System.Data.SqlClient.SqlParameter("@ID_SP", obj.IDSP);
                i = i+1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MAPB", obj.MAPB);
                i = i+1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@TENDV", obj.TENDV);
                i = i+1;
                prms[i] = new System.Data.SqlClient.SqlParameter("@MOTA", obj.MOTA);

                QLPHONGKHAM.clsSQLExecute.ExcuteSP("dbo.sp_Update_SANPHAM_DICHVU", ref prms, 4, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }

        public void Delete(int sID_SP, ref string errMsg)
        {
            string sqlstr = "DELETE  FROM dbo.SANPHAM_DICHVU WHERE ID_SP=" + sID_SP;
            QLPHONGKHAM.clsSQLExecute.ExcuteSQL(sqlstr, ref errMsg);

        }

        public List<cls_SanPhamDichVu_entity> GetList(string strWhereCondition, string sOrderBy, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string sqlstr = null;
                if (strWhereCondition.Trim() == string.Empty)
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  SANPHAM_DICHVU";
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM SANPHAM_DICHVU order by " + sOrderBy;
                    }
                }
                else
                {
                    if (sOrderBy.Trim() == string.Empty)
                    {
                        sqlstr = "SELECT  *  FROM  SANPHAM_DICHVU  WHERE  " + strWhereCondition;
                    }
                    else
                    {
                        sqlstr = "SELECT  *  FROM SANPHAM_DICHVU  WHERE  " + strWhereCondition + " order by " + sOrderBy;
                    }
                }
                IDataReader dr = QLPHONGKHAM.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                List<cls_SanPhamDichVu_entity> objList = new List<cls_SanPhamDichVu_entity>();
                List<object> objObjectList = new List<object>();
                objObjectList = CBO.FillList(dr, typeof(cls_SanPhamDichVu_entity));
                int index = 0;
                for (index = 0; index <= objObjectList.Count - 1; index++)
                {
                    objList.Add((cls_SanPhamDichVu_entity)objObjectList[index]);
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