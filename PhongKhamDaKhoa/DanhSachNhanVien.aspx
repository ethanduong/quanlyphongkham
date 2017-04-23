<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhSachNhanVien.aspx.cs" Inherits="PhongKhamDaKhoa.DanhSachNhanVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Danh Sách Bệnh Nhân</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="Grv_NhanVien" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv" OnRowCommand="Grv_BenhNhan_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
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
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chức Vụ">
                                <ItemTemplate>
                                    <asp:Label ID="lblChieuCao" runat="server" Text='<%# Bind("TEN")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phòng ban">
                                <ItemTemplate>
                                    <asp:Label ID="lblCanNang" runat="server" Text='<%# Bind("TENPHONG")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điện Thoại">
                                <ItemTemplate>
                                    <asp:Label ID="lblDienThoai" runat="server" Text='<%# Bind("DIENTHOAI")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ảnh đại diện">
                                <ItemTemplate>
                                    <asp:Image ID="Img_NhanVien" runat="server" ImageUrl='<%# Bind("FILE_NAME")%>' CssClass="img-responsive" Height="80px" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("MANV")%>'>  
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="55px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Bệnh Nhân"
                                        runat="server" CommandArgument='<%# Bind("MANV")%>' OnClientClick="javascript: return my_confirm();"> 
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
                    <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" UseSubmitBehavior="False" />
                    <br />
                    <asp:Label ID="lblMsgCheck" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <asp:Panel ID="PnlThemMoi" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thông Tin Nhân viên</h2>
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
                        <div class="form-horizontal form-label-left">
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="HoTen">
                                    Họ Tên <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtHoTen" runat="server" required="required" class="form-control col-md-7 col-xs-12" data-validate-length-range="6,100"></asp:TextBox>
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
                                <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Chức vụ</label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList ID="DrlChucVu" runat="server" class="form-control col-md-7 col-xs-12"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Phòng ban
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList ID="DrlPhongBan" runat="server" class="form-control col-md-7 col-xs-12"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">
                                    Điện Thoại 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtDienThoai" type="tel" runat="server" name="phone" required="required" Style="padding-left: 10px" class="form-control col-md-7 col-xs-12" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Ảnh đại diện 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:FileUpload ID="Img_Upload" runat="server" />
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="item form-group">
                                <div class="control-label col-md-3 col-sm-3 col-xs-12"></div>
                                <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 btn">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu thông tin" CssClass="btn btn-primary" OnClick="btnLuu_Click" />
                                    <button type="reset" class="btn btn-danger">Hủy </button>
                                    <asp:Label ID="lblAction" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblIDUpdate" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentFooter" runat="server">
</asp:Content>
