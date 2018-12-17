using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		int ignore = 0;
		List<string> json = new List<string>();
		public Form1()	
		{
			InitializeComponent();
			ClipboardNotification.ClipboardUpdate += (o,e) => {
				if(ignore==0 && Clipboard.ContainsText(TextDataFormat.Text)) {
					string s = Clipboard.GetText(TextDataFormat.Text);
					json.Add(System.Uri.EscapeUriString(s));
					textBox1.AppendText(s + "\r\n\r\n");
				} else
				{
					if (ignore > 1) ignore = 0; ;
				}
			};
		}
		private void button1_Click(object sender, EventArgs e)
		{
			string[] allLines = textBox1.Text.Split(new[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
			string jsonOut = JsonConvert.SerializeObject(json);
			ignore = 1;
			Clipboard.SetText(jsonOut);
		}
	}
}
