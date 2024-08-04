<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" --> 
<%
	Dim rte
	Set rte=new RichTextEditor
	editortext = ""
	rte.Name = "Editor1"
    rte.ContentCss="example.css"
	rte.Text="<table cellspacing=""4"" cellpadding=""4"" border=""0""><tr><td><p><img src=""http://www.richtexteditor.com/uploads/j0262681.jpg"" alt="""" /></p></td> <td> <p>When your algorithmic and programming skills have reached a level which you cannot improve any further, refining your team strategy will give you that extra edge you need to reach the top. We practiced programming contests with different team members and strategies for many years, and saw a lot of other teams do so too.</p></td></tr> <tr> <td> <p> <img src=""http://www.richtexteditor.com/uploads/PH02366J.jpg"" alt="""" /></p></td> <td> <p>From this we developed a theory about how an optimal team should behave during a contest. However, a refined strategy is not a must: The World Champions of 1995, Freiburg University, were a rookie team, and the winners of the 1994 Northwestern European Contest, Warsaw University, met only two weeks before that contest.</p></td></tr></table>"	
	If len(Request.Form(rte.Name))>0 Then
		rte.Text = Request.Form(rte.Name)
	End If
	rte.MvcInit()
	
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - XHTML Output</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
</head>
<body>
	<form method="post" action="output_xhtml.asp">
       <h1>
            Support output well-formed HTML and XHTML</h1>
        <p>
            This example show you RichTextEditor supports output well-formed XHTML. Your choice
			of XHTML 1.0 or HTML 4.01 output.
        </p>
        <div>            
            <%= rte.GetString()%>
            <br/>
		    <button type="submit">Submit</button>
        </div>
        <br/>
        <h3>XHTML:</h3>
		<textarea style="height:120px;width:760px;"><%
                                                    If len(Request.Form(rte.Name))>0 Then
                                                   %> <%=rte.XHTML%>
                                                   <%
													End If
						%></textarea>
    </form>
</body>
</html>