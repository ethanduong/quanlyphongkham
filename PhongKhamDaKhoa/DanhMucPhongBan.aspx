<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucPhongBan.aspx.cs" Inherits="PhongKhamDaKhoa.DanhMucPhongBan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Danh Sách Phòng Ban</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="gvDSPB" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered grv" OnRowCommand="gvDSPB_RowCommand">
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
                          

                            <asp:TemplateField HeaderText="Tên Phòng Ban">
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
                                    <asp:LinkButton ID="link_del" CommandName="cmdDelete" Text="Xóa" ToolTip="Xóa Thông Tin Phòng Ban"
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
                    <asp:Button ID="btnThemMoi" runat="server" Text="Thêm Mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                </div>
            </div>
        </div>
    </div>

         <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-12 col-sm-12  col-xs-12">
            <asp:Panel ID="pnlAddNewPB" runat="server" Visible="false">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Thêm mới phòng ban</h2>
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
                           

                        <div class="form-group" >
                            <label class="control-label col-md-4 col-sm-4 col-xs-12" for="Tên Phòng Ban" runat="server"  style="text-align:right">
                                Tên Phòng Ban <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">

                                <input type="text" id="txtTenPB" name="Tên Phòng Ban" runat="server" required="required" class="form-control col-md-7 col-xs-12">
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
