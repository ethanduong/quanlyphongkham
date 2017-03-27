using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhMucChucVu : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM dbo.CHUCVU";
            DataTable dt = new DataTable();
            dt = CSKHHANOI.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            gvDSCV.DataSource = dt;
            gvDSCV.DataBind();
            ViewState["dtcv"] = dt;
        }

        protected void lnkAddNewCV_Click(object sender, EventArgs e)
        {
            lblAction.Text = "insert";
            txtMaCV.Text = string.Empty;
            txtTenCV.Text = string.Empty;
            pnlAddNewCV.Visible = true;
            txtMaCV.Focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = string.Empty;
            txtTenCV.Text = string.Empty;
            pnlAddNewCV.Visible = false;
            lblMsg.Text = "";
        }

        protected bool validate()
        {
            if (txtMaCV.Text == string.Empty)
            {
                lblMsg.Text = "Mã chức vụ không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtMaCV.Focus();
                return false;
            }
           
            if (txtTenCV.Text == string.Empty)
            {
                lblMsg.Text = "Tên chức vụ không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtTenCV.Focus();
                return false;
            }

            return true;
        }


        protected void gvDSCV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsChucVu_entity cvent = new clsChucVu_entity();
            clsChucVu_controller controller = new clsChucVu_controller();
            int id = CSKHHANOI.Common.ConvertObj2Int(e.CommandArgument.ToString());
            /* if (e.CommandName.ToString() == "cmdEdit")
             {
                 lblMsg.Text = string.Empty;
                 txtMaCV.Focus();
                 lblID_Update.Text = e.CommandArgument.ToString();
                 lblAction.Text = "update";
                 formHeader.Text = "Cập Nhật Phân Loại Khách Hàng";
                 cvent = controller.GetData(int id, ref string errMsg);
                 if (errMsg == string.Empty)
                 {
                     pnlAddNewCV.Visible = true;
                     txtMaCV.Text = cvent.MACV.ToString;
                     txtTen.Text = PhanLoai.MO_TA;
                     txtSTT.Text = PhanLoai.STT.ToString();
                     txtKY_HIEU.Focus();
                 } 
                 else
                 {
                     lblMsg.Text = "Lỗi xử lý dữ liệu !";
                     lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                 }
           }*/
            if (e.CommandName.ToString() == "cmdDelete")
            {
                controller.Delete(id.ToString(), ref errMsg);
                if (errMsg == string.Empty)
                {
                    lblMsg.Text = "Xóa chức vụ thành công !";
                   
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                    LoadDataToGridView();
                }
                else
                {
                    lblMsg.Text = "Không thể xóa phân loại khách hàng !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
                LoadDataToGridView();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (lblAction.Text == "insert")
            {
                clsChucVu_entity cvent = new clsChucVu_entity();
                clsChucVu_controller controller = new clsChucVu_controller();
                if (validate())
                {
                    cvent.MACV = int.Parse(txtMaCV.Text);
                    cvent.TENCV = txtTenCV.Text;
                    controller.Insert(cvent, ref errMsg);
                    if (errMsg == string.Empty)
                    {
                        lblMsg.Text = "Thêm mới thành công !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                        LoadDataToGridView();
                        txtMaCV.Text = string.Empty;
                        txtTenCV.Text = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
                else { return; }

            }
        }
    }
}