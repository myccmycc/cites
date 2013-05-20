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
using MySql.Data;
using MySql.Data.MySqlClient;

using System.Diagnostics;

namespace CitesApp
{
    public partial class FormMain : Form
    {
#if MY_KEYBOARD
    private KeyboardCtrl_V3.KeyboardCtrl keyboardCtrl1;
#endif

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
#if MY_KEYBOARD
            //===========step2:建立Keyboard实例================//
            this.keyboardCtrl1 = new KeyboardCtrl_V3.KeyboardCtrl();
            this.keyboardCtrl1.Location = new System.Drawing.Point(screenRect.Width / 2 - keyboardCtrl1.Width / 2, screenRect.Height);
            this.keyboardCtrl1.Name = "keyboardCtrl1";
           // this.keyboardCtrl1.Size = new System.Drawing.Size(942, 208);
            this.keyboardCtrl1.TabIndex = 3;
            this.Controls.Add(this.keyboardCtrl1);
            keyboardCtrl1.BringToFront();
#endif
           
        }

        //和flash通信
        private void axShockwaveFlash1_FSCommand(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent e)
        {
             if (e.command == "show_inputtext")
            {
                string args = e.args;
                int a = args.IndexOf(':');
                string x = args.Substring(0,a);
                string y=args.Substring(a+1);

                int result1 = int.Parse(x);
                int result2 = int.Parse(y);
                textBox1.Visible = true;
                textBox1.Text = "";
                textBox1.Location = new Point(result1, result2);
            }
             else if (e.command == "hide_inputtext")
            {
                textBox1.Visible = false;
            }
             if (e.command == "b5_search")
             {
                 string sqlKeyword = textBox1.Text;
                 string sqlStr = "select * from cites_animal where name_latin like '%" + sqlKeyword + "%' || name_cn like '%" + sqlKeyword + "%' || name_en like '%" + sqlKeyword + "%' || name_alias like '%" + sqlKeyword + "%'";

                /* MySqlDataReader myRead = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sqlStr, null);

                 if (myRead.Read())
                 {
                     //MessageBox.Show(myRead["name_cn"].ToString());
                     // string str = "<invoke name='ShowSearchResultData' returntype='xml'><arguments> <string>Helloworld</string> </arguments></invoke>";
                     string str = EncodeXML("ShowSearchResultData", myRead["name_cn"].ToString(), myRead["name_latin"].ToString(), myRead["name_en"].ToString(), myRead["name_alias"].ToString()
                                  , myRead["cites_phylum"].ToString(), myRead["cites_class"].ToString(), myRead["cites_order"].ToString(), myRead["cites_family"].ToString(),
                                  myRead["information"].ToString(), myRead["cites_level"].ToString(), myRead["country_level"].ToString());
                     axShockwaveFlash1.CallFunction(str);
                 }
                 myRead.Close();*/
 
             }


            if (e.command == "keyboard")
            {
#if MY_KEYBOARD
                if (e.args == "show" && keyboardCtrl1.IsShow==false)
                {
                    keyboardCtrl1.ShowKeyBoard(true);
                }
                else if (e.args == "hide" && keyboardCtrl1.IsShow == true)
                {
                    keyboardCtrl1.ShowKeyBoard(false);
                }
#else
                if (e.args == "show")
                {
                   /* Process[] myprocess = Process.GetProcessesByName("TabTip");
                    if (myprocess.Length > 0)
                    {
                        myprocess[0].Kill();
                    }

                    Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");*/
                }
                else if (e.args == "hide")
                {
                   /* Process[] myprocess = Process.GetProcessesByName("TabTip");
                    if (myprocess.Length > 0)
                    {
                        myprocess[0].Kill();
                    }*/
                }
#endif

            }
            if (e.command == "b3_search_name")
            {
                string sqlKeyword = textBox1.Text;
                string sqlStr = "select * from cites_animal where name_latin like '%" + sqlKeyword + "%' || name_cn like '%" + sqlKeyword + "%' || name_en like '%" + sqlKeyword + "%' || name_alias like '%"+ sqlKeyword + "%'";

                MySqlDataReader myRead = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sqlStr, null);

                while (myRead.Read())
                {
                    //显示搜索到的记录
                    string str2 = EncodeXMLNameCn("ShowResultList",myRead["name_cn"].ToString());
                    axShockwaveFlash1.CallFunction(str2);
                }
                myRead.Close();
            }

            if (e.command == "b3_search")
            {
               // string sqlKeyword = e.args.Trim();
                string sqlKeyword = textBox1.Text;
                string sqlStr = "select * from cites_animal where name_latin like '%" + sqlKeyword + "%' || name_cn like '%" + sqlKeyword + "%' || name_en like '%" + sqlKeyword + "%' || name_alias like '%" + sqlKeyword + "%'";

                MySqlDataReader myRead = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sqlStr, null);

                if (myRead.Read())
                {
                    //MessageBox.Show(myRead["name_cn"].ToString());
                    // string str = "<invoke name='ShowSearchResultData' returntype='xml'><arguments> <string>Helloworld</string> </arguments></invoke>";
                    string str = EncodeXML("ShowSearchResultData", myRead["name_cn"].ToString(), myRead["name_latin"].ToString(), myRead["name_en"].ToString(), myRead["name_alias"].ToString()
                                 , myRead["cites_phylum"].ToString(), myRead["cites_class"].ToString(), myRead["cites_order"].ToString(), myRead["cites_family"].ToString(),
                                 myRead["information"].ToString(), myRead["cites_level"].ToString(), myRead["country_level"].ToString());
                    axShockwaveFlash1.CallFunction(str);
                }
                myRead.Close();
            }

            if (e.command == "b7_search_question")
            {
                //显示搜索到的记录
                string sqlKeyword = textBox1.Text;
                string str2 = EncodeXMLNameCn("SearchQuestion", sqlKeyword);
                axShockwaveFlash1.CallFunction(str2);
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

        private string EncodeXMLNameCn(string funName, string name_cn)
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
            //---------name_cn-----------------------

            xw.WriteEndElement();
            //---------参数-----------------

            xw.WriteEndElement();


            xw.Flush();

            xw.Close();

            return sb.ToString();

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";

           /* Process[] myprocess = Process.GetProcessesByName("TabTip");
            if (myprocess.Length > 0)
            {
                myprocess[0].Kill();
            }*/
            Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
        } 
    }
}