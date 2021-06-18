using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwitcherX
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();


            setConst();

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(SwitcherX.ModifierKeys.Control | SwitcherX.ModifierKeys.Shift,
                Keys.F12);
            this.WindowState = FormWindowState.Minimized;
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            //this.Text = e.Modifier.ToString() + " + " + e.Key.ToString();

            if (chkClip.Checked)
            {
                txtFrom.Text =Clipboard.GetText();
                if (chkAuto.Checked)
                {
                    txtTo.Text = puntoSwitch(txtFrom.Text);
                    Clipboard.SetText(txtTo.Text);
                    this.WindowState = FormWindowState.Minimized;
                    return;
                }
            }

            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }


        const string alphabitEn = "qwertyuiop[]\\asdfghjkl;'zxcvbnm,./`1234567890-=";
        //const string alphabitEnShiftFrom = "QWERTYUIOP[]\\ASDFGHJKL;'ZXCVBNM,./`1234567890-=";
        const string alphabitEnShiftTo = "QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?~!@#$%^&*()_+";
        const string alphabitRu = "йцукенгшщзхъ\\фывапролджэячсмитьбю.ё1234567890-=";
        const string alphabitRuShiftTo = "ЙЦУКЕНГШЩЗХЪ\\ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,Ё!\"№;%:?*()_+";


        static List<String> list = new List<String>();
   

        static string puntoSwitch(string toDec)
        {
            string dec = "";
            Boolean wayFound = false;
            try
            {
                for (int i = 0; i < toDec.Length; i++)
                {
                    wayFound = false;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j][0] == toDec[i])
                        {
                            dec += list[j][1];
                            wayFound = true;
                            break;
                        }
                    }
                    if (!wayFound)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j][1] == toDec[i])
                            {
                                dec += list[j][0];
                                wayFound = true;
                                break;
                            }
                        }
                    }

                    if (!wayFound)
                    {
                        dec += toDec[i];
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dec;
        }

        static void setConst()
        {
            list.Add("`ё");
            list.Add("qй");
            list.Add("wц");
            list.Add("eу");
            list.Add("rк");
            list.Add("tе");
            list.Add("yн");
            list.Add("uг");
            list.Add("iш");
            list.Add("oщ");
            list.Add("pз");
            list.Add("[х");
            list.Add("]ъ");
            list.Add("aф");
            list.Add("sы");
            list.Add("dв");
            list.Add("fа");
            list.Add("gп");
            list.Add("hр");
            list.Add("jо");
            list.Add("kл");
            list.Add("lд");
            list.Add(";ж");
            list.Add("'э");
            list.Add("\\\\");
            list.Add("zя");
            list.Add("xч");
            list.Add("cс");
            list.Add("vм");
            list.Add("bи");
            list.Add("nт");
            list.Add("mь");
            list.Add(",б");
            list.Add(".ю");
            list.Add("/.");
            list.Add("~Ё");
            list.Add("QЙ");
            list.Add("WЦ");
            list.Add("EУ");
            list.Add("RК");
            list.Add("TЕ");
            list.Add("YН");
            list.Add("UГ");
            list.Add("IШ");
            list.Add("Oщ");
            list.Add("PЗ");
            list.Add("{Х");
            list.Add("}Ъ");
            list.Add("AФ");
            list.Add("SЫ");
            list.Add("DВ");
            list.Add("FА");
            list.Add("GП");
            list.Add("HР");
            list.Add("JО");
            list.Add("KЛ");
            list.Add("LД");
            list.Add(":Ж");
            list.Add("\"Э");
            list.Add("ZЯ");
            list.Add("XЧ");
            list.Add("CС");
            list.Add("VМ");
            list.Add("BИ");
            list.Add("NТ");
            list.Add("MЬ");
            list.Add("<Б");
            list.Add(">Ю");
            list.Add("?,");
            list.Add("#№");
            list.Add("&?");
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            txtTo.Text = puntoSwitch(txtFrom.Text);
            if (chkClip.Checked)
            {
                Clipboard.SetText(txtTo.Text);
            }
        }
    }
}
