<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhongKhamDaKhoa.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="css/custom.min.css" rel="stylesheet" />
    <link href="css/master.css" rel="stylesheet" />
    <style>
        .login_content .form input[type=text], .login_content .form input[type=email], .login_content .form input[type=password] {
            border-radius: 3px;
            -ms-box-shadow: 0 1px 0 #fff,0 -2px 5px rgba(0,0,0,.08) inset;
            -o-box-shadow: 0 1px 0 #fff,0 -2px 5px rgba(0,0,0,.08) inset;
            box-shadow: 0 1px 0 #fff, 0 -2px 5px rgba(0,0,0,.08) inset;
            border: 1px solid #c8c8c8;
            color: #777;
            margin: 0 0 20px;
            width: 100%;
        }

        :-webkit-any(article,aside,nav,section) h1 {
            font-size: 1.5em;
            -webkit-margin-before: 0.5em;
            -webkit-margin-after: 0.5em;
        }
    </style>
</head>
<body class="login">
    <form id="form1" runat="server">
        <a class="hiddenanchor" id="signup"></a>
        <a class="hiddenanchor" id="signin"></a>

        <div class="login_wrapper">
            <div class="animate form login_form">
                <section class="login_content">
                    <div class="form">
                        <h1>Đăng Nhập Tài Khoản</h1>
                        <div>
                            <asp:TextBox ID="txtUsername" class="form-control" runat="server" placeholder="Tên Đăng Nhập" required=""></asp:TextBox>
                        </div>
                        <div>
                            <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Mật Khẩu" required=""></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="btnSubmit" class="btn btn-default submit" runat="server" Text="Đăng nhập" OnClick="btnSubmit_Click" />
                        </div>

                        <div class="clearfix"></div>

                        <div class="separator">
                            <div class="clearfix"></div>
                            <br />

                            <div>
                                <h1><i class="fa fa-paw"></i> Medical Info !</h1>
                                <p>©2017 Team5</p>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>

    </form>
</body>
</html>
