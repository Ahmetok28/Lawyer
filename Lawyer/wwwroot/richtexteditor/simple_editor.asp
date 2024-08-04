<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<%
	Dim rte,rte2,rte3,rte4

    Set rte=new RichTextEditor
    rte.Text="Type here"
    rte.Name="Editor1"
    rte.Height="200px"
    rte.Skin="officexpsilver"
    rte.Toolbar="minimal"
    rte.MvcInit()
    

    Set rte2=new RichTextEditor
    rte2.Text="Type here"
    rte2.Name="Editor2"
    rte2.Height="200px"
    rte2.Skin="officexpblue"
    rte2.Toolbar="email"
    rte2.MvcInit()
    rte2.RenderSupportAjax=false

%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Default Toolbar Config</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
</head>
<body>
		<h1>
			Simple Configuration example</h1>
		<p>
			This example shows the simple Configuration of editor.
		</p>
        <%= rte.GetString()%>
		<br />
        <%= rte2.GetString()%>
</body>
</html>