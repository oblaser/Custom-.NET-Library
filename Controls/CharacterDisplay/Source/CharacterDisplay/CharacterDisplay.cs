using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomNETlib
{
    namespace Controls
    {
        namespace CharacterDisplay
        {
            public class CharacterDisplay : System.Windows.Forms.Control
            {
                //
                // const
                //
                private const string DefaultEndOfLineSequence = "\r\n";
                private const int nDotX = 5;
                private const int nDotY = 7;


                //
                // private attributes without public
                //
                private PictureBox pb;
                private char[][] _DisplayArray;
                private string[] _TextLines;
                private byte[,] _Charset;


                //
                // private attributes of publics
                //
                private Color _BackColor;
                private Color _ForeColor;
                private Color _DotOffColor;
                private DotShape _DotShape;
                private int _BorderSpace;
                private int _DigitSpace;
                private int _DotSpace;
                private int _DotSize;
                private string _EndOfLineSequence;
                private string _Text;
                private int _nColumns;
                private int _nRows;
                private CursorPosition _CursorPosition;


                //
                // public attributes
                //
                #region public attributes
                public override Color BackColor { get { return this._BackColor; } set { this._BackColor = value; this.OnBackColorChanged(EventArgs.Empty); } }
                public override Color ForeColor { get { return this._ForeColor; } set { this._ForeColor = value; this.OnForeColorChanged(EventArgs.Empty); } }
                public Color DotOffColor { get { return this._DotOffColor; } set { this._DotOffColor = value; this.OnDotOffColorChanged(EventArgs.Empty); } }
                public DotShape DotShape { get { return this._DotShape; } set { this._DotShape = value; this.PaintDotMatrix(); } }
                public int BorderSpace
                {
                    get { return this._BorderSpace; }
                    set
                    {
                        this._BorderSpace = value;
                        this.recalcSize();
                        this.PaintDotMatrix();
                    }
                }
                public int DigitSpace
                {
                    get { return this._DigitSpace; }
                    set
                    {
                        this._DigitSpace = value;
                        this.recalcSize();
                        this.PaintDotMatrix();
                    }
                }
                public int DotSpace
                {
                    get { return this._DotSpace; }
                    set
                    {
                        this._DotSpace = value;
                        this.recalcSize();
                        this.PaintDotMatrix();
                    }
                }
                public int DotSize
                {
                    get { return this._DotSize; }
                    set
                    {
                        this._DotSize = value;
                        this.recalcSize();
                        this.PaintDotMatrix();
                    }
                }
                public string EndOfLineSequence
                {
                    get { return this._EndOfLineSequence; }
                    set
                    {
                        if (String.IsNullOrEmpty(value)) this._EndOfLineSequence = DefaultEndOfLineSequence;
                        else this._EndOfLineSequence = value;

                        this.atrCpyCnv_Text_to_TextLines();
                        this.atrCpyCnv_TextLines_to_DisplayArray();
                    }
                }

                public override string Text
                {
                    get { return this._Text; }
                    set
                    {
                        this._Text = value;
                        this.atrCpyCnv_Text_to_TextLines();
                        this.atrCpyCnv_TextLines_to_DisplayArray();
                        this.OnTextChanged(EventArgs.Empty);
                    }
                }

                public int nColumns
                {
                    get { return this._nColumns; }
                    set
                    {
                        if (value < 1) throw new ArgumentOutOfRangeException();

                        this._nColumns = value;

                        this.setupDisplayArrays();
                        this.recalcSize();
                        this.PaintDotMatrix();
                    }
                }
                public int nRows
                {
                    get { return this._nRows; }
                    set
                    {
                        if (value < 1) throw new ArgumentOutOfRangeException();

                        this._nRows = value;

                        this.setupDisplayArrays();
                        this.recalcSize();
                        this.PaintDotMatrix();
                    }
                }
                public CursorPosition CursorPosition { get { return this._CursorPosition; } }
                #endregion


                //
                // constructor
                //
                public CharacterDisplay()
                {
                    this.TabStop = false;

                    this._nRows = 2;
                    this._nColumns = 16;
                    this._CursorPosition = new CursorPosition(0, 0);

                    this._EndOfLineSequence = DefaultEndOfLineSequence;
                    this._Text = String.Empty;
                    this.setupDisplayArrays();

                    this._Charset = defaultCharset();

                    this.Size = new Size(451, 79);

                    this.pb = new PictureBox();
                    this.pb.Size = this.Size;
                    this.pb.Location = new Point(0, 0);
                    this.Controls.Add(this.pb);

                    this._DotShape = DotShape.Square;
                    this._BorderSpace = 3;
                    this._DigitSpace = 3;
                    this._DotSpace = 1;
                    this._DotSize = 5;
                    this.recalcSize();

                    this.LoadColorScheme(ColorScheme.GreenOnGray);

                    this.PaintDotMatrix();
                }


                //
                // private methods
                //
                #region private methods
                private void recalcSize()
                {
                    this.Size = new Size(
                        (nDotX * this._DotSize * this._nColumns) + ((this._nColumns - 1) * this._DigitSpace) + (2 * this._BorderSpace),
                        (nDotY * this._DotSize * this._nRows) + ((this._nRows - 1) * this._DigitSpace) + (2 * this._BorderSpace));

                    this.pb.Size = new Size(this.Size.Width, this.Size.Height);
                }

                private void setupDisplayArrays()
                {
                    this._TextLines = new string[this.nRows];

                    this._DisplayArray = new char[this.nRows][];

                    for (int i = 0; i < this._DisplayArray.GetLength(0); i++) this._DisplayArray[i] = new char[this.nColumns];

                    atrCpyCnv_Text_to_TextLines();
                    atrCpyCnv_TextLines_to_DisplayArray();
                }

                private void atrCpyCnv_TextLines_to_Text()
                {
                    for (int i = 0; i < this._TextLines.Length; ++i)
                    {
                        if (i > 0) this._Text += this._EndOfLineSequence;

                        this._Text += this._TextLines[i];
                    }
                }

                private void atrCpyCnv_Text_to_TextLines()
                {
                    if (String.IsNullOrEmpty(this._Text)) for (int i = 0; i < this._TextLines.Length; ++i) this._TextLines[i] = String.Empty;
                    else
                    {
                        string[] tmp = this._Text.Split(new string[] { this.EndOfLineSequence }, StringSplitOptions.None);

                        for (int i = 0; i < this._TextLines.Length; ++i)
                        {
                            try { this._TextLines[i] = tmp[i]; }
                            catch { this._TextLines[i] = String.Empty; }
                        }
                    }
                }

                private void atrCpyCnv_TextLines_to_DisplayArray()
                {
                    for (int ri = 0; ri < this._DisplayArray.GetLength(0); ++ri)
                    {
                        try
                        {
                            char[] tmp = this._TextLines[ri].ToCharArray();

                            for (int ci = 0; ci < this._DisplayArray[ri].Length; ++ci)
                            {
                                try { this._DisplayArray[ri][ci] = tmp[ci]; }
                                catch { this._DisplayArray[ri][ci] = (char)0x20; }
                            }
                        }

                        catch
                        {
                            for (int ci = 0; ci < this._DisplayArray[ri].Length; ++ci) this._DisplayArray[ri][ci] = (char)0x20;
                        }
                    }
                }

                private void atrCpyCnv_DisplayArray_to_TextLines()
                {
                    for (int i = 0; i < this._TextLines.Length; ++i)
                    {
                        try { this._TextLines[i] = new string(this._DisplayArray[i]); }
                        catch { this._TextLines[i] = String.Empty; }
                    }
                }

                private void PaintDotMatrix()
                {
                    Bitmap bmp = new Bitmap(this.Size.Width, this.Size.Height); ;
                    Graphics g = Graphics.FromImage(bmp);

                    g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Size.Width, this.Size.Height);

                    for (int ri = 0; ri < this._DisplayArray.GetLength(0); ++ri)
                    {
                        for (int ci = 0; ci < this._DisplayArray[ri].Length; ++ci)
                        {
                            for (int dotRi = 0; dotRi < 7; ++dotRi)
                            {
                                byte tmp = this._Charset[0x20, dotRi];
                                try { tmp = this._Charset[this._DisplayArray[ri][ci], dotRi]; }
                                catch { }

                                for (int dotCi = 0; dotCi < 5; ++dotCi)
                                {
                                    Brush brush = new SolidBrush(this._DotOffColor);

                                    if ((tmp & (1 << (4 - dotCi))) != 0) brush = new SolidBrush(this.ForeColor);

                                    int x = this._BorderSpace + (dotCi * this._DotSize) + (this._DotSpace / 2) + (ci * nDotX * this._DotSize) + (ci * this._DigitSpace);
                                    int y = this._BorderSpace + (dotRi * this._DotSize) + (this._DotSpace / 2) + (ri * nDotY * this._DotSize) + (ri * this._DigitSpace);
                                    int w = this._DotSize - this._DotSpace;
                                    int h = this._DotSize - this._DotSpace;

                                    switch (this._DotShape)
                                    {
                                        case DotShape.Circle:
                                            g.FillEllipse(brush, x, y, w, h);
                                            break;

                                        case DotShape.Square:
                                        default:
                                            g.FillRectangle(brush, x, y, w, h);
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    this.pb.Image = bmp;
                }

                private void addToCharset(ref byte[,] cs, int pos, byte[] data)
                {
                    try
                    {
                        for (int i = 0; i < cs.GetLength(1); ++i) cs[pos, i] = data[i];
                    }
                    catch { }
                }
                private byte[,] defaultCharset()
                {
                    byte[,] cs = new byte[char.MaxValue + 1, 7];

                    byte[,] ascii = this.asciiCharset();

                    // set cs to 0
                    for (int i0 = 0; i0 < cs.GetLength(0); ++i0)
                    {
                        for (int i1 = 0; i1 < cs.GetLength(1); ++i1) cs[i0, i1] = 0;
                    }

                    // copy ascii
                    for (int i0 = 0; i0 < ascii.GetLength(0); ++i0)
                    {
                        for (int i1 = 0; i1 < ascii.GetLength(1); ++i1) cs[i0, i1] = ascii[i0, i1];
                    }

                    // add specific chars (https://www.compart.com/de/unicode/block/U+0080)
                    this.addToCharset(ref cs, 0x00b0, new byte[] { 14, 10, 14, 0, 0, 0, 0 });       // ° degreeSymbol
                    this.addToCharset(ref cs, 0x00b5, new byte[] { 0, 0, 17, 17, 17, 30, 16 });     // Micro Sign
                    this.addToCharset(ref cs, 0x00c4, new byte[] { 17, 14, 17, 17, 31, 17, 17 });   // Ä
                    this.addToCharset(ref cs, 0x00d6, new byte[] { 17, 14, 17, 17, 17, 17, 14 });   // Ö
                    this.addToCharset(ref cs, 0x00dc, new byte[] { 10, 0, 17, 17, 17, 17, 14 });    // Ü
                    this.addToCharset(ref cs, 0x00e4, new byte[] { 10, 0, 15, 17, 17, 19, 13 });    // ä
                    this.addToCharset(ref cs, 0x00f6, new byte[] { 10, 0, 14, 17, 17, 17, 14 });    // ö
                    this.addToCharset(ref cs, 0x00fc, new byte[] { 10, 0, 17, 17, 17, 19, 13 });    // ü
                    this.addToCharset(ref cs, 0x03a9, new byte[] { 0, 14, 17, 17, 17, 10, 27 });    // Greek Capital Letter Omega
                    this.addToCharset(ref cs, 0x2190, new byte[] { 0, 4, 8, 31, 8, 4, 0 });         // arrow left
                    this.addToCharset(ref cs, 0x2191, new byte[] { 0, 4, 14, 21, 4, 4, 0 });        // arrow up
                    this.addToCharset(ref cs, 0x2192, new byte[] { 0, 4, 2, 31, 2, 4, 0 });         // arrow right
                    this.addToCharset(ref cs, 0x2193, new byte[] { 0, 4, 4, 21, 14, 4, 0 });        // arrow down
                    this.addToCharset(ref cs, 0x2588, new byte[] { 31, 31, 31, 31, 31, 31, 31 });   // full block

                    return cs;
                }
                private byte[,] asciiCharset()
                {
                    // https://www.compart.com/de/unicode/block/U+0000

                    return new byte[,]
                    {
                        //
                        // ASCII control characters
                        //
                        /* 000 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 001 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 002 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 003 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 004 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 005 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 006 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 007 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 008 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 009 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 010 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 011 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 012 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 013 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 014 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 015 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 016 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 017 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 018 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 019 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 020 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 021 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 022 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 023 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 024 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 025 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 026 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 027 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 028 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 029 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 030 */ { 0, 0, 0, 0, 0, 0, 0 },
                        /* 031 */ { 0, 0, 0, 0, 0, 0, 0 },

                        //
                        // ASCII printable characters
                        //
                        /* 032 */ { 0, 0, 0, 0, 0, 0, 0 },                  //   (space)
                        /* 033 */ { 4, 4, 4, 4, 4, 0, 4 },                  // !
                        /* 034 */ { 10, 10, 10, 0, 0, 0, 0 },               // "
                        /* 035 */ { 0, 10, 31, 10, 31, 10, 0 },             // #
                        /* 036 */ { 4, 15, 20, 14, 5, 30, 4 },              // $
                        /* 037 */ { 24, 25, 2, 4, 8, 19, 3 },              // %
                        /* 038 */ { 12, 18, 20, 8, 21, 18, 13 },            // &
                        /* 039 */ { 4, 4, 8, 0, 0, 0, 0 },                  // '
                        /* 040 */ { 2, 4, 4, 4, 4, 4, 2 },                  // (
                        /* 041 */ { 8, 4, 4, 4, 4, 4, 8 },                  // )
                        /* 042 */ { 0, 4, 21, 14, 21, 4, 0 },               // *
                        /* 043 */ { 0, 4, 4, 31, 4, 4, 0 },                 // +
                        /* 044 */ { 0, 0, 0, 0, 4, 4, 8 },                  // ,
                        /* 045 */ { 0, 0, 0, 14, 0, 0, 0 },                 // -
                        /* 046 */ { 0, 0, 0, 0, 0, 12, 12 },                // .
                        /* 047 */ { 0, 1, 2, 4, 8, 16, 0 },                 // /

                        /* 048 */ { 14, 17, 17, 17, 17, 17, 14 },           // 0
                        /* 049 */ { 2, 6, 10, 2, 2, 2, 2 },                 // 1
                        /* 050 */ { 14, 17, 1, 2, 4, 8, 31 },                  // 2
                        /* 051 */ { 14, 17, 1, 6, 1, 17, 14 },                  // 3
                        /* 052 */ { 2, 6, 10, 18, 31, 2, 2 },                  // 4
                        /* 053 */ { 31, 16, 30, 1, 1, 17, 14 },                  // 5
                        /* 054 */ { 6, 8, 16, 30, 17, 17, 14 },                  // 6
                        /* 055 */ { 31, 1, 2, 4, 8, 8, 8 },                  // 7
                        /* 056 */ { 14, 17, 17, 14, 17, 17, 14 },                  // 8
                        /* 057 */ { 14, 17, 17, 15, 1, 2, 12 },                  // 9

                        /* 058 */ { 0, 12, 12, 0, 12, 12, 0 },              // :
                        /* 059 */ { 0, 12, 12, 0, 12, 4, 8 },               // ;
                        /* 060 */ { 2, 4, 8, 16, 8, 4, 2 },                 // <
                        /* 061 */ { 0, 0, 31, 0, 31, 0, 0 },                // =
                        /* 062 */ { 8, 4, 2, 1, 2, 4, 8 },                  // >
                        /* 063 */ { 14, 17, 17, 2, 4, 0, 4 },               // ?
                        /* 064 */ { 14, 17, 1, 13, 21, 21, 14 },            // @

                        /* 065 */ { 14, 17, 17, 17, 31, 17, 17 },             //A
                        /* 066 */ { 30, 17, 17, 30, 17, 17, 30 },		      //B
                        /* 067 */ { 14, 17, 16, 16, 16, 17, 14 },		      //C	      
                        /* 068 */ { 30, 17, 17, 17, 17, 17, 30 },		      //D
                        /* 069 */ { 31, 16, 16, 30, 16, 16, 31 },		      //E
                        /* 070 */ { 31, 16, 16, 30, 16, 16, 16 },		      //F
                        /* 071 */ { 14, 17, 16, 23, 17, 17, 14 },		      //G	
                        /* 072 */ { 17, 17, 17, 31, 17, 17, 17 },		      //H
                        /* 073 */ { 14, 4, 4, 4, 4, 4, 14 },			      //I
                        /* 074 */ { 7, 2, 2, 2, 18, 18, 12 },			      //J
                        /* 075 */ { 17, 18, 20, 24, 20, 18, 17 },		      //K
                        /* 076 */ { 16, 16, 16, 16, 16, 16, 31 },		      //L
                        /* 077 */ { 17, 27, 21, 21, 17, 17, 17 },		    	 //M
                        /* 078 */ { 17, 17, 25, 21, 19, 17, 17 },		     	 //N
                        /* 079 */ { 14, 17, 17, 17, 17, 17, 14 },			 //O
                        /* 080 */ { 30, 17, 17, 30, 16, 16, 16 },			 //P
                        /* 081 */ { 14, 17, 17, 17, 21, 14, 1 },			 //Q
                        /* 082 */ { 30, 17, 17, 30, 20, 18, 17 },			 //R
                        /* 083 */ { 14, 17, 16, 14, 1, 17, 14 },			 //S
                        /* 084 */ { 31, 4, 4, 4, 4, 4, 4 },				 //T
                        /* 085 */ { 17, 17, 17, 17, 17, 17, 14 },			 //U
                        /* 086 */ { 17, 17, 17, 17, 17, 10, 4 },			 //V
                        /* 087 */ { 17, 17, 17, 21, 21, 27, 17 },			 //W
                        /* 088 */ { 17, 17, 10, 4, 10, 17, 17 },				 //X
                        /* 089 */ { 17, 17, 17, 10, 4, 4, 4 },				 //Y
                        /* 090 */ { 31, 1, 2, 4, 8, 16, 31 },                 //Z

                        /* 091 */ { 14, 8, 8, 8, 8, 8, 14 },                // [
                        /* 092 */ { 0, 16, 8, 4, 2, 1, 0 },                 // \ 
                        /* 093 */ { 14, 2, 2, 2, 2, 2, 14 },                // ]
                        /* 094 */ { 4, 10, 17, 0, 0, 0, 0 },                // ^
                        /* 095 */ { 0, 0, 0, 0, 0, 0, 31 },                 // _
                        /* 096 */ { 8, 4, 2, 0, 0, 0, 0 },                  // `

                        /* 097 */ { 0, 0, 15, 17, 17, 19, 13 },             // a
                        /* 098 */ { 16, 16, 22, 25, 17, 17, 30 },           // b
                        /* 099 */ { 0, 0, 14, 16, 16, 16, 14 },             // c
                        /* 100 */ { 1, 1, 13, 19, 17, 17, 15 },             // d
                        /* 101 */ { 0, 0, 14, 17, 30, 16, 14 },             // e
                        /* 102 */ { 6, 9, 8, 28, 8, 8, 8 },                 // f
                        /* 103 */ { 0, 15, 17, 17, 15, 1, 14 },             // g
                        /* 104 */ { 16, 16, 22, 25, 17, 17, 17 },           // h
                        /* 105 */ { 0, 4, 0, 12, 4, 4, 14 },                // i
                        /* 106 */ { 0, 2, 0, 2, 2, 10, 4 },                 // j
                        /* 107 */ { 16, 16, 18, 20, 24, 20, 18 },           // k
                        /* 108 */ { 12, 4, 4, 4, 4, 4, 14 },                // l
                        /* 109 */ { 0, 0, 26, 21, 21, 21, 17 },             // m
                        /* 110 */ { 0, 0, 22, 25, 17, 17, 17 },             // n
                        /* 111 */ { 0, 0, 14, 17, 17, 17, 14 },             // o
                        /* 112 */ { 0, 0, 28, 18, 28, 16, 16 },             // p
                        /* 113 */ { 0, 0, 13, 19, 15, 1, 1 },               // q
                        /* 114 */ { 0, 0, 22, 25, 16, 16, 16 },             // r
                        /* 115 */ { 0, 0, 14, 16, 14, 1, 14 },              // s
                        /* 116 */ { 8, 8, 28, 8, 8, 8, 4 },                 // t
                        /* 117 */ { 0, 0, 17, 17, 17, 19, 13 },             // u
                        /* 118 */ { 0, 0, 17, 17, 17, 10, 4 },              // v
                        /* 119 */ { 0, 0, 17, 17, 21, 21, 10 },             // w
                        /* 120 */ { 0, 0, 17, 10, 4, 10, 17 },              // x
                        /* 121 */ { 0, 0, 17, 17, 15, 1, 14 },              // y
                        /* 122 */ { 0, 0, 31, 2, 4, 8, 31 },                // z

                        /* 123 */ { 2, 4, 4, 8, 4, 4, 2 },                  // {
                        /* 124 */ { 4, 4, 4, 4, 4, 4, 4 },                  // |
                        /* 125 */ { 8, 4, 4, 2, 4, 4, 8 },                  // }
                        /* 126 */ { 0, 0, 8, 21, 2, 0, 0 },                 // ~

                        //
                        // ASCII control character 127
                        //
                        /* 127 */ { 0, 0, 0, 0, 0, 0, 0 }
                    };
                }

                private bool isValidCursorPosition(CursorPosition position)
                {
                    if ((position.Row >= this._nRows) || (position.Row < 0) ||
                        (position.Column >= this._nColumns) || (position.Column < 0))
                    {
                        return false;
                    }

                    return true;
                }
                #endregion


                //
                // public methods
                //
                #region public methods
                public byte[,] GetCharset() { return this._Charset; }
                /// <summary>
                /// Sets the hole charset.
                /// </summary>
                /// <param name="charset"></param>
                public void SetCharset(byte[,] charset)
                {
                    this._Charset = charset;
                    this.PaintDotMatrix();
                }
                /// <summary>
                /// Overwrites the dot graphic at a specific position.
                /// </summary>
                /// <param name="position"></param>
                /// <param name="dotGraph"></param>
                public void SetCharset(int position, byte[] dotGraph) { this.addToCharset(ref this._Charset, position, dotGraph); }
                public void SetCharsetToDefault()
                {
                    this._Charset = this.defaultCharset();
                    this.PaintDotMatrix();
                }
                public string[] GetTextLines() { return this._TextLines; }
                public void SetTextLines(string[] lines)
                {
                    for (int i = 0; i < this._TextLines.Length; ++i)
                    {
                        try { this._TextLines[i] = lines[i]; }
                        catch { };
                    }

                    this.atrCpyCnv_TextLines_to_Text();
                    this.atrCpyCnv_TextLines_to_DisplayArray();
                    this.OnTextChanged(EventArgs.Empty);
                }
                public char[][] GetDisplayArray() { return this._DisplayArray; }
                public void SetDisplayArray(char[][] arr)
                {
                    for (int ri = 0; ri < this._DisplayArray.GetLength(0); ++ri)
                    {
                        try
                        {
                            for (int ci = 0; ci < this._DisplayArray[ri].Length; ++ci)
                            {
                                try { this._DisplayArray[ri][ci] = arr[ri][ci]; }
                                catch { this._DisplayArray[ri][ci] = (char)0x20; }
                            }
                        }

                        catch
                        {
                            for (int ci = 0; ci < this._DisplayArray[ri].Length; ++ci) this._DisplayArray[ri][ci] = (char)0x20;
                        }
                    }

                    this.atrCpyCnv_DisplayArray_to_TextLines();
                    this.atrCpyCnv_TextLines_to_Text();
                    this.OnTextChanged(EventArgs.Empty);
                }
                public Image GetImage()
                {
                    return this.pb.Image;
                }
                public void SetDisplaySize(int nRows, int nColumns)
                {
                    if ((nRows < 1) || (nColumns < 1)) throw new ArgumentOutOfRangeException();

                    this._nRows = nRows;
                    this._nColumns = nColumns;

                    this.setupDisplayArrays();
                    this.recalcSize();
                    this.PaintDotMatrix();
                }

                /// <summary>
                /// Gets the first character of the EndOfLineSequence attribute.
                /// </summary>
                public char GetEndOfLineSequenceChar() { return this.EndOfLineSequence.ToCharArray()[0]; }

                /// <summary>
                /// Sets the EndOfLineSequence attribute to a single character.
                /// </summary>
                /// <param name="c"></param>
                public void SetEndOfLineSequenceChar(char c) { this.EndOfLineSequence = Char.ToString(c); }

                public void SetCursorPosition(CursorPosition position)
                {
                    if (!this.isValidCursorPosition(position)) throw new ArgumentOutOfRangeException();

                    this._CursorPosition = position;
                }
                public void SetCursorPosition(int Row, int Column)
                {
                    CursorPosition p = new CursorPosition(Row, Column);

                    if (!this.isValidCursorPosition(p)) throw new ArgumentOutOfRangeException();

                    this._CursorPosition = p;
                }

                /// <summary>
                /// Writes Text to the current cursor position.
                /// </summary>
                /// <param name="text">End of line sequences haven't any effect to the cursor.</param>
                public void SetText(string text)
                {
                    try { this.SetText(text.ToCharArray()); }
                    catch (Exception ex) { throw ex; }
                }

                /// <summary>
                /// Writes Text to the current cursor position.
                /// </summary>
                /// <param name="text">End of line sequences haven't any effect to the cursor.</param>
                public void SetText(char[] text)
                {
                    if (!this.isValidCursorPosition(this._CursorPosition)) throw new ArgumentOutOfRangeException();

                    int x = this._CursorPosition.X;
                    int y = this._CursorPosition.Y;

                    try
                    {
                        for (int i = x; i < this._DisplayArray[y].Length; ++i)
                        {
                            try
                            {
                                this._DisplayArray[y][i] = text[i - x];
                            }
                            catch { break; }

                            this._CursorPosition.X++;
                        }
                    }
                    catch { throw new ArgumentException(); }

                    if (this._CursorPosition.X >= this._nColumns) this._CursorPosition.X = this._nColumns - 1;

                    this.atrCpyCnv_DisplayArray_to_TextLines();
                    this.atrCpyCnv_TextLines_to_Text();
                    this.PaintDotMatrix();
                }

                /// <summary>
                /// Writes Text to a specific cursor position without any effect to the actual cursor position.
                /// </summary>
                /// <param name="text">End of line sequences haven't any effect to the cursor.</param>
                /// <param name="position"></param>
                public void SetText(string text, CursorPosition position)
                {
                    try { this.SetText(text.ToCharArray(), position); }
                    catch (Exception ex) { throw ex; }
                }

                /// <summary>
                /// Writes Text to a specific cursor position without any effect to the actual cursor position.
                /// </summary>
                /// <param name="text">End of line sequences haven't any effect to the cursor.</param>
                /// <param name="position"></param>
                public void SetText(char[] text, CursorPosition position)
                {
                    if (!this.isValidCursorPosition(position)) throw new ArgumentOutOfRangeException();

                    try
                    {
                        for (int i = position.X; i < this._DisplayArray[position.Y].Length; ++i)
                        {
                            try { this._DisplayArray[position.Y][i] = text[i - position.X]; }
                            catch { break; }
                        }
                    }
                    catch { throw new ArgumentException(); }

                    this.atrCpyCnv_DisplayArray_to_TextLines();
                    this.atrCpyCnv_TextLines_to_Text();
                    this.PaintDotMatrix();
                }

                public void LoadColorScheme(ColorScheme scheme)
                {
                    Color bg = Color.FromKnownColor(KnownColor.Control);
                    Color fg = Color.FromKnownColor(KnownColor.ControlText);
                    Color dotOff = Color.FromKnownColor(KnownColor.ControlLightLight);

                    switch (scheme)
                    {
                        case ColorScheme.GreenOnGray:
                            bg = Color.FromArgb(71, 71, 71);
                            fg = Color.FromArgb(0, 156, 41);
                            dotOff = Color.FromArgb(82, 82, 82);
                            break;

                        case ColorScheme.WhiteOnBlue:
                            bg = Color.FromArgb(0, 0, 255);
                            fg = Color.FromArgb(242, 242, 242);
                            dotOff = Color.FromArgb(40, 40, 255);
                            break;

                        case ColorScheme.Windows:
                        default:
                            bg = Color.FromKnownColor(KnownColor.Control);
                            fg = Color.FromKnownColor(KnownColor.ControlText);
                            dotOff = Color.FromKnownColor(KnownColor.ControlLightLight);
                            break;
                    }

                    this._BackColor = bg;
                    this._ForeColor = fg;
                    this._DotOffColor = dotOff;
                    this.PaintDotMatrix();
                }
                #endregion


                //
                // overrided base class events
                //
                protected override void OnBackColorChanged(EventArgs e)
                {
                    base.OnBackColorChanged(e);
                    this.PaintDotMatrix();
                }
                protected override void OnForeColorChanged(EventArgs e)
                {
                    base.OnForeColorChanged(e);
                    this.PaintDotMatrix();
                }
                protected override void OnTextChanged(EventArgs e)
                {
                    base.OnTextChanged(e);
                    this.PaintDotMatrix();
                }


                //
                // events
                //
                public event EventHandler DotOffColorChanged;


                //
                // event rise methods
                //
                protected virtual void OnDotOffColorChanged(EventArgs e)
                {
                    if (DotOffColorChanged != null) DotOffColorChanged(this, e);
                    this.PaintDotMatrix();
                }
            }

            public enum DotShape
            {
                Square = 0,
                Circle
            }

            public enum ColorScheme
            {
                GreenOnGray,
                WhiteOnBlue,
                Windows
            }

            /// <summary>
            /// Represents a 0 based cursor position relative to the top left corner.
            /// </summary>
            public struct CursorPosition
            {
                public static CursorPosition Null = new CursorPosition(0, 0);

                private int r;
                private int c;

                public int Row
                {
                    get { return this.r; }
                    set { this.r = value; }
                }

                public int Column
                {
                    get { return this.c; }
                    set { this.c = value; }
                }

                public int X
                {
                    get { return this.c; }
                    set { this.c = value; }
                }

                public int Y
                {
                    get { return this.r; }
                    set { this.r = value; }
                }

                public CursorPosition(int Row, int Column)
                {
                    this.r = Row;
                    this.c = Column;
                }

                public CursorPosition(System.Drawing.Point Position)
                {
                    this.r = Position.Y;
                    this.c = Position.X;
                }
            }
        }
    }
}
