/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLCommon.h>

namespace VSL
{

// TODO - 3/8/2006 - this should go elsewhere, but don't want to take a dependency on VSLWindows.h
// here.
class DeviceContextResourceTraits
{
public:
	typedef std::pair<HDC, HWND> ResourceType;
	typedef HDC CastType;
	typedef DeviceContextResourceTraits Allocator;
	typedef DeviceContextResourceTraits Values;
	typedef DeviceContextResourceTraits Cloner;
	static std::pair<HDC, HWND> GetNullValue()
	{
		return std::pair<HDC, HWND>(static_cast<HDC>(NULL), static_cast<HWND>(NULL));
	}
	static void Free(std::pair<HDC, HWND>& pair)
	{
		::ReleaseDC(pair.second, pair.first);
	}
	static HDC CastToResource(const std::pair<HDC, HWND>& pair)
	{
		return pair.first;
	}
};

class DeviceContext
{
private:

VSL_DECLARE_NOT_COPYABLE(DeviceContext);

	// FUTURE - default construction could be supported
	DeviceContext();

	typedef Resource<DeviceContextResourceTraits> HandlePair;

public:
	DeviceContext(_In_ HWND hWindow):
		m_HandlePair(HandlePair::ResourceType(reinterpret_cast<HDC>(VSL_CHECKHANDLE_GLE(::GetDC(hWindow))), hWindow))
	{
	}

	// The compiler generated destructor is fine

	template<class LPARAM_T>
	void EnumFontFamiliesExW(_In_ LPLOGFONTW lpLogfont, _In_ FONTENUMPROCW lpProc, _In_ LPARAM_T& lParam, _In_ DWORD dwFlags = 0)
	{
		// Return value will be that provided by the last call to lpProc and 0 indicates an 
		// unspecified error
		VSL_CHECKBOOLEAN((0 != ::EnumFontFamiliesEx(
			m_HandlePair, 
			lpLogfont, 
			lpProc, 
			reinterpret_cast<LPARAM>(&lParam), 
			dwFlags)), E_FAIL);
	}

	// FUTURE - 3/8/2006 - can add additional wrapper methods

private:
	HandlePair m_HandlePair;
};

class VsFontCommandHandling
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(VsFontCommandHandling)

public:
	template <class FontContainer_T>
	static void FontContainerToVariant(const FontContainer_T& rFontContainer, _Out_ VARIANT *pvarOut)
	{
		VSL_CHECKPOINTER(pvarOut, E_INVALIDARG);

		// Clear the out the value here in case of failure
		::VariantClear(pvarOut);

		VSL_CHECKBOOLEAN(rFontContainer.size() > 0, E_FAIL);

		ATL::CComSafeArray<BSTR> fontArray(static_cast<ULONG>(rFontContainer.size()));

		int iIndex = 0;
		for(FontContainer_T::const_iterator i = rFontContainer.begin(); 
			i != rFontContainer.end(); 
			++i, ++iIndex)
		{
			// Deep copies the value by default
			fontArray.SetAt(iIndex, *i);
		}

		V_ARRAY(pvarOut) = fontArray.Detach();
		V_VT(pvarOut) = VT_ARRAY | VT_BSTR;
	}

	// FontNameContainer_T needs to be a container of BSTR's
	template <class FontNameContainer_T>
	class FontNameContainerElementDeallocator
	{

	VSL_DECLARE_NOT_COPYABLE(FontNameContainerElementDeallocator)

	public:
		typedef FontNameContainer_T FontNameContainer;

		FontNameContainerElementDeallocator()
		{
		}

		~FontNameContainerElementDeallocator()
		{
			// Free all of the BSTR's
			for(FontNameContainer_T::const_iterator i = m_Container.begin(); 
				i != m_Container.end(); 
				++i)
			{
				::SysFreeString(*i);
			}
			// The element values now all point to bogus memory, but that's
			// okay as the container will be destructed right after this.
		}

		FontNameContainer_T& GetContainer()
		{
			return m_Container;
		}

	private:
		FontNameContainer_T m_Container;
	};

	// This takes a FontNameContainerElementDeallocator rather then a FontNameContainer
	// to ensure the the font names, which are BSTR's, will get freed.
	template <class FontNameContainerElementDeallocator_T>
	static void PopulateFontNameContainerElementDeallocator(FontNameContainerElementDeallocator_T& rFontNameDeallocator, bool bIgnoreNonTrueTypeFonts = true)
	{
		// The desktop window will supply all of the system fonts
		DeviceContext dc(::GetDesktopWindow());

		EnumFontNamesCallBackLPARAM<FontNameContainerElementDeallocator_T::FontNameContainer> lParam =
		{
			rFontNameDeallocator.GetContainer(),
			bIgnoreNonTrueTypeFonts
		};

		dc.EnumFontFamiliesExW(
			NULL, 
			reinterpret_cast<FONTENUMPROCW>(&EnumFontNamesCallBack<FontNameContainerElementDeallocator_T::FontNameContainer>),
			lParam);

		// FUTURE - could call std::sort algorithm if container doesn't have a sort method
		rFontNameDeallocator.GetContainer().sort(IsStringLessThen);
	}

private:

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
	template <class FontNameContainer_T>
	struct EnumFontNamesCallBackLPARAM
	{
		FontNameContainer_T& rFontNameContainer;
		bool bIgnoreNonTrueTypeFonts;
	};
#pragma warning(pop)

	// This static function is called by Windows in the course of processing
	// the ::EnumFontFamiliesEx call in PopulateFontNameContainerElementDeallocator.
	// Windows calls the method once for each font/character set pair, but the 
	// character set is ignored as the user isn't not given an option to select the 
	// chracter set, only the font name.
	template <class FontNameContainer_T>
	static int CALLBACK EnumFontNamesCallBack(
		_In_ ENUMLOGFONTEX* pEnumLogFont,
		_In_ NEWTEXTMETRICEX* /*pTextMetric*/, 
		DWORD dwFontType, 
		_In_ LPARAM lParam)
	{
		VSL_STDMETHODTRY{
			
		CHKPTR(pEnumLogFont, E_FAIL);
		CHKPTR(lParam, E_FAIL);
		CHKPTR(pEnumLogFont, E_FAIL);
		// lfFaceName is an array, don't need to check it against NULL
		CHK(pEnumLogFont->elfLogFont.lfFaceName[0] != L'\0', E_FAIL);

		// Get the data that was passed into EnumFontFamiliesEx.
		EnumFontNamesCallBackLPARAM<FontNameContainer_T>* p = reinterpret_cast<EnumFontNamesCallBackLPARAM<FontNameContainer_T>*>(lParam);

		// Non TrueType fonts have scaling issues, so ignore those
		if(p->bIgnoreNonTrueTypeFonts && !(TRUETYPE_FONTTYPE & dwFontType))
		{
			return TRUE;
		}

		FontNameContainer_T& rFontNameContainer = p->rFontNameContainer;

		if(rFontNameContainer.size() == 0 || 0 != ::wcscmp(rFontNameContainer.back(), pEnumLogFont->elfLogFont.lfFaceName))
		{
			// Add the font name to the end of the list if it isn't there already
			rFontNameContainer.push_back(CHKPTR(::SysAllocString(pEnumLogFont->elfLogFont.lfFaceName), E_OUTOFMEMORY));
		}

		}VSL_STDMETHODCATCH()

		// 0 stops enumeration, anything else continues it
		return SUCCEEDED(VSL_GET_STDMETHOD_HRESULT()) ? 1 : 0;
	}

};

} // namespace VSL

#endif // VSLFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
