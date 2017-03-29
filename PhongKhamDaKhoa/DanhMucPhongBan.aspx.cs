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
    public partial class DanhMucPhongBan : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM dbo.PHONGBAN";
            DataTable dt = new DataTable();
            dt = CSKHHANOI.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            gvDSPB.DataSource = dt;
            gvDSPB.DataBind();
            ViewState["dtpb"] = dt;
        }
        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        protected void lnkAddNewPB_Click(object sender, EventArgs e)
        {
            formHeader.Text = "Thêm Mới Phòng Ban";
            lblAction.Text = "insert";
            lblMsg.Text = string.Empty;
            txtTenPB.Text = string.Empty;
            pnlAddNewPB.Visible = true;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (lblAction.Text == "insert")
            {
                clsPhongBan_entity cvent = new clsPhongBan_entity();
                clsPhongBan_controller controller = new clsPhongBan_controller();
                if (validate())
                {
                    cvent.TENPHONG = txtTenPB.Text;
                    controller.Insert(cvent, ref errMsg);
                    if (errMsg == string.Empty)
                    {
                        lblMsg.Text = "Thêm mới thành công !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                        pnlAddNewPB.Visible = false;
                        LoadDataToGridView();
                     
                        txtTenPB.Text = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
                else { return; }
            }
            if (lblAction.Text == "update")
            {
                clsPhongBan_entity cvent = new clsPhongBan_entity();
                clsPhongBan_controller controller = new clsPhongBan_controller();
                if (validate())
                {
                    cvent.MAPB = CSKHHANOI.Common.ConvertObj2Int(lblID_Update.Text);
                    cvent.TENPHONG = txtTenPB.Text;

                    controller.Update(cvent, ref errMsg);

                    if (errMsg == string.Empty)
                    {

                        lblMsg.Text = "Thay đổi thông tin thành công !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                        pnlAddNewPB.Visible = false;
                        LoadDataToGridView();
                        txtTenPB.Text = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thay đổi thông tin thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
                else { return; }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtTenPB.Text = string.Empty;
            pnlAddNewPB.Visible = false;
            lblMsg.Text = string.Empty;
        }
        protected bool validate()
        {


            if (txtTenPB.Text == string.Empty)
            {
                lblMsg.Text = "Tên phòng ban không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtTenPB.Focus();
                return false;
            }

            return true;
        }

        protected void gvDSPB_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsPhongBan_entity cvent = new clsPhongBan_entity();
            clsPhongBan_controller controller = new clsPhongBan_controller();
            int id = CSKHHANOI.Common.ConvertObj2Int(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "cmdEdit")
            {
                lblMsg.Text = string.Empty;
                lblID_Update.Text = e.CommandArgument.ToString();
                lblAction.Text = "update";
                formHeader.Text = "Cập Nhập Phòng Ban";
                cvent = controller.GetData(id.ToString(), ref errMsg);
                if (errMsg == string.Empty)
                {
                    pnlAddNewPB.Visible = true;
                    txtTenPB.Text = cvent.TENPHONG;

                }
                else
                {
                    lblMsg.Text = "Lỗi xử lý dữ liệu !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
            if (e.CommandName.ToString() == "cmdDelete")
            {
                controller.Delete(id.ToString(), ref errMsg);
                if (errMsg == string.Empty)
                {
                    lblMsg.Text = "Xóa phòng ban thành công !";

                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                    LoadDataToGridView();
                }
                else
                {
                    lblMsg.Text = "Không thể xóa phòng ban !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
                LoadDataToGridView();
            }
        }

        protected void gvDSPB_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvDSPB.PageIndex = e.NewPageIndex;
                int trang_thu = e.NewPageIndex;
                int so_dong = gvDSPB.PageSize;       //moi trang co bao nhieu don
                _stt = trang_thu * so_dong + 1;
                //==================

                DataTable dtcv = (DataTable)ViewState["dtpb"];
                gvDSPB.DataSource = dtcv;
                gvDSPB.DataBind();
            }
            catch (Exception)
            {
            }
        }
    }
}