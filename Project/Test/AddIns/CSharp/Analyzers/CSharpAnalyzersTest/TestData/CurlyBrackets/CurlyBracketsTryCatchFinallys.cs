using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsTryCatchFinallys
    {
        public void TestTryCatchFinally()
        {
            // Invalid
            try { } catch(Exception ex) { } 
            try { int x; } catch(Exception ex) { int y; }

            try { } finally { }
            try { int x; } finally { int z; }

            try { } catch (Exception ex) { } finally { }
            try { int x; } catch (Exception ex) { int y; } finally { int z; }

            try 
            { 
                int x; } 
            catch (Exception ex) 
            { 
                int y; }
            finally 
            { 
                int z; }

            try {
                int x; 
            }
            catch (Exception ex) {
                int y; 
            }
            finally {
                int z; 
            }

            try {
                int x; }
            catch (Exception ex) {
                int y; }
            finally {
                int z; }

            try 
            { int x; 
            }
            catch (Exception ex) 
            { int y; 
            }
            finally 
            { int z; 
            }

            try 
            { int x; }
            catch (Exception ex) 
            { int y; }
            finally 
            { int z; }

            // Valid
            try
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            try 
            { 
                int x; 
            }
            catch (Exception ex) 
            { 
                int y; 
            }
            finally 
            { 
                int z; 
            }
        }
    }
}