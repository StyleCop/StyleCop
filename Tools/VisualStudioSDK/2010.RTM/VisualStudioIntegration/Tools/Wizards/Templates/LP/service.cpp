#include "service.h"
%IncludeList%

/*---------------------------------------------------------
  Globals
---------------------------------------------------------*/
const wchar_t*  g_languageName              = %LanguageName%;
const wchar_t*  g_languageFileExtensions[]  = { %LanguageExtensions% NULL };
const CLSID     g_languageCLSID             = {%PackageGuid2%};

const LanguageProperty g_languageProperties[] =
{
  { L"RequestStockColors", %SyntaxColor% },

  { L"ShowCompletion",     %ShowCompletion%     },
  { L"SortMemberList",     %SortMemberList%     },

  { L"CodeSense",          %SyntaxCheck%  },
  { L"CodeSenseDelay",     %SyntaxCheckDelay% },
  { L"MaxErrorMessages",   %MaxErrMsg%     },
  { L"QuickInfo",          %QuickInfo%     },
  { L"MatchBraces",        %MatchBraces%     },
  { L"ShowMatchingBrace",  %ShowMatchingBrace%     },
  { L"MatchBracesAtCaret", %MatchBracesAtCaret%     },

  { NULL, 0 }
};

/*---------------------------------------------------------
  Create Service
---------------------------------------------------------*/
HRESULT CreateBabelService( out IBabelService** babelService )
{
  TRACE(L"CreateBabelService");
  OUTARG(babelService);

  *babelService = new Service();
  if (*babelService == NULL) return E_OUTOFMEMORY;

  return S_OK;
}

%CommentFormatImpl%

/*---------------------------------------------------------
  Tokens
---------------------------------------------------------*/
override const TokenInfo* Service::getTokenInfo() const
{
  static TokenInfo tokenInfoTable[] =
  {
	%TokensInfo%
    //always end with the 'TokenEnd' token.
    { TokenEnd,     ClassText,      "<unknown>" }
  };

  return tokenInfoTable;
};