using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhMucSanPhamDichVu : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToGridView();
                return;
            }

        }
        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM dbo.SANPHAM_DICHVU";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_DichVu.DataSource = dt;
            Grv_DichVu.DataBind();
            ViewState["dtdv"] = dt;
        }

        private void LoadMaPB()
        {
            string strSQL = "select MAPB from dbo.PHONGBAN";
            DataTable dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            drplControl.DataSource = dt;          
            drplControl.DataTextField = "MAPB";
            drplControl.DataValueField = "MAPB"; 
            drplControl.DataBind();
            ViewState["dtdv"] = dt;
            

        }
        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            pnlAddNewSP.Visible = true;
            LoadMaPB();
            txtTenDV.Value = "";
            txtMoTa.Value = "";
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            pnlAddNewSP.Visible = false;
            txtTenDV.Value = "";
            txtMoTa.Value = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTenDV.Value = "";
            txtMoTa.Value = "";
        }


    }
}