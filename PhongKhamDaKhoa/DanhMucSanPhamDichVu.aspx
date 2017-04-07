<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucSanPhamDichVu.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucSanPhamDichVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Danh Sách Dịch Vụ</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="Grv_DichVu" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv">
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

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã Dịch Vụ">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaDV" runat="server" Text='<%# Bind("ID_SP")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tên Dịch Vụ">
                                <ItemTemplate>
                                    <asp:Label ID="lblTenDV" runat="server" Text='<%# Bind("TENDV") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mô tả">
                                <ItemTemplate>
                                    <asp:Label ID="lblMoTa" runat="server" Text='<%# Bind("MOTA")%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_edit" CommandName="cmdEdit" Text="Sửa" runat="server" CommandArgument='<%# Bind("ID_SP")%>'>  
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="55px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Dịch Vụ"
                                        runat="server" CommandArgument='<%# Bind("ID_SP")%>' OnClientClick="javascript: return my_confirm();"> 
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


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <asp:Panel ID="pnlAddNewSP" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thêm mới dịch vụ</h2>
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


                        <form id="demo-form3" class="form-horizontal form-label-left">

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Mã Phòng Ban" runat="server">
                                    Mã Phòng Ban <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList ID="drplControl" runat="server" CssClass="form-control input-sm">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Tên Dịch Vụ" runat="server">
                                    Tên Dịch Vụ <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">

                                    <input type="text" id="txtTenDV" name="Tên Dịch Vụ" runat="server"  class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label for="Mô Tả" class="control-label col-md-3 col-sm-3 col-xs-12" runat="server">Mô Tả</label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtMoTa" class="form-control col-md-7 col-xs-12" type="text" name="Mô Tả" runat="server">
                                </div>
                            </div>

                            <div class="ln_solid"></div>
                            <div class="item form-group">
                                <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-primary" OnClick="btnHuy_Click" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />

                                    <button type="submit" class="btn btn-success" id="btnSubmit">Submit</button>
                                </div>
                            </div>

                          
                        </form>
                    </div>

                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
