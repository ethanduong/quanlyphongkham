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
    public partial class DanhMucNguoiDung : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUser_entity objUser = new clsUser_entity();
            clsUser_controller con = new clsUser_controller();
            if (QLPHONGKHAM.Common.GetUserID() < 0)
            {
                //Response.Write("<script>alert('Bạn chưa đăng nhập. Vui lòng đăng nhập')</script>");

                ClientScript.RegisterStartupScript(this.GetType(), "Log", "<script type='text/javascript'>alert('Bạn chưa đăng nhập, Vui lòng đăng nhập');window.location='Login.aspx';</script>'");
            }
            if (!IsPostBack)
            {
                LoadDataToGridView();
                LoadDataToDropdownNhanvien();
                LoadDataToDropdownPhongBan();
            }
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM view_USER";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_NhanVien.DataSource = dt;
            Grv_NhanVien.DataBind();
            ViewState["dtbn"] = dt;

        }
        private void LoadDataToDropdownPhongBan()
        {
            string strSQL = "SELECT * FROM PHONGBAN";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);

            DrlPhongBan.DataSource = dt;
            DrlPhongBan.DataTextField = "TENPHONG";
            DrlPhongBan.DataValueField = "MAPB";
            DrlPhongBan.DataBind();

        }

        private void LoadDataToDropdownNhanvien()
        {
            string strSQL = "SELECT * FROM NHANVIEN";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);

            DrlNhanvien.DataSource = dt;
            DrlNhanvien.DataTextField = "HOTEN";
            DrlNhanvien.DataValueField = "MANV";
            DrlNhanvien.DataBind();

        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            PnlThemMoi.Visible = true;
            lblAction.Text = "insert";
        }
        protected void clearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        protected void Upload_()
        {
            ViewState["fileName"] = "UPLOAD_FILE/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + Img_Upload.FileName;
            ViewState["filePath"] = MapPath(ViewState["fileName"].ToString());
            Img_Upload.SaveAs(ViewState["filePath"].ToString());

        }
        protected bool validate()
        {
            if (txtUsername.Text == string.Empty)
            {
                lblMsg.Text = "Username không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUsername.Focus();
                return false;
            }
            if (txtUsername.Text.Length > 50)
            {
                lblMsg.Text = "Username không được quá 50 ký tự !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUsername.Focus();
                return false;
            }
            if (Img_Upload.HasFile)
            {
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lệ !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    lblMsgCheck.Text = "Thêm mới không thành công !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    Img_Upload.Focus();
                    return false;
                }
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lệ !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    lblMsgCheck.Text = "Thêm mới không thành công !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    Img_Upload.Focus();
                    return false;
                }
            }

            return true;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {

            if (validate())
            {
                if (lblAction.Text == "insert")
                {
                    clsUser_entity entity = new clsUser_entity();
                    clsUser_controller controller = new clsUser_controller();

                    entity.USERNAME = txtUsername.Text;
                    entity.PASS = QLPHONGKHAM.Common.HashPassword(txtPassword.Text);
                    entity.MANV = Int32.Parse(DrlNhanvien.SelectedValue);
                    entity.MAPB = Int32.Parse(DrlPhongBan.SelectedValue);
                    if (Img_Upload.HasFiles)
                    {
                        Upload_();
                        entity.URL_IMAGE = ViewState["filePath"].ToString();
                        entity.FILE_NAME = ViewState["fileName"].ToString();
                    }
                    controller.Insert(entity, ref errMsg);
                    if (errMsg == string.Empty)
                    {
                        LoadDataToGridView();
                        lblMsgCheck.Text = "Đã thêm người dùng mới!";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff ");
                        clearForm();
                    }
                    else
                    {
                        lblMsgCheck.Text = "Thêm mới thất bại !";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }

                //else { return; }
                //} 
                if (lblAction.Text == "update")
                {
                    clsUser_entity entity = new clsUser_entity();
                    clsUser_controller controller = new clsUser_controller();
                    //if (validate())
                    //{
                    int id = Int32.Parse(lblIDUpdate.Text);
                    entity.USERNAME = txtUsername.Text;
                    entity.MANV = Int32.Parse(DrlNhanvien.SelectedValue);
                    entity.MAPB = Int32.Parse(DrlPhongBan.SelectedValue);
                    entity.PASS = QLPHONGKHAM.Common.HashPassword(txtPassword.Text);
                    if (Img_Upload.HasFiles)
                    {
                        Upload_();
                        entity.URL_IMAGE = ViewState["filePath"].ToString();
                        entity.FILE_NAME = ViewState["fileName"].ToString();
                    }

                    controller.Update(entity, ref errMsg);

                    if (errMsg == string.Empty)
                    {

                        clearForm();
                        LoadDataToGridView();
                        PnlThemMoi.Visible = false;
                        lblMsgCheck.Text = "Đã thay đổi thông tin Nhân viên!";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff ");
                    }
                    else
                    {
                        lblMsgCheck.Text = "Đã xảy ra lỗi ! Không thể cập nhật thông tin";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
            }
        }


        protected void Grv_NhanVien_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsUser_entity entity = new clsUser_entity();
            clsUser_controller controller = new clsUser_controller();
            int id = QLPHONGKHAM.Common.ConvertObj2Int(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "cmdEdit")
            {
                lblMsgCheck.Text = string.Empty;
                
                lblIDUpdate.Text = e.CommandArgument.ToString();
                lblAction.Text = "update";
                //formHeader.Text = "Cập Nhập Chức Vụ";
                entity = controller.GetData(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    PnlThemMoi.Visible = true;
                    txtUsername.Text = entity.USERNAME;
                    
                    DrlNhanvien.SelectedValue = entity.MANV.ToString();
                    DrlPhongBan.SelectedValue = entity.MAPB.ToString();
                   
                }
                else
                {
                    lblMsgCheck.Text = "Lỗi xử lý dữ liệu !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
            if (e.CommandName.ToString() == "cmdDelete")
            {
                lblMsg.Text = string.Empty;
                controller.Delete(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    LoadDataToGridView();
                    clearForm();
                }
                else
                {
                    lblMsgCheck.Text = "Thông tin đã được xử dụng không thể xóa !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
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
    }
}