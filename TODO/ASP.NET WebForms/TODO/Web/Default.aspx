<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" language="javascript" src="/Scripts/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" language="javascript" src="/Scripts/jquery.ui.js"></script>
    <script type="text/javascript" language="javascript" src="/Scripts/app.js"></script>
    <script type="text/javascript" language="javascript" src="/Scripts/app.functions.js"></script>
    <link rel="stylesheet" href="/Styles/jquery-ui.css" />
    <title>TODO</title>
</head>
<body>
    <div id="dvSearch" align="right">
        <span>search: <input type="text" id="txtSearch" /></span>
    </div>
    <div id="dvTasks">
        <span>Task: <input type="text" id="txtTask" /></span><input type="button" id="btnOk" value="ok" />
        <ul id="lstTasks"></ul>
    </div>
  
</body>
</html>
