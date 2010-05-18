//------------------------------------------------------------------------------
// <copyright file="LanguageService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <owner current="true" primary="true">clovett</owner>
// <owner current="true" primary="false">tejalj</owner>
//------------------------------------------------------------------------------
using System;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Shell;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Microsoft.VisualStudio.Package {
    
    internal class NativeHelpers {
        private NativeHelpers() { }

        public static void RaiseComError(int hr) {
            throw new COMException("", (int)hr);
        }
        public static void RaiseComError(int hr, string message) {
            throw new COMException(message, (int)hr);
        }
        
    }

    /// <include file='doc\Utilities.uex' path='docs/doc[@for="CompoundActionHelpers"]/*' />
    public abstract class CompoundActionFactory {
        [CLSCompliant(false)]
        public static CompoundActionBase GetCompoundAction(IVsTextView view, Source src, string description) {
            if (view != null) {
                return new CompoundViewAction(view, description);
            } else if (src != null) {
                return new CompoundAction(src, description);
            } else {
                throw new ArgumentNullException("Either view or src is expected to be non null");
            }
        }
    }

    /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper"]/*' />
    [CLSCompliant(false)]
    public sealed class TextSpanHelper {

    private TextSpanHelper(){}

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.StartsAfterStartOf"]/*' />
        /// <devdoc>Returns true if the first span starts after the start of the second span.</devdoc>
        public static bool StartsAfterStartOf(TextSpan span1, TextSpan span2) {
            return (span1.iStartLine > span2.iStartLine || (span1.iStartLine == span2.iStartLine && span1.iStartIndex >= span2.iStartIndex));
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.StartsAfterEndOf"]/*' />
        /// <devdoc>Returns true if the first span starts after the end of the second span.</devdoc>
        public static bool StartsAfterEndOf(TextSpan span1, TextSpan span2) {
            return (span1.iStartLine > span2.iEndLine || (span1.iStartLine == span2.iEndLine && span1.iStartIndex >= span2.iEndIndex));
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.StartsBeforeStartOf"]/*' />
        /// <devdoc>Returns true if the first span starts before the start of the second span.</devdoc>
        public static bool StartsBeforeStartOf(TextSpan span1, TextSpan span2) {
            return !StartsAfterStartOf(span1, span2);
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.StartsBeforeEndOf"]/*' />
        /// <devdoc>Returns true if the first span starts before the end of the second span.</devdoc>
        public static bool StartsBeforeEndOf(TextSpan span1, TextSpan span2) {
            return (span1.iStartLine < span2.iEndLine ||
                (span1.iStartLine == span2.iEndLine && span1.iStartIndex < span2.iEndIndex));
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.EndsBeforeStartOf"]/*' />
        /// <devdoc>Returns true if the first span ends before the start of the second span.</devdoc>
        public static bool EndsBeforeStartOf(TextSpan span1, TextSpan span2) {
            return (span1.iEndLine < span2.iStartLine || (span1.iEndLine == span2.iStartLine && span1.iEndIndex <= span2.iStartIndex));
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.EndsBeforeEndOf"]/*' />
        /// <devdoc>Returns true if the first span starts before the end of the second span.</devdoc>
        public static bool EndsBeforeEndOf(TextSpan span1, TextSpan span2) {
            return (span1.iEndLine < span2.iEndLine || (span1.iEndLine == span2.iEndLine && span1.iEndIndex <= span2.iEndIndex));
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.EndsAfterStartOf"]/*' />
        /// <devdoc>Returns true if the first span ends after the start of the second span.</devdoc>
        public static bool EndsAfterStartOf(TextSpan span1, TextSpan span2) {
            return (span1.iEndLine > span2.iStartLine ||
                (span1.iEndLine == span2.iStartLine && span1.iEndIndex > span2.iStartIndex));
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.EndsBeforeEndOf"]/*' />
        /// <devdoc>Returns true if the first span starts after the end of the second span.</devdoc>
        public static bool EndsAfterEndOf(TextSpan span1, TextSpan span2) {
            return !EndsBeforeEndOf(span1, span2);
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.Merge"]/*' />
        public static TextSpan Merge(TextSpan span1, TextSpan span2) {
            TextSpan span = new TextSpan();

            if (StartsAfterStartOf(span1, span2)) {
                span.iStartLine = span2.iStartLine;
                span.iStartIndex = span2.iStartIndex;
            } else {
                span.iStartLine = span1.iStartLine;
                span.iStartIndex = span1.iStartIndex;
            }

            if (EndsBeforeEndOf(span1, span2)) {
                span.iEndLine = span2.iEndLine;
                span.iEndIndex = span2.iEndIndex;
            } else {
                span.iEndLine = span1.iEndLine;
                span.iEndIndex = span1.iEndIndex;
            }

            return span;
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.IsPositive"]/*' />
        public static bool IsPositive(TextSpan span) {
            return (span.iStartLine < span.iEndLine || (span.iStartLine == span.iEndLine && span.iStartIndex <= span.iEndIndex));
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.ClearTextSpan"]/*' />
        public static void Clear(ref TextSpan span) {
            span.iStartLine = span.iEndLine = 0;
            span.iStartIndex = span.iEndIndex = 0;
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.IsEmpty"]/*' />
        public static bool IsEmpty(TextSpan span) {
            return (span.iStartLine == span.iEndLine) && (span.iStartIndex == span.iEndIndex);
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.MakePositive"]/*' />
        public static void MakePositive(ref TextSpan span) {
            if (!IsPositive(span)) {
                int line;
                int idx;

                line = span.iStartLine;
                idx = span.iStartIndex;
                span.iStartLine = span.iEndLine;
                span.iStartIndex = span.iEndIndex;
                span.iEndLine = line;
                span.iEndIndex = idx;
            }

            return;
        }
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.TextSpanNormalize"]/*' />
        /// <devdoc>Pins the text span to valid line bounds returned from IVsTextLines.</devdoc>
        public static void Normalize(ref  TextSpan span, IVsTextLines textLines) {
            MakePositive(ref span);
            if (textLines == null) return;
            //adjust max. lines
            int lineCount;
            if (NativeMethods.Failed(textLines.GetLineCount(out lineCount)) )
                return;
            span.iEndLine = Math.Min(span.iEndLine, lineCount - 1);
            //make sure the start is still before the end
            if (!IsPositive(span)) {
                span.iStartLine = span.iEndLine;
                span.iStartIndex = span.iEndIndex;
            }
            //adjust for line length
            int lineLength;
            if ( NativeMethods.Failed(textLines.GetLengthOfLine(span.iStartLine, out lineLength)) )
                return;
            span.iStartIndex = Math.Min(span.iStartIndex, lineLength);
            if ( NativeMethods.Failed( textLines.GetLengthOfLine(span.iEndLine, out lineLength)) )
                return;
            span.iEndIndex = Math.Min(span.iEndIndex, lineLength);
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.IsSameSpan"]/*' />
        public static bool IsSameSpan(TextSpan span1, TextSpan span2) {
            return span1.iStartLine == span2.iStartLine && span1.iStartIndex == span2.iStartIndex && span1.iEndLine == span2.iEndLine && span1.iEndIndex == span2.iEndIndex;
        }

        // Returns true if the given position is to left of textspan.
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.IsBeforeStartOf"]/*' />
        public static bool IsBeforeStartOf(TextSpan span, int line, int col) {
            if (line < span.iStartLine || (line == span.iStartLine && col < span.iStartIndex)) {
                return true;
            }
            return false;
        }

        // Returns true if the given position is to right of textspan.
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.IsAfterEndOf"]/*' />
        public static bool IsAfterEndOf(TextSpan span, int line, int col) {
            if (line > span.iEndLine || (line == span.iEndLine && col > span.iEndIndex)) {
                return true;
            }
            return false;
        }

        // Returns true if the given position is at the edge or inside the span.
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.ContainsInclusive"]/*' />
        public static bool ContainsInclusive(TextSpan span, int line, int col) {
            if (line > span.iStartLine && line < span.iEndLine)
                return true;

            if (line == span.iStartLine) {
                return (col >= span.iStartIndex && (line < span.iEndLine ||
                    (line == span.iEndLine && col <= span.iEndIndex )));
            }
            if (line == span.iEndLine) {
                return col <= span.iEndIndex;
            }
            return false;
        }
        
        // Returns true if the given position is purely inside the span.
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.ContainsExclusive"]/*' />
        public static bool ContainsExclusive(TextSpan span, int line, int col) {
            if (line > span.iStartLine && line < span.iEndLine)
                return true;

            if (line == span.iStartLine) {
                return (col > span.iStartIndex && (line < span.iEndLine ||
                    (line == span.iEndLine && col < span.iEndIndex)));
            }
            if (line == span.iEndLine) {
                return col < span.iEndIndex;
            }
            return false;
        }

        //returns true is span1 is Embedded in span2
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.IsEmbedded"]/*' />
        public static bool IsEmbedded(TextSpan span1, TextSpan span2) {
            return ( !TextSpanHelper.IsSameSpan(span1, span2) &&
                TextSpanHelper.StartsAfterStartOf(span1, span2) &&
                    TextSpanHelper.EndsBeforeEndOf(span1, span2));
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.Intersects"]/*' />
        public static bool Intersects(TextSpan span1, TextSpan span2) {
            return TextSpanHelper.StartsBeforeEndOf(span1, span2) &&
                TextSpanHelper.EndsAfterStartOf(span1, span2);
        }

        // This method simulates what VS does in debug mode so that we can catch the
        // errors in managed code before they go to the native debug assert.
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.ValidSpan"]/*' />
        public static bool ValidSpan(Source src, TextSpan span) {
            if (!ValidCoord(src, span.iStartLine, span.iStartIndex))
                return false;

            if (!ValidCoord(src, span.iEndLine, span.iEndIndex))
                return false;

            // end must be >= start
            if (!TextSpanHelper.IsPositive(span))
                return false;

            return true;
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="TextSpanHelper.ValidCoord"]/*' />
        public static bool ValidCoord(Source src, int line, int pos) {
            // validate line
            if (line < 0) {
                Debug.Assert(false, "line < 0");
                return false;
            }

            // validate index
            if (pos < 0) {
                Debug.Assert(false, "pos < 0");
                return false;
            }

            if (src != null) {
                int lineCount = src.GetLineCount();
                if (line >= lineCount) {
                    Debug.Assert(false, "line > linecount");
                    return false;
                }

                int lineLength = src.GetLineLength(line);
                if (pos > lineLength) {
                    Debug.Assert(false, "pos > linelength");
                    return false;
                }

            }
            return true;
        }

    }

    /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant"]/*' />
    [CLSCompliant(false), StructLayout(LayoutKind.Sequential)]
    public struct Variant {

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType"]/*' />
        public enum VariantType {
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_EMPTY"]/*' />
            VT_EMPTY = 0,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_NULL"]/*' />
            VT_NULL = 1,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_I2"]/*' />
            VT_I2 = 2,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_I4"]/*' />
            VT_I4 = 3,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_R4"]/*' />
            VT_R4 = 4,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_R8"]/*' />
            VT_R8 = 5,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_CY"]/*' />
            VT_CY = 6,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_DATE"]/*' />
            VT_DATE = 7,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_BSTR"]/*' />
            VT_BSTR = 8,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_DISPATCH"]/*' />
            VT_DISPATCH = 9,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_ERROR"]/*' />
            VT_ERROR = 10,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_BOOL"]/*' />
            VT_BOOL = 11,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_VARIANT"]/*' />
            VT_VARIANT = 12,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_UNKNOWN"]/*' />
            VT_UNKNOWN = 13,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_DECIMAL"]/*' />
            VT_DECIMAL = 14,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_I1"]/*' />
            VT_I1 = 16,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_UI1"]/*' />
            VT_UI1 = 17,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_UI2"]/*' />
            VT_UI2 = 18,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_UI4"]/*' />
            VT_UI4 = 19,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_I8"]/*' />
            VT_I8 = 20,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_UI8"]/*' />
            VT_UI8 = 21,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_INT"]/*' />
            VT_INT = 22,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_UINT"]/*' />
            VT_UINT = 23,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_VOID"]/*' />
            VT_VOID = 24,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_HRESULT"]/*' />
            VT_HRESULT = 25,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_PTR"]/*' />
            VT_PTR = 26,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_SAFEARRAY"]/*' />
            VT_SAFEARRAY = 27,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_CARRAY"]/*' />
            VT_CARRAY = 28,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_USERDEFINED"]/*' />
            VT_USERDEFINED = 29,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_LPSTR"]/*' />
            VT_LPSTR = 30,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_LPWSTR"]/*' />
            VT_LPWSTR = 31,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_FILETIME"]/*' />
            VT_FILETIME = 64,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_BLOB"]/*' />
            VT_BLOB = 65,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_STREAM"]/*' />
            VT_STREAM = 66,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_STORAGE"]/*' />
            VT_STORAGE = 67,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_STREAMED_OBJECT"]/*' />
            VT_STREAMED_OBJECT = 68,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_STORED_OBJECT"]/*' />
            VT_STORED_OBJECT = 69,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_BLOB_OBJECT"]/*' />
            VT_BLOB_OBJECT = 70,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_CF"]/*' />
            VT_CF = 71,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_CLSID"]/*' />
            VT_CLSID = 72,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_VECTOR"]/*' />
            VT_VECTOR = 0x1000,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_ARRAY"]/*' />
            VT_ARRAY = 0x2000,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_BYREF"]/*' />
            VT_BYREF = 0x4000,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_RESERVED"]/*' />
            VT_RESERVED = 0x8000,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_ILLEGAL"]/*' />
            VT_ILLEGAL = 0xffff,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_ILLEGALMASKED"]/*' />
            VT_ILLEGALMASKED = 0xfff,
            /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.VariantType.VT_TYPEMASK"]/*' />
            VT_TYPEMASK = 0xfff
        };

        private ushort vt;

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.Vt"]/*' />
        public VariantType Vt {
            get {
                return (VariantType)vt;
            }
            set {
                vt = (ushort)value;
            }
        }
        short reserved1;
        short reserved2;
        short reserved3;

        private long value;

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.Value"]/*' />
        public long Value {
            get {
                return this.value;
            }
            set {
                this.value = value;
            }
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.ToVariant"]/*' />
        public static Variant ToVariant(IntPtr ptr) {
            // Marshal.GetObjectForNativeVariant is doing way too much work.
            // it is safer and more efficient to map only those things we 
            // care about.

            try {
                Variant v = (Variant)Marshal.PtrToStructure(ptr, typeof(Variant));
                return v;
#if DEBUG
            } catch (ArgumentException e) {
                Debug.Assert(false, e.Message);
#else
                } catch (ArgumentException) {
#endif
            }
            return new Variant();
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="Variant.ToChar"]/*' />
        public char ToChar() {
            if (this.Vt == VariantType.VT_UI2) {
                ushort cv = (ushort)(this.value & 0xffff);
                return Convert.ToChar(cv);
            }
            return '\0';
        }

    }
    /// <include file='doc\Utilities.uex' path='docs/doc[@for="TimeUtilities"]/*' />
    [CLSCompliant(false)]
    internal sealed class TimeUtilities {
        public static int TimeSince(int start) {
            int ticks = Environment.TickCount;
            long t = (long)ticks;
            long s = (long)start;
            // ticks wraps around every 29 days from int.MaxValue to int.MinValue, so we have to watch out 
            // for wrap around!
            if (ticks < start) {
                s = s - (long)int.MaxValue;
                t = t - (long)int.MinValue;
            }
            return (int)Math.Min((long)int.MaxValue, t - s);
        }
    }

    /// <include file='doc\Utilities.uex' path='docs/doc[@for="FilePathUtilities"]/*' />
    [CLSCompliant(false)]
    public sealed class FilePathUtilities    {
        /// <include file='doc\Utilities.uex' path='docs/doc[@for="FilePathUtilities.GetFilePath"]/*' />
        /// <summary>
        /// Get path for text buffer.
        /// </summary>
        /// <param name="textLines">The text buffer.</param>
        /// <returns>The path of the text buffer.</returns>
        [CLSCompliant(false)]
        public static string GetFilePath(IVsTextLines textLines){
            if (textLines == null){
                throw new ArgumentNullException("textLines");
            }

            return GetFilePathInternal(textLines);
        }

        /// <include file='doc\Utilities.uex' path='docs/doc[@for="FilePathUtilities.GetFilePath"]/*' />
        /// <summary>
        /// Get file path for an object that is implementing IVsUserData.
        /// </summary>
        /// <param name="unknown">Reference to an IUnknown interface.</param>
        /// <returns>The file path</returns>
        public static string GetFilePath(IntPtr unknown){
            if (unknown == IntPtr.Zero){
                throw new ArgumentNullException("unknown");}
            object obj = Marshal.GetObjectForIUnknown(unknown);
            return GetFilePathInternal(obj);
        }

        internal static string GetFilePathInternal(object obj){
            string fname = null;
            int hr = 0;
            IVsUserData ud = obj as IVsUserData;
            if (ud != null){
                object oname;
                Guid GUID_VsBufferMoniker = typeof(IVsUserData).GUID;
                hr = ud.GetData(ref GUID_VsBufferMoniker, out oname);
                if (ErrorHandler.Succeeded(hr) && oname != null)
                    fname = oname.ToString();
            }
            if (string.IsNullOrEmpty(fname)){
                IPersistFileFormat fileFormat = obj as IPersistFileFormat;
                if (fileFormat != null)
                {
                    uint format;
                    hr = fileFormat.GetCurFile(out fname, out format);
                }
            }
            if (!string.IsNullOrEmpty(fname)){
                Url url = new Url(fname);
                if (!url.Uri.IsAbsoluteUri){
                    // make the file name absolute using app startup path...
                    Url baseUrl = new Url(Application.StartupPath + Path.DirectorySeparatorChar);
                    url = new Url(baseUrl, fname);
                    fname = url.AbsoluteUrl;
                }
            }
            return fname;
        }

        /// <include file='doc\HierarchyItem.uex' path='docs/doc[@for="VsShell.GetFilePath"]/*' />
        /// <summary>This method returns the file extension in lower case, including the "."
        /// and trims any blanks or null characters from the string.  Null's can creep in via
        /// interop if we get a badly formed BSTR</summary>
        public static string GetFileExtension(string moniker){
            string ext = Path.GetExtension(moniker);
            ext = ext.Trim();
            int i = 0;
            for (i = ext.Length - 1; i >= 0; i--){
                if (ext[i] != '\0') break;
            }
            i++;
            if (i >= 0 && i < ext.Length) ext = ext.Substring(0, i);
            return ext;
        }
    }
}