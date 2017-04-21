using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;

namespace PhongKhamDaKhoa
{
    public partial class DanhSachChoKham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUser_entity objUser = new clsUser_entity();
            clsUser_controller con = new clsUser_controller();
            if (QLPHONGKHAM.Common.GetUserID() < 0)
            {
                //Response.Write("<script>alert('Bạn chưa đăng nhập. Vui lòng đăng nhập')</script>");

                ClientScript.RegisterStartupScript(this.GetType(), "Log", "<script type='text/javascript'>alert('Bạn chưa đăng nhập, Vui lòng đăng nhập');window.location='Login.aspx';</script>'");
            }
        }
    }
}