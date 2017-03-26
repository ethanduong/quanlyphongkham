using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhMucChucVu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkAddNewCV_Click(object sender, EventArgs e)
        {
            pnlAddNewCV.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}