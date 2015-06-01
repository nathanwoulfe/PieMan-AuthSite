<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OAuth.aspx.cs" Inherits="Auth" %>

<!DOCTYPE html>
<html>
    <head>
        <title>PieMan oAuth</title>
        <link rel="stylesheet" href="/css/umbraco.css" />
        
        <style>

            header {
                background:#1d1d1d;
                padding:15px 15px 7px;
                margin-bottom:15px;
            }

            section {
                padding:15px;
            }

            h1 {
                margin:0;
                color:#d9d9d9;
            }

            h1 span {
                color:#df7f48;
            }

            h2 {
                margin:-5px 0 0;
                text-transform:uppercase;
                font-size:18px;
                color:#d9d9d9;
            }

            p:last-of-type {
                margin-bottom:30px;
            }
            .btns {
                text-align:right;
                border-top:1px solid #eee;
                padding-top:15px;
                margin-top:15px;
            }

        </style>
    </head>
    <body>
        <form runat="server">
            <div class="authcontainer">
                <header>
                    <h1>
                        <span class="icon-pie-chart"></span>
                        PieMan
                    </h1>
                    <h2>Simple analytics for Umbraco</h2>
                </header>
                <section>
                    <p>For PieMan to deliver piping hot stats, it needs access to the Google Analytics account linked to this website.</p>
                    <p>PieMan stores only the bare essentials to fill your analytics appetite.</p>
                    <div class="btns">
                        <asp:Hyperlink ID="link" Text="Sign in" runat="server" CssClass="btn btn-success" />
                        <button class="btn" onclick="window.close()">Close</button>
                    </div>
                </section>
            </div>
        </form>
    </body>
</html>