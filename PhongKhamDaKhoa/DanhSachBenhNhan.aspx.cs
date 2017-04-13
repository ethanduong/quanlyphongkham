using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhSachBenhNhan : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        private int idUpdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToGridView();
            }
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM dbo.VIEW_TT_BENHNHAN";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_BenhNhan.DataSource = dt;
            Grv_BenhNhan.DataBind();
            ViewState["dtbn"] = dt;

        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            PnlThemMoi.Visible = true;
            lblAction.Text = "insert";
        }
        protected void clearForm()
        {
            txtHoTen.Text = string.Empty;
            txtCanNang.Text = string.Empty;
            txtChieuCao.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            single_cal3.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        protected bool validate()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
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
                txtHoTen.Focus();
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                lblMsg.Text = "Số điện thoại không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtHoTen.Focus();
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                return false;
            }

            return true;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (lblAction.Text == "insert")
                {
                    clsTTBenhNhan_entity entity = new clsTTBenhNhan_entity();
                    clsTTBenhNhan_controller controller = new clsTTBenhNhan_controller();

                    /* if (validate())
                     {*/

                    entity.HOTEN = txtHoTen.Text;
                    entity.NGAYSINH = DateTime.ParseExact(single_cal3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    entity.GIOITINH = Convert.ToBoolean(rdbgGioiTinh.SelectedValue);
                    entity.DIENTHOAI = txtDienThoai.Text;
                    if (!string.IsNullOrEmpty(txtChieuCao.Text))
                    {
                        entity.CHIEUCAO = Int32.Parse(txtChieuCao.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCanNang.Text))
                    {
                        entity.CANNANG = Int32.Parse(txtCanNang.Text);
                    }

                    controller.Insert(entity, ref errMsg);
                    if (errMsg == string.Empty)
                    {
                        LoadDataToGridView();
                        lblMsgCheck.Text = "Đã thêm mới thông tin bệnh nhân!";
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
                    clsTTBenhNhan_entity entity = new clsTTBenhNhan_entity();
                    clsTTBenhNhan_controller controller = new clsTTBenhNhan_controller();
                    //if (validate())
                    //{
                    int id = Int32.Parse(lblIDUpdate.Text);
                    entity = controller.GetData(id, ref errMsg);

                    entity.HOTEN = txtHoTen.Text;
                    entity.NGAYSINH = DateTime.ParseExact(single_cal3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    entity.GIOITINH = Convert.ToBoolean(rdbgGioiTinh.SelectedValue);
                    entity.DIENTHOAI = txtDienThoai.Text;
                    if (!string.IsNullOrEmpty(txtChieuCao.Text))
                    {
                        entity.CHIEUCAO = Int32.Parse(txtChieuCao.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCanNang.Text))
                    {
                        entity.CANNANG = Int32.Parse(txtCanNang.Text);
                    }


                    controller.Update(entity, ref errMsg);

                    if (errMsg == string.Empty)
                    {

                        clearForm();
                        LoadDataToGridView();
                        PnlThemMoi.Visible = false;
                        lblMsgCheck.Text = "Đã thay đổi thông tin!";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff ");
                    }
                    else
                    {
                        lblMsgCheck.Text = "Thay đổi thông tin thất bại !";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
            }

        }


        protected void Grv_BenhNhan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsTTBenhNhan_entity entity = new clsTTBenhNhan_entity();
            clsTTBenhNhan_controller controller = new clsTTBenhNhan_controller();
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
                    txtChieuCao.Text = entity.CHIEUCAO.ToString();
                    txtCanNang.Text = entity.CANNANG.ToString();
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
                    lblMsgCheck.Text = "Đã xóa thông tin bệnh nhân";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                }
                else
                {
                    lblMsgCheck.Text = "Thông tin đã được xử dụng không thể xóa !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
        }


    }
}