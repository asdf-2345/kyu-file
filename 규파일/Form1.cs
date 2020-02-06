/*
 * Created by SharpDevelop.
 * User: asdf-2345
 * Date: 2020-02-04
 * Time: 오후 3:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace 규파일
{
	public partial class Form1 : Form
	{
		string[] KyuTxt;
		public string[] kyuTxt
		{
    		get {return this.KyuTxt;}
    		set {this.KyuTxt = value;}
		}
		
		string output;
		public string fileName
		{
    		get { return this.output; } // Form2에서 얻은(get) 값을 다른폼(Form1)으로 전달 목적
    		set { this.output = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
		}
		
		public Form1()
		{
			InitializeComponent();
		}
		
		void Form1Load(object sender, EventArgs e)
		{
			textBox2.ScrollBars = ScrollBars.Vertical;
			for(int a = 0; a < KyuTxt.Length; a++){
				string[] str = KyuTxt[a].Split(new string[] {"$%^"}, StringSplitOptions.None);
				textBox2.AppendText(a.ToString() + " - " + str[1] + "\n");
			}	
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			int HorizontalScroll = panel1.HorizontalScroll.Value;
			Console.WriteLine(HorizontalScroll);
			Graphics g = this.panel1.CreateGraphics();
			
			g.Clear(Color.White); // 지우고 다시 그려야 전에 있던 도형이 안남아있음
			Pen p = new Pen(Color.Black, 3);
            
			SolidBrush b = new SolidBrush(Color.Black);
			StringFormat drawFormat = new StringFormat();
			Font drawFont = new Font("바탕", 10);
			
            panel1.AutoScrollMinSize = new Size(KyuTxt.Length * 50 + 20, 0);
            
            int Count = 0;
			for(int a = 0; a < KyuTxt.Length; a++){
            	Console.WriteLine(a);
				int y = 10;
				int x = 10;
				
				if(KyuTxt[a].Contains("&*(")){
					string[] str = KyuTxt[a].Split(new string[] {"&*("}, StringSplitOptions.None);
					int num1 = int.Parse(str[1]);
					x += 50 * (num1 - Count + 1) - HorizontalScroll;
					y += count(a) * 50;
					Console.WriteLine(x + " " +y);
					
				}
				else{
					x += 50 * (a - Count) - HorizontalScroll;
				}
				Rectangle rec = new Rectangle(x, y, 40, 20);
            	g.DrawRectangle(p, rec);
            	g.DrawString(a.ToString(), drawFont, b, x, y+5, drawFormat);
			}
		}
		
		int count(int line){
			int output = 0;
			if(kyuTxt[line].Contains("&*(")){
				char[] asdf = kyuTxt[line].ToCharArray();
				for(int a = 0; a < asdf.Length; a++){
					if(asdf[a] == '&' && asdf[a+1] == '*' && asdf[a+2] == '('){
						output++;
						a += 2;
						Console.WriteLine("증가");
					}
				}
			}
			return output;
		}
	}
}
