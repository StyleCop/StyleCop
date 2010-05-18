using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;

namespace Microsoft.VisualStudio.Package {

    /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer"]/*' />
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class Colorizer : IVsColorizer, IDisposable {
        IScanner scanner;
        TokenInfo[] cachedLineInfo;
        int cachedLine;
        int cachedLineState;
        string cachedLineText;
        int suspended;
        LanguageService svc;
        internal IVsTextLines buffer;

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.Colorizer"]/*' />
        public Colorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner) {
            this.cachedLine = -1;
            this.scanner = scanner;
            this.svc = svc;
            this.buffer = buffer;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.Finalize"]/*' />
        ~Colorizer() {
#if LANGTRACE
            Trace.WriteLine("~Colorizer");
#endif
            Dispose(false);
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.Dispose"]/*' />
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            // We do not null out the scanner since we don't need to, it's a managed object, and 
            // we may need it if a paint message comes in after colorizer is closed since the core
            // text editor will still call ColorizeLine in that case.  This stops the text from
            // going black when the window is closed.
            // this.scanner = null; 
            this.cachedLineInfo = null;
            this.svc = null;
            this.buffer = null;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.Scanner"]/*' />
        public IScanner Scanner {
            get { return this.scanner; }
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.CloseColorizer"]/*' />
        public virtual void CloseColorizer() {
            if (this.svc != null) {
                svc.OnCloseColorizer(this);
            }
            Dispose(true);
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.GetStateMaintenanceFlag"]/*' />
        public virtual int GetStateMaintenanceFlag(out int flag) {
            flag = 1;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.GetStartState"]/*' />
        public virtual int GetStartState(out int start) {
            start = 0;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.GetStateAtEndOfLine"]/*' />
        public virtual int GetStateAtEndOfLine(int line, int length, IntPtr ptr, int state) {
            return ColorizeLine(line, length, ptr, state, null);
        }

        TokenInfo tokenInfo = new TokenInfo();

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.ColorizeLine"]/*' />
        public virtual int ColorizeLine(int line, int length, IntPtr ptr, int state, uint[] attrs) {
            int linepos = 0;
            if (this.scanner != null) {
                try {
                    string text = Marshal.PtrToStringUni(ptr, length);

                    this.scanner.SetSource(text, 0);

                    tokenInfo.EndIndex = -1;
                    
                    while (this.scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state)) {
                        if (attrs != null) {
                            for (; linepos < tokenInfo.StartIndex; linepos++)
                                attrs[linepos] = (uint)TokenColor.Text;

                            uint color = (uint)tokenInfo.Color;
                            if (tokenInfo.Type == TokenType.Comment ||
                                tokenInfo.Type == TokenType.LineComment ||
                                tokenInfo.Type == TokenType.String ||
                                tokenInfo.Type == TokenType.Text) {
                                color |= (uint)COLORIZER_ATTRIBUTE.HUMAN_TEXT_ATTR;
                            }
                            for (; linepos <= tokenInfo.EndIndex; linepos++)
                                attrs[linepos] = color;
                        }
                    }
#if LANGTRACE
                } catch (Exception e) {
                    Debug.Assert(false, "ColorizeLine caught exception:\n" + e.ToString());
#else
                } catch (Exception) {
#endif
                }
            }
            if (attrs != null) {
                // Must initialize the colors in all cases, otherwise you get 
                // random color junk on the screen.
                for (; linepos < length; linepos++)
                    attrs[linepos] = (uint)TokenColor.Text;
            }
            return state;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.GetColorInfo"]/*' />
        public virtual int GetColorInfo(string line, int length, int state) {
            if (this.scanner == null) return 0;

            this.scanner.SetSource(line, 0);

            ArrayList cache = new ArrayList();
            TokenInfo tokenInfo = new TokenInfo();

            tokenInfo.EndIndex = -1;

            bool firstTime = true;

            while (this.scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state)) {
                if (firstTime && tokenInfo.StartIndex > 1) {
                    cache.Add(new TokenInfo(0, tokenInfo.StartIndex - 1, TokenType.WhiteSpace));
                }

                firstTime = false;
                cache.Add(tokenInfo);
                tokenInfo = new TokenInfo();
            }

            if (cache.Count > 0) {
                tokenInfo = (TokenInfo)cache[cache.Count - 1];
            }

            if (tokenInfo.EndIndex < length - 1) {
                cache.Add(new TokenInfo(tokenInfo.EndIndex + 1, length - 1, TokenType.WhiteSpace));
            }

            this.cachedLineInfo = (TokenInfo[])cache.ToArray(typeof(TokenInfo));
            return state;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.GetLineInfo"]/*' />
        public virtual TokenInfo[] GetLineInfo(IVsTextLines buffer, int line, IVsTextColorState colorState) {

            int length;

            NativeMethods.ThrowOnFailure(buffer.GetLengthOfLine(line, out length));
            if (length == 0)
                return null;

            string text;

            NativeMethods.ThrowOnFailure(buffer.GetLineText(line, 0, line, length, out text));

            int state;

            NativeMethods.ThrowOnFailure(colorState.GetColorStateAtStartOfLine(line, out state));

            if (this.cachedLine == line && this.cachedLineText == text &&
                this.cachedLineState == state && this.cachedLineInfo != null) {
                return this.cachedLineInfo;
            }

            // recolorize the line, and cache the results
            this.cachedLineInfo = null;
            this.cachedLine = line;
            this.cachedLineText = text;
            this.cachedLineState = state;

            // GetColorInfo will update the cache. Note that here we don't use NativeMethods.ThrowOnFailure
            // because the return code is the current parsing state, not an HRESULT.
            GetColorInfo(text, length, state);

            //now it should be in the cache
            return this.cachedLineInfo;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.Suspend"]/*' />
        public virtual void Suspend() {
            suspended++;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.Resume"]/*' />
        public virtual void Resume() {
            suspended--;
            Debug.Assert(suspended >= 0);
        }

    }

    /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem"]/*' />
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class ColorableItem : IVsColorableItem, IVsHiColorItem, IVsMergeableUIItem {
        string name, displayName;
        COLORINDEX foreColor, backColor;
        Color hiForeColor, hiBackColor;
        FONTFLAGS fontFlags;

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.ColorableItem"]/*' />
        public ColorableItem(string name, string displayName, COLORINDEX foreColor, COLORINDEX backColor, Color hiForeColor, Color hiBackColor, FONTFLAGS fontFlags) {
            this.name = name;
            this.displayName = displayName;
            this.foreColor = foreColor;
            this.backColor = backColor;
            this.fontFlags = fontFlags;
            this.hiForeColor = hiForeColor;
            this.hiBackColor = hiBackColor;
        }

        #region IVsColorableItem methods
        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.GetDefaultColors"]/*' />
        public virtual int GetDefaultColors(COLORINDEX[] foreColor, COLORINDEX[] backColor) {
            if (foreColor != null) foreColor[0] = this.foreColor;
            if (backColor != null) backColor[0] = this.backColor;
            return NativeMethods.S_OK;
        }
        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.GetDefaultFontFlags"]/*' />
        public virtual int GetDefaultFontFlags(out uint fontFlags) {
            fontFlags = (uint)this.fontFlags;
            return NativeMethods.S_OK;
        }
        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.GetDisplayName"]/*' />
        public virtual int GetDisplayName(out string name) {
            name = this.displayName;
            return NativeMethods.S_OK;
        }
        #endregion

        #region IVsHiColorItem methods
        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="Colorizer.GetColorData"]/*' />
        public virtual int GetColorData(int cdElement, out uint crColor) 
        {
            crColor = 0;

            switch (cdElement) 
            {
                case (int)__tagVSCOLORDATA.CD_FOREGROUND: 
                    {
                        if (!this.hiForeColor.IsEmpty) 
                        {
                            crColor = ColorToRgb(this.hiForeColor);
                            return NativeMethods.S_OK;
                        }
                        break;
                    }
                case (int)__tagVSCOLORDATA.CD_BACKGROUND: 
                    {
                        if (!this.hiBackColor.IsEmpty) 
                        {
                            crColor = ColorToRgb(this.hiBackColor);
                            return NativeMethods.S_OK;
                        }
                        break;
                    }
                default:
                    return NativeMethods.E_FAIL;
            }

            return NativeMethods.E_FAIL;
        }

        private uint ColorToRgb(Color color) 
        {
            byte red = (byte)color.R;
            short green = (short)(byte)color.G;
            int blue = (byte)color.B;

            return (uint)(red | (green << 8) | (blue << 16));
        }
        #endregion


        #region IVsMergeableUIItem Members

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.GetCanonicalName"]/*' />
        public virtual int GetCanonicalName(out string name) {
            name = this.name;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.GetDescription"]/*' />
        public virtual int GetDescription(out string desc) {
            // The reason this is not implemented is because the core text editor
            // doesn't use it.
            desc = null;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\Colorizer.uex' path='docs/doc[@for="ColorableItem.GetMergingPriority"]/*' />
        public virtual int GetMergingPriority(out int priority) {
            priority = -1;
            return NativeMethods.E_NOTIMPL;
        }

        #endregion
    }
}