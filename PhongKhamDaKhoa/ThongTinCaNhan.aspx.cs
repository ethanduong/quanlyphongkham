using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLPHONGKHAM;
using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;

namespace PhongKhamDaKhoa
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        private string errMsg;
      
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
            clsUser_entity objUser = new clsUser_entity();
            clsUser_controller controller = new clsUser_controller();

            objUser = controller.GetData(QLPHONGKHAM.Common.GetUserID(), ref errMsg);
            txtUserName.Value = objUser.USERNAME;
            txtPass.Value = objUser.PASS.ToString();
            txtTenUser.Value = objUser.HOTEN;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
            txtTenUser.Disabled = true;
            txtUserName.Disabled = true;
            txtPass.Disabled = true;
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            txtTenUser.Disabled = false;
            txtUserName.Disabled = false;
            txtPass.Disabled = false;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUser_entity objUser = new clsUser_entity();
            clsUser_controller controller = new clsUser_controller();
            int id = QLPHONGKHAM.Common.GetUserID();
            objUser.ID = id;
            objUser.USERNAME = txtUserName.Value;
            objUser.PASS = txtPass.Value;
            objUser.HOTEN = txtTenUser.Value;

            controller.Update(objUser, ref errMsg);
            LoadDataToGridView();
            txtTenUser.Disabled = true;
            txtUserName.Disabled = true;
            txtPass.Disabled = true;
        }
    }
}