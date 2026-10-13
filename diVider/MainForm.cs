 /*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 11.03.2022
 * Time: 19:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace diVider {
    
    public partial class MainForm : Form {
        
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        
        IntPtr hWnd;
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        
        
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);
        
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;
        const uint SWP_NOACTIVATE = 0x0010;
        
        
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        const int SW_SHOWNORMAL = 1;
        
        public struct Rect {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
        
        bool InternalClosing = false;
        bool lBtnDownLast = false;
        
        int screenWidth = 100, screenHeight = 100;
        int screenLeft = 0, screenTop = 0;
        
        int dX = 80, dY = 50;
        Point p1 = new Point(0, 0), oldP1 = new Point(0, 0);
        Point pStart = new Point(), pStop = new Point();
                    
        SelectionPad firstPad = null;
        
        String settingsFile = "screeen_divider.conf";
        
        AdvancedKey Key_Activate = new AdvancedKey( new Keys[] { Keys.LControlKey , Keys.LWin } );
        AdvancedKey Key_Esc = new AdvancedKey( Keys.Escape );
        AdvancedKey Key_Enter = new AdvancedKey( Keys.Enter );
        
        Timer timerKeys = new Timer();
        
        int _lastWidth  = 0;
        int _lastHeight = 0;
        SelectionPad _padRT = new SelectionPad(); // Right Top
        SelectionPad _padRD = new SelectionPad(); // Right Down
        SelectionPad _padLD = new SelectionPad(); // Left Down
        SelectionPad _padLT = new SelectionPad(); // Left Top

        void supportPadsUpdateSize() {
            _padLD.Width    = dX;
            _padLD.Height   = dY;
            _padLT.Width    = dX;
            _padLT.Height   = dY;
            _padRD.Width    = dX;
            _padRD.Height   = dY;
            _padRT.Width    = dX;
            _padRT.Height   = dY;
        }
        
        void supportPadsShow() {
            supportPadsUpdateSize();
            _padLD.BackColor = Color.Red;
            _padLT.BackColor = Color.Red;
            _padRD.BackColor = Color.Red;
            _padRT.BackColor = Color.Red;
            
            _padLD.Opacity = 0.7;
            _padLT.Opacity = 0.7;
            _padRD.Opacity = 0.7;
            _padRT.Opacity = 0.7;
            
            _padLD.Show();
            _padLT.Show();
            _padRD.Show();
            _padRT.Show();
        }
        
        void supportPadsHide() {
            _padLD.Hide();
            _padLT.Hide();
            _padRD.Hide();
            _padRT.Hide();
        }
        
        Keys[] StringIntToKeys( string keystr ) {
            Keys[] keys1 = new Keys[1];
            
            try {
                string[] keyCodes = keystr.Split( '+' );
                
                keys1 = new Keys[ keyCodes.Length ];
                
                for( int i = 0; i < keyCodes.Length; i++ ) {
                    keys1[i] = (Keys)( Convert.ToInt32( keyCodes[ i ] ) );
                }
            } catch {}
            
            return keys1;
        }
        
        void SetNewActiveKey( string keystr ) {
            Keys[] keys1 = StringIntToKeys( keystr );
            Key_Activate.SetNewKeys( keys1 );
        }
        
        void timerKeys_TestForKeys(object sender, EventArgs e) {
            
            if( tlStrpMnItActive.Checked ) {
                Key_Activate.TryKey();
                if( Key_Activate.KeyDownFirst && !timer1.Enabled) {
                    supportPadsUpdateSize();
                    LoadForApplication();
                    timer1.Start();
                }
            }
            
            if( timer1.Enabled ){
                Key_Esc.TryKey();
                if( Key_Esc.KeyDownFirst ) CancleNewSize();
            } else { 
                if( Visible ) {
                    Hide();
                    supportPadsHide();
                }
            }
            
        }
        
        bool firstLaunch = true;
        public MainForm() {
            InitializeComponent();
            
            GetMaxSizeOfScreens();
            ReadSettings();
//            UpdateGrid();
            UpdateByPadSize();
            
            timerKeys.Interval = 50;
            timerKeys.Tick += timerKeys_TestForKeys;
            timerKeys.Start();
            
            notifyIcon1.Visible = true;
            Hide();
            
            supportPadsShow();
            supportPadsHide();
        }
        
        void MainFormLoad(object sender, EventArgs e) {
            if( firstLaunch ) {
                Hide();
                supportPadsHide();
                firstLaunch = false; }
        }
        
        void OpacityTlStrpTxtBxTextChanged(object sender, EventArgs e) {
            UpdateOpacity();
        }
        
        void Timer1Tick(object sender, EventArgs e) {
            if( Width < 2*dX + 10 ) Width = 2*dX + 10;
            if( Height < 2*dY + 10 ) Height = 2*dY+ 10;
            
        
            Point mp = MousePosition;
            p1 = mp;
            
/* Good method to calculate the left upper corner of the pad; relative to the (0,0) of all screens */
            p1.X = ( ( mp.X - (mp.X < 0 ? dX : 0) ) / dX) * dX;
            p1.Y = ( ( mp.Y - (mp.Y < 0 ? dY : 0) ) / dY) * dY;
            
            if( oldP1.X != p1.X || oldP1.Y != p1.Y ) {
                Left = mp.X - Width/2;
                Top = mp.Y - Height/2;
                
                Refresh();
            }
            
            if( firstPad == null ) {
				_padLT.Left = p1.X - _lastWidth + dX;
				_padLD.Left = p1.X - _lastWidth + dX;
				_padRT.Left = p1.X + _lastWidth - dX;
				_padRD.Left = p1.X + _lastWidth - dX;
				
				_padLT.Top = p1.Y - _lastHeight + dY;
				_padRT.Top = p1.Y - _lastHeight + dY;
				_padLD.Top = p1.Y + _lastHeight - dY;
				_padRD.Top = p1.Y + _lastHeight - dY;
            }
            
            oldP1 = p1;
            
            if( GetAsyncKeyState( Keys.LButton ) != 0 && !lBtnDownLast) {
                lBtnDownLast = true;
                if( firstPad != null ) {
                    timer1.Stop();
                    pStart = firstPad.Location;
                    pStop = p1;
                    
                    
                    if( pStop.X < pStart.X ) {
                        int a = pStop.X;
                        pStop.X = pStart.X;
                        pStart.X = a;
                    }
                    
                    if( pStop.Y < pStart.Y ) {
                        int a = pStop.Y;
                        pStop.Y = pStart.Y;
                        pStart.Y = a;
                    }
                    
                    pStop.X += dX; pStop.Y += dY;
                    
                    ApplyNewSize();
                    
                    Hide();
                    supportPadsHide();
                } else {
                    firstPad = new SelectionPad();
                    firstPad.Show();
                    firstPad.Width = dX;
                    firstPad.Height = dY;
                    firstPad.Location = p1;
                    
                }
            } else if( GetAsyncKeyState( Keys.LButton ) == 0 ) { lBtnDownLast = false; }
        }
        
        void MainFormPaint(object sender, PaintEventArgs e) {
            e.Graphics.Clear( TransparencyKey );
            e.Graphics.FillRectangle( new SolidBrush( Color.Green ), new Rectangle( p1.X - Left, p1.Y - Top, dX, dY ) );
        }
        
        // These magic numbers represents thickness of a window border
        // x -= 7, width += 14, height += 7        
        public void ApplyNewSize() {
            ShowWindow( hWnd, SW_SHOWNORMAL );
            //SetWindowPos( hWnd, IntPtr.Zero, 0, 0, 320, 300, SWP_NOACTIVATE );
            SetWindowPos( hWnd, IntPtr.Zero,
                pStart.X - 7, pStart.Y, pStop.X - pStart.X + 14, pStop.Y - pStart.Y + 7,
                SWP_NOACTIVATE );
            
            _lastWidth  = Math.Abs(pStop.X - pStart.X);
            _lastHeight = Math.Abs(pStop.Y - pStart.Y);
            
            if( firstPad != null ) { firstPad.Dispose(); firstPad = null; }
        }
        
        
        public void CancleNewSize() {
            if( firstPad != null ) { firstPad.Dispose(); firstPad = null; }
            Hide();
            supportPadsHide();
            timer1.Stop();
        }
        
        void MainFormFormClosing(object sender, FormClosingEventArgs e) {
            if( !InternalClosing ) e.Cancel = true;
            
            SaveSettings();
        }
        
        
        void TlStrpMnItCloseClick(object sender, EventArgs e) {
            InternalClosing = true;
            Application.Exit();
        }
        
        
        public void LoadForApplication(){
            hWnd = GetForegroundWindow();
            
            Rect rect = new Rect();
            GetWindowRect( hWnd, ref rect );
            
            int capacity = GetWindowTextLength( hWnd ) * 2;
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(capacity);
            
            GetWindowText( hWnd, stringBuilder, stringBuilder.Capacity );
            
            Show();
            supportPadsShow();
        }
        
        
        void ReadSettings() {
            if( File.Exists( settingsFile ) ){
                using( StreamReader rd = new StreamReader(settingsFile) ){
                    String line = "";
                    
                    while( ( line = rd.ReadLine() ) != null ){    
                        if( line.Contains("=") ){
                            
                            String data = line.Substring( line.IndexOf('=') + 1 );
                            
                            if( line.Contains("COLS") )
                                colsTlStrpTxtBx.Text = data.Substring( 0, data.IndexOf(';') );
                            
                            if( line.Contains("ROWS") )
                                rowsTlStrpTxtBx.Text = data.Substring( 0, data.IndexOf(';') );
                            
                            if( line.Contains("OPACITY") )
                                opacityTlStrpTxtBx.Text = data.Substring( 0, data.IndexOf(';') );
                            
                            if( line.Contains("WIDTH") )
                                padWidthTlStrpTxtBx.Text = data.Substring( 0, data.IndexOf(';') );
                            
                            if( line.Contains("HEIGHT") )
                                padHeightTlStrpTxtBx.Text = data.Substring( 0, data.IndexOf(';') );
                        }
                    }
                }
            }
        }
        
        void SaveSettings(){
            using( StreamWriter sw = new StreamWriter( settingsFile ) ){
                sw.WriteLine( "ROWS=" + rowsTlStrpTxtBx.Text + ";" );
                sw.WriteLine( "COLS=" + colsTlStrpTxtBx.Text + ";" );
                sw.WriteLine( "OPACITY=" + opacityTlStrpTxtBx.Text + ";" );
                sw.WriteLine( "WIDTH=" + padWidthTlStrpTxtBx.Text + ";" );
                sw.WriteLine( "HEIGHT=" + padHeightTlStrpTxtBx.Text + ";" );
            }
        }
        
        void UpdateTlStrpMnItmClick(object sender, EventArgs e) {
            UpdateGrid();
        }
        
        void GetMaxSizeOfScreens() {
            int screenRight = 0;
            foreach( Screen s in Screen.AllScreens ){
                
                if( s.WorkingArea.Left + s.WorkingArea.Width >= screenRight )
                    screenRight = s.WorkingArea.Left + s.WorkingArea.Width;
                    
                if( s.WorkingArea.Top + s.WorkingArea.Height >= screenHeight )
                    screenHeight = s.WorkingArea.Top + s.WorkingArea.Height;
                
                if( s.WorkingArea.Left <= screenLeft ) screenLeft = s.WorkingArea.Left;
                if( s.WorkingArea.Top <= screenTop ) screenTop = s.WorkingArea.Top;
            }
            screenWidth = screenRight - screenLeft;
            int i = 0;
        }
        
        void UpdateGrid(){
            try {
                int cols, rows;
                cols = Math.Abs( Convert.ToInt32( colsTlStrpTxtBx.Text ) );
                rows = Math.Abs( Convert.ToInt32( rowsTlStrpTxtBx.Text ) );
                
                dX = screenWidth/cols;
                dY = screenHeight/rows;
                
                padWidthTlStrpTxtBx.Text = dX.ToString();
                padWidthTlStrpTxtBx.Text = dY.ToString();
            } catch { }
        }
        
        void UpdateOpacity() {
            double newOpacity = this.Opacity;
            try {
                newOpacity = (double)(
                    Convert.ToInt16(
                        opacityTlStrpTxtBx.Text.Replace("%", " ")
                    )
                ) / 100;
                
                this.Opacity = newOpacity;
            } catch {}
        }
        
        void UpdatePadSizeTlStrpMnItmClick(object sender, EventArgs e) {
            UpdateByPadSize();
        }
        
        void UpdateByPadSize() {
            try {
                dX = Math.Abs( Convert.ToInt32( padWidthTlStrpTxtBx.Text ) );
                dY = Math.Abs( Convert.ToInt32( padHeightTlStrpTxtBx.Text ) );
                
                Width = dX;
                Height = dY;
            } catch { }
        }
    }
}
