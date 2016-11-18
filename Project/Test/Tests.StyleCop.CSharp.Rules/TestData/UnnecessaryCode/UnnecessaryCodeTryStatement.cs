namespace UnnecessaryTryAndFinally
{
    class Class1
    {
        public void NecessaryTryAndFinally()
        {
            // Try is necessary because there is a catch statement attached.
            try
            {
                int x = 0;
            }
            catch (Exception ex)
            {
            }

            // Try is necessary because there is a non-empty finally statement attached.
            try
            {
                int x = 0;
            }
            finally
            {
                int y = 2;
            }

            // Try is necessary because there is a catch statement and a non-empty finally statement attached.
            try
            {
                int x = 0;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                int y = 2;
            }

            // Try is necessary because there is a non-empty catch statement attached.
            try
            {
                int x = 0;
            }
            catch (Exception ex)
            {
                int y = 4;
            }
        }

        public void UnnecessaryTryAndFinally()
        {
            // Both try and finally are not necessary as they are empty.
            try
            {
            }
            finally
            {
            }

            // Try is empty, so there is nothing to catch even though there is a catch block.
            try
            {
            }
            catch (Exception)
            {
            }

            // Try is empty, and catch and finally are empty too. All is unnecessary.
            try
            {
            }
            catch (Exception)
            {
            }
            finally
            {
            }

            // Try and finally don't contain any code and aren't necessary.
            try
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
            finally
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }

            // Try doesn't contain any code so there is nothing to catch.
            try
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
            catch (Exception)
            {
            }

            // Try and finally are not needed.
            try
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
            catch (Exception)
            {
            }
            finally
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }

            // Try contains code, but finally block is empty so try is not needed.
            try
            {
                int x = 0;
            }
            finally
            {
            }

            // Try contains code, but finally block contains no code so not needed.
            try
            {
                int x = 0;
            }
            finally
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
        }

        public void CriticalSections()
        {
            // Try is empty, but there is a non-empty exception block present. The empty try should be allowed as it creates a critical execution unit and the 
            // exception block will run in case of something like a ThreadAbortException.
            try
            {
            }
            catch (Exception)
            {
                int x = 0;
            }

            // Try is empty, but there is a non-empty exception block present. The empty try should be allowed as it creates a critical execution unit and the 
            // exception block will run in case of something like a ThreadAbortException.
            try
            {
            }
            catch (SomeException)
            {
            }
            catch (SomeOtherException)
            {
                int x = 0;
            }

            // Try is empty, but there is a non-empty finally present. The empty try should be allowed as it creates a critical execution unit and the 
            // finally block will run in case of something like a ThreadAbortException.
            try
            {
            }
            finally
            {
                int x = 0;
            }
        }
    }
}