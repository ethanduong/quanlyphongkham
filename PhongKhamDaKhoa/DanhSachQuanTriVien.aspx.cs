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
    public partial class QuanTriVien : System.Web.UI.Page
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
                LoadDataToDropdownPhongBan();
                DrlPhongBan.SelectedValue = "-1";
            }
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM ViewUsers";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_USER.DataSource = dt;
            Grv_USER.DataBind();
            ViewState["dtbn"] = dt;

        }
        private void LoadDataToDropdownNhanVien(int MAPB)
        {
            string strSQL = "SELECT * FROM NHANVIEN WHERE MAPB="+MAPB;
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);

            DrdlNhanVien.DataSource = dt;
            DrdlNhanVien.DataTextField = "HOTEN";
            DrdlNhanVien.DataValueField = "MANV";
            DrdlNhanVien.DataBind();

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

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            PnlThemMoi.Visible = true;
            lblAction.Text = "insert";
        }
        protected void clearForm()
        {
            txtUserName.Text = string.Empty;
            txtPassWord.Text = string.Empty;
            DrlPhongBan.ClearSelection();
            DrdlNhanVien.ClearSelection();            

        }
        protected void Upload_()
        {
            ViewState["fileName"] = "UPLOAD_FILE/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + Img_Upload.FileName;
            ViewState["filePath"] = MapPath(ViewState["fileName"].ToString());
            Img_Upload.SaveAs(ViewState["filePath"].ToString());

        }
        protected bool validate()
        {
            if (txtUserName.Text == string.Empty)
            {
                lblMsg.Text = "Tên đăng nhập không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUserName.Focus();
                return false;
            }
            if (txtUserName.Text.Length > 50)
            {
                lblMsg.Text = "Tên đăng nhập không được quá 50 ký tự !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtUserName.Focus();
                return false;
            }
            if (lblAction.Text=="insert")
            {
                string strSQL = " select * from [phongkham].[dbo].[USER] where USERNAME = '" + txtUserName.Text + "' ";
            if (QLPHONGKHAM.clsSQLExecute.CheckExistDataBySQL_clause(strSQL) == true)
            {
                QLPHONGKHAM.Common.ShowError_Label(ref lblMsgCheck, "Tên đăng nhập '"+ txtUserName.Text + "' đã được sử dụng, xin hãy chọn lại !");
                //QLPHONGKHAM.Common.ShowError_Label(ref lblError, Common.HashPassword("123456"));
                txtUserName.Text = string.Empty;
                txtUserName.Focus();
                return false;
            }
            }
            if (txtPassWord.Text == string.Empty)
            {
                lblMsgCheck.Text = "Mật khẩu không được để trống !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");                
                txtUserName.Focus();
                return false;
            }
            if (txtPassWord.Text.Length > 50)
            {
                lblMsgCheck.Text = "Mật khẩu không được quá 50 ký tự !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");                
                txtUserName.Focus();
                return false;
            }
            if (DrdlNhanVien.SelectedValue==string.Empty)
            {
                lblMsgCheck.Text = "Hãy chọn Nhân viên trong danh sách !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");                
                txtUserName.Focus();
                return false;
            }
            if (Img_Upload.HasFile)
            {
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lê !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");                    
                    Img_Upload.Focus();
                    return false;
                }
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lê !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");                   
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

                    entity.USERNAME = txtUserName.Text;
                    entity.PASS = QLPHONGKHAM.Common.HashPassword(txtPassWord.Text);
                    entity.MAPB = Int32.Parse(DrlPhongBan.SelectedValue);
                    entity.MANV = Int32.Parse(DrdlNhanVien.SelectedValue);
                    int pl = entity.PASS.Length;
                             
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
                        lblMsgCheck.Text = "Đã Thêm mới thông tin người sử dụng!";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff ");
                        clearForm();
                        Response.Redirect(Request.Url.AbsoluteUri);
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
                    entity = controller.GetData(id, ref errMsg);
                    entity.ID = id;
                    entity.USERNAME = txtUserName.Text;
                    entity.PASS = QLPHONGKHAM.Common.HashPassword(txtPassWord.Text);
                    entity.MAPB = Int32.Parse(DrlPhongBan.SelectedValue);
                    entity.MANV = Int32.Parse(DrdlNhanVien.SelectedValue);
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
                        PnlThemMoi.Visible = false;
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        lblMsgCheck.Text = "Đã xảy ra lỗi ! Không thể cập nhật thông tin";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
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

        protected void Grv_USER_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    txtUserName.Text = entity.USERNAME;
                    txtUserName.Enabled = false;
                    txtPassWord.Text = "";
                    txtPassWord.ToolTip = "Nhập mật khẩu muốn dùng vào đây";
                    DrlPhongBan.SelectedValue = entity.MAPB.ToString();                    
                    LoadDataToDropdownNhanVien(entity.MAPB);
                    DrdlNhanVien.SelectedValue = entity.MANV.ToString();
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
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    lblMsgCheck.Text = "Thông tin đã được xử dụng không thể xóa !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
        }

        protected void DrlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataToDropdownNhanVien(Int32.Parse(DrlPhongBan.SelectedValue));
        }
    }
}