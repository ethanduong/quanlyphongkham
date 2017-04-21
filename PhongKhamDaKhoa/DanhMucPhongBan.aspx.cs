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
                return;
            }
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM dbo.PHONGBAN";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            gvDSPB.DataSource = dt;
            gvDSPB.DataBind();
            ViewState["dtpb"] = dt;
        }
        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            // formHeader.Text = "Thêm Mới Phòng Ban";
            lblAction.Text = "insert";
            lblMsg.Text = string.Empty;
            txtTenPB.Text = string.Empty;
            pnlAddNewPB.Visible = true;
        }
        protected bool validate()
        {
            if (txtTenPB.Text == string.Empty)
            {
                lblMsg.Text = "Tên phòng ban không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtTenPB.Focus();
                return false;
            }
            if (txtTenPB.Text.Length > 100)
            {
                lblMsg.Text = "Tên phòng ban không được quá 100 ký tự !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                lblMsgCheck.Text = "Thêm mới không thành công !";
                lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtTenPB.Focus();
                return false;
            }

            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (lblAction.Text == "insert")
                {
                    clsPhongBan_entity cvent = new clsPhongBan_entity();
                    clsPhongBan_controller controller = new clsPhongBan_controller();
                    //if (validate())
                    //{
                    cvent.TENPHONG = txtTenPB.Text;
                    controller.Insert(cvent, ref errMsg);
                    if (errMsg == string.Empty)
                    {

                        pnlAddNewPB.Visible = false;
                        LoadDataToGridView();
                        lblMsgCheck.Text = "Đã thêm mới phòng ban !";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                        txtTenPB.Text = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
                //    else { return; }
                //}
                if (lblAction.Text == "update")
                {
                    clsPhongBan_entity cvent = new clsPhongBan_entity();
                    clsPhongBan_controller controller = new clsPhongBan_controller();
                    //if (validate())
                    //{
                    cvent.MAPB = QLPHONGKHAM.Common.ConvertObj2Int(lblID_Update.Text);
                    cvent.TENPHONG = txtTenPB.Text;

                    controller.Update(cvent, ref errMsg);

                    if (errMsg == string.Empty)
                    {
                        lblMsgCheck.Text = "Đã thay đổi thông tin phòng ban !";
                        lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                        pnlAddNewPB.Visible = false;
                        LoadDataToGridView();
                        txtTenPB.Text = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thay đổi thông tin thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                    //}
                    //else { return; }

                }
            }

        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenPB.Text = string.Empty;
            pnlAddNewPB.Visible = false;
            lblMsg.Text = string.Empty;
        }
        //protected bool validate()
        //{


        //    if (txtTenPB.Text == string.Empty)
        //    {
        //        lblMsg.Text = "Tên phòng ban không được để trống !";
        //        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
        //        txtTenPB.Focus();
        //        return false;
        //    }

        //    return true;
        //}

        protected void gvDSPB_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsPhongBan_entity cvent = new clsPhongBan_entity();
            clsPhongBan_controller controller = new clsPhongBan_controller();
            int id = QLPHONGKHAM.Common.ConvertObj2Int(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "cmdEdit")
            {
                lblMsg.Text = string.Empty;
                lblID_Update.Text = e.CommandArgument.ToString();
                lblAction.Text = "update";
                //   formHeader.Text = "Cập Nhập Phòng Ban";
                cvent = controller.GetData(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    pnlAddNewPB.Visible = true;
                    txtTenPB.Text = cvent.TENPHONG;

                }
                else
                {
                    lblMsgCheck.Text = "Lỗi xử lý dữ liệu !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
            if (e.CommandName.ToString() == "cmdDelete")
            {
                controller.Delete(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    lblMsgCheck.Text = "Đã xóa phòng ban !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");
                    LoadDataToGridView();
                }
                else
                {
                    lblMsgCheck.Text = "Không thể xóa phòng ban !";
                    lblMsgCheck.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTenPB.Text = string.Empty;

            lblMsg.Text = string.Empty;
        }
    }
}