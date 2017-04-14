﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Collections;
using Microsoft.VisualBasic;
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
            Common.ShowError_Label(ref lblError, Common.HashPassword("123456"));
            string strSQL = null;

            string errMsg = null;
            strSQL = "  select * from [dbo].[USER] where USERNAME = '" + txtUsername.Text + "' ";
            if (QLPHONGKHAM.clsSQLExecute.CheckExistDataBySQL_clause(strSQL,"USER") == false)
            {
                QLPHONGKHAM.Common.ShowError_Label(ref lblError, "Không tồn tại tên đăng nhập trong hệ thống.");
                //QLPHONGKHAM.Common.ShowError_Label(ref lblError, Common.HashPassword("123456"));
                return;

            }
            
            if (Common.VerifyHashedPassword(clsSQLExecute.GetValueFromTable("[dbo].[USER]", "PASS", "USERNAME='" + txtUsername.Text + "' ", string.Empty, ref errMsg), txtPassword.Text) == false)
            {
                QLPHONGKHAM.Common.ShowError_Label(ref lblError, "Sai mật khẩu.");
                return;
            }
            //====================

            Session[QLPHONGKHAM.Constant.SESSION_NAMES.ID_UserLogin] = QLPHONGKHAM.clsSQLExecute.GetValueFromTable("[dbo].[USER]", "ID", "USERNAME='" + txtUsername.Text + "' ", string.Empty, ref errMsg);
            Response.Redirect("Default.aspx");

        }
    }
}