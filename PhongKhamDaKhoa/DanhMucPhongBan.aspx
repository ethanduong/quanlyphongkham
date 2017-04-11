<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucPhongBan.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucPhongBan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"
                    Text=" Quản lý danh sách phòng ban" Width="456px">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvDSPB" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowPaging="true" PageSize="10" CssClass="table table-striped" OnRowCommand="gvDSPB_RowCommand" OnPageIndexChanging="gvDSPB_PageIndexChanging">
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã Phòng Ban">
                            <ItemTemplate>
                                <asp:Label ID="lblMaPB" runat="server" Text='<%# Bind("MAPB")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tên Phòng Ban">
                            <ItemTemplate>
                                <asp:Label ID="lblTenCV" runat="server" Text='<%# Bind("TENPHONG")%>'></asp:Label>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("MAPB")%>' >  
                                </asp:LinkButton>
                            </ItemTemplate>
                              <ItemStyle Width="55px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Phòng Ban"
                                    runat="server" CommandArgument='<%# Bind("MAPB")%>' OnClientClick="javascript: return my_confirm();"> 
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
            </td>
        </tr>
        <tr>
            <td style="width: 249px; height: 21px">
                <asp:LinkButton ID="lnkAddNewPB" runat="server" CssClass="btn btn-info" OnClick="lnkAddNewPB_Click">Thêm mới</asp:LinkButton>
            </td>
            <td style="width: 252px; height: 21px"></td>
            <td style="width: 169px; height: 21px"></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px; text-align: center"></td>
        </tr>
    </table>
    <div class="row text-center" style="padding: 5px; font-size: 1.2em; font-weight: bold">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:Panel ID="pnlAddNewPB" runat="server" class="panel col-lg-6 col-lg-offset-3 col-md-8"
                Style="font-size: 1.2em; font-family: Arial; font-weight: bold; color: #5b5b5b; background-color: #fbf0d8"
                Visible="false">
                <div class="text-center" style="padding: 15px">
                    <asp:Label runat="server" ID="formHeader" Text="Thêm mới phòng ban" CssClass="lead"
                        Style="color: #404040; font-weight: bold"></asp:Label>
                </div>
                <table class="table">
                    <tr>
                        <td colspan="2" style="text-align: center"></td>
                    </tr>
                    
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblTenPhong" runat="server" Text="Tên Phòng Ban" CssClass="Normal_Label"></asp:Label>(<span
                                style="color: Red">*</span>):
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenPB" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAction" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnInsert" runat="server" Text="Ghi" Width="85px" CssClass="btn btn-success" OnClick="btnInsert_Click" OnClientClick="javascript: return my_confirm();"/>
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy" Width="95px" CssClass="btn btn-info" OnClick="btnCancel_Click" />
                            <asp:Label ID="lblID_Update" runat="server" Visible="False"></asp:Label>

                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
