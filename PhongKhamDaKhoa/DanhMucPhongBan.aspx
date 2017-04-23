<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucPhongBan.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucPhongBan" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContent" runat="server">
    <style>
        .dataTables_filter {
            width: 100%;
            float: right;
            text-align: right;
        }

        .panel_toolbox > li {
            float: right;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-8 col-md-10 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Danh Sách Phòng ban</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="gvDSPB" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv" OnRowCommand="gvDSPB_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="60px"/>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Tên phòng ban">
                                <ItemTemplate>
                                    <asp:Label ID="lblTenPB" runat="server" Text='<%# Bind("TENPHONG") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("MAPB")%>'>  
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="55px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Phòng ban"
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
                    <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                    <br />
                    <asp:Label ID="lblMsgCheck" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>
    <div class="row">
        <div class="col-lg-8 col-md-10 col-sm-12 col-xs-12">
            <asp:Panel ID="pnlAddNewPB" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thêm mới Phòng ban</h2>
                        <ul class="nav navbar-right panel_toolbox text-right">
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">

                        <br />
                        <%--   <form id="demo-form3" class="form-horizontal form-label-left"> --%>


                        <div class="form-group">
                            <label class="control-label col-md-4 col-sm-4 col-xs-12" for="Tên phòng ban" runat="server" style="text-align: right">
                                Tên phòng ban <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtTenPB" runat="server" required="required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                <asp:Label ID="lblAction" runat="server" Visible="False"></asp:Label>                                                               
                                <asp:Button ID="btnSubmit" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                <button type="reset" class="btn btn-danger">Hủy</button>
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
