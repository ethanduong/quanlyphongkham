<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucChucVu.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucChucVu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContent" runat="server">
    <style>
        .dataTables_filter {
            width: 100%;
            float: right;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-8 col-md-10 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_title">
                        <h2>Danh Sách Chức Vụ</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <asp:GridView ID="gvDSCV" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv" OnRowCommand="gvDSCV_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="STT">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="text-center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mã Chức Vụ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaCV" runat="server" Text='<%# Bind("MACV")%>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" />
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Tên Chức Vụ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenCV" runat="server" Text='<%# Bind("TEN") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center" />
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("MACV")%>'>  
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="55px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Chức Vụ"
                                            runat="server" CommandArgument='<%# Bind("MACV")%>' OnClientClick="javascript: return my_confirm();"> 
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
                        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                        <br />
                        <asp:Label ID="lblMsgCheck" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>
    <div class="row">
        <div class="col-lg-8 col-md-10 col-sm-12  col-xs-12">
            <asp:Panel ID="pnlAddNewCV" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thêm mới chức vụ</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">

                        <br />
                        <%--   <form id="demo-form3" class="form-horizontal form-label-left"> --%>


                        <div class="form-group">
                            <label class="control-label col-md-4 col-sm-4 col-xs-12" for="Tên Chức Vụ" runat="server" style="text-align: right">
                                Tên Chức Vụ <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtTenCV" runat="server" required="" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                <asp:Label ID="lblAction" runat="server" Visible="False"></asp:Label>                                
                                <asp:Button ID="btnSubmit" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSubmit_Click" />                                
                                <button type="reset" class="btn btn-primary">Hủy</button>                                
                                <asp:Label ID="lblID_Update" runat="server" Visible="False"></asp:Label>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <%-- </form> --%>
                    </div>

                </div>
            </asp:Panel>
        </div>
    </div>

</asp:Content>

