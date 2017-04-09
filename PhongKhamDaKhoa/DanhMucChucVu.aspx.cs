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
            if (!IsPostBack)
            {
                LoadDataToGridView();
                return;
            }
        }

        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM dbo.CHUCVU";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            gvDSCV.DataSource = dt;
            gvDSCV.DataBind();
            ViewState["dtcv"] = dt;
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            
           // formHeader.Text = "Thêm Mới Chức Vụ";
            lblAction.Text = "insert";
            lblMsg.Text = string.Empty;
            txtTenCV.Value = string.Empty;
            pnlAddNewCV.Visible = true;

           
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
           
            txtTenCV.Value = string.Empty;
            pnlAddNewCV.Visible = false;
            lblMsg.Text = string.Empty;
        }

     /*   protected bool validate()
        {

           

            if (txtTenCV.Text == string.Empty)
            {
                lblMsg.Text = "Tên chức vụ không được để trống !";
                lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                txtTenCV.Focus();
                return false;
            }

            return true;
        }
        */

        protected void gvDSCV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clsChucVu_entity cvent = new clsChucVu_entity();
            clsChucVu_controller controller = new clsChucVu_controller();
            int id = QLPHONGKHAM.Common.ConvertObj2Int(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "cmdEdit")
            {
                lblMsg.Text = string.Empty;
              
                lblID_Update.Text = e.CommandArgument.ToString();
                lblAction.Text = "update";
                //formHeader.Text = "Cập Nhập Chức Vụ";
                cvent = controller.GetData(id, ref errMsg);
                if (errMsg == string.Empty)
                {
                    pnlAddNewCV.Visible = true;
                  
                    txtTenCV.Value = cvent.TEN;
                   
                }
                else
                {
                    lblMsg.Text = "Lỗi xử lý dữ liệu !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
            }
            if (e.CommandName.ToString() == "cmdDelete")
            {
                pnlAddNewCV.Visible = false;
                lblMsg.Text = string.Empty;
                controller.Delete(id, ref errMsg);
                if (errMsg == string.Empty)
                {

                    pnlAddNewCV.Visible = false;
                    LoadDataToGridView();
                    txtTenCV.Value = string.Empty;
                }
                else
                {
                    lblMsg.Text = "Không thể xóa chức vụ !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
                LoadDataToGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            if (lblAction.Text == "insert")
            {
                clsChucVu_entity cvent = new clsChucVu_entity();
                clsChucVu_controller controller = new clsChucVu_controller();
               
               /* if (validate())
                {*/

                    cvent.TEN = txtTenCV.Value;
                    controller.Insert(cvent, ref errMsg);
                    if (errMsg == string.Empty)
                    {
                       
                        pnlAddNewCV.Visible = false;
                        LoadDataToGridView();
                      
                        txtTenCV.Value = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
                //else { return; }
            //} 
            if (lblAction.Text == "update")
            {
                clsChucVu_entity cvent = new clsChucVu_entity();
                clsChucVu_controller controller = new clsChucVu_controller();
                //if (validate())
                //{
                    cvent.MACV = QLPHONGKHAM.Common.ConvertObj2Int(lblID_Update.Text);
                    cvent.TEN = txtTenCV.Value;
                   
                  
                    controller.Update(cvent, ref errMsg);

                    if (errMsg == string.Empty)
                    {
                     
                        pnlAddNewCV.Visible = false;
                        LoadDataToGridView();
                     
                        txtTenCV.Value = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Thay đổi thông tin thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
                }
            //    else { return; }

            //}
        }

        protected void gvDSCV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvDSCV.PageIndex = e.NewPageIndex;
                int trang_thu = e.NewPageIndex;
                int so_dong = gvDSCV.PageSize;       //moi trang co bao nhieu don
                _stt = trang_thu * so_dong + 1;
                //==================

                DataTable dtcv = (DataTable)ViewState["dtcv"];
                gvDSCV.DataSource = dtcv;
                gvDSCV.DataBind();
            }
            catch (Exception)
            {
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTenCV.Value = string.Empty;
           
            lblMsg.Text = string.Empty;
        }

        


    }
}