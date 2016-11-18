namespace BlockStatementComments
{
    public class Class1
    {
        public bool SingleLineComment()
        {
            try
                // comment
            {
            }
            // comment
            catch
            // comment
            {
            }

            try
            // comment
            {
            }
            // comment
            finally
            // comment
            {
            }

            try
            // comment
            {
            }
            // comment
            catch
            // comment
            {
            }
            // comment
            finally
            // comment
            {
            }

            try
            // comment
            {
            }
            // comment
            catch (Exception ex)
            // comment
            {
            }
            // comment
            catch
            // comment
            {
            }
            // comment
            finally
            // comment
            {
            }

            if (true)
            // comment
            {
            }
            // comment
            else
            // comment
            {
            }

            if (true)
            // comment
            {
            }
            // comment
            else if (false)
            // comment
            {
            }
            // comment
            else
            // comment
            {
            }

            checked
            // comment
            {
            }

            unchecked
            // comment
            {
            }

            fixed (int i = 0)
            // comment
            {
            }

            for (int i = 0; i < 2; ++i)
            // comment
            {
            }

            foreach (int i in new int[] { 1 })
            // comment
            {
            }

            lock (this)
            // comment
            {
            }

            int i;
            switch (i)
            // comment
            {
                case 1:
                    break;
            }

            unsafe
            // comment
            {
            }

            using (new Form())
            // comment
            {
            }

            while (true)
            // comment
            {
            }

            do
            // comment
            {
            }
            // comment
            while (true);
        }

        public bool MultiLineComment()
        {
            try            /* comment */
            {
            }            /* comment */
            catch            /* comment */
            {
            }

            try            /* comment */
            {
            }
            /* comment */            finally
            /* comment */            {
            }

            try            /* comment */
            {
            }            /* comment */
            catch
            /* comment */            {
            }
            /* comment */
            finally            /* comment */
            {
            }

            try            /* comment */
            {
            }            /* comment */
            catch (Exception ex)            /* comment */
            {
            }            /* comment */
            catch
            /* comment */            {
            }
            /* comment */            finally
            /* comment */            {
            }

            if (true)            /* comment */
            {
            }            /* comment */
            else            /* comment */            {
            }

            if (true)            /* comment */
            {
            }            /* comment */
            else if (false)            /* comment */
            {
            }            /* comment */
            else            /* comment */
            {
            }

            checked
            /* comment */
            {
            }

            unchecked
            /* comment */
            {
            }

            fixed (int i = 0)
            /* comment */
            {
            }

            for (int i = 0; i < 2; ++i)
            /* comment */
            {
            }

            foreach (int i in new int[] { 1 })
            /* comment */
            {
            }

            lock (this)
            /* comment */
            {
            }

            int i;
            switch (i)
            /* comment */
            {
                case 1:
                    break;
            }

            unsafe
            /* comment */
            {
            }

            using (new Form())
            /* comment */
            {
            }

            while (true)
            /* comment */
            {
            }

            do
            /* comment */
            {
            } /* comment */
            while (true);
        }

        public bool XmlHeader()
        {
            try
            /// comment
            {
            }
            // comment
            catch
            /// comment
            {
            }

            try
            /// comment
            {
            }
            /// comment
            finally
            /// comment
            {
            }

            try
            /// comment
            {
            }
            /// comment
            catch
            /// comment
            {
            }
            /// comment
            finally
            /// comment
            {
            }

            try
            /// comment
            {
            }
            /// comment
            catch (Exception ex)
            /// comment
            {
            }
            /// comment
            catch
            /// comment
            {
            }
            /// comment
            finally
            /// comment
            {
            }

            if (true)
            /// comment
            {
            }
            /// comment
            else
            /// comment
            {
            }

            if (true)
            /// comment
            {
            }
            /// comment
            else if (false)
            /// comment
            {
            }
            /// comment
            else
            /// comment
            {
            }

            checked
            /// comment
            {
            }

            unchecked
            /// comment
            {
            }

            fixed (int i = 0)
            /// comment
            {
            }

            for (int i = 0; i < 2; ++i)
            /// comment
            {
            }

            foreach (int i in new int[] { 1 })
            /// comment
            {
            }

            lock (this)
            /// comment
            {
            }

            int i;
            switch (i)
            /// comment
            {
                case 1:
                    break;
            }

            unsafe
            /// comment
            {
            }

            using (new Form())
            /// comment
            {
            }

            while (true)
            /// comment
            {
            }

            do
            /// comment
            {
            }
            /// comment
            while (true);
        }

        public bool Regions()
        {
            try
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            catch
            #region Region
            #endregion
            {
            }

            try
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            finally
            #region Region
            #endregion
            {
            }

            try
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            catch
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            finally
            #region Region
            #endregion
            {
            }

            try
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            catch (Exception ex)
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            catch
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            finally
            #region Region
            #endregion
            {
            }

            if (true)
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            else
            #region Region
            #endregion
            {
            }

            if (true)
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            else if (false)
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            else
            #region Region
            #endregion
            {
            }

            checked
            #region Region
            #endregion
            {
            }

            unchecked
            #region Region
            #endregion
            {
            }

            fixed (int i = 0)
            #region Region
            #endregion
            {
            }

            for (int i = 0; i < 2; ++i)
            #region Region
            #endregion
            {
            }

            foreach (int i in new int[] { 1 })
            #region Region
            #endregion
            {
            }

            lock (this)
            #region Region
            #endregion
            {
            }

            int i;
            switch (i)
            #region Region
            #endregion
            {
                case 1:
                    break;
            }

            unsafe
            #region Region
            #endregion
            {
            }

            using (new Form())
            #region Region
            #endregion
            {
            }

            while (true)
            #region Region
            #endregion
            {
            }

            do
            #region Region
            #endregion
            {
            }
            #region Region
            #endregion
            while (true);
        }
    }
}