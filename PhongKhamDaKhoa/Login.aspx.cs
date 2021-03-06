﻿using System;
using QLPHONGKHAM;

namespace PhongKhamDaKhoa
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strSQL = null;
            string errMsg = null;
            strSQL = " select * from [phongkham].[dbo].[USER] where USERNAME = '" + txtUsername.Text + "' ";
            if (clsSQLExecute.CheckExistDataBySQL_clause(strSQL) == false)
            {
                Common.ShowError_Label(ref lblError, txtUsername.Text + " không tồn tại tên đăng nhập trong hệ thống.");
                //QLPHONGKHAM.Common.ShowError_Label(ref lblError, Common.HashPassword("123456"));
                return;

            }

            if (Common.VerifyHashedPassword(clsSQLExecute.GetValueFromTable("[phongkham].[dbo].[USER]", "PASS", "USERNAME='" + txtUsername.Text + "' ", string.Empty, ref errMsg), txtPassword.Text) == false)
            {
                Common.ShowError_Label(ref lblError, "Sai mật khẩu.");
                return;
            }
            //====================

            Session[Constant.SESSION_NAMES.ID_UserLogin] = clsSQLExecute.GetValueFromTable("[phongkham].[dbo].[USER]", "ID", "USERNAME='" + txtUsername.Text + "' ", string.Empty, ref errMsg);
            Response.Redirect("Default.aspx");

        }
    }
}