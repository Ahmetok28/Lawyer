<%@  language="VBScript" %>
<!-- #include file="richtexteditor/include_rte.asp" -->
<% 
	Dim rte
	Set rte=new RichTextEditor   
    rte.ContentCss="example.css"     
	Dim typ
	typ = Request.QueryString("type")
	If len(typ)>0 Then
		If  typ="html" Then
			rte.MaxHTMLLength=100
		End If
		If typ="text" Then
			rte.MaxTextLength=100
		End If
	End If       
	rte.Text="Type here"
	rte.MvcInit()
	
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Setting the max length</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
	<meta content="text/html" charset="utf-8" />
    <script type="text/javascript" src="changeurlparam.js"></script>
</head>
<body>
        <h1>
			Use MaxHTMLLength or MaxTextLength to Protect Your Database</h1>
		<p>
			We often use a database backend such as <a target="_blank" href="http://www.microsoft.com/sql/">
				SQL Server</a> to store data. In such databases, you have to specify the length
			of any textual field when a table is designed. If you tried to insert a record whose
			text length is greater than allowed by your table, an error will be reported.
			<br />
			<br />
			To prevent this type of error from occurring, developers can use <strong>MaxHTMLLength</strong>
			or <strong>MaxTextLength</strong> in the RichTextEditor to limit the length of the
			user's input.
		</p>
        <div>
            <input type="radio" id="radio_1" name="type" value="" checked="true" onclick="ChangeType(this.value);"/>
            <label for="radio_2">Non-limit</label>
            <input type="radio" id="radio_2" name="type" value="html" onclick="ChangeType(this.value);"/>
            <label for="radio_2">MaxHTMLLength : 100</label>
            <input type="radio" id="radio_3" name="type" value="text" onclick="ChangeType(this.value);"/>
            <label for="radio_3">MaxTextLength : 100</label>
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
        <%= rte.GetString()%>
</body>
</html>