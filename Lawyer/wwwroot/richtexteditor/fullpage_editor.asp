<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<%
	Dim rte
    Set rte=new RichTextEditor
    htmltext = ""    
    rte.Name = "Editor1"
    rte.ContentCss="example.css"
    rte.TagBlackList=""
    rte.StyleBlackList="" 
    rte.AllowScriptCode=true
    rte.EditCompleteDocument=true
    rte.Text = "<html> <head></head><body> <p>Rich Text Editor: Editing full page</p><p style='font-weight:bold'>Editor1.AllowScriptCode = true;<br />Editor1.EditCompleteDocument = true;<br /> Editor1.TagBlackList = &quot;&quot;;</p></body></html>"
    If len(Request.Form(rte.Name))>0 Then
		rte.Text = Request.Form(rte.Name)
		htmltext = rte.Text
	End If	
	rte.MvcInit()

%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Edit full html</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
</head>
<body>
	<form action="fullpage_editor.asp" method="post">
        <h1>
		    Edit full html page</h1>
	    <p>
		    This example demonstrates you can use RichTextEditor to edit full html page.
	    </p>
        <div>            
            <%= rte.GetString()%>
            <br/>
		    <button type="submit">Submit</button>
        </div>
        <br/>
        <h3>HTML Code:</h3>
		<textarea style="height:120px;width:760px;"><%= htmltext %></textarea>
    </form>
</body>
</html>