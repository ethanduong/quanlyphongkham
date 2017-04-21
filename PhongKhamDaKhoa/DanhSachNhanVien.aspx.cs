using QLPHONGKHAM.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;

namespace PhongKhamDaKhoa
{
    public partial class DanhSachNhanVien : System.Web.UI.Page
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
                LoadDataToDropdownChucVu();
                LoadDataToDropdownPhongBan();
            }
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM view_NhanVien";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_NhanVien.DataSource = dt;
            Grv_NhanVien.DataBind();
            ViewState["dtbn"] = dt;

        }
        private void LoadDataToDropdownChucVu()
        {
            string strSQL = "SELECT * FROM CHUCVU";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);

            DrlChucVu.DataSource = dt;
            DrlChucVu.DataTextField = "TEN";
            DrlChucVu.DataValueField = "MACV";
            DrlChucVu.DataBind();

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
            txtHoTen.Text = string.Empty;
            DrlChucVu.ClearSelection();
            DrlPhongBan.ClearSelection();
            txtDienThoai.Text = string.Empty;
            single_cal3.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        protected void Upload_()
        {
            ViewState["fileName"] = "UPLOAD_FILE/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + Img_Upload.FileName;
            ViewState["filePath"] = MapPath(ViewState["fileName"].ToString());
            Img_Upload.SaveAs(ViewState["filePath"].ToString());

        }
        protected bool validate()
        {
            if (txtHoTen.Text == string.Empty)
            {
                lblMsg.Text = "Tên nhân viên không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtHoTen.Focus();
                return false;
            }
            if (txtHoTen.Text.Length > 100)
            {
                lblMsg.Text = "Tên nhân viên không được quá 100 ký tự !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtHoTen.Focus();
                return false;
            }
            if (Img_Upload.HasFile)
            {
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lê !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    lblMsgCheck.Text = "Thêm mới không thành công !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    Img_Upload.Focus();
                    return false;
                }
                if (!CheckFileType(Img_Upload.FileName))
                {
                    lblMsg.Text = "Định dạng ảnh không hợp lê !";
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
                    clsNhanVien_entity entity = new clsNhanVien_entity();
                    clsNhanVien_controller controller = new clsNhanVien_controller();

                    entity.HOTEN = txtHoTen.Text;
                    entity.NGAYSINH = DateTime.ParseExact(single_cal3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    entity.GIOITINH = Convert.ToBoolean(rdbgGioiTinh.SelectedValue);
                    entity.DIENTHOAI = txtDienThoai.Text;
                    entity.MACV = Int32.Parse(DrlChucVu.SelectedValue);
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
                        lblMsgCheck.Text = "Đã thêm mới thông tin nhân viên!";
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
                    clsNhanVien_entity entity = new clsNhanVien_entity();
                    clsNhanVien_controller controller = new clsNhanVien_controller();
                    //if (validate())
                    //{
                    int id = Int32.Parse(lblIDUpdate.Text);
                    entity = controller.GetData(id, ref errMsg);
                    entity.MANV = id;
                    entity.HOTEN = txtHoTen.Text;
                    entity.NGAYSINH = DateTime.ParseExact(single_cal3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    entity.GIOITINH = Convert.ToBoolean(rdbgGioiTinh.SelectedValue);
                    entity.DIENTHOAI = txtDienThoai.Text;
                    entity.MACV = Int32.Parse(DrlChucVu.SelectedValue);
                    entity.MAPB = Int32.Parse(DrlPhongBan.SelectedValue);
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
                        lblMsgCheck.Text = "Đã thay đổi thông tin nhân viên!";
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


        protected void Grv_BenhNhan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsNhanVien_entity entity = new clsNhanVien_entity();
            clsNhanVien_controller controller = new clsNhanVien_controller();
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
                    txtHoTen.Text = entity.HOTEN;
                    single_cal3.Text = entity.NGAYSINH.ToString("dd/MM/yyyy");
                    txtDienThoai.Text = entity.DIENTHOAI;
                    DrlChucVu.SelectedValue = entity.MACV.ToString();
                    DrlPhongBan.SelectedValue = entity.MAPB.ToString();
                    if (entity.GIOITINH == true)
                    {
                        rdbgGioiTinh.SelectedIndex = 0;
                    }
                    else rdbgGioiTinh.SelectedIndex = 1;

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