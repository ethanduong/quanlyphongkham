<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhSachBenhNhan.aspx.cs" Inherits="PhongKhamDaKhoa.DanhSachBenhNhan" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="content_Head" ContentPlaceHolderID="headerContent" runat="server">
    <style>
        .radio-btn input[type=radio], .radio-btn label {
            cursor: pointer;
        }

        .radio-btn label {
            margin-right: 15px;
            margin-top: 8px;
            font-style: normal;
        }

        .form-group label {
        }

        .radio-btn input[type=radio] {
            width: 15px;
            height: 15px;
            margin-top: 8px;
            margin-right: 5px;
            border-color: #26B99A;
            margin-left: 10px;
        }

        .form-group label, .form-group input {
        }

        input[type='radio']:after {
            width: 15px;
            height: 15px;
            border-radius: 15px;
            top: -2px;
            left: -1px;
            position: relative;
            background-color: #d1d3d1;
            content: '';
            display: inline-block;
            visibility: visible;
            border: 2px solid white;
        }

        input[type='radio']:checked:after {
            width: 15px;
            height: 15px;
            border-radius: 15px;
            top: -2px;
            left: -1px;
            position: relative;
            background-color: #26B99A;
            content: '';
            display: inline-block;
            visibility: visible;
            border: 2px solid #d1d3d1;
        }

        .x_title {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Danh Sách Bệnh Nhân</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="Grv_BenhNhan" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã BN">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaBN" runat="server" Text='<%# Bind("MABN")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ Tên">
                                <ItemTemplate>
                                    <asp:Label ID="lblHoTen" runat="server" Text='<%# Bind("HOTEN")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày Sinh">
                                <ItemTemplate>
                                    <asp:Label ID="lblNgaySinh" runat="server" Text='<%# Eval("NGAYSINH", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giới Tính">
                                <ItemTemplate>
                                    <asp:Label ID="lblGioiTinh" runat="server" Text='<%# Bind("GIOITINH")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điện Thoại">
                                <ItemTemplate>
                                    <asp:Label ID="lblDienThoai" runat="server" Text='<%# Bind("DIENTHOAI")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chiều Cao (Cm)">
                                <ItemTemplate>
                                    <asp:Label ID="lblChieuCao" runat="server" Text='<%# Bind("CHIEUCAO")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cân Nặng (Kg)">
                                <ItemTemplate>
                                    <asp:Label ID="lblCanNang" runat="server" Text='<%# Bind("CANNANG")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tiền Sử">
                                <ItemTemplate>
                                    <asp:Label ID="lblTienSu" runat="server" Text='<%# Bind("TIENSU")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("MABN")%>'>  
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="55px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Bệnh Nhân"
                                        runat="server" CommandArgument='<%# Bind("MABN")%>' OnClientClick="javascript: return my_confirm();"> 
                                    </asp:LinkButton>
                                    <script>
                                        function my_confirm() {
                                            var result = confirm("Bạn có chắc chắn không?");
                                            if (result) {
                                                return true;
                                            }
                                            return false;
                                        }
                                    </script>

                                </ItemTemplate>
                                <ItemStyle Width="55px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnThemMoi" runat="server" Text="Thêm Mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" UseSubmitBehavior="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <asp:Panel ID="PnlThemMoi" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thông Tin Bệnh Nhân</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            </li>
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                    <div class="x_content">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                        </asp:UpdatePanel>
                        <div class="form-horizontal form-label-left form">
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="HoTen">
                                    Họ Tên <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="HoTen" runat="server" required="required" class="form-control col-md-7 col-xs-12" data-validate-length-range="6,100"></asp:TextBox>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="NgaySinh">
                                    Ngày Sinh <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox class="form-control has-feedback-left" ID="single_cal3" ClientIDMode="Static" aria-describedby="inputSuccess2Status3" runat="server" required="required"></asp:TextBox>
                                    <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                    <span id="inputSuccess2Status3" class="sr-only">(success)</span>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="col-md-3 col-sm-3 col-xs-12 control-label">
                                    Giới Tính                                                
                                </label>
                                <div class="col-md-9 col-sm-9 col-xs-12 rdb">
                                    <asp:RadioButtonList ID="rdbgGioiTinh" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radio-btn">
                                        <asp:ListItem Text="Nam" Value="true" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Nữ" Value="false"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Chiều Cao (Cm)</label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtChieuCao" runat="server" type="number" Style="padding-left: 10px" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Cân Nặng (Kg)
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtCanNang" runat="server" type="number" Style="padding-left: 10px" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">
                                    Điện Thoại <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtDienThoai" type="tel" runat="server" name="phone" required="required" data-validate-length-range="8,11" Style="padding-left: 10px" class="form-control col-md-7 col-xs-12" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="item form-group">
                                <div class="control-label col-md-3 col-sm-3 col-xs-12"></div>
                                <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 btn">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu thông tin" CssClass="btn btn-primary" OnClick="btnLuu_Click" />
                                    <asp:Button ID="btnXoa" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btnXoa_Click"/>                                     
                                    <asp:Label ID="lblAction" runat="server" Text=""></asp:Label>    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
<asp:Content ContentPlaceHolderID="contentFooter" runat="server" ID="contentfoot">
    <!-- validator -->
    <script src="vendors/validator/validator.js"></script>
    <script>        
       
    </script>
</asp:Content>
