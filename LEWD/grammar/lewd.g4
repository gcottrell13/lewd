grammar lewd;

@rulecatch {
   catch (RecognitionException e) {
    throw e;
   }
}

// ----------------------------------------------------------------------------------------------------------
// Document and Expression
// ----------------------------------------------------------------------------------------------------------

// Represented with LEWD.Document
document : docLevelExpression? (WS docLevelExpression)* WS? ;

docLevelExpression : assignment | functionCall ;
expression : constant | functionCall | functionDef ;

// ----------------------------------------------------------------------------------------------------------
// Assignment
// ----------------------------------------------------------------------------------------------------------

// Represented with LEWD.Assignment
assignment : assignmentLHS WS? '=' WS? assignmentRHS ;
assignmentLHS : name ;
assignmentRHS : (expression | functionDef) ;

// ----------------------------------------------------------------------------------------------------------
// Function Defs and Calls
// ----------------------------------------------------------------------------------------------------------

// Represented with LEWD.FunctionCall
functionCall : name WS? '(' WS? expression? (WS expression)* WS? ')' ;
// Represented with LEWD.Function
functionDef : '(' WS? (parameter WS)* parameter? WS? ')' WS? '=>' WS? functionBody ;
functionBody : expression ;
// Represented with LEWD.Parameter
parameter : SYMBOL_TEXT;


// ----------------------------------------------------------------------------------------------------------
// Constants and Literals
// ----------------------------------------------------------------------------------------------------------

constant : collection | number | symbol | record | str | truefalse ;
// Represented with LEWD.Collection
collection : '[' WS? expression? (WS expression)* WS? ']' ;
// Represented with LEWD.Number
number : NUMBER_TEXT ;
// Represented with LEWD.Symbol
symbol : SYMBOL_TEXT ;
// Represented with LEWD.Record
record : '{' WS? recordEntry? (WS recordEntry)* WS? '}' ;
// Represented with LEWD.Str
str : StringLiteral ;
// Represented with LEWD.RecordEntry
recordEntry : expression WS? '->' WS? expression ;

truefalse : 'true' | 'false' ;

// ----------------------------------------------------------------------------------------------------------
// Aliases
// ----------------------------------------------------------------------------------------------------------
name : symbol;

// ----------------------------------------------------------------------------------------------------------
// Tokens
// ----------------------------------------------------------------------------------------------------------
StringLiteral
    :  '"' ( EscapeSequence | ~[\\"]  )* '"'
    ;

fragment HexDigit 
    : [0-9a-fA-F] 
    ;

fragment EscapeSequence
    :   '\\' [btnfr"'\\]
    |   UnicodeEscape
    |   OctalEscape
    ;

fragment OctalEscape
    :   '\\' [0-3] [0-7] [0-7]
    |   '\\' [0-7] [0-7]
    |   '\\' [0-7]
    ;

fragment UnicodeEscape
    :   '\\' 'u' HexDigit HexDigit HexDigit HexDigit
    ;

SYMBOL_TEXT : (TEXT | SPECIAL_SYMBOL_CHAR) (ALPHANUMERIC | SPECIAL_SYMBOL_CHAR)* ;
NUMBER_TEXT : '-'? (DIGIT+ (PERIOD DIGIT*)? | PERIOD DIGIT* ) ;

fragment ALPHANUMERIC : TEXT | DIGIT ;

fragment DIGIT : ('0'..'9') ;

PERIOD : '.' ;

fragment TEXT : [a-zA-Z_] ;

STRING : TEXT+ ;

fragment SPECIAL_SYMBOL_CHAR : '+' | '/' | '*' | '?' | '-' ;

WS : [ \t\n\r]+ ;

COMMENT : '/*' .*? '*/' -> skip ;