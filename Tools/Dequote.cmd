   :: A routine that will reliably remove quotes from a variable's contents.
   
   ::  This routine will only affects items that both begin AND end with 
   ::  a double quote. 
   ::  e.g. will turn "C:\Program Files\somefile.txt"  
   ::       into       C:\Program Files\somefile.txt 
   ::  while still preserving cases such as  Height=5'6" and Symbols="!@#
   
   
   ::BEGIN FUNCTION::::::::::::::::::::::::::::::::::::::::::::::::::::::
   @ECHO OFF

   :: Removes the outer set of double quotes from a variable.
   :: Written by Frank P. Westlake, 2001.09.22, 2001.09.24
   :: Modified by Simon Sheppard 2002.06.09
   
   :: Usage as a function within a script:
   ::   CALL :DeQuote VariableName
   ::
   :: Calling as a function from another batch file:
   ::   CALL DeQuote.cmd VariableName
   ::
   :: If the first and last characters of the variable contents are double
   :: quotes then they will be removed. This function preserves cases such as
   ::   Set Height=5'6" and Set Symbols="!@#
   ::
   :: If a variable is quoted twice and has delimiters then you will 
   :: need to run the function twice to remove both sets.
   ::   Set var=""Two Quotes;And,Delimiters=Fails""
   ::
   :: If the variable name itself contains spaces the routine will fail
   :: e.g. %v_my_variable% rather than %my variable%
   
   :DeQuote
   SET DeQuote.Variable=%1
   CALL Set DeQuote.Contents=%%%DeQuote.Variable%%%
   Echo.%DeQuote.Contents%|FindStr/brv ""^">NUL:&&Goto :EOF
   Echo.%DeQuote.Contents%|FindStr/erv ""^">NUL:&&Goto :EOF
   
   Set DeQuote.Contents=####%DeQuote.Contents%####
   Set DeQuote.Contents=%DeQuote.Contents:####"=%
   Set DeQuote.Contents=%DeQuote.Contents:"####=%
   Set %DeQuote.Variable%=%DeQuote.Contents%
   
   Set DeQuote.Variable=
   Set DeQuote.Contents=
   Goto :EOF
   ::END FUNCTION::::::::::::::::::::::::::::::::::::::::::::::::::::::
