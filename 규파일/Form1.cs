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
			
			try{
				for(int a = 0; a < KyuTxt.Length; a++){
					string[] str = KyuTxt[a].Split(new string[] {"$%^"}, StringSplitOptions.None);
					textBox2.AppendText(a.ToString() + " - " + str[1] + "\n");
				}
			}
			catch{
				MessageBox.Show("규파일.txt를 선택하지 않았거나 다른 오류가 있습니다.", "오류");
				this.Close();
			}
		}
		
		void drawLine(int x, int y, Pen p, Graphics g){
			//선긋기 (옆으로)
			Point point1 = new Point(x + 40, y + 10);
			Point point2 = new Point(x + 50, y + 10);
			g.DrawLine(p, point1, point2);
		}
		
		Color[] getRandomColor(Color[] PenColor){ // 선겹칠때 햇갈리니까 색깔변경
			PenColor[0] =  Color.FromArgb(0, 0, 0);
			PenColor[1] =  Color.FromArgb(255, 0, 0);
			PenColor[2] =  Color.FromArgb(0, 255, 0);
			PenColor[3] =  Color.FromArgb(0, 0, 255);
			PenColor[4] =  Color.FromArgb(255, 100, 0);
			PenColor[5] =  Color.FromArgb(255, 0 , 100);
			PenColor[6] =  Color.FromArgb(100, 255, 0);
			PenColor[7] =  Color.FromArgb(0, 255, 100);
			PenColor[8] =  Color.FromArgb(100, 0, 255);
			PenColor[9] =  Color.FromArgb(0, 100, 255);
			
			return PenColor;
		}
		
		int maxBranchLength = 0;
		
		void BranchConfirmation(){
			for(int a = 0; a < KyuTxt.Length; a++){
				string[] str = KyuTxt[a].Split(new string[] {@"!%("}, StringSplitOptions.None);
				string[] str2 = str[1].Split(new string[] {@"$%^"}, StringSplitOptions.None);
				
				branch[a] = int.Parse(str2[0]);
				if(branch[a] > maxBranchLength){
					maxBranchLength = branch[a];
				}
			}
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			try{
			branch = new int[KyuTxt.Length];
			BranchConfirmation();
			
			Color[] PenColor = new Color[10];
			PenColor = getRandomColor(PenColor);
			int HorizontalScroll = panel1.HorizontalScroll.Value;
			int VerticalScroll = panel1.VerticalScroll.Value;
			Graphics g = this.panel1.CreateGraphics();
			
			g.Clear(Color.White); // 지우고 다시 그려야 전에 있던 도형이 안남아있음
			StringFormat drawFormat = new StringFormat();
			Font drawFont = new Font("바탕", 10);
			
            panel1.AutoScrollMinSize = new Size(KyuTxt.Length * 50 + 20, branch.Length * 30 + 20);
            int[] X = new int[maxBranchLength + 1];
            int[] positionX = new int[KyuTxt.Length + 1];
            bool[] branchCheck = new bool[maxBranchLength + 1];
			for(int a = 0; a < KyuTxt.Length; a++){
            	Pen p = new Pen(PenColor[branch[a] % 10], 3);
            	SolidBrush b = new SolidBrush(PenColor[branch[a] % 10]);
            	int y = 10 + (branch[a] * 30) - VerticalScroll;
				int x = 10;
				
				if(branchCheck[branch[a]] == false){
					int num1 = 0;
					if(KyuTxt[a].Contains("&*(")){
						string[] str = KyuTxt[a].Split(new string[] {"&*("}, StringSplitOptions.None);
						num1 = int.Parse(str[1]);
					}
					branchCheck[branch[a]] = true;
					X[branch[a]] = positionX[num1];
					x += X[branch[a]] - HorizontalScroll;
					
					//선긋기 (위쪽으로)
					if(branch[a] != 0){
						Point point1 = new Point(x + 20, y);
						Point point2 = new Point(x + 20, y - (10 + ((branch[a] - branch[num1] - 1) * 30)));
						g.DrawLine(p, point1, point2);
					}
					drawLine(x, y, p, g);
				}
				else{
					X[branch[a]] += 50;
					x += X[branch[a]] - HorizontalScroll;
					
					drawLine(x, y, p, g);
				}
				
				positionX[a] = X[branch[a]];
				Rectangle rec = new Rectangle(x, y, 40, 20);
            	g.DrawRectangle(p, rec);
            	g.DrawString(a.ToString(), drawFont, b, x, y+5, drawFormat);
			}
			}
			catch(Exception ex){
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
