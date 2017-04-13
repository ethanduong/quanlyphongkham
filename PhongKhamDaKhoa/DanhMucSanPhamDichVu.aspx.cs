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
    public partial class DanhMucSanPhamDichVu : System.Web.UI.Page
    {
        private string errMsg;
        private int _stt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToGridView();
                LoadMaPB();
               
            }

        }
        private void LoadDataToGridView()
        {

            string strSQL = "SELECT * FROM view_SANPHAMDICHVU";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);
            Grv_DichVu.DataSource = dt;
            Grv_DichVu.DataBind();
            ViewState["dtdv"] = dt;
        }

        private void LoadMaPB()
        {
            string strSQL = "SELECT * FROM PHONGBAN";
            DataTable dt = new DataTable();
            dt = QLPHONGKHAM.clsSQLExecute.LoadDataFromDB(strSQL, "TemTB", ref errMsg);

            drplControl.DataSource = dt;
            drplControl.DataTextField = "TENPHONG";
            drplControl.DataValueField = "MAPB";
            drplControl.DataBind();
        
            

        }
        public string STT()
        {
            return Convert.ToString(_stt++);
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {

            pnlAddNewSP.Visible = true;
            LoadMaPB();
            lblAction.Text = "insert";
            txtTenDV.Value = "";
            txtMoTa.Value = "";
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            pnlAddNewSP.Visible = false;
            txtTenDV.Value = "";
            txtMoTa.Value = "";
            drplControl.ClearSelection();
          
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTenDV.Value = "";
            txtMoTa.Value = "";
            drplControl.ClearSelection();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblAction.Text == "insert")
            {
                cls_SanPhamDichVu_entity cvent = new cls_SanPhamDichVu_entity();
                clsSanPhamDichVu_controller controller = new clsSanPhamDichVu_controller();
                cvent.MAPB = Int32.Parse(drplControl.SelectedValue);
                    cvent.TENDV = txtTenDV.Value;
                    cvent.MOTA = txtMoTa.Value;
                    controller.Insert(cvent, ref errMsg);
                    if (errMsg == string.Empty)
                    {
                      
                        pnlAddNewSP.Visible = false;
                        LoadDataToGridView();
                        txtTenDV.Value = "";
                        txtMoTa.Value = "";
                      
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
             
            } 
            if (lblAction.Text == "update")
            {
                cls_SanPhamDichVu_entity cvent = new cls_SanPhamDichVu_entity();
                clsSanPhamDichVu_controller controller = new clsSanPhamDichVu_controller();            
               
                    cvent.IDSP = QLPHONGKHAM.Common.ConvertObj2Int(lblID_Update.Text);
                    cvent.MAPB = Int32.Parse(drplControl.SelectedValue);
                    cvent.TENDV = txtTenDV.Value;
                    cvent.MOTA = txtMoTa.Value;

                    controller.Update(cvent, ref errMsg);

                    if (errMsg == string.Empty)
                    {
                        pnlAddNewSP.Visible = false;
                        LoadDataToGridView();
                        txtTenDV.Value = "";
                        txtMoTa.Value = "";
                        
                    }
                    else
                    {
                        lblMsg.Text = "Thay đổi thông tin thất bại !";
                        lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                    }
               
            }
        }

        protected void Grv_DichVu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            cls_SanPhamDichVu_entity cvent = new cls_SanPhamDichVu_entity();
            clsSanPhamDichVu_controller controller = new clsSanPhamDichVu_controller();   
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
                    pnlAddNewSP.Visible = true;
                    LoadMaPB();

                    txtTenDV.Value = cvent.TENDV;
                    txtMoTa.Value = cvent.MOTA;

                    drplControl.SelectedValue = cvent.MAPB.ToString();

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
                    pnlAddNewSP.Visible = false;
                    LoadDataToGridView();
                    txtTenDV.Value = "";
                    txtMoTa.Value = "";
                }
                else
                {
                    lblMsg.Text = "Không thể xóa !";
                    lblMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000 ");
                }
                LoadDataToGridView();
            }
        }


    }
}