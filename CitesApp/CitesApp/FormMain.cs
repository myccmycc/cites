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
                //textBox1.Text = "";
                textBox1.Location = new Point(result1, result2);
            }
             else if (e.command == "hide_inputtext")
            {
                textBox1.Visible = false;
            }

             if (e.command == "hide_Text_GridView")
             {
                 textBox1.Visible = false;
                 dataGridView1.Visible = false;
             }

             if (e.command == "show_Text_GridView")
             {
                 textBox1.Visible = true;
                 dataGridView1.Visible = true;
             }
             if (e.command == "b5_search" || e.command == "b5_search_2")
             {
                 string sqlKeyword = textBox1.Text;
                 if (sqlKeyword == "")
                     return;
                 //1.物种信息显示
                 string sqlStr1 = "select * from cites_table where name_latin like '%" + sqlKeyword + "%' || name_cn like '%" + sqlKeyword + "%' || name_en like '%" + sqlKeyword + "%' || name_alias like '%" + sqlKeyword + "%'";

                 MySqlDataReader myRead = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sqlStr1, null);

                 if (myRead.Read())
                 {
                     //显示搜索到的记录
                     string str = EncodeXMLB5("ReSearchHSCode", myRead["name_cn"].ToString(), myRead["name_latin"].ToString(), myRead["name_en"].ToString(), myRead["name_alias"].ToString(),
                                 myRead["cites_level"].ToString(), myRead["country_level"].ToString(), myRead["product_table"].ToString());
                     axShockwaveFlash1.CallFunction(str);
                 }
                 myRead.Close();

                 //2.hs编码数据
                 string sqlStr = "select * from cites_productid  where ProductTable in ( select product_table from cites_table where  name_latin like '%" + sqlKeyword + "%' || name_cn like '%" + sqlKeyword + "%' || name_en like '%" + sqlKeyword + "%' || name_alias like '%" + sqlKeyword + "%')";

                 dataGridView1.Visible = true;
                 dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlStr, null).Tables[0].DefaultView;

                 dataGridView1.Columns[0].HeaderCell.Value = "商品编号";
                 dataGridView1.Columns[1].HeaderCell.Value = "商品名称";
                 dataGridView1.Columns[2].HeaderCell.Value = "监管条件";
                 dataGridView1.Columns[3].HeaderCell.Value = "说明";

                 dataGridView1.Columns[0].Width = 100;
                 dataGridView1.Columns[1].Width = 250;
                 dataGridView1.Columns[2].Width = 100;
                 dataGridView1.Columns[3].Width = 250;

                 dataGridView1.Columns[4].Visible = false;
                 dataGridView1.Columns[5].Visible = false;
             }
             if (e.command == "b5_GridView1_show")
                 dataGridView1.Visible = true;
             if (e.command == "b5_GridView1_hide")
                 dataGridView1.Visible = false;


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

                DataSet ds= MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlStr, null);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    string name_cn = ds.Tables[0].Rows[0]["name_cn"].ToString();
                    string name_latin = ds.Tables[0].Rows[0]["name_latin"].ToString();
                    string name_en = ds.Tables[0].Rows[0]["name_en"].ToString();
                    string name_alias = ds.Tables[0].Rows[0]["name_alias"].ToString();


                    string cites_phylum = ds.Tables[0].Rows[0]["cites_phylum"].ToString();
                    string cites_class = ds.Tables[0].Rows[0]["cites_class"].ToString();
                    string cites_order = ds.Tables[0].Rows[0]["cites_order"].ToString();
                    string cites_family = ds.Tables[0].Rows[0]["cites_family"].ToString();
                    string information = ds.Tables[0].Rows[0]["information"].ToString();
                    string cites_level = ds.Tables[0].Rows[0]["cites_level"].ToString();

                    string country_level = ds.Tables[0].Rows[0]["country_level"].ToString();
                    string is_animal = ds.Tables[0].Rows[0]["is_animal"].ToString();

                    string str = EncodeXML("ShowSearchResultData",name_cn, name_latin,name_en, name_alias,cites_phylum, cites_class, cites_order, cites_family,
                                    information, cites_level, country_level, is_animal);
                    axShockwaveFlash1.CallFunction(str);
                }

                else if (ds.Tables[0].Rows.Count > 1)
                {
                    foreach (DataRow myRead in ds.Tables[0].Rows)
                    {
                        //显示搜索到的记录
                        string str2 = EncodeXMLNameCn("ShowResultList", myRead["name_cn"].ToString(), myRead["name_latin"].ToString());
                        axShockwaveFlash1.CallFunction(str2);
                    }

                }

            }

            if (e.command == "b3_search")
            {
                string sqlKeyword = e.args.Trim();
                string sqlStr = "select * from cites_animal where name_latin like '%" + sqlKeyword + "%' || name_cn like '%" + sqlKeyword + "%' || name_en like '%" + sqlKeyword + "%' || name_alias like '%" + sqlKeyword + "%'";

                MySqlDataReader myRead = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sqlStr, null);

                if (myRead.Read())
                {
                    string str = EncodeXML("ShowSearchResultData", myRead["name_cn"].ToString(), myRead["name_latin"].ToString(), myRead["name_en"].ToString(), myRead["name_alias"].ToString()
                                 , myRead["cites_phylum"].ToString(), myRead["cites_class"].ToString(), myRead["cites_order"].ToString(), myRead["cites_family"].ToString(),
                                 myRead["information"].ToString(), myRead["cites_level"].ToString(), myRead["country_level"].ToString(), myRead["is_animal"].ToString());
                    axShockwaveFlash1.CallFunction(str);
                }
                myRead.Close();
            }

            if (e.command == "b7_search_question")
            {
                //显示搜索到的记录
                string sqlKeyword = textBox1.Text;
                string str2 = EncodeXMLOne("SearchQuestion", sqlKeyword);
                axShockwaveFlash1.CallFunction(str2);
            }
            
        }

        private string EncodeXML(string funName,string name_cn,string name_latin,string name_en,string name_alias
							 ,string _phylum,string _class,string _order,string _family,
							 string _information,string _cites_level,string _country_level,string is_animal)
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

            //--------is_animal---------------------
            xw.WriteStartElement("string");
            xw.WriteString(is_animal);
            xw.WriteEndElement();

            xw.WriteEndElement();

            xw.WriteEndElement();



            xw.Flush();

            xw.Close();

            return sb.ToString();

        }

        private string EncodeXMLNameCn(string funName, string name_cn, string name_latin)
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

            //---------name_latin-----------------------
            xw.WriteStartElement("string");
            xw.WriteString(name_latin);
            xw.WriteEndElement();
            //---------name_latin-----------------------


            xw.WriteEndElement();
            //---------参数-----------------

            xw.WriteEndElement();


            xw.Flush();

            xw.Close();

            return sb.ToString();

        }

        private string EncodeXMLOne(string funName, string one)
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
            xw.WriteString(one);
            xw.WriteEndElement();
            //---------name_cn-----------------------

            xw.WriteEndElement();
            //---------参数-----------------

            xw.WriteEndElement();


            xw.Flush();

            xw.Close();

            return sb.ToString();

        }

        private string EncodeXMLB5(string funName, string name_cn,string name_latin,string name_en,string name_alias
                             , string _cites_level, string _country_level, string product_table)
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

            //--------_cites_level---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_cites_level);
            xw.WriteEndElement();

            //--------_country_level---------------------
            xw.WriteStartElement("string");
            xw.WriteString(_country_level);
            xw.WriteEndElement();

            //--------table_id---------------------
            xw.WriteStartElement("string");
            xw.WriteString(product_table);
            xw.WriteEndElement();

            xw.WriteEndElement();

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