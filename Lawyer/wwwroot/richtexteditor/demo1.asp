<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<%
Dim editor
Set editor=new RichTextEditor

editor.MvcInit()

%>
<html>
<head>
	<title>Demo 1 - use SaveDirectory property</title>
</head>
<body>
	<div>
		<%=editor.GetString() %>
	</div>
</body>
</html>
