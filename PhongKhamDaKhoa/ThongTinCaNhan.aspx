<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="PhongKhamDaKhoa.ThongTinCaNhan" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12  col-xs-12">

            <div class="x_panel">
                <div class="x_title">
                    <h2>Thông tin cá nhân</h2>
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
                        <label class="control-label col-md-4 col-sm-4 col-xs-12" runat="server" style="text-align: right">
                            Họ Và Tên <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <input type="text" id="txtHoTen" name="Tên User" runat="server" class="form-control col-md-7 col-xs-12" disabled="disabled">
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="control-label col-md-4 col-sm-4 col-xs-12"  runat="server" style="text-align: right">
                            UserName <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">

                            <input type="text" id="txtUsername" name="Username" runat="server" required="required" class="form-control col-md-7 col-xs-12" disabled="disabled">
                        </div>
                    </div>

                    <div class=" form-group">
                        <label class="control-label col-md-4 col-sm-4 col-xs-12" runat="server" style="text-align: right">PassWord<span class="required">*</span></label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <input id="txtPass" class="form-control col-md-7 col-xs-12" required="required" type="password" name="Pass" runat="server" disabled="disabled">
                        </div>
                    </div>
                     <div class="item form-group">
                                <label class="control-label col-md-4 col-sm-4 col-xs-12">
                                    Ảnh đại diện 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:FileUpload ID="Img_Upload" runat="server" Enabled="false"  />
                                </div>
                            </div>
                    <div class="clearfix"></div>
                    <div class="ln_solid"></div>
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-4">
                            <asp:Label ID="lblAction" runat="server" Visible="False"></asp:Label>
                            <asp:Button ID="btnSua" runat="server" Text="Sửa" CssClass="btn btn-primary" OnClick="btnSua_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
                            <asp:Button ID="btnSubmit" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblID_Update" runat="server" Visible="False"></asp:Label>

                        </div>
                    </div>


                    <%-- </form> --%>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
