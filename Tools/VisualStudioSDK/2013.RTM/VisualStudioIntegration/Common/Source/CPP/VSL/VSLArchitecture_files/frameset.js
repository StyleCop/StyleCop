
var MSIE = false;
var ver = 0;
var indexOfMSIE = navigator.userAgent.indexOf("MSIE"); 
if(indexOfMSIE != -1)
{
	MSIE = true;
	ver = parseFloat(navigator.userAgent.substring(indexOfMSIE + 5, navigator.userAgent.indexOf(";", indexOfMSIE)));
}

var isMac = (navigator.appVersion.indexOf("Macintosh") >= 0);
var isUpLevel = (MSIE && ver >= 5 && !isMac);

var xmlData = XMLData("VSLArchitecture_files/data.xml");

var g_RowStyleList = new  Array(
 "propViewerEvenRow",
 "propViewerOddRow"
);


var strShape	= "Shape Name:";



function XMLData(file)
{
	var temp = null;
	if(isUpLevel)
	{
		temp = CreateObject("Microsoft.XMLDOM");
		if (temp == null)
		{
			temp = CreateObject("MSXML2.DOMDocument");
		}

		if (temp != null)
		{
			temp.async = false;
		
			temp.load(file);
			if (temp.parseError.errorCode != 0)
			{
				temp = null;
			}
		}
	}

	return temp;
}

function CreateObject (strObj)
{
	var obj = null;
	eval ("try { obj = new ActiveXObject(strObj); } catch (e) {}");
	return obj;
}

function doVersion()
{
	if(isUpLevel)
	{
		frmToolbar.divDownLevel.innerHTML = "";
		frmToolbar.divUpLevel.innerHTML = frmWidgets.divData.innerHTML;
	}
}	
	
	
function FindShapeXML (pageID, shapeID)
{
	var shapeObj = null;

	if (xmlData != null)
	{
		var pagesObj = xmlData.selectSingleNode("VisioDocument/Pages");
		if(!pagesObj)
		{
			return null;
		}

		var pageQuerryString = './/Page[@ID = "' + pageID + '"]';
		var pageObj = pagesObj.selectSingleNode(pageQuerryString);
		if(pageObj == null)
		{
			return null;
		}

		var shapeQuerryString = './/Shape[@ID = "' + shapeID + '"]';
		shapeObj = pageObj.selectSingleNode(shapeQuerryString);
	}

	return shapeObj;
}

function OnShapeKey(pageID, shapeID)
{
	var e = window.frmDrawing.event;
	
	if(e.keyCode == 13 && e.ctrlKey)		//ctrl + enter
	{
		UpdateProps (pageID, shapeID);
	}
	else if (e.keyCode == 13)
	{
		OnShapeClick (pageID, shapeID);
	}
}

function OnShapeClick (pageID, shapeID)
{
	if (isUpLevel)
	{
		var e = frmDrawing.window.event;
		var elem = e.srcElement;

		if (e != null && e.ctrlKey && frmToolbar.widgets && frmToolbar.widgets.Details)
		{
			UpdateProps (pageID, shapeID);
		}
		else
		{
			var shapeNode = FindShapeXML (pageID, shapeID);
			var hlObj = GetHLAction (shapeNode, pageID, shapeID);
			if (hlObj != null)
			{
				if (hlObj.DoFunction.length > 0)
				{
					eval (hlObj.DoFunction);
				}
				else if (hlObj.Hyperlink.length > 0)
				{
					if (hlObj.NewWindow)
					{
						window.open (hlObj.Hyperlink);
					}
					else
					{
						top.location.href = hlObj.Hyperlink.substr (0, 510);
					}
				}
				else if (elem != null)
				{
					var href = elem.origHref;
					if (href == null)
					{
						href = elem.href;
					}

					var target = elem.origTarget;
					if (target == null)
					{
						target = elem.target;
					}

					if (href && href.length > 0)
					{
						href = HTMLEscape (href);
						if (target && target == "_blank")
						{
							window.open (href);
						}
						else
						{
							top.location.href = href.substr (0, 510);
						}
					}
				}
			}
		}
	}

	return (!isUpLevel);
}

function UpdateProps(pageID, shapeID)
{
	var shape = FindShapeXML (pageID, shapeID);

	FillPropPane(shape, frmToolbar.hideDetails);
}

function UpdatePropsByShapeName(pageName, shapeName)
{
	var shape = FindShapeXMLByName (pageName, shapeName);

	FillPropPane(shape, frmToolbar.hideDetails);
}

function FillPropPane (shapeNode, outputDivObj )
{
	if (shapeNode != null && outputDivObj != null)
	{
		if(outputDivObj.style.display == "none")
		{
			frmToolbar.ToggleWidget(outputDivObj);
		}
	
		var strCPHTML = "";
		
		var shapeNameAttr = shapeNode.attributes.getNamedItem ("Name");
		if (shapeNameAttr)
		{
			strCPHTML += "<span class='p2' style='padding-left:2px;'>" + strShape + " " + HTMLEscape(shapeNameAttr.text) + "</span>";
		}

		var strTableHTML = CreatePropTable (shapeNode);
		if(strTableHTML.indexOf("<table") == -1)
		{
			strTableHTML = "<p class='p2' style='margin-left:1em;margin-top:0em;'>" + strTableHTML + "</p>";
		}

		if (strTableHTML.length > 0)
		{
			strCPHTML += strTableHTML;
		}
		else
		{
			strCPHTML = strNoCustomPropertiesToDisplayText;
		}
		
		outputDivObj.innerHTML = strCPHTML;
		outputDivObj.minHeight = 75;
	}
}

function CreatePropTable (shapeNode)
{
	var strCPHTML = "";
	var strStartTable = "<table class='propViewerTABLE' borderColor='#999999' cellPadding='2' width='95%' border='1' summary='This table contains shape details'>";
		strStartTable += "<THEAD class='propViewerTHEAD'><TH>Label</TH><TH>Value</TH></THEAD>";
	var strEndTable = "</TABLE>";

	if (shapeNode != null)
	{
		var propColl = shapeNode.selectNodes ("Prop");

		var propCount = propColl.length;
		for (var count = 0; count < propCount; count++)
		{
			strCPHTML += "<TR class='" + g_RowStyleList[count % 2] + "'>";
			
			var strLabelText = "";
			oPropLabel = propColl.item(count).selectSingleNode("Label/textnode()");
			if (oPropLabel != null)
			{
				strLabelText = HTMLEscape (oPropLabel.text);
			}
			else
			{
				oPropName = propColl.item(count).attributes.getNamedItem ("Name");
				if (oPropName)
				{
					strLabelText = HTMLEscape (oPropName.text);
				}
			}

			if (strLabelText.length > 0)
			{
				strCPHTML += "<TD class='propViewerTD'>" + strLabelText + "</TD>";
				strCPHTML += "<TD class='propViewerTD'>"

				var strValueText = "&nbsp;";
				oPropValue = propColl.item(count).selectSingleNode("Value/textnode()");
				if (oPropValue)
				{
					strValueText = HTMLEscape (oPropValue.text);
				}

				strCPHTML += strValueText + "</TD></TR>";
			}
		}

		if(strCPHTML != "")
		{
			strCPHTML = strStartTable + strCPHTML + strEndTable;
		}
		else
		{
			strCPHTML = "No Details Available.";
		}
	}

	return strCPHTML;
}

function keyHandler()
{
	var e = frmDrawing.window.event;
	if(e.keyCode == 13) //enter
	{
		e.srcElement.click();
	}
}

function GoToPage(index)
{
	if (viewMgr)
	{
		viewMgr.loadPage (index);
	}
	else
	{
		DefPageLoad (index);
	}
}

function GoToPageByID(pageID)
{
	var pageIndex = PageIndexFromID (pageID);
	if (pageIndex >= 0)
	{
		GoToPage (pageIndex);
	}
}

function PageIndexFromID (pageID)
{
	if (g_FileList != null)
	{
		var entry;

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			if (pageID == g_FileList[count].PageID)
			{
				return count;
			}
		}
	}
	return -1;
}

function PageIndexFromName (strPageName)
{
	if (g_FileList != null)
	{
		var entry;

		var strPageNameLower = strPageName;
		strPageNameLower = strPageNameLower.toLowerCase ();

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			var strFileListPageName = g_FileList[count].PageName;
			strFileListPageName = HTMLUnescape (strFileListPageName);
			strFileListPageName = strFileListPageName.toLowerCase ();
			if (strPageNameLower == strFileListPageName)
			{
				return count;
			}
		}
	}
	return -1;
}

function PageIndexFromFileName (strFileName)
{
	if (g_FileList != null)
	{
		var entry;

		var strFileNameLower = strFileName;
		strFileNameLower = strFileNameLower.toLowerCase ();

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			var strFileListFileName = g_FileList[count].PriImage;
			strFileListFileName = strFileListFileName.toLowerCase ();
			if (strFileNameLower == strFileListFileName)
			{
				return count;
			}

			strFileListFileName = g_FileList[count].SecImage;
			strFileListFileName = strFileListFileName.toLowerCase ();
			if (strFileNameLower == strFileListFileName)
			{
				return count;
			}
		}
	}
	return -1;
}

function PageIndexFromVisioPageIndex (pageIndex)
{
	if (g_FileList != null)
	{
		var entry;

		var count;
		var fileEntry;
		var bFoundEntry = false;
		for (count = 0; 
			 count < g_FileList.length && !bFoundEntry; 
			 count++)
		{
			if (pageIndex == g_FileList[count].PageIndex)
			{
				return count;
			}
		}
	}
	return -1;
}

function FindShapeXML (pageID, shapeID)
{
	var shapeObj = null;

	if (xmlData)
	{
		var pagesObj = xmlData.selectSingleNode("VisioDocument/Pages");
		if(!pagesObj)
		{
			return null;
		}
		
		var pageQuerryString = './/Page[@ID = "' + pageID + '"]';
		var pageObj = pagesObj.selectSingleNode(pageQuerryString);
		if(!pageObj)
		{
			return null;
		}

		var shapeQuerryString = './/Shape[@ID = "' + shapeID + '"]';
		shapeObj = pageObj.selectSingleNode(shapeQuerryString);
	}

	return shapeObj;
}

function FindShapeXMLByName (pageName, shapeName)
{
	var shapeObj = null;

	if (xmlData)
	{
		var pagesObj = xmlData.selectSingleNode("VisioDocument/Pages");
		if(!pagesObj)
		{
			return null;
		}
		
		var pageQuerryString = './/Page[@Name $ieq$ "' + EscapeString (pageName) + '"]';
		var pageObj = pagesObj.selectSingleNode(pageQuerryString);
		if(!pageObj)
		{
			return null;
		}

		var shapeQuerryString = './/Shape[@Name $ieq$ "' + EscapeString (shapeName) + '"]';
		shapeObj = pageObj.selectSingleNode(shapeQuerryString);
	}

	return shapeObj;
}

function Unquote (str)
{
	var nStartIndex = 0;
	var nEndIndex = str.length;

	if (str.charAt (0) == '"')
	{
		nStartIndex = 1;
	}

	if (str.charAt (nEndIndex - 1) == '"')
	{
		nEndIndex -= 1;
	}

	return str.substring (nStartIndex, nEndIndex);
}

function ConvertXorYCoordinate(PosValue, OldMin, OldMax, NewMin, NewMax, MapBackwards)
{
	var OldMid = (OldMax - OldMin) / 2;
	var NewMid = (NewMax - NewMin) / 2;
	var ConvertResult = 1 * PosValue;
	ConvertResult = ConvertResult - (OldMin + OldMid);
	ConvertResult = ConvertResult / OldMid;
	if(MapBackwards != 0)
	{
		ConvertResult = 0 - ConvertResult;
	}
	ConvertResult = ConvertResult * NewMid;
	ConvertResult = ConvertResult + (NewMin + NewMid);
	return ConvertResult;
}

function showObject( divObject, divID ) 
{
	if( divObject == null )
		divObject = getObj( divID );
	
	if( divObject != null ) 
	{
		divObject.style.display = "";
		divObject.style.visibility = "visible"
	}
	return divObject;
}

function hideObject( divObject, divID ) 
{
	if( divObject == null )
		divObject = getObj( divID );
	
	if( divObject != null ) 
	{
		divObject.style.visibility = "hidden";
		divObject.style.display = "none";
	}
	return divObject;
}

function EscapeString (str)
{
	var strResult = "";

	for (var i = 0 ; i < str.length ; i++)
	{
		var curChar = str.charAt(i);
		if (curChar == '\\')
		{
			strResult += "\\\\";
		}
		else if (curChar == "\"")
		{
			strResult += "\\\"";
		}
		else if (curChar == "\'")
		{
			strResult += "\\\'";
		}
		else
		{
			strResult += curChar;
		}
	}

	return strResult;
}

function HTMLEscape (str)
{
	var strResult = "";

	for (var i = 0 ; i < str.length ; i++)
	{
		var curChar = str.charAt(i);
		if (curChar == '\\')
		{
			strResult += "&#92;";
		}
		else if (curChar == '\"')
		{
			strResult += "&#34;";
		}
		else if (curChar == '\'')
		{
			strResult += "&#39;";
		}
		else if (curChar == '<')
		{
			strResult += "&#60;";
		}
		else if (curChar == '<')
		{
			strResult += "&#62;";
		}
		else if (curChar == '&')
		{
			strResult += "&#38;";
		}
		else
		{
			strResult += curChar;
		}
	}

	return strResult;
}

function HTMLUnescape (str)
{
	var strResult = "";
	var strEscapePattern = "&#xx;";

	for (var i = 0 ; i < str.length - strEscapePattern.length + 1; i++)
	{
		if (str.charAt(i) == '&' && 
			str.charAt(i + 1) == '#' &&
			str.charAt(i + 4) == ';')
		{
			var charCode = str.charAt(i + 2);
			charCode += str.charAt(i + 3);

			if (charCode == "34")
			{
				strResult += '"';
			}
			else if (charCode == "39")
			{
				strResult += '\'';
			}
			else if (charCode == "60")
			{
				strResult += '<';
			}
			else if (charCode == "62")
			{
				strResult += '>';
			}
			else if (charCode == "92")
			{
				strResult += '\\';
			}
			else if (charCode == "38")
			{
				strResult += '&';
			}
			
			i = i + strEscapePattern.length - 1;
		}
		else
		{
			strResult += str.charAt(i);
		}
	}

	strResult += str.substring (i, str.length);

	return strResult;
}


// SIG // Begin signature block
// SIG // MIIanwYJKoZIhvcNAQcCoIIakDCCGowCAQExCzAJBgUr
// SIG // DgMCGgUAMGcGCisGAQQBgjcCAQSgWTBXMDIGCisGAQQB
// SIG // gjcCAR4wJAIBAQQQEODJBs441BGiowAQS9NQkAIBAAIB
// SIG // AAIBAAIBAAIBADAhMAkGBSsOAwIaBQAEFNA3Cl43FjKb
// SIG // QaT784pPGM7lVGapoIIVgjCCBMMwggOroAMCAQICEzMA
// SIG // AAA0JDFAyaDBeY0AAAAAADQwDQYJKoZIhvcNAQEFBQAw
// SIG // dzELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0
// SIG // b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1p
// SIG // Y3Jvc29mdCBDb3Jwb3JhdGlvbjEhMB8GA1UEAxMYTWlj
// SIG // cm9zb2Z0IFRpbWUtU3RhbXAgUENBMB4XDTEzMDMyNzIw
// SIG // MDgyNVoXDTE0MDYyNzIwMDgyNVowgbMxCzAJBgNVBAYT
// SIG // AlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQH
// SIG // EwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29y
// SIG // cG9yYXRpb24xDTALBgNVBAsTBE1PUFIxJzAlBgNVBAsT
// SIG // Hm5DaXBoZXIgRFNFIEVTTjpCOEVDLTMwQTQtNzE0NDEl
// SIG // MCMGA1UEAxMcTWljcm9zb2Z0IFRpbWUtU3RhbXAgU2Vy
// SIG // dmljZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoC
// SIG // ggEBAOUaB60KlizUtjRkyzQg8rwEWIKLtQncUtRwn+Jc
// SIG // LOf1aqT1ti6xgYZZAexJbCkEHvU4i1cY9cAyDe00kOzG
// SIG // ReW7igolqu+he4fY8XBnSs1q3OavBZE97QVw60HPq7El
// SIG // ZrurorcY+XgTeHXNizNcfe1nxO0D/SisWGDBe72AjTOT
// SIG // YWIIsY9REmWPQX7E1SXpLWZB00M0+peB+PyHoe05Uh/4
// SIG // 6T7/XoDJBjYH29u5asc3z4a1GktK1CXyx8iNr2FnitpT
// SIG // L/NMHoMsY8qgEFIRuoFYc0KE4zSy7uqTvkyC0H2WC09/
// SIG // L88QXRpFZqsC8V8kAEbBwVXSg3JCIoY6pL6TUAECAwEA
// SIG // AaOCAQkwggEFMB0GA1UdDgQWBBRfS0LeDLk4oNRmNo1W
// SIG // +3RZSWaBKzAfBgNVHSMEGDAWgBQjNPjZUkZwCu1A+3b7
// SIG // syuwwzWzDzBUBgNVHR8ETTBLMEmgR6BFhkNodHRwOi8v
// SIG // Y3JsLm1pY3Jvc29mdC5jb20vcGtpL2NybC9wcm9kdWN0
// SIG // cy9NaWNyb3NvZnRUaW1lU3RhbXBQQ0EuY3JsMFgGCCsG
// SIG // AQUFBwEBBEwwSjBIBggrBgEFBQcwAoY8aHR0cDovL3d3
// SIG // dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNyb3Nv
// SIG // ZnRUaW1lU3RhbXBQQ0EuY3J0MBMGA1UdJQQMMAoGCCsG
// SIG // AQUFBwMIMA0GCSqGSIb3DQEBBQUAA4IBAQAPQlCg1R6t
// SIG // Fz8fCqYrN4pnWC2xME8778JXaexl00zFUHLycyX25IQC
// SIG // xXUccVhDq/HJqo7fym9YPInnL816Nexm19Veuo6fV4aU
// SIG // EKDrUTetV/YneyNPGdjgbXYEJTBhEq2ljqMmtkjlU/JF
// SIG // TsW4iScQnanjzyPpeWyuk2g6GvMTxBS2ejqeQdqZVp7Q
// SIG // 0+AWlpByTK8B9yQG+xkrmLJVzHqf6JI6azF7gPMOnleL
// SIG // t+YFtjklmpeCKTaLOK6uixqs7ufsLr9LLqUHNYHzEyDq
// SIG // tEqTnr+cg1Z/rRUvXClxC5RnOPwwv2Xn9Tne6iLth4yr
// SIG // sju1AcKt4PyOJRUMIr6fDO0dMIIE7DCCA9SgAwIBAgIT
// SIG // MwAAALARrwqL0Duf3QABAAAAsDANBgkqhkiG9w0BAQUF
// SIG // ADB5MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
// SIG // Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMV
// SIG // TWljcm9zb2Z0IENvcnBvcmF0aW9uMSMwIQYDVQQDExpN
// SIG // aWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQTAeFw0xMzAx
// SIG // MjQyMjMzMzlaFw0xNDA0MjQyMjMzMzlaMIGDMQswCQYD
// SIG // VQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4G
// SIG // A1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0
// SIG // IENvcnBvcmF0aW9uMQ0wCwYDVQQLEwRNT1BSMR4wHAYD
// SIG // VQQDExVNaWNyb3NvZnQgQ29ycG9yYXRpb24wggEiMA0G
// SIG // CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDor1yiIA34
// SIG // KHy8BXt/re7rdqwoUz8620B9s44z5lc/pVEVNFSlz7SL
// SIG // qT+oN+EtUO01Fk7vTXrbE3aIsCzwWVyp6+HXKXXkG4Un
// SIG // m/P4LZ5BNisLQPu+O7q5XHWTFlJLyjPFN7Dz636o9UEV
// SIG // XAhlHSE38Cy6IgsQsRCddyKFhHxPuRuQsPWj/ov0DJpO
// SIG // oPXJCiHiquMBNkf9L4JqgQP1qTXclFed+0vUDoLbOI8S
// SIG // /uPWenSIZOFixCUuKq6dGB8OHrbCryS0DlC83hyTXEmm
// SIG // ebW22875cHsoAYS4KinPv6kFBeHgD3FN/a1cI4Mp68fF
// SIG // SsjoJ4TTfsZDC5UABbFPZXHFAgMBAAGjggFgMIIBXDAT
// SIG // BgNVHSUEDDAKBggrBgEFBQcDAzAdBgNVHQ4EFgQUWXGm
// SIG // WjNN2pgHgP+EHr6H+XIyQfIwUQYDVR0RBEowSKRGMEQx
// SIG // DTALBgNVBAsTBE1PUFIxMzAxBgNVBAUTKjMxNTk1KzRm
// SIG // YWYwYjcxLWFkMzctNGFhMy1hNjcxLTc2YmMwNTIzNDRh
// SIG // ZDAfBgNVHSMEGDAWgBTLEejK0rQWWAHJNy4zFha5TJoK
// SIG // HzBWBgNVHR8ETzBNMEugSaBHhkVodHRwOi8vY3JsLm1p
// SIG // Y3Jvc29mdC5jb20vcGtpL2NybC9wcm9kdWN0cy9NaWND
// SIG // b2RTaWdQQ0FfMDgtMzEtMjAxMC5jcmwwWgYIKwYBBQUH
// SIG // AQEETjBMMEoGCCsGAQUFBzAChj5odHRwOi8vd3d3Lm1p
// SIG // Y3Jvc29mdC5jb20vcGtpL2NlcnRzL01pY0NvZFNpZ1BD
// SIG // QV8wOC0zMS0yMDEwLmNydDANBgkqhkiG9w0BAQUFAAOC
// SIG // AQEAMdduKhJXM4HVncbr+TrURE0Inu5e32pbt3nPApy8
// SIG // dmiekKGcC8N/oozxTbqVOfsN4OGb9F0kDxuNiBU6fNut
// SIG // zrPJbLo5LEV9JBFUJjANDf9H6gMH5eRmXSx7nR2pEPoc
// SIG // sHTyT2lrnqkkhNrtlqDfc6TvahqsS2Ke8XzAFH9IzU2y
// SIG // RPnwPJNtQtjofOYXoJtoaAko+QKX7xEDumdSrcHps3Om
// SIG // 0mPNSuI+5PNO/f+h4LsCEztdIN5VP6OukEAxOHUoXgSp
// SIG // Rm3m9Xp5QL0fzehF1a7iXT71dcfmZmNgzNWahIeNJDD3
// SIG // 7zTQYx2xQmdKDku/Og7vtpU6pzjkJZIIpohmgjCCBbww
// SIG // ggOkoAMCAQICCmEzJhoAAAAAADEwDQYJKoZIhvcNAQEF
// SIG // BQAwXzETMBEGCgmSJomT8ixkARkWA2NvbTEZMBcGCgmS
// SIG // JomT8ixkARkWCW1pY3Jvc29mdDEtMCsGA1UEAxMkTWlj
// SIG // cm9zb2Z0IFJvb3QgQ2VydGlmaWNhdGUgQXV0aG9yaXR5
// SIG // MB4XDTEwMDgzMTIyMTkzMloXDTIwMDgzMTIyMjkzMlow
// SIG // eTELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0
// SIG // b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1p
// SIG // Y3Jvc29mdCBDb3Jwb3JhdGlvbjEjMCEGA1UEAxMaTWlj
// SIG // cm9zb2Z0IENvZGUgU2lnbmluZyBQQ0EwggEiMA0GCSqG
// SIG // SIb3DQEBAQUAA4IBDwAwggEKAoIBAQCycllcGTBkvx2a
// SIG // YCAgQpl2U2w+G9ZvzMvx6mv+lxYQ4N86dIMaty+gMuz/
// SIG // 3sJCTiPVcgDbNVcKicquIEn08GisTUuNpb15S3GbRwfa
// SIG // /SXfnXWIz6pzRH/XgdvzvfI2pMlcRdyvrT3gKGiXGqel
// SIG // cnNW8ReU5P01lHKg1nZfHndFg4U4FtBzWwW6Z1KNpbJp
// SIG // L9oZC/6SdCnidi9U3RQwWfjSjWL9y8lfRjFQuScT5EAw
// SIG // z3IpECgixzdOPaAyPZDNoTgGhVxOVoIoKgUyt0vXT2Pn
// SIG // 0i1i8UU956wIAPZGoZ7RW4wmU+h6qkryRs83PDietHdc
// SIG // pReejcsRj1Y8wawJXwPTAgMBAAGjggFeMIIBWjAPBgNV
// SIG // HRMBAf8EBTADAQH/MB0GA1UdDgQWBBTLEejK0rQWWAHJ
// SIG // Ny4zFha5TJoKHzALBgNVHQ8EBAMCAYYwEgYJKwYBBAGC
// SIG // NxUBBAUCAwEAATAjBgkrBgEEAYI3FQIEFgQU/dExTtMm
// SIG // ipXhmGA7qDFvpjy82C0wGQYJKwYBBAGCNxQCBAweCgBT
// SIG // AHUAYgBDAEEwHwYDVR0jBBgwFoAUDqyCYEBWJ5flJRP8
// SIG // KuEKU5VZ5KQwUAYDVR0fBEkwRzBFoEOgQYY/aHR0cDov
// SIG // L2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVj
// SIG // dHMvbWljcm9zb2Z0cm9vdGNlcnQuY3JsMFQGCCsGAQUF
// SIG // BwEBBEgwRjBEBggrBgEFBQcwAoY4aHR0cDovL3d3dy5t
// SIG // aWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNyb3NvZnRS
// SIG // b290Q2VydC5jcnQwDQYJKoZIhvcNAQEFBQADggIBAFk5
// SIG // Pn8mRq/rb0CxMrVq6w4vbqhJ9+tfde1MOy3XQ60L/svp
// SIG // LTGjI8x8UJiAIV2sPS9MuqKoVpzjcLu4tPh5tUly9z7q
// SIG // QX/K4QwXaculnCAt+gtQxFbNLeNK0rxw56gNogOlVuC4
// SIG // iktX8pVCnPHz7+7jhh80PLhWmvBTI4UqpIIck+KUBx3y
// SIG // 4k74jKHK6BOlkU7IG9KPcpUqcW2bGvgc8FPWZ8wi/1wd
// SIG // zaKMvSeyeWNWRKJRzfnpo1hW3ZsCRUQvX/TartSCMm78
// SIG // pJUT5Otp56miLL7IKxAOZY6Z2/Wi+hImCWU4lPF6H0q7
// SIG // 0eFW6NB4lhhcyTUWX92THUmOLb6tNEQc7hAVGgBd3TVb
// SIG // Ic6YxwnuhQ6MT20OE049fClInHLR82zKwexwo1eSV32U
// SIG // jaAbSANa98+jZwp0pTbtLS8XyOZyNxL0b7E8Z4L5UrKN
// SIG // MxZlHg6K3RDeZPRvzkbU0xfpecQEtNP7LN8fip6sCvsT
// SIG // J0Ct5PnhqX9GuwdgR2VgQE6wQuxO7bN2edgKNAltHIAx
// SIG // H+IOVN3lofvlRxCtZJj/UBYufL8FIXrilUEnacOTj5XJ
// SIG // jdibIa4NXJzwoq6GaIMMai27dmsAHZat8hZ79haDJLmI
// SIG // z2qoRzEvmtzjcT3XAH5iR9HOiMm4GPoOco3Boz2vAkBq
// SIG // /2mbluIQqBC0N1AI1sM9MIIGBzCCA++gAwIBAgIKYRZo
// SIG // NAAAAAAAHDANBgkqhkiG9w0BAQUFADBfMRMwEQYKCZIm
// SIG // iZPyLGQBGRYDY29tMRkwFwYKCZImiZPyLGQBGRYJbWlj
// SIG // cm9zb2Z0MS0wKwYDVQQDEyRNaWNyb3NvZnQgUm9vdCBD
// SIG // ZXJ0aWZpY2F0ZSBBdXRob3JpdHkwHhcNMDcwNDAzMTI1
// SIG // MzA5WhcNMjEwNDAzMTMwMzA5WjB3MQswCQYDVQQGEwJV
// SIG // UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
// SIG // UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBv
// SIG // cmF0aW9uMSEwHwYDVQQDExhNaWNyb3NvZnQgVGltZS1T
// SIG // dGFtcCBQQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAw
// SIG // ggEKAoIBAQCfoWyx39tIkip8ay4Z4b3i48WZUSNQrc7d
// SIG // GE4kD+7Rp9FMrXQwIBHrB9VUlRVJlBtCkq6YXDAm2gBr
// SIG // 6Hu97IkHD/cOBJjwicwfyzMkh53y9GccLPx754gd6udO
// SIG // o6HBI1PKjfpFzwnQXq/QsEIEovmmbJNn1yjcRlOwhtDl
// SIG // KEYuJ6yGT1VSDOQDLPtqkJAwbofzWTCd+n7Wl7PoIZd+
// SIG // +NIT8wi3U21StEWQn0gASkdmEScpZqiX5NMGgUqi+YSn
// SIG // EUcUCYKfhO1VeP4Bmh1QCIUAEDBG7bfeI0a7xC1Un68e
// SIG // eEExd8yb3zuDk6FhArUdDbH895uyAc4iS1T/+QXDwiAL
// SIG // AgMBAAGjggGrMIIBpzAPBgNVHRMBAf8EBTADAQH/MB0G
// SIG // A1UdDgQWBBQjNPjZUkZwCu1A+3b7syuwwzWzDzALBgNV
// SIG // HQ8EBAMCAYYwEAYJKwYBBAGCNxUBBAMCAQAwgZgGA1Ud
// SIG // IwSBkDCBjYAUDqyCYEBWJ5flJRP8KuEKU5VZ5KShY6Rh
// SIG // MF8xEzARBgoJkiaJk/IsZAEZFgNjb20xGTAXBgoJkiaJ
// SIG // k/IsZAEZFgltaWNyb3NvZnQxLTArBgNVBAMTJE1pY3Jv
// SIG // c29mdCBSb290IENlcnRpZmljYXRlIEF1dGhvcml0eYIQ
// SIG // ea0WoUqgpa1Mc1j0BxMuZTBQBgNVHR8ESTBHMEWgQ6BB
// SIG // hj9odHRwOi8vY3JsLm1pY3Jvc29mdC5jb20vcGtpL2Ny
// SIG // bC9wcm9kdWN0cy9taWNyb3NvZnRyb290Y2VydC5jcmww
// SIG // VAYIKwYBBQUHAQEESDBGMEQGCCsGAQUFBzAChjhodHRw
// SIG // Oi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL01p
// SIG // Y3Jvc29mdFJvb3RDZXJ0LmNydDATBgNVHSUEDDAKBggr
// SIG // BgEFBQcDCDANBgkqhkiG9w0BAQUFAAOCAgEAEJeKw1wD
// SIG // RDbd6bStd9vOeVFNAbEudHFbbQwTq86+e4+4LtQSooxt
// SIG // YrhXAstOIBNQmd16QOJXu69YmhzhHQGGrLt48ovQ7DsB
// SIG // 7uK+jwoFyI1I4vBTFd1Pq5Lk541q1YDB5pTyBi+FA+mR
// SIG // KiQicPv2/OR4mS4N9wficLwYTp2OawpylbihOZxnLcVR
// SIG // DupiXD8WmIsgP+IHGjL5zDFKdjE9K3ILyOpwPf+FChPf
// SIG // wgphjvDXuBfrTot/xTUrXqO/67x9C0J71FNyIe4wyrt4
// SIG // ZVxbARcKFA7S2hSY9Ty5ZlizLS/n+YWGzFFW6J1wlGys
// SIG // OUzU9nm/qhh6YinvopspNAZ3GmLJPR5tH4LwC8csu89D
// SIG // s+X57H2146SodDW4TsVxIxImdgs8UoxxWkZDFLyzs7BN
// SIG // Z8ifQv+AeSGAnhUwZuhCEl4ayJ4iIdBD6Svpu/RIzCzU
// SIG // 2DKATCYqSCRfWupW76bemZ3KOm+9gSd0BhHudiG/m4LB
// SIG // J1S2sWo9iaF2YbRuoROmv6pH8BJv/YoybLL+31HIjCPJ
// SIG // Zr2dHYcSZAI9La9Zj7jkIeW1sMpjtHhUBdRBLlCslLCl
// SIG // eKuzoJZ1GtmShxN1Ii8yqAhuoFuMJb+g74TKIdbrHk/J
// SIG // mu5J4PcBZW+JC33Iacjmbuqnl84xKf8OxVtc2E0bodj6
// SIG // L54/LlUWa8kTo/0xggSJMIIEhQIBATCBkDB5MQswCQYD
// SIG // VQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4G
// SIG // A1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0
// SIG // IENvcnBvcmF0aW9uMSMwIQYDVQQDExpNaWNyb3NvZnQg
// SIG // Q29kZSBTaWduaW5nIFBDQQITMwAAALARrwqL0Duf3QAB
// SIG // AAAAsDAJBgUrDgMCGgUAoIGiMBkGCSqGSIb3DQEJAzEM
// SIG // BgorBgEEAYI3AgEEMBwGCisGAQQBgjcCAQsxDjAMBgor
// SIG // BgEEAYI3AgEVMCMGCSqGSIb3DQEJBDEWBBRqmv0zgSoR
// SIG // aJcTsaiigQniNg9sVjBCBgorBgEEAYI3AgEMMTQwMqAY
// SIG // gBYAZgByAGEAbQBlAHMAZQB0AC4AagBzoRaAFGh0dHA6
// SIG // Ly9taWNyb3NvZnQuY29tMA0GCSqGSIb3DQEBAQUABIIB
// SIG // AInPbt1G1uYMHJS9LyUx0FuCQXbEMD1f1tPm+rSUmXLS
// SIG // sjj6eTgnL2pOq4xwf1pAyqz2opfw1QqPITNfM1iCsDRA
// SIG // FIAHaP1GZtIGDepNMeYRYrOoQmoc4WTPD80xHjuzGCpK
// SIG // 6BFIY7T77qBDDkz6uYxh8f21ccAT2zgMe3bUYaR6d5Mr
// SIG // 6wr7o1l+ryxAylcAVC6ZcaCm4m4xgWDJoPnYhgJ+5EEM
// SIG // 02XzxMk/XGf4sBVcNO2uUNGUaamW6eUWvOtlca31qBZC
// SIG // 35QZ9tr0HdMKkuUK6Fuc28GWNitWtBsOkcA2OcDYcR73
// SIG // OodPLFJkbtNM9DKPl7fENjcBsekyW8B+TIuhggIoMIIC
// SIG // JAYJKoZIhvcNAQkGMYICFTCCAhECAQEwgY4wdzELMAkG
// SIG // A1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAO
// SIG // BgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29m
// SIG // dCBDb3Jwb3JhdGlvbjEhMB8GA1UEAxMYTWljcm9zb2Z0
// SIG // IFRpbWUtU3RhbXAgUENBAhMzAAAANCQxQMmgwXmNAAAA
// SIG // AAA0MAkGBSsOAwIaBQCgXTAYBgkqhkiG9w0BCQMxCwYJ
// SIG // KoZIhvcNAQcBMBwGCSqGSIb3DQEJBTEPFw0xMzA2MTcw
// SIG // MzQwMzdaMCMGCSqGSIb3DQEJBDEWBBRw2y3ixT80CJ1l
// SIG // 3hXuXV+pxIxVpDANBgkqhkiG9w0BAQUFAASCAQDGj2sw
// SIG // dlKHW1t1HY1Mt19zua0rM8FoVCh//kS+iBh06mcTkXFw
// SIG // EqqT0f/CEzDxX1lHPqHXhhVtLrinUJTVBbfjwBYCTru6
// SIG // 8Q5wipoHaXXdz6zRidgvfI4iSGyAJIUqN/A/QnrtArEM
// SIG // IR91VE8rugCKIBjPK9jrmHyNkqLIRcrjGjaCIYvwxOhq
// SIG // Mbf+dVwq20oubuEqtUS2tcTBWL3gsm0crwbHLzZeYWRI
// SIG // B77SGFWlglugstwLlTVsBWZxwrSOZ1pXcRGzjVEt6EJw
// SIG // gf04ng8mHter6t8kJsMLN1/kddLKBvZztxEZeJZbCfw0
// SIG // 1RcInfZHVOkLXXPZG/gcgJl6pwvF
// SIG // End signature block
