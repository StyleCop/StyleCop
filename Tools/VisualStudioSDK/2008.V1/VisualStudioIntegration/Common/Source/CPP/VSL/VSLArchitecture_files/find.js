
var strShapeName	= "Shape Name";
var strShapeText	= "Shape Text";
var strProps		= "Custom Properties";
var strResults		= "Search results for:";

var strShape	= "Shape Name:";
var strNoCustomPropertiesToDisplayText = "CTRL+click a shape in the drawing to view details.";

var FindShapeXML = parent.FindShapeXML;
var Unquote = parent.Unquote;
var put_Location = parent.put_Location;


var strChkBox		= "Chkbox";
var strPropChkBox	= "PropChkbox";

function doExpando(xxx,yyy){
	if (xxx.style.display=="none"){
		xxx.style.display = ""
		yyy.src = up.src;
	}else{
		xxx.style.display = "none"
		yyy.src = down.src;
	}
}

function doExp(xxx,yyy){
	if (xxx.style.display=="none"){
		xxx.style.display = ""
		yyy.src = "minus.gif";
	}else{
		xxx.style.display = "none"
		yyy.src = "plus.gif";
	}
}


function FindOnClick()
{
	var count, indexOfString;
	
	var fieldsToSearchArray = new Array();
	if (parent.xmlData != null && document.theForm[strProps + strChkBox].checked)
	{
		for( count=0; count < document.theForm.length; count++ )
		{
			indexOfString = document.theForm[count].name.indexOf(strPropChkBox);
			if( -1 != indexOfString && document.theForm[count].checked )
			{
				fieldsToSearchArray[ fieldsToSearchArray.length ] = document.theForm[count].name.slice(0, indexOfString);
			}
		}
	}

	var searchTokensArray = CreateSearchTokens (document.theForm.findString.value);

	if (searchTokensArray.length > 0)
	{
		var findArray = Find(searchTokensArray, fieldsToSearchArray);
		var ArrayLength = findArray.length;
		var strResultsHTML = "No matches found.";
		var lastPageID = null;
		var shapeID;
		
		
		if(ArrayLength > 0)
		{
			strResultsHTML = strResults + ' <b>'+ parent.HTMLEscape(document.theForm.findString.value) +'</b>';
			for ( count = 0; count < ArrayLength; count++)
			{
			
				if( lastPageID != findArray[count].PageID )
				{
					lastPageID = findArray[count].PageID;
				}

				shapeID = findArray[count].ShapeID;
				strResultsHTML += '<p class="results"><a href="javascript:populateSearchResultDetails(\'results_'+ lastPageID +'_'+ shapeID +'\', '+ lastPageID +','+ shapeID +'); TogglePlus(results_' + lastPageID + '_' + shapeID + ',\'img_' + lastPageID + '_' + shapeID + '\', hideResults)"><img src="plus.gif" alt="Shows/hides shape details" width="13" height="9" border="0" id="img_'+ lastPageID +'_'+ shapeID +'"></a>\n'
				strResultsHTML += '<a  class="blu1" href="JavaScript:FindQuerySelect(';

				strResultsHTML += findArray[count].PageID + ",";
				strResultsHTML += findArray[count].ShapeID + ",";
				strResultsHTML += findArray[count].PinX + ",";
				strResultsHTML += findArray[count].PinY;

				strResultsHTML += ')">'+ findArray[count].Title +'</a></p>\n'

				strResultsHTML += '</div>\n';
				strResultsHTML += '<div class="indent" id="results_'+ lastPageID +'_'+ shapeID +'" style="display:none;width:100%;"></div>\n'
			}

		}
		var divAdvSrch = document.all("hideAdvSrch");
		var imgAS0 = document.all("as0");
		
		var tmpObj = document.all("hideResults");
		if( tmpObj != null )
		{
			tmpObj.innerHTML = strResultsHTML;
			tmpObj.open = "true";
			tmpObj.style.display = "block";
		}
	}
}

function CreateSearchTokens (strUserString)
{
	var searchTokensArray = new Array();

	var strToken = "";
	var chCurChar;

	for (var count = 0; count < strUserString.length; count++)
	{
		chCurChar = strUserString.charAt(count);
		if (chCurChar == '"')
		{
			var nNextQuote = strUserString.indexOf('"', count + 1);
			if (nNextQuote >= 0)
			{
				strToken = strUserString.slice(count + 1, nNextQuote);
				searchTokensArray[searchTokensArray.length] = strToken;
				strToken = "";
				count = nNextQuote;
			}
		}
		else if (chCurChar == ' ')
		{
			if (strToken.length > 0)
			{
				searchTokensArray[searchTokensArray.length] = strToken;
			}

			strToken = "";
		}
		else
		{
			strToken += chCurChar;
		}
	}

	if (strToken.length > 0)
	{
		searchTokensArray[searchTokensArray.length] = strToken;
	}

	return searchTokensArray;
}

function populateSearchResultDetails( divID, pageID, shapeID )
{
	var tmpShape = FindShapeXML (pageID, shapeID);
	var strOutput = CreatePropTable( tmpShape );
	
	var tmpObj = document.all(divID);
	if( tmpObj != null )
	{
		tmpObj.innerHTML = strOutput;
	}
}

function makeAdvancedFindCheckboxes(div)
{
	if (parent.xmlData)
	{
		var strOutput = "";

		strOutput += "<INPUT type='checkbox' name='" + strShapeName + strChkBox + "' id='" + strShapeName + strChkBox + "' checked><label for='" + strShapeName + strChkBox + "'>" + strShapeName + "</label><br>\n";
		strOutput += "<INPUT type='checkbox' name='" + strShapeText + strChkBox + "' id='" + strShapeText + strChkBox + "' checked><label for='" + strShapeText + strChkBox + "'>" + strShapeText + "</label><br>\n";
		strOutput += "<INPUT type='checkbox' name='" + strProps + strChkBox + "' id='" + strProps + strChkBox + "' onclick='AdvSearchCustomPropCheck ()'checked ><label for='" + strProps + strChkBox + "'>" + strProps +"</label><br>\n";
		strOutput += "<div id='divCPBoxes' style='margin-left:1em;'>";
		
		var objNodes = parent.xmlData.selectNodes(".//Shape/Prop/Label");
		var filter = "";
		var boolFirstPass = true;
		var tmpPropName;
		while( objNodes.length > 0)
		{
			tmpPropName = objNodes.item( 0 ).text;
			var escapedPropName = parent.EscapeString(tmpPropName);
			if( true == boolFirstPass )
			{
				filter = ". != '" + escapedPropName + "'";
				boolFirstPass = false;
			}
			else
			{
				filter += " and . != '" + escapedPropName + "'";
			}

			tmpPropName = parent.HTMLEscape (tmpPropName);
			strOutput += "<INPUT type='checkbox' name='" + tmpPropName + strPropChkBox + "' id='"+ tmpPropName + strPropChkBox + "' checked><label for='"+ tmpPropName + strPropChkBox + "'>" + tmpPropName +"</label><br>\n";

			objNodes = parent.xmlData.selectNodes(".//Shape/Prop/Label["+ filter + "]");
		}
		strOutput += "</div>"
		div.innerHTML = strOutput;
	}
}

function AdvSearchCustomPropCheck ()
{
	for( count=0; count < document.theForm.length; count++ )
	{
		indexOfString = document.theForm[count].name.indexOf(strPropChkBox);
		if( -1 != indexOfString )
		{
			document.theForm[count].disabled = !document.theForm[strProps + strChkBox].checked;
		}
	}
}


function CResultItem(title, pageID, shapeID, pinX, pinY)
{
	 this["Title"] = title;
	 this["PageID"] = pageID;
	 this["ShapeID"] = shapeID;
	 this["PinX"] = pinX;
	 this["PinY"] = pinY;
}

function FindParentPage(nodeObject)
{
	if(nodeObject == null)
	{
		return null;
	}
	if(nodeObject.baseName == "Page")
		return nodeObject;
	else
		return FindParentPage(nodeObject.parentNode);
}

function QueryStringForMatch(shapeNode, regTextForFind, filterString)
{
	if (filterString.length > 0)
	{
		var nodesToCheck = shapeNode.selectNodes(filterString);

		var nodeCount = nodesToCheck.length;
		var stringToParse;
		for(var ncount = 0; ncount < nodeCount; ncount++)
		{
			stringToParse = nodesToCheck.item(ncount).text;
			stringToParse = stringToParse.toLowerCase ();
			if(stringToParse.indexOf(regTextForFind) > -1)
			{
				return true;
			}
		}
	}
}

function GetShapeTitle(shapeNode)
{
	var objTempName = null;
	var objTempTextElement = shapeNode.selectSingleNode("./Text");
	if(objTempTextElement != null)
	{
		var objTextNode = objTempTextElement.selectSingleNode("textnode()");
		if (objTextNode != null)
		{
			return parent.HTMLEscape (objTextNode.text);
		}
	}

	objTempName = shapeNode.selectSingleNode("./@Name");
	if(objTempName != null)
	{
		return parent.HTMLEscape (objTempName.text);
	}

	return "";
}

function GetPageTitle(pageID)
{
	var pagesObj = parent.xmlData.selectSingleNode("VisioDocument/Pages");
	if(!pagesObj)
	{
		return "";
	}

	var pageQuerryString = './/Page[@ID = "' + pageID + '"]';
	var pageObj = pagesObj.selectSingleNode(pageQuerryString);
	if(!pageObj)
	{
		return "";
	}

	var pageNameNode = pageObj.selectSingleNode("@Name");
	if(!pageNameNode)
	{
		return "";
	}
	return pageNameNode.text;
}

function Find(searchTokensArray, propsToSearchArray)
{
	var bXMLNotValid = false;
	var findArray = new Array();
	var findIndex = 0;

	if (parent.xmlData != null && searchTokensArray.length > 0)
	{
		var fieldsToSearchArray = new Array();
		var filterString = "";
		if( null != propsToSearchArray &&
			propsToSearchArray.length > 0 )
		{
			var propFilterString = "";
			for( var count=0; count< propsToSearchArray.length; count++ )
			{
				if( count == 0 )
				{
					propFilterString = "[. = '" + parent.EscapeString (propsToSearchArray[count]) + "'";
				}
				else
				{
					propFilterString += " or . = '"+ parent.EscapeString (propsToSearchArray[count]) + "'";
				}
			}
			propFilterString += "]";

			fieldsToSearchArray[fieldsToSearchArray.length] = "Prop[Label"+ propFilterString +"]/Value";
		}

		if (document.theForm[strShapeText + strChkBox].checked)
		{
			fieldsToSearchArray[fieldsToSearchArray.length] = "Text";
		}

		if (fieldsToSearchArray.length > 0)
		{
			filterString = "(.//(";

			for (var fieldCount = 0; fieldCount < fieldsToSearchArray.length; fieldCount++)
			{
				if (fieldCount != 0)
				{
					filterString += " | ";
				}

				filterString += fieldsToSearchArray[fieldCount];
			}

			filterString += ")/textnode())";
		}

		var objShapeNodes;

		if (document.theForm[strShapeName + strChkBox].checked)
		{
			if (filterString.length > 0)
			{
				filterString += " | ";
			}
			filterString += "(@Name)";

			var objShapeNodes = parent.xmlData.selectNodes(".//Shape");
		}
		else
		{
			var objShapeNodes = parent.xmlData.selectNodes(".//Shape[(Prop/Value | Prop/Label | Text)]");
		}

		var shapeCount = objShapeNodes.length;
		var objTempData = new CResultItem("A Label","PageID","ShapeID","PinX","PinY");
		var objTempShape = null;

		for (count = 0; count < shapeCount; count++)
		{		
			objTempShape = objShapeNodes.item(count);

			var objParentPageNode = FindParentPage(objTempShape);
			if (objParentPageNode == null)
			{
				continue;
			}

			var objPageIDNode = objParentPageNode.selectSingleNode("@ID/textnode()");
			if(objPageIDNode == null)
			{
				continue;
			}
			var pageID = objPageIDNode.text;

			var pageIndex = parent.PageIndexFromID (pageID);
			if (pageIndex < 0)
			{
				continue;
			}

			var objLayerMember = objTempShape.selectSingleNode("LayerMem/LayerMember");
			if (objLayerMember != null && objLayerMember.text.length > 0)
			{
				var layerArray = objLayerMember.text.split (';');
				var visibleLayer = false;
				for (var layerCount = 0; (layerCount < layerArray.length) && !visibleLayer; layerCount++)
				{
					var objLayerVisible = objParentPageNode.selectSingleNode("Layer[@IX=" + layerArray[layerCount] + "]/Visible");
					if (objLayerVisible != null)
					{
						 visibleLayer = (objLayerVisible.text != 0);
					}
				}
				
				if (!visibleLayer)
				{
					continue;
				}
			}

			for (var tokenCount = 0; tokenCount < searchTokensArray.length; tokenCount++)
			{
				var textToFind = searchTokensArray[tokenCount];
				textToFind = textToFind.toLowerCase ();

				if (QueryStringForMatch(objTempShape, textToFind, filterString))
				{
					objTempData.Title = GetShapeTitle(objTempShape);
					objTempData.PageID = pageID;

					objShapeIDNode = objTempShape.selectSingleNode("@ID/textnode()");
					if(objShapeIDNode == null)
					{
						bXMLNotValid = true;
						break;
					}
					objTempData.ShapeID = objShapeIDNode.text;
					objPinXNode = objTempShape.selectSingleNode("XForm/PinX/textnode()");
					if(objPinXNode == null)
					{
						bXMLNotValid = true;
						break;
					}
					objTempData.PinX = objPinXNode.text;
					objPinYNode = objTempShape.selectSingleNode("XForm/PinY/textnode()");
					if(objPinYNode == null)
					{
						bXMLNotValid = true;
						break;
					}
					objTempData.PinY = objPinYNode.text;

					findArray[findIndex] = new CResultItem(objTempData.Title, objTempData.PageID, objTempData.ShapeID, objTempData.PinX, objTempData.PinY);
					findIndex++;
					break;
				}
			}
		}
		if(bXMLNotValid)
		{
			findArray.length = 0;
		}
	}

	return findArray;
}

function FindQuerySelect(pageID, shapeID, pinX, pinY)
{
	if (widgets.GoTo && (parent.g_FileList[document.all("Select1").value].PageID != pageID))
	{
		parent.g_callBackFunctionArray[parent.g_callBackFunctionArray.length] = function () { parent.viewMgr.put_Location (pageID, shapeID, pinX, pinY); };
		parent.GoToPageByID(pageID);
	}
	else 
	{
		if (parent.viewMgr != null)
		{
			parent.viewMgr.put_Location (pageID, shapeID, pinX, pinY);
		}
	}
}

function TreeSelect(pageID, shapeID)
{
	var shapeNode = FindShapeXML (pageID, shapeID);
	if (shapeNode != null)
	{
		var pinXNode = shapeNode.selectSingleNode("XForm/PinX/textnode()");
		var pinYNode = shapeNode.selectSingleNode("XForm/PinY/textnode()");

		if (pinXNode != null && pinYNode != null)
		{
			FindQuerySelect (pageID, shapeID, pinXNode.text, pinYNode.text);
		}
	}
}


var g_RowStyleList = parent.g_RowStyleList;
var FillPropPane = parent.FillPropPane;
var CreatePropTable = parent.CreatePropTable;

