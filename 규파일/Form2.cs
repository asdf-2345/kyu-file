/*
 * Created by SharpDevelop.
 * User: asdf-2345
 * Date: 2020-02-07
 * Time: 오전 7:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace 규파일
{
	public partial class Form2 : Form
	{
		
		int fileName;
		public int FileName
		{
    		get {return this.fileName;}
    		set {this.fileName = value;}
		}
		
		int newBranch;
		public int NewBranch
		{
    		get {return this.newBranch;}
    		set {this.newBranch = value;}
		}
		
		string[] KyuTxt;
		public string[] kyuTxt
		{
    		get {return this.KyuTxt;}
    		set {this.KyuTxt = value;}
		}
		
		public Form2()
		{
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			try{
				newBranch = int.Parse(textBox1.Text.ToString());
				fileName = int.Parse(textBox2.Text.ToString());
			}
			catch{
				MessageBox.Show("다시입력해주세요.");
			}
			
			for(int a = 0; a < KyuTxt.Length; a++){
				string[] str = KyuTxt[a].Split(new string[] {@"!%("}, StringSplitOptions.None);
				string[] str2 = str[1].Split(new string[] {@"$%^"}, StringSplitOptions.None);
				
				if(int.Parse(str2[0]) == newBranch){
					MessageBox.Show("이미있는 가지 이름 입니다.");
					return;
				}
			}
			this.Close();
		}
	}
}
