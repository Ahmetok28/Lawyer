<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<%
	Dim rte,rte2
    Set rte=new RichTextEditor
    rte.Text="<div style='color:red;'><strong>1. Easy for developers</strong></div>"
    rte.Name="Editor1"
    rte.Height="200px"
    rte.Skin="smartblue"
    rte.Toolbar="forum"
    rte.ContentCss="example.css"
	If len(Request.Form(rte.Name))>0 Then
		rte.Text = Request.Form(rte.Name)
	End If
    rte.MvcInit()
    

	Set rte2=new RichTextEditor
    rte2.Text="<div style='color:darkgreen;'><strong>2. Seamless Integration with Web Forms</strong></div>"
    rte2.Name="Editor2"
    rte2.Height="200px"
    rte2.Skin="smartsilver"
    rte2.Toolbar="forum"
	If len(Request.Form(rte2.Name))>0 Then
		rte2.Text = Request.Form(rte2.Name)
	End If
    rte2.MvcInit()
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Multiple editors</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
</head>
<body>
	<form action="multiple_editors.asp" method="post">
        <h1>
            Multiple Editors in one page</h1>
        <p>
            This example shows how to setup multiple editors on the same page.
        </p>
		<div>
            <%= rte.GetString()%>
			<br />            
            <%= rte2.GetString()%>
			<br />
			<button type="submit">Submit</button>
		</div>
		<br />
		<div>
			<div>
				<% 
                    If len(rte.Text)>0 OR len(rte.Text)>0 Then
                   %> 
					<div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/><%=rte.Text %>
                    <br/><div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/><%=rte2.Text %>
                   <%End If
                %>
			</div>
		</div>
	</form>
</body>
</html>