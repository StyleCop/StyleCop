/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/



namespace Babel.ParserGenerator
{
    public class Rule
    {
        public int lhs; // symbol
		public int[] rhs; // symbols

        public Rule(int lhs, int[] rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
    }
}
