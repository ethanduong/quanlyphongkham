using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLPHONGKHAM;
using PhongKhamDaKhoa.entity;
using PhongKhamDaKhoa.controller;

namespace PhongKhamDaKhoa
{
    public partial class SiteMaster : MasterPage
    {
        private string ErrMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
        //    clsUser_entity objUser = new clsUser_entity();
        //    clsUser_controller controller = new clsUser_controller();

        //    objUser = controller.GetData(QLPHONGKHAM.Common.GetUserID(), ref ErrMsg);
     
        //     lblUserLogin.Text = objUser.HOTEN;
        //    lblUserLogin1.Text = objUser.HOTEN;
            
       
           
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session[QLPHONGKHAM.Constant.SESSION_NAMES.ID_UserLogin] = string.Empty;

            Response.Redirect("Login.aspx");
        }
    }
}