<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucThongSoKyThuat.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucThongSoKyThuat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Danh Sách Thông Số Kỹ Thuật</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="Grv_TSKT" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv" OnRowCommand="Grv_TSKT_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mã Thông Số">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaTS" runat="server" Text='<%# Bind("ID")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên Dịch Vụ">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaDV" runat="server" Text='<%# Bind("TENDV")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên Thông Số">
                                <ItemTemplate>
                                    <asp:Label ID="lblTenTS" runat="server" Text='<%# Bind("TENTHONGSO") %>'></asp:Label>
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
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Thông Số"
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
                    <asp:Button ID="btnThemMoi" runat="server" Text="Thêm Mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-12 col-sm-12  col-xs-12">
            <asp:Panel ID="pnlAddNewTS" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thêm mới thông số</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#">Settings 1</a>
                                    </li>
                                    <li><a href="#">Settings 2</a>
                                    </li>
                                </ul>
                            </li>
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">

                        <br />
                        <%--   <form id="demo-form3" class="form-horizontal form-label-left"> --%>
                        <div class="form-group">
                            <label class="control-label col-md-4 col-sm-4 col-xs-12" for="Mã Dịch Vụ" runat="server" style="text-align: right">
                                Tên Dịch Vụ <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="drplControlTSKT" runat="server" CssClass="form-control col-md-7 col-xs-12">
                                </asp:DropDownList>

                            </div>
                        </div>


                        <div class="form-group">
                            <label class="control-label col-md-4 col-sm-4 col-xs-12" for="Tên Thông Số" runat="server" style="text-align: right">
                                Tên Thông Số <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">

                                <input type="text" id="txtTenTS" name="Tên Thông Số" runat="server" required="required" class="form-control col-md-7 col-xs-12">
                            </div>
                        </div>


                        <div class="clearfix"></div>
                        <div class="ln_solid"></div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-4">
                                <asp:Label ID="lblAction" runat="server" Visible="False"></asp:Label>
                                <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-primary" OnClick="btnHuy_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblID_Update" runat="server" Visible="False"></asp:Label>

                            </div>
                        </div>


                        <%-- </form> --%>
                    </div>

                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
