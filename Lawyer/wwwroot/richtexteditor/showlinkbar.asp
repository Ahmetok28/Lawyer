<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<%
	Dim rte
	Set rte=new RichTextEditor
    rte.ContentCss="example.css"
	Dim typ
	typ = Request.QueryString("type")
	If len(typ)>0 Then
		If typ="true" OR typ="1" Then
			rte.ShowLinkbar=true
		Else
			rte.ShowLinkbar=false
		End If
	End If       
	rte.Text="<a href=""http://www.richtexteditor.com"">RichTextEditor</a>"
	rte.MvcInit()
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Show or hide link editing box</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
    <script type="text/javascript" src="changeurlparam.js"></script>
</head>
<body>
        <h1>
            Show or hide link editing box</h1>
        <p>
            When a hyperlink is selected, a link editing box will be displayed in the editor.
            You can turn it off by setting this property to "false".
        </p>
        <div>
            <input type="radio" id="radio_2" name="type" value="true" checked="true" onclick="ChangeType(this.value);"/>
            <label for="radio_2">True</label>
            <input type="radio" id="radio_3" name="type" value="false" onclick="ChangeType(this.value);"/>
            <label for="radio_3">False</label>
        </div>
        <br/>
        <script type="text/javascript">
            function InitParams()
            {
                var pv = geturlparam("type") || "";
                //if(!pv) return;
                var radios = document.getElementsByName("type");
                for(var i=0;i<radios.length;i++)
                {
                    var radio = radios[i];
                    if(radio.value == pv)
                    {
                        radio.checked = true;
                        break;
                    }
                }
            }
            InitParams();
    
            function ChangeType(v)
            {
                changeurlparam("type", v);
            }
        </script>
        <%=rte.GetString()%>
</body>
</html>