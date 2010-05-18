%{
#include "service.h"
#include "parser.cpp.h"
%}

%s init
%s comment

White0          [ \t\r\f\v]
White           {White0}|\n

CommentStart    \/\*
CommentEnd      \*\/
Hint            {White0}*[A-Z0-9_]+{White0}*:.*\n


%%

<init>if                        { return KWIF;}
<init>else                      { return KWELSE;}
<init>otherwise                 { return KWELSE;}

<init>while                     { return KWWHILE; }
<init>for                       { return KWFOR;}
<init>break                     { return KWBREAK;}
<init>continue                  { return KWCONTINUE;}
<init>return                    { return KWRETURN;}
<init>extern                    { return KWEXTERN;}
<init>static                    { return KWSTATIC;}
<init>auto                      { return KWAUTO;}
<init>int                       { return KWINT;}
<init>void                      { return KWVOID;}

<init>[a-zA-Z_][a-zA-Z0-9_]*    { return IDENTIFIER; }
<init>[0-9]+                    { return NUMBER; }


<init>;                         { return ';';    }

<init>,                         { return ',';    }
<init>\(                        { return '(';    }
<init>\)                        { return ')';    }
<init>\{                        { return '{';    }
<init>\}                        { return '}';    }
<init>=                         { return '=';    }

<init>\^                        { return '^';    }
<init>\+                        { return '+';    }
<init>\-                        { return '-';    }
<init>\*                        { return '*';    }
<init>\/                        { return '/';    }
<init>\!                        { return '!';    }
<init>==                        { return EQ;  }
<init>\!=                       { return NEQ;   }
<init>\>                        { return GT; }
<init>\>=                       { return GTE;    }
<init>\<                        { return LT;     }
<init>\<=                       { return LTE;    }
<init>\&                        { return '&';    }
<init>\&\&                      { return AMPAMP; }
<init>\|                        { return '|';    }
<init>\|\|                      { return BARBAR; }
<init>\.                        { return '.';    }

<init>{CommentStart}            { g_service->enterComment( comment );
                                  yymore();
                                } 
<init>{White0}+                 { return LEX_WHITE; }
<init>\n                        { return LEX_WHITE; }
<init>.                         { char buf[80];
                                  sprintf_s( buf, 80, "invalid character ('%c', 0x%x)", yytext[0], yytext[0] );
                                  g_service->lexicalError( SevError, buf );
                                  yymore();
                                }

<comment>{CommentStart}         { g_service->enterComment();
                                  yymore();
                                }
<comment>{CommentEnd}           { g_service->leaveComment();
                                  return LEX_COMMENT;
                                }
<comment>.                      { yymore(); }
<comment>\n                     { return LEX_COMMENT; }

.|\n                            { g_service->setLexState(init); yyless(0); }


%%

#include <stdservice.c>