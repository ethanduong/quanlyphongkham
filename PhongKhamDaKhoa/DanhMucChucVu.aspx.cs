using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhMucChucVu : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        private void LoadDataToGridView()
        {
         
            string strSQL = "SELECT * FROM dbo.CHUCVU";
            DataTable dt = new DataTable();
            dt = CSKHHANOI.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            gvDSCV.DataSource = dt;
            gvDSCV.DataBind();
            ViewState["dtcv"] = dt;
        }

        protected void lnkAddNewCV_Click(object sender, EventArgs e)
        {
            pnlAddNewCV.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = string.Empty;
            txtTenCV.Text = string.Empty;
            pnlAddNewCV.Visible = false;

        }
    }
}