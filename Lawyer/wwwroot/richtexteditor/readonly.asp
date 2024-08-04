<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<%
	Dim rte
	Set rte=new RichTextEditor
    rte.ContentCss="example.css"
	rte.Text="This is a readonly editor."
	rte.ReadOnly = true
	rte.MvcInit()
	
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Readonly</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
</head>
<body>
       <h1>
            Readonly support</h1>
        <p>
            This example shows you can set ReadOnly property to true if you would like to display
            read-only content of Editor in some situations.
        </p>
			<%= rte.GetString()%>
</body>
</html>