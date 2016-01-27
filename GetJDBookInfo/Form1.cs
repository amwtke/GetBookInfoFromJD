using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Collections;

namespace GetJDBookInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            if (IsInterNetConnected())
            {
                try
                {
                    string realUlr = tx_url.Text;
                    HtmlHelper.HtmlFromWebReq req = new HtmlHelper.HtmlFromWebReq(
                        realUlr, delegate(byte[] data)
                        {
                            //string constructedString = System.Text.Encoding.UTF8.GetString(data);
                            string constructedString = System.Text.Encoding.GetEncoding("GB2312").GetString(data);
                            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(constructedString);
                            HtmlAgilityPack.HtmlNode nodeTitle = doc.DocumentNode.SelectSingleNode("/html[1]/head[1]/title");
                            string bookAuthor="";
                            string abstraction = nodeTitle.InnerHtml;
                            int posOfBookMark = abstraction.IndexOf("》");

                            //获取最后一个）符号的位置
                            int posOflastBrace = abstraction.IndexOf(")", posOfBookMark);
                            int temp = posOflastBrace;
                            while (temp != -1)
                            {
                                posOflastBrace = temp;
                                temp = abstraction.IndexOf(")", temp+1);
                            }

                            if (posOflastBrace != -1)
                                bookAuthor = abstraction.Substring(posOfBookMark + 2, posOflastBrace - posOfBookMark - 2);

                            HtmlAgilityPack.HtmlNodeCollection _nodes = doc.DocumentNode.SelectNodes(@"//html[1]/head[1]/meta[@name='keywords']");
                            foreach (HtmlAgilityPack.HtmlNode no in _nodes)
                            {
                                //no.GetAttributeValue("content","");
                                string s = no.GetAttributeValue("content", "");
                                string[] bookinfo = s.Split(new char[] { ',' });
                                string bookname = bookinfo[0];
                                if (!String.IsNullOrEmpty(bookinfo[1]))
                                    bookAuthor = bookinfo[1];
                                string bookPublisher = bookinfo[2];
                                string bookISBN = bookinfo[3];
                                SetText( bookname + "\n" + bookAuthor + "\n" + bookPublisher + "\n" + bookISBN);
                            }

                            //获取书籍图片
                            HtmlAgilityPack.HtmlNode pBoxNode = doc.DocumentNode.SelectSingleNode(@"//html[1]/body[1]/div[@id='p-box']/div[3]/div[@id='product-intro']/div[@id='preview']/div[@id='spec-n1']");
                            if (pBoxNode != null)
                            {
                                HtmlAgilityPack.HtmlNode image = pBoxNode.SelectSingleNode(@"//img[1]");
                                if (image != null)
                                {
                                    string imagesrc = image.GetAttributeValue("src", "");
                                    using(WebClient wc = new WebClient())
                                    {
                                        picBox.Load("http:"+imagesrc);
                                    }
                                    
                                }
                            }

                        });

                    req.BeginCreateHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                MessageBox.Show("没有互联网！");
        }
        

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(
        ref   int dwFlag,
        int dwReserved
        );
        public static bool IsInterNetConnected()
        {
            System.Int32 dwFlag = new int();
            return InternetGetConnectedState(ref   dwFlag, 0);
            //MessageBox.Show("未连网!");   
            //else   
            //if((dwFlag   &   INTERNET_CONNECTION_MODEM)!=0)   
            //MessageBox.Show("采用调治解调器上网。");   
            //else   
            //if((dwFlag   &   INTERNET_CONNECTION_LAN)!=0)   
            //MessageBox.Show("采用网卡上网。");   
        }

        private delegate void SetRichTextBox(String s);
        public void SetText(string txt)
        {
            if (this.rtx_info.InvokeRequired)
            {
                SetRichTextBox s = new SetRichTextBox(SetRt);
                this.Invoke(s, new object[] { txt });
            }
            else
            {
                rtx_info.Text = txt;
            }
        }

        private void SetRt(string text)
        {
            rtx_info.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsInterNetConnected())
            {
                try
                {
                    string realUlr = tx_url.Text;
                    HtmlHelper.HtmlFromWebReq req = new HtmlHelper.HtmlFromWebReq(
                        realUlr, delegate(byte[] data)
                        {
                            //string constructedString = System.Text.Encoding.UTF8.GetString(data);
                            string constructedString = System.Text.Encoding.UTF8.GetString(data);
                            SetText(constructedString);
                            //Object o = JsonConvert.DeserializeObject(constructedString);
                            //Console.WriteLine(o.ToString());


                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
                            dynamic dy = jss.Deserialize(constructedString, typeof(object)) as dynamic;  

                        });

                    req.BeginCreateHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                MessageBox.Show("没有互联网！");
        }

    }

    public class DynamicJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            if (type == typeof(object))
            {
                return new DynamicJsonObject(dictionary);
            }

            return null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(object) })); }
        }
    }

    public class DynamicJsonObject : DynamicObject
    {
        private IDictionary<string, object> Dictionary { get; set; }

        public DynamicJsonObject(IDictionary<string, object> dictionary)
        {
            this.Dictionary = dictionary;
        }

        //public override bool TryGetMember(GetMemberBinder binder, out object result)
        //{
        //    result = this.Dictionary[binder.Name];

        //    if (result is IDictionary<string, object>)
        //    {
        //        result = new DynamicJsonObject(result as IDictionary<string, object>);
        //    }
        //    else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
        //    {
        //        result = new List<DynamicJsonObject>((result as ArrayList).().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
        //    }
        //    else if (result is ArrayList)
        //    {
        //        result = new List<object>((result as ArrayList).ToArray());
        //    }

        //    return this.Dictionary.ContainsKey(binder.Name);
        //}
    }
}
