using CSKHHANOI;
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
                IDataReader dr = CSKHHANOI.clsSQLExecute.getIDataReader(sqlstr, ref errMsg);
                clsChucVu_entity obj = new clsChucVu_entity();
                obj = (clsChucVu_entity)CBO.FillObject(dr, typeof(clsChucVu_entity));
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}