<!-- #include file="server_asp/aspuploader/include_aspuploader.asp" -->
<script runat="server" language="JScript" src="server_asp/rte/rteimpl.js"></script>
<script runat=server language=VBScript>

Class RichTextEditor
	
	Private internalimpl
		
	Public Property Get Impl
		If internalimpl = EMPTY Then
			Dim uploader
			Set uploader=new AspUploader
			uploader.MultipleFilesUpload=true
			Set internalimpl=RichTextEditorCreateCoreImplemenation(Me,uploader)
		End If
		Set Impl=internalimpl
	End Property
	
	
	Private Sub Class_Initialize()
		
	End Sub
		
	Public Property Get Text
		Text=Impl.GetText()
	End Property
	Public Property Let Text(val)
		Impl.SetText(val)
	End Property
	
	Public Property Get PlainText
		PlainText=Impl.GetPlainText()
	End Property
	Public Property Let PlainText(val)
		Impl.SetPlainText(val)
	End Property
	
	Public Property Get XHTML
		XHTML=Impl.GetXHTML()
	End Property
	Public Property Let XHTML(val)
		Impl.SetXHTML(val)
	End Property

	
	Public Property Get BBCode
		BBCode=Impl.GetBBCode()
	End Property
	Public Property Let BBCode(val)
		Impl.SetBBCode(val)
	End Property
	
	Public Property Get ID
		ID=Impl.Name
	End Property
	Public Property Let ID(val)
		Impl.SetName(val)
	End Property
	
	Public Property Get Name
		Name=Impl.Name
	End Property
	Public Property Let Name(val)
		Impl.SetName(val)
	End Property
	
	Public Property Get TempDirectory
		TempDirectory=Impl.LoadTempDirectory()
	End Property
	Public Property Let TempDirectory(val)
		Impl.SetTempDirectory(val)
	End Property
	
	Public Property Get Width
		Width=Impl.Width
	End Property
	Public Property Let Width(val)
		Impl.Width=val
	End Property
	
	Public Property Get Height
		Height=Impl.Height
	End Property
	Public Property Let Height(val)
		Impl.Height=val
	End Property
	
	Public Property Get LoadDelay
		LoadDelay=Impl.LoadDelay
	End Property
	Public Property Let LoadDelay(val)
		Impl.LoadDelay=val
	End Property
	
	Public Property Get RenderSupportAjax
		RenderSupportAjax=Impl.RenderSupportAjax
	End Property
	Public Property Let RenderSupportAjax(val)
		Impl.RenderSupportAjax=val
	End Property
		
	Public Property Get Skin
		Skin=Impl.Skin
	End Property
	Public Property Let Skin(val)
		Impl.Skin=val
	End Property
	
	Public Property Get Toolbar
		Toolbar=Impl.Toolbar
	End Property
	Public Property Let Toolbar(val)
		Impl.Toolbar=val
	End Property
	
	Public Property Get EnableDragDrop
		EnableDragDrop=Impl.EnableDragDrop
	End Property
	Public Property Let EnableDragDrop(val)
		Impl.EnableDragDrop=val
	End Property
	
	Public Property Get Language
		Language=Impl.Language
	End Property
	Public Property Let Language(val)
		Impl.Language=val
	End Property
	
	Public Property Get ContentCss
		ContentCss=Impl.ContentCss
	End Property
	Public Property Let ContentCss(val)
		Impl.ContentCss=val
	End Property
	
	Public Property Get ContentCssText
		ContentCssText=Impl.ContentCssText
	End Property
	Public Property Let ContentCssText(val)
		Impl.ContentCssText=val
	End Property
	
	Public Property Get PreviewCss
		PreviewCss=Impl.PreviewCss
	End Property
	Public Property Let PreviewCss(val)
		Impl.PreviewCss=val
	End Property
	
	Public Property Get PreviewCssText
		PreviewCssText=Impl.PreviewCssText
	End Property
	Public Property Let PreviewCssText(val)
		Impl.PreviewCssText=val
	End Property
	
	Public Property Get ToolbarItems
		ToolbarItems=Impl.ToolbarItems
	End Property
	Public Property Let ToolbarItems(val)
		Impl.ToolbarItems=val
	End Property
	
	Public Property Get DisabledItems
		DisabledItems=Impl.DisabledItems
	End Property
	Public Property Let DisabledItems(val)
		Impl.DisabledItems=val
	End Property
	
	Public Property Get TextDirection
		TextDirection=Impl.TextDirection
	End Property
	Public Property Let TextDirection(val)
		Impl.TextDirection=val
	End Property
	
	Public Property Get URLType
		URLType=Impl.URLType
	End Property
	Public Property Let URLType(val)
		Impl.URLType=val
	End Property
		
	Public Property Get ResizeMode
		ResizeMode=Impl.ResizeMode
	End Property
	Public Property Let ResizeMode(val)
		Impl.ResizeMode=val
	End Property
		
	Public Property Get PasteMode
		PasteMode=Impl.PasteMode
	End Property
	Public Property Let PasteMode(val)
		Impl.PasteMode=val
	End Property
		
	Public Property Get EnterKeyTag
		EnterKeyTag=Impl.EnterKeyTag
	End Property
	Public Property Let EnterKeyTag(val)
		Impl.EnterKeyTag=val
	End Property
		
	Public Property Get ShiftEnterKeyTag
		ShiftEnterKeyTag=Impl.ShiftEnterKeyTag
	End Property
	Public Property Let ShiftEnterKeyTag(val)
		Impl.ShiftEnterKeyTag=val
	End Property
		
	Public Property Get EditorMode
		EditorMode=Impl.EditorMode
	End Property
	Public Property Let EditorMode(val)
		Impl.EditorMode=val
	End Property
		
	Public Property Get FullScreen
		FullScreen=Impl.FullScreen
	End Property
	Public Property Let FullScreen(val)
		Impl.FullScreen=val
	End Property
		
	Public Property Get ToggleBorder
		ToggleBorder=Impl.ToggleBorder
	End Property
	Public Property Let ToggleBorder(val)
		Impl.ToggleBorder=val
	End Property
		
	Public Property Get ReadOnly
		ReadOnly=Impl.ReadOnly
	End Property
	Public Property Let ReadOnly(val)
		Impl.ReadOnly=val
	End Property
		
	Public Property Get DesignDocType
		DesignDocType=Impl.DesignDocType
	End Property
	Public Property Let DesignDocType(val)
		Impl.DesignDocType=val
	End Property
		
	Public Property Get SaveButtonScript
		SaveButtonScript=Impl.SaveButtonScript
	End Property
	Public Property Let SaveButtonScript(val)
		Impl.SaveButtonScript=val
	End Property
			
	Public Property Get SaveButtonMode
		SaveButtonMode=Impl.SaveButtonMode
	End Property
	Public Property Let SaveButtonMode(val)
		Impl.SaveButtonMode=val
	End Property
			
	Public Property Get ContextMenuMode
		ContextMenuMode=Impl.ContextMenuMode
	End Property
	Public Property Let ContextMenuMode(val)
		Impl.ContextMenuMode=val
	End Property
			
	Public Property Get EnableContextMenu
		EnableContextMenu=Impl.EnableContextMenu
	End Property
	Public Property Let EnableContextMenu(val)
		Impl.EnableContextMenu=val
	End Property
			
	Public Property Get EnableIEBorderRadius
		EnableIEBorderRadius=Impl.EnableIEBorderRadius
	End Property
	Public Property Let EnableIEBorderRadius(val)
		Impl.EnableIEBorderRadius=val
	End Property
			
	Public Property Get EnableAntiSpamEmailEncoder
		EnableAntiSpamEmailEncoder=Impl.EnableAntiSpamEmailEncoder
	End Property
	Public Property Let EnableAntiSpamEmailEncoder(val)
		Impl.EnableAntiSpamEmailEncoder=val
	End Property
			
	Public Property Get EnableObjectResizing
		EnableObjectResizing=Impl.EnableObjectResizing
	End Property
	Public Property Let EnableObjectResizing(val)
		Impl.EnableObjectResizing=val
	End Property
			
	Public Property Get BaseHref
		BaseHref=Impl.BaseHref
	End Property
	Public Property Let BaseHref(val)
		Impl.BaseHref=val
	End Property
			
	Public Property Get EditorBodyId
		EditorBodyId=Impl.EditorBodyId
	End Property
	Public Property Let EditorBodyId(val)
		Impl.EditorBodyId=val
	End Property
			
	Public Property Get EditorBodyClass
		EditorBodyClass=Impl.EditorBodyClass
	End Property
	Public Property Let EditorBodyClass(val)
		Impl.EditorBodyClass=val
	End Property
			
	Public Property Get EditorBodyStyle
		EditorBodyStyle=Impl.EditorBodyStyle
	End Property
	Public Property Let EditorBodyStyle(val)
		Impl.EditorBodyStyle=val
	End Property
			
	Public Property Get DisableClassList
		DisableClassList=Impl.DisableClassList
	End Property
	Public Property Let DisableClassList(val)
		Impl.DisableClassList=val
	End Property
			
	Public Property Get AutoParseClasses
		AutoParseClasses=Impl.AutoParseClasses
	End Property
	Public Property Let AutoParseClasses(val)
		Impl.AutoParseClasses=val
	End Property
			
	Public Property Get MaxHTMLLength
		MaxHTMLLength=Impl.MaxHTMLLength
	End Property
	Public Property Let MaxHTMLLength(val)
		Impl.MaxHTMLLength=val
	End Property
			
	Public Property Get MaxTextLength
		MaxTextLength=Impl.MaxTextLength
	End Property
	Public Property Let MaxTextLength(val)
		Impl.MaxTextLength=val
	End Property
			
	Public Property Get AutoFocus
		AutoFocus=Impl.AutoFocus
	End Property
	Public Property Let AutoFocus(val)
		Impl.AutoFocus=val
	End Property
			
	Public Property Get ShowRulers
		ShowRulers=Impl.ShowRulers
	End Property
	Public Property Let ShowRulers(val)
		Impl.ShowRulers=val
	End Property
				
	Public Property Get ShowEditMode
		ShowEditMode=Impl.ShowEditMode
	End Property
	Public Property Let ShowEditMode(val)
		Impl.ShowEditMode=val
	End Property
				
	Public Property Get ShowCodeMode
		ShowCodeMode=Impl.ShowCodeMode
	End Property
	Public Property Let ShowCodeMode(val)
		Impl.ShowCodeMode=val
	End Property
				
	Public Property Get ShowPreviewMode
		ShowPreviewMode=Impl.ShowPreviewMode
	End Property
	Public Property Let ShowPreviewMode(val)
		Impl.ShowPreviewMode=val
	End Property
				
	Public Property Get ShowTagList
		ShowTagList=Impl.ShowTagList
	End Property
	Public Property Let ShowTagList(val)
		Impl.ShowTagList=val
	End Property
				
	Public Property Get ShowZoomView
		ShowZoomView=Impl.ShowZoomView
	End Property
	Public Property Let ShowZoomView(val)
		Impl.ShowZoomView=val
	End Property
				
	Public Property Get ShowStatistics
		ShowStatistics=Impl.ShowStatistics
	End Property
	Public Property Let ShowStatistics(val)
		Impl.ShowStatistics=val
	End Property
				
	Public Property Get ShowResizeCorner
		ShowResizeCorner=Impl.ShowResizeCorner
	End Property
	Public Property Let ShowResizeCorner(val)
		Impl.ShowResizeCorner=val
	End Property
				
	Public Property Get ShowBottomBar
		ShowBottomBar=Impl.ShowBottomBar
	End Property
	Public Property Let ShowBottomBar(val)
		Impl.ShowBottomBar=val
	End Property
				
	Public Property Get ShowLinkbar
		ShowLinkbar=Impl.ShowLinkbar
	End Property
	Public Property Let ShowLinkbar(val)
		Impl.ShowLinkbar=val
	End Property
				
	Public Property Get ShowToolbar
		ShowToolbar=Impl.ShowToolbar
	End Property
	Public Property Let ShowToolbar(val)
		Impl.ShowToolbar=val
	End Property
				
	Public Property Get ShowCodeToolbar
		ShowCodeToolbar=Impl.ShowCodeToolbar
	End Property
	Public Property Let ShowCodeToolbar(val)
		Impl.ShowCodeToolbar=val
	End Property
				
	Public Property Get ShowPreviewToolbar
		ShowPreviewToolbar=Impl.ShowPreviewToolbar
	End Property
	Public Property Let ShowPreviewToolbar(val)
		Impl.ShowPreviewToolbar=val
	End Property
				
	Public Property Get AllowScriptCode
		AllowScriptCode=Impl.AllowScriptCode
	End Property
	Public Property Let AllowScriptCode(val)
		Impl.AllowScriptCode=val
	End Property
				
	Public Property Get UseHTMLEntities
		UseHTMLEntities=Impl.UseHTMLEntities
	End Property
	Public Property Let UseHTMLEntities(val)
		Impl.UseHTMLEntities=val
	End Property
				
	Public Property Get EditCompleteDocument
		EditCompleteDocument=Impl.EditCompleteDocument
	End Property
	Public Property Let EditCompleteDocument(val)
		Impl.EditCompleteDocument=val
	End Property
				
	Public Property Get TagWhiteList
		TagWhiteList=Impl.TagWhiteList
	End Property
	Public Property Let TagWhiteList(val)
		Impl.TagWhiteList=val
	End Property
				
	Public Property Get TagBlackList
		TagBlackList=Impl.TagBlackList
	End Property
	Public Property Let TagBlackList(val)
		Impl.TagBlackList=val
	End Property
				
	Public Property Get AttrWhiteList
		AttrWhiteList=Impl.AttrWhiteList
	End Property
	Public Property Let AttrWhiteList(val)
		Impl.AttrWhiteList=val
	End Property
					
	Public Property Get AttrBlackList
		AttrBlackList=Impl.AttrBlackList
	End Property
	Public Property Let AttrBlackList(val)
		Impl.AttrBlackList=val
	End Property
					
	Public Property Get StyleWhiteList
		AttrWhiteList=Impl.StyleWhiteList
	End Property
	Public Property Let StyleWhiteList(val)
		Impl.StyleWhiteList=val
	End Property
					
	Public Property Get StyleBlackList
		StyleBlackList=Impl.StyleBlackList
	End Property
	Public Property Let StyleBlackList(val)
		Impl.StyleBlackList=val
	End Property
					
	Public Property Get AjaxPostbackUrl
		AjaxPostbackUrl=Impl.AjaxPostbackUrl
	End Property
	Public Property Let AjaxPostbackUrl(val)
		Impl.AjaxPostbackUrl=val
	End Property
				
	Public Property Get SecurityPolicyFile
		SecurityPolicyFile=Impl.SecurityPolicyFile
	End Property
	Public Property Let SecurityPolicyFile(val)
		Impl.SecurityPolicyFile=val
	End Property
	
	Public Function SetSecurity(category,storageid,name,value)
		Impl.SetSecurity category,storageid,name,value 
	End Function
	
	Public Function SetConfig(name,value)
		Impl.SetConfig name,value 
	End Function
	
	Public Function GetString()
		GetString=Impl.GetString()
	End Function
	
	Public Function MvcInit()
		Impl.MvcInit()
	End Function
	
	Public Function ApplyFilter(val)
		ApplyFilter=Impl.ApplyFilter(val)
	End Function
	
	Public Function BBCode2HTML(val)
		BBCode2HTML=Impl.BBCode2HTML(val)
	End Function
	Public Function HTML2BBCode(val)
		HTML2BBCode=Impl.HTML2BBCode(val)
	End Function

End Class




</script>
