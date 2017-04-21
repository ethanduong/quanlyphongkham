using System;
using PhongKhamDaKhoa.controller;
using PhongKhamDaKhoa.entity;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhongKhamDaKhoa
{
    public partial class DanhMucThongSoKyThuat : System.Web.UI.Page
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
                LoadMaDV();
                return;
            }
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM view_THONGSOKYTHUAT";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_TSKT.DataSource = dt;
            Grv_TSKT.DataBind();
            ViewState["dtts"] = dt;
        }

        private void LoadMaDV()
        {
            string strSQL = "select * from dbo.SANPHAM_DICHVU";
            DataTable dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            drplControlTSKT.DataSource = dt;
            drplControlTSKT.DataTextField = "TENDV";
            drplControlTSKT.DataValueField = "ID_SP";
            drplControlTSKT.DataBind();
         

        }

        public string STT()
        {
            return Convert.ToString(_stt++);
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            pnlAddNewTS.Visible = false;
            txtTenTS.Value = "";
            drplControlTSKT.ClearSelection();
          
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTenTS.Value = "";
            drplControlTSKT.ClearSelection();
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblAction.Text == "insert")
            {
                cls_ThongSoKyThuat_entity cvent = new cls_ThongSoKyThuat_entity();
                clsThongSoKyThuat_controller controller = new clsThongSoKyThuat_controller();
                cvent.ID_SP = Int32.Parse(drplControlTSKT.SelectedValue);
                cvent.TENTHONGSO = txtTenTS.Value;
              
                controller.Insert(cvent, ref errMsg);
                if (errMsg == string.Empty)
                {

                    pnlAddNewTS.Visible = false;
                    LoadDataToGridView();
                    txtTenTS.Value = "";
                 

                }
                else
                {
                    lblMsg.Text = "Thêm mới thất bại !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }

            }
            if (lblAction.Text == "update")
            {
                cls_ThongSoKyThuat_entity cvent = new cls_ThongSoKyThuat_entity();
                clsThongSoKyThuat_controller controller = new clsThongSoKyThuat_controller();

                cvent.ID = QLPHONGKHAM.Common.ConvertObj2Int(lblID_Update.Text);
                cvent.ID_SP = Int32.Parse(drplControlTSKT.SelectedValue);
                cvent.TENTHONGSO = txtTenTS.Value;
            

                controller.Update(cvent, ref errMsg);

                if (errMsg == string.Empty)
                {
                    pnlAddNewTS.Visible = false;
                    LoadDataToGridView();
                    txtTenTS.Value = "";

                }
                else
                {
                    lblMsg.Text = "Thay đổi thông tin thất bại !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }

            }
        }

        protected void Grv_TSKT_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            cls_ThongSoKyThuat_entity cvent = new cls_ThongSoKyThuat_entity();
            clsThongSoKyThuat_controller controller = new clsThongSoKyThuat_controller();
            int id = QLPHONGKHAM.Common.ConvertObj2Int(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "cmdEdit")
            {
                lblMsg.Text = string.Empty;
                lblID_Update.Text = e.CommandArgument.ToString();
                lblAction.Text = "update";
                //  formHeader.Text = "Cập Nhập Dịch Vụ";
                cvent = controller.GetData(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    pnlAddNewTS.Visible = true;
                    LoadMaDV();
                    drplControlTSKT.SelectedValue = cvent.ID_SP.ToString();
                    txtTenTS.Value = cvent.TENTHONGSO;

                   

                }
                else
                {
                    lblMsg.Text = "Lỗi xử lý dữ liệu !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
            if (e.CommandName.ToString() == "cmdDelete")
            {
                controller.Delete(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    pnlAddNewTS.Visible = false;
                    LoadDataToGridView();
                    txtTenTS.Value = "";  
                  
                }
                else
                {
                    lblMsg.Text = "Không thể xóa !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
                LoadDataToGridView();
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            pnlAddNewTS.Visible = true;
            LoadMaDV();
            lblAction.Text = "insert";
            txtTenTS.Value = "";
            
        }
    }
}