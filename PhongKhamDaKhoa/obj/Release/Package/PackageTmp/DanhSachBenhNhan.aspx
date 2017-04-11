<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhSachBenhNhan.aspx.cs" Inherits="PhongKhamDaKhoa.DanhSachBenhNhan" %>

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
                            <asp:TemplateField HeaderText="Mã Bệnh Nhân">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaBN" runat="server" Text='<%# Bind("MABN")%>'></asp:Label>
                                </ItemTemplate>

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
                            <asp:TemplateField HeaderText="Chiều Cao">
                                <ItemTemplate>
                                    <asp:Label ID="lblChieuCao" runat="server" Text='<%# Bind("CHIEUCAO")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cân Nặng">
                                <ItemTemplate>
                                    <asp:Label ID="lblCanNang" runat="server" Text='<%# Bind("CANNANG")%>'></asp:Label>
                                </ItemTemplate>
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
                    <asp:Button ID="btnThemMoi" runat="server" Text="Button" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
