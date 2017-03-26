<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucChucVu.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucChucVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"
                    Text=" Quản lý danh sách chức vụ của nhân viên" Width="456px">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvDSCV" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowPaging="true" PageSize="10" CssClass="table table-striped">
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã Chức Vụ">
                            <ItemTemplate>
                                <asp:Label ID="lblMaCV" runat="server" Text="Bind"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tên Chức Vụ">
                            <ItemTemplate>
                                <asp:Label ID="lblTenCV" runat="server" Text="Bind"></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument="BindidCV">  
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa thông tin người thu"
                                    runat="server" CommandArgument="BindidCV">  
                                </asp:LinkButton>
                               
                            </ItemTemplate>
                            <ItemStyle CssClass="text-center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
         <tr>
            <td style="width: 249px; height: 21px">
                <asp:LinkButton ID="lnkAddNewCV" runat="server" CssClass="btn btn-info" OnClick="lnkAddNewCV_Click">Thêm mới</asp:LinkButton>
            </td>
            <td style="width: 252px; height: 21px">
            </td>
            <td style="width: 169px; height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px; text-align: center">
            </td>
        </tr>
    </table>
     <div class="row">
        <div class="col-lg-12">
            <asp:Panel ID="pnlAddNewCV" runat="server" class="panel col-lg-6 col-lg-offset-3 col-md-8"
                Style="font-size: 1.2em; font-family: Arial; font-weight: bold; color: #5b5b5b;
                background-color: #fbf0d8" Visible="false">
                <div class="text-center" style="padding: 15px">
                    <asp:Label runat="server" ID="formHeader" Text="Thêm mới người thu tiền điện" CssClass="lead"
                        Style="color: #404040; font-weight: bold"></asp:Label></div>
                <table class="table">
                    <tr>
                        <td colspan="2" style="text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lbl_Ten_Nguoi_Thu" runat="server" Text="Tên người thu " CssClass="Normal_Label"></asp:Label>(<span
                                style="color: Red">*</span>):
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Ten_Nguoi_Thu" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label5" runat="server" Text="Thuộc đơn vị " CssClass="Normal_Label"></asp:Label>(<span
                                style="color: Red">*</span>):
                        </td>
                       
                      
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label2" runat="server" Text="Điểm thu " CssClass="Normal_Label"></asp:Label>(<span
                                style="color: Red">*</span>)
                        </td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="lblAction" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblID_NguoiThu" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnInsert" runat="server" Text="Ghi " Width="85px" CssClass="btn btn-success"
                              />
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy" Width="95px" CssClass="btn btn-info" OnClick="btnCancel_Click"
                              />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

