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
		
		int[] branch;
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
		
		void drawLine(int x, int y, Pen p, Graphics g){
			//선긋기 (옆으로)
			Point point1 = new Point(x + 40, y + 10);
			Point point2 = new Point(x + 50, y + 10);
			g.DrawLine(p, point1, point2);
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			branch = new int[KyuTxt.Length];
			for(int a = 0; a < KyuTxt.Length; a++){
				string[] str = KyuTxt[a].Split(new string[] {@"!%("}, StringSplitOptions.None);
				string[] str2 = str[1].Split(new string[] {@"$%^"}, StringSplitOptions.None);
				
				branch[a] = int.Parse(str2[0]);
				Console.WriteLine(branch[a]);
			}
			
			int HorizontalScroll = panel1.HorizontalScroll.Value;
			Console.WriteLine(HorizontalScroll);
			Graphics g = this.panel1.CreateGraphics();
			
			g.Clear(Color.White); // 지우고 다시 그려야 전에 있던 도형이 안남아있음
			Pen p = new Pen(Color.Black, 3);
            
			SolidBrush b = new SolidBrush(Color.Black);
			StringFormat drawFormat = new StringFormat();
			Font drawFont = new Font("바탕", 10);
			
            panel1.AutoScrollMinSize = new Size(KyuTxt.Length * 50 + 20, branch.Length * 30 + 20);
            
            int[] X = new int[branch.Length];
            int[] positionX = new int[branch.Length];
            bool[] branchCheck = new bool[KyuTxt.Length];
			for(int a = 0; a < KyuTxt.Length; a++){
            	Console.WriteLine(a);
            	int y = 10 + (branch[a] * 30);
				int x = 10;
				
				if(branchCheck[branch[a]] == false){
					int num1 = 0;
					if(KyuTxt[a].Contains("&*(")){
						string[] str = KyuTxt[a].Split(new string[] {"&*("}, StringSplitOptions.None);
						num1 = int.Parse(str[1]);
					}
					branchCheck[branch[a]] = true;
					int branchLength = X[branch[num1]];
					X[branch[a]] = positionX[num1];
					x += X[branch[a]] - HorizontalScroll;
					
					//선긋기 (위쪽으로)
					if(branch[a] != 0){
						Point point1 = new Point(x + 20, y);
						Console.WriteLine(10 + ((branch[a] - branch[num1] - 1) * 30));
						Point point2 = new Point(x + 20, y - (10 + ((branch[a] - branch[num1] - 1) * 30)));
						g.DrawLine(p, point1, point2);
						
						drawLine(x, y, p, g);
					}
				}
				else{
					X[branch[a]] += 50;
					x += X[branch[a]] - HorizontalScroll;
					
					drawLine(x, y, p, g);
				}
				
				positionX[a] = X[branch[a]];
				Console.WriteLine(x+" "+y);
				Rectangle rec = new Rectangle(x, y, 40, 20);
            	g.DrawRectangle(p, rec);
            	g.DrawString(a.ToString(), drawFont, b, x, y+5, drawFormat);
			}
		}
	}
}
