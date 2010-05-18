%{
#include "service.h"

ScopeStorage g_storage;

%}
%expect 5

%token IDENTIFIER NUMBER 
%token KWIF KWELSE KWWHILE KWFOR KWCONTINUE KWBREAK KWRETURN
%token KWEXTERN KWSTATIC KWAUTO KWINT KWVOID 

%token ',' ';' '(' ')' '{' '}' '=' 
%token '+' '-' '*' '/' '!' '&' '|' '^'
%token EQ NEQ GT GTE LT LTE AMPAMP BARBAR 
%token LEX_WHITE LEX_COMMENT

%token '.'

%left '*' '/'
%left '+' '-'
%%

Program
    : Declarations 
    ;

Declarations
    : Declaration Declarations
    | /* empty */
    ;
    
Declaration
    : { g_storage = StorageStatic; } Declaration_
    ;

Declaration_
    : Class1 Type IDENTIFIER ParenParams Block  
                                 { g_service->addScope( $1, $5, ScopeProcedure, AccessPublic, StorageType,
                                                        $3, $1, $4, &$2 ); } 
    | Class1 IDENTIFIER ParenParams Block                                                                       
                                 { g_service->addScope( $1, $4, ScopeProcedure, AccessPublic, StorageType,
                                                        $2, $1, $3 ); } 
    | Type IDENTIFIER ParenParams Block                                                                       
                                 { g_service->addScope( $1, $4, ScopeProcedure, AccessPublic, StorageType,
                                                        $2, $1, $3, &$1 ); } 
    | IDENTIFIER ParenParams Block                                                                       
                                 { g_service->addScope( $1, $3, ScopeModule, AccessPublic, StorageType,
                                                        $1, $1, $2 ); }     
    | SimpleDeclaration    
    ;


SimpleDeclarations1
    : SimpleDeclaration SimpleDeclarations1
    | SimpleDeclaration 
    ;

SimpleDeclaration
    : SemiDeclaration ';'
    | SemiDeclaration error     { g_service->expectError( "declaration", ";" ); }  
    ;


SemiDeclaration
    : SemiDeclaration ',' IDENTIFIER                                 
                                 { g_service->addScope( $2, $3, ScopeVariable, AccessPublic, g_storage,
                                                        $3, $1, $3, &$1 , -1 /* glyph */, false /* merge */, true /* makeDescription */);  }     
    | Class1 Type IDENTIFIER     { $$ = $2;
                                   g_service->addScope( $1, $3, ScopeVariable, AccessPublic, g_storage,
                                                        $3, $1, $3, &$2 );}
    | Type IDENTIFIER            { g_service->addScope( $1, $2, ScopeVariable, AccessPublic, g_storage,
                                                        $2, $1, $2, &$1 );}
    ;


Params1
    : Params1 ',' Type IDENTIFIER { $$ = $4;
                                    g_service->addScope( $3, $4, ScopeVariable, AccessPublic, StorageParameter,
                                                        $4, $3, $4, &$3 );  }  
    | Type IDENTIFIER             { $$ = $2;
                                    g_service->addScope( $1, $2, ScopeVariable, AccessPublic, StorageParameter,
                                                         $2, $1, $2, &$1 );  }
    ;

ParenParams
    :  '(' ')'                   { $$ = $2; g_service->matchPair($1,$2); }
    |  '(' Params1 ')'           { $$ = $3; g_service->matchPair($1,$3); }
    |  '(' Params1 error         { $$ = $2; g_service->expectError( "unmatched parenthesis", ")" ); }
    |  '(' error ')'             { $$ = $3;
                                   g_service->matchPair($1,$3); 
                                   g_service->syntaxError( "parameters", &$2 ); }
    ;


Class1
    : KWSTATIC                  
    | KWAUTO
    | KWEXTERN
    ;


Type
    : KWINT
    | KWVOID
    ;


Block
    : OpenBlock CloseBlock      { $$ = $2;
                                  g_service->matchPair($1,$2); 
                                  g_service->codeSpan($1,$2);
                                  g_service->addScopeText( $1, $2, ScopeBlock, AccessPublic, StorageNone); }
    | OpenBlock BlockContent1 CloseBlock
                                { $$ = $3;
                                  g_service->matchPair($1,$3);
                                  g_service->codeSpan($1,$3);
                                  g_service->addScopeText( $1, $3, ScopeBlock, AccessPublic, StorageNone);  }
    | OpenBlock BlockContent1 error 
                                { $$ = @3;
                                  g_service->codeSpan($1,$3);
                                  g_service->expectError( "block", "}" ); 
                                  g_service->addScopeText( $1, @3, ScopeBlock, AccessPublic, StorageNone); }
    | OpenBlock error CloseBlock
                                { $$ = $3;
                                  g_service->codeSpan($1,$3);
                                  g_service->matchPair($1,$3); 
                                  g_service->syntaxError( "block", &@2 );
                                  g_service->addScopeText( $1, $3, ScopeBlock, AccessPublic, StorageNone ); }
    ;

OpenBlock
    : '{'                       { g_storage = StorageLocal }
    ;

CloseBlock
    : '}'                       
    ;

BlockContent1
    : SimpleDeclarations1 Statements1
    | SimpleDeclarations1
    | Statements1
    ;

Statements1
    : Statement Statements1
    | Statement
    ;

Statement
    : SemiStatement ';'
    | SemiStatement error       { g_service->expectError( "statement", ";" ); } 
  
    | KWWHILE ParenExprAlways Statement
    | KWFOR ForHeader Statement
    | KWIF ParenExprAlways Statement
    | KWIF ParenExprAlways Statement KWELSE Statement
                                { g_service->matchPair($1,$4); }
    | Block
    ;

ParenExprAlways
    : ParenExpr
    | error ')'                 { g_service->syntaxError( "expression" ); }
    | error                     { g_service->syntaxError( "expression" ); }
    ;

ParenExpr
    : '(' Expr ')'              { g_service->matchPair($1,$3); }
    | '(' Expr error            { g_service->expectError( "unmatched parenthesis", ")" ); }
    ;

ForHeader
    : '(' ForBlock ')'          { g_service->matchPair($1,$3); }
    | '(' ForBlock error        { g_service->expectError( "unmatched parenthesis", ")" ); }
    | '(' error ')'             { g_service->matchPair($1,$3); 
                                  g_service->syntaxError( "for-statement", &@2 ); }
    ;

ForBlock
    : AssignExpr ';' Expr ';' AssignExpr
    ;

SemiStatement
    : AssignExpr 
    | KWRETURN Expr 
    | KWBREAK 
    | KWCONTINUE     
    ;
    
Arguments1
    : Expr ',' { g_service->parameter($2); } Arguments1
    | Expr
    ;

ParenArguments
    : StartArg EndArg                { g_service->matchPair($1,$2); } 
    | StartArg Arguments1 EndArg     { g_service->matchPair($1,$3); }
    | StartArg Arguments1 error      { g_service->endParameters(@3);
                                       g_service->expectError( "unmatched parenthesis", ")" ); }
    ;

StartArg
    : '('                       { g_service->startParameters($1); }
    ;

EndArg
    : ')'                       { g_service->endParameters($1); }
    ;    

AssignExpr
    : Identifier '=' Expr   
    | Expr
    ;

Expr
    : RelExpr BoolOp Expr
    | RelExpr
    | RelExpr RelExpr           { g_service->syntaxError( "expression" ); } /* this one adds 3 shift/reduce conflicts */
    | error                     { g_service->syntaxError( "expression" ); }
    ;

BoolOp
    : AMPAMP | BARBAR 
    ;

RelExpr
    : BitExpr RelOp RelExpr
    | BitExpr
    ;

RelOp
    : GT | GTE | LT | LTE | EQ | NEQ
    ;
     
BitExpr
    : AddExpr BitOp BitExpr
    | AddExpr
    ;

BitOp
    : '|' | '&' | '^'
    ;


AddExpr
    : MulExpr AddOp AddExpr
    | MulExpr
    ;

AddOp
    : '+' | '-'
    ;


MulExpr
    : PreExpr MulOp MulExpr
    | PreExpr 
    ;

MulOp 
    : '*' | '/'
    ;

PreExpr
    : PrefixOp Factor
    | Factor
    ;

PrefixOp
    : '!' 
    ;


Factor
    : Identifier ParenArguments 
    | Identifier
    | NUMBER
    | ParenExpr
    ;     
    
Identifier
    : IDENTIFIER                        { g_service->startName($1); }
    | Identifier '.' IDENTIFIER            { g_service->qualifyName( $2, $3 ); }    
    | Identifier '.' error              { g_service->qualifyName( $2, $2 ); }
    ;
    
%%

