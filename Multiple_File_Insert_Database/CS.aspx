﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }

        table
        {
            border: 1px solid #ccc;
        }

        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }

        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
            <hr />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="File Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
