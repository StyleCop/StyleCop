
function ViewMgrSetVMLLocation(pageID, shapeID, pinX, pinY)
{
	doc = parent.frmDrawing.document;
	if (this.highlightDiv != null)
	{
		clickMenu ();

		var VMLImage = this.s;

		var imageLeft = 0;
		var imageRight = imageLeft + VMLImage.pixelWidth;
		var imageTop = 0;
		var imageBottom = imageTop + VMLImage.pixelHeight;

		var xLong = parent.ConvertXorYCoordinate(pinX, this.visBBoxLeft, this.visBBoxRight, imageLeft, imageRight, 0);
		var yLong = parent.ConvertXorYCoordinate(pinY, this.visBBoxBottom, this.visBBoxTop, imageTop, imageBottom, 1);

		xLong += doc.all['ConvertedImage'].style.posLeft;
		yLong += doc.all['ConvertedImage'].style.posTop;

		var arrowHalfWidth = viewMgr.highlightDiv.clientWidth / 2;
		var arrowHeight = viewMgr.highlightDiv.clientHeight;

		var boolNeedToScroll = false;

		if( !( (xLong - arrowHalfWidth) > doc.body.scrollLeft && (xLong + arrowHalfWidth) < (doc.body.scrollLeft + doc.body.clientWidth) ))
		{
			boolNeedToScroll = true;
		}
		
		if( !( (yLong - arrowHeight) > doc.body.scrollTop && (yLong + arrowHeight) < (doc.body.scrollTop + doc.body.clientHeight) ))
		{
			boolNeedToScroll = true;
		}
		
		if( boolNeedToScroll == true )
		{
			window.scrollTo( xLong - doc.body.clientWidth / 2, yLong - doc.body.clientHeight / 2);
		}
		
		this.highlightDiv.style.posLeft = xLong - arrowHalfWidth;
		this.highlightDiv.style.posTop = yLong;
		this.highlightDiv.style.visibility = "visible";

		setTimeout( "parent.hideObject(viewMgr.highlightDiv)", 200 );
		setTimeout( "parent.showObject(viewMgr.highlightDiv)", 400 );
		setTimeout( "parent.hideObject(viewMgr.highlightDiv)", 600 );
		setTimeout( "parent.showObject(viewMgr.highlightDiv)", 800 );
		setTimeout( "parent.hideObject(viewMgr.highlightDiv)", 1000 );
		setTimeout( "parent.showObject(viewMgr.highlightDiv)", 1200 );
		setTimeout( "parent.hideObject(viewMgr.highlightDiv)", 1400 );
		setTimeout( "parent.showObject(viewMgr.highlightDiv)", 1600 );
		setTimeout( "parent.hideObject(viewMgr.highlightDiv)", 1800 );

	}
}

function VMLZoomChange(size)
{
	if(size)
	{
		if(size == "up")
		{
			size = zoomLast + 50;
		}
		else if(size == "down")
		{
			size = zoomLast - 50;
		}
		
		size = parseInt(size);
		if(typeof(size) != "number")
			size = 100;
	}
	else
	{
		size = 100;
	}

	clickMenu ();

	viewMgr.zoomLast = size;

	var zoomFactor = size/100;

	var width = this.s.pixelWidth;
	var height = this.s.pixelHeight;

	var margin = parseInt(document.body.style.margin) * 2;

	var clientWidth = document.body.clientWidth;
	var clientHeight = document.body.clientHeight;

	var newScrollLeft = document.body.scrollLeft;
	var newScrollTop = document.body.scrollTop;

	var winwidth = clientWidth - margin;
	var winheight = clientHeight - margin;

	var widthRatio = winwidth / width;
	var heightRatio = winheight / height;

	if (widthRatio < heightRatio)
	{
		width = zoomFactor * winwidth;
		height = width / this.origWH;
	}
	else
	{
		height = zoomFactor * winheight;
		width = height * this.origWH;
	}

	this.s.pixelWidth = Math.max(width,1);
	this.s.pixelHeight = Math.max(height,1);

	this.sizeLast = size;

	var centerX = (zoomFactor / viewMgr.zoomFactor) * (newScrollLeft + (clientWidth / 2) - this.s.posLeft);
	var centerY = (zoomFactor / viewMgr.zoomFactor) * (newScrollTop + (clientHeight / 2) - this.s.posTop);

	viewMgr.zoomFactor = zoomFactor;

	if (width <= clientWidth)
	{
		this.s.posLeft = Math.max( 0, (clientWidth / 2) - (width / 2));
	}
	else
	{
		var left = centerX - (clientWidth / 2);
		if ( left >= 0 )
		{
			this.s.posLeft = 0;
			newScrollLeft = left;
		}
		else
		{
			this.s.posLeft = -left;
			newScrollLeft = 0;
		}
	}

	if (height <= clientHeight)
	{
		this.s.posTop = Math.max( 0, (clientHeight / 2) - (height / 2));
	}
	else
	{
		var top = centerY - (clientHeight / 2);
		if ( top >= 0 )
		{
			this.s.posTop = 0;
			newScrollTop = top;
		}
		else
		{
			this.s.posTop = -top;
			newScrollTop = 0;
		}
	}

	window.scrollTo(newScrollLeft, newScrollTop);

	this.s.visibility = "visible";

	var newXOffsetPercent = document.body.scrollLeft / this.s.pixelWidth;
	var newYOffsetPercent = document.body.scrollTop / this.s.pixelHeight;
	var newWidthPercent = document.body.clientWidth / this.s.pixelWidth;
	var newHeightPercent = document.body.clientHeight / this.s.pixelHeight;

	if (viewMgr.viewChanged)
	{
		viewMgr.viewChanged (newXOffsetPercent, newYOffsetPercent, newWidthPercent, newHeightPercent);
	}

	if (viewMgr.PostZoomProcessing)
	{
		viewMgr.PostZoomProcessing(size);
	}
}

function VMLSetView (xOffsetPercent, yOffsetPercent)
{
	var leftPixelOffset = xOffsetPercent * this.s.pixelWidth;
	var topPixelOffset = yOffsetPercent * this.s.pixelHeight;

	window.scrollTo (leftPixelOffset - this.s.posLeft, topPixelOffset - this.s.posTop);

	if (viewMgr.PostSetViewProcessing)
	{
		viewMgr.PostSetViewProcessing();
	}
}

function VMLOnResize ()
{
	if (viewMgr.zoomLast == 100)
	{
		viewMgr.Zoom(100);
	}

	if (viewMgr.viewChanged)
	{
		var image = document.all['ConvertedImage'];

		var newWidthPercent = document.body.clientWidth / image.style.pixelWidth;
		var newHeightPercent = document.body.clientHeight / image.style.pixelHeight;

		viewMgr.viewChanged (null, null, newWidthPercent, newHeightPercent);
	}
}

function VMLOnScroll ()
{
	if (viewMgr.viewChanged)
	{
		var image = document.all['ConvertedImage'];

		var newXOffsetPercent = document.body.scrollLeft / image.style.pixelWidth;
		var newYOffsetPercent = document.body.scrollTop / image.style.pixelHeight;

		viewMgr.viewChanged (newXOffsetPercent, newYOffsetPercent, null, null);
	}
}



