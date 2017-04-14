using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        private string errMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Disabled = true;
            txtPass.Disabled = true;
            txtHoTen.Disabled = true;
            if (!IsPostBack)
            {
                LoadDataToGridView();


            }
        }

        private void LoadDataToGridView()
        {

            clsUser_entity objUser = new clsUser_entity();
            clsUser_controller controller = new clsUser_controller();

            objUser = controller.GetData(QLPHONGKHAM.Common.GetUserID(), ref errMsg);
            txtHoTen.Value = objUser.HOTEN;
            txtPass.Value = objUser.PASS;
            txtUsername.Value = objUser.USERNAME;
         
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
            txtUsername.Disabled = true;
            txtPass.Disabled = true;
            txtHoTen.Disabled = true;
            lblMsg.Text = string.Empty;
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            txtUsername.Disabled = false;
            txtPass.Disabled = false;
            txtHoTen.Disabled = false;
            lblMsg.Text = string.Empty;
            Img_Upload.Enabled = true;
           

        }
        bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
        protected bool validate()
        {
            if (txtHoTen.Value == string.Empty)
            {
                lblMsg.Text = "Tên không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUsername.Disabled = false;
                txtPass.Disabled = false;
                txtHoTen.Disabled = false;
                txtHoTen.Focus();
                return false;
            }
            if (txtUsername.Value == string.Empty)
            {
                lblMsg.Text = "Tên đăng nhập không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUsername.Disabled = false;
                txtPass.Disabled = false;
                txtHoTen.Disabled = false;
                txtHoTen.Focus();
                return false;
            }
            if (txtPass.Value == string.Empty)
            {
                lblMsg.Text = "Mật khẩu không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUsername.Disabled = false;
                txtPass.Disabled = false;
                txtHoTen.Disabled = false;
                txtHoTen.Focus();
                return false;
            }
            if (txtHoTen.Value.Length > 100)
            {
                lblMsg.Text = "Tên không được quá 100 ký tự !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUsername.Disabled = false;
                txtPass.Disabled = false;
                txtHoTen.Disabled = false;
                txtHoTen.Focus();
                return false;
            }
            if (Img_Upload.HasFile)
            {
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lê !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    txtUsername.Disabled = false;
                    txtPass.Disabled = false;
                    txtHoTen.Disabled = false;
                    Img_Upload.Focus();
                    return false;
                }
               
            }

            return true;
        }
        protected void Upload_()
        {
            ViewState["fileName"] = "UPLOAD_FILE/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + Img_Upload.FileName;
            ViewState["filePath"] = MapPath(ViewState["fileName"].ToString());
            Img_Upload.SaveAs(ViewState["filePath"].ToString());

        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            clsUser_entity entity = new clsUser_entity();
            clsUser_controller controller = new clsUser_controller();
            if (validate())
            {
                entity.ID = QLPHONGKHAM.Common.GetUserID();
                entity.USERNAME = txtUsername.Value;
                entity.HOTEN = txtHoTen.Value;
                entity.PASS = md5(txtPass.Value);
                if (Img_Upload.HasFiles)
                {
                    Upload_();
                    entity.URL_IMAGE = ViewState["filePath"].ToString();
                    entity.FILE_NAME = ViewState["fileName"].ToString();
                }
                controller.Update(entity, ref errMsg);
                if (errMsg == string.Empty)
                {
                    LoadDataToGridView();
                    lblMsg.Text = "Sửa thành công!";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff ");
                    

                }
                else
                {
                    lblMsg.Text = "Sửa thất bại !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    txtUsername.Disabled = false;
                    txtPass.Disabled = false;
                    txtHoTen.Disabled = false;
                }
            }

        }
    }
}