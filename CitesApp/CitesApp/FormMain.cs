using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace CitesApp
{
    public partial class FormMain : Form
    {
        private KeyboardCtrl_V3.KeyboardCtrl keyboardCtrl1;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Rectangle screenRect = Screen.AllScreens[0].Bounds;
            this.Location = new Point(0, 0);
            this.Size = new Size(screenRect.Width,screenRect.Height);

            axShockwaveFlash1.Location = new Point(0, 0);
            axShockwaveFlash1.Size = new Size(screenRect.Width,screenRect.Height);

            axShockwaveFlash1.Movie = Application.StartupPath + "\\CitesAppFlash_v2.swf";

            //===========step2:建立Keyboard实例================//
            this.keyboardCtrl1 = new KeyboardCtrl_V3.KeyboardCtrl();
            this.keyboardCtrl1.Location = new System.Drawing.Point(screenRect.Width / 2 - keyboardCtrl1.Width / 2, screenRect.Height);
            this.keyboardCtrl1.Name = "keyboardCtrl1";
           // this.keyboardCtrl1.Size = new System.Drawing.Size(942, 208);
            this.keyboardCtrl1.TabIndex = 3;
            this.Controls.Add(this.keyboardCtrl1);
            keyboardCtrl1.BringToFront();

           
        }

        //和flash通信
        private void axShockwaveFlash1_FSCommand(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent e)
        {
            if (e.command == "keyboard")
            {
                if (e.args == "show" && keyboardCtrl1.IsShow==false)
                {

                    keyboardCtrl1.ShowKeyBoard(true);
                }
                else if (e.args == "hide" && keyboardCtrl1.IsShow == true)
                {
                    keyboardCtrl1.ShowKeyBoard(false);
                }

            }
            if (e.command == "b3_search")
            {
                string sqlKeyword = e.args;

              //  string str = "<invoke name='ShowSearchResultData' returntype='xml'><arguments> <string>Helloworld</string> </arguments></invoke>";
                string str = EncodeXML("ShowSearchResultData","string name_cn","string name_latin","string name_en","string name_alias"
							 ,"string _phylum","string _class","string _order","string _family",
							 "string _information","string _cites_level","string _country_level");
                axShockwaveFlash1.CallFunction(str);
            }
            
        }

        private string EncodeXML(string funName,string name_cn,string name_latin,string name_en,string name_alias
							 ,string _phylum,string _class,string _order,string _family,
							 string _information,string _cites_level,string _country_level)
        {

            StringBuilder sb = new StringBuilder();

            XmlTextWriter xw = new XmlTextWriter(new StringWriter(sb));



            xw.WriteStartElement("invoke");

            xw.WriteAttributeString("name", funName);

            xw.WriteAttributeString("returntype", "xml");



            //---------参数-----------------
            xw.WriteStartElement("arguments");

            //---------name_cn-----------------------
            xw.WriteStartElement("string");
            xw.WriteString(name_cn);
            xw.WriteEndElement();

            //--------name_latin---------------------
            xw.WriteStartElement("string");
            xw.WriteString(name_latin);
            xw.WriteEndElement();

            //--------name_en---------------------
            xw.WriteStartElement("string");
            xw.WriteString(name_en);
            xw.WriteEndElement();

            //--------name_alias---------------------
            xw.WriteStartElement("string");
            xw.WriteString(name_alias);
            xw.WriteEndElement();

            //--------_phylum---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_phylum);
            xw.WriteEndElement();

            //--------_class---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_class);
            xw.WriteEndElement();

            //--------_order---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_order);
            xw.WriteEndElement();

            //--------_family---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_family);
            xw.WriteEndElement();

            //--------_information---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_information);
            xw.WriteEndElement();

            //--------_cites_level---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_cites_level);
            xw.WriteEndElement();

            //--------_country_level---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_country_level);
            xw.WriteEndElement();

            xw.WriteEndElement();

            xw.WriteEndElement();



            xw.Flush();

            xw.Close();



            return sb.ToString();

        } 


    }
}
