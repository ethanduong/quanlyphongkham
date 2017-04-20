<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuanTriVien.aspx.cs" Inherits="PhongKhamDaKhoa.QuanTriVien" %>
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
                    <asp:GridView ID="Grv_USER" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv" OnRowCommand="Grv_USER_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Tên Đăng Nhập">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("USERNAME") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>                                                        
                            <asp:TemplateField HeaderText="Phòng Ban">
                                <ItemTemplate>
                                    <asp:Label ID="lblCanNang" runat="server" Text='<%# Bind("TENPHONG")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên Nhân Viên">
                                <ItemTemplate>
                                    <asp:Label ID="lblHoTen" runat="server" Text='<%# Bind("HOTEN") %>'></asp:Label>
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
                                    <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("ID")%>'>  
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="55px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Bệnh Nhân"
                                        runat="server" CommandArgument='<%# Bind("ID")%>' OnClientClick="javascript: return my_confirm();"> 
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
                        <h2>Thông Tin Người Sử Dụng</h2>
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
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Tên Đăng Nhập
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Mật Khẩu
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                </div>
                            </div>                                                        
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Phòng Ban
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DrlPhongBan" runat="server" class="form-control col-md-7 col-xs-12" OnSelectedIndexChanged="DrlPhongBan_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" DataTextField="" DataValueField="-1">
                                                <asp:ListItem>-- Chọn phòng ban --</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>                                        
                                    </asp:UpdatePanel>
                                    
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Nhân Viên
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DrdlNhanVien" runat="server" class="form-control col-md-7 col-xs-12"></asp:DropDownList>
                                        </ContentTemplate>                                        
                                    </asp:UpdatePanel>                                    
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
