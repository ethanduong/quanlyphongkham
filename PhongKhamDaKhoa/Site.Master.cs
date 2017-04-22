using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLPHONGKHAM;
using PhongKhamDaKhoa.entity;
using PhongKhamDaKhoa.controller;
using QLPHONGKHAM.Entities;
namespace PhongKhamDaKhoa
{
    public partial class SiteMaster : MasterPage
    {
        private string ErrMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUser_entity objUser = new clsUser_entity();
            clsUser_controller controller = new clsUser_controller();

            objUser = controller.GetData(QLPHONGKHAM.Common.GetUserID(), ref ErrMsg);
            clsNhanVien_entity nv = new clsNhanVien_entity();
            clsNhanVien_controller con = new clsNhanVien_controller();
            nv = con.GetData(objUser.MANV, ref ErrMsg);

             lblUserLogin.Text = nv.HOTEN;
            lblUserLogin1.Text = nv.HOTEN;
            anh1.ImageUrl = objUser.FILE_NAME;
            anh2.ImageUrl = objUser.FILE_NAME;
            
       
           
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session[QLPHONGKHAM.Constant.SESSION_NAMES.ID_UserLogin] = string.Empty;

            Response.Redirect("Login.aspx");
        }
    }
}