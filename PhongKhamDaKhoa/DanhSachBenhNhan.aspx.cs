using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhSachBenhNhan : System.Web.UI.Page
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

            string strSQL = "SELECT * FROM dbo.TT_BENHNHAN";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_BenhNhan.DataSource = dt;
            Grv_BenhNhan.DataBind();
            ViewState["dtbn"] = dt;
        }
    }
}