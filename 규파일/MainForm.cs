/*
 * Created by SharpDevelop.
 * User: asdf-2345
 * Date: 2020-02-04
 * Time: 오후 2:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace 규파일
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		string Folderposition = "";
		string fileName = "";
		int FileName = 0;
		string txtName = "";
		string extensionName = "";
		string[] kyuTxt;
		string changeFileName;
		void Button1Click(object sender, EventArgs e) // 저장위치지정
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			Folderposition = dialog.SelectedPath;
			label1.Text = "현재위치 : " + Folderposition;
		}
		
		void Button2Click(object sender, EventArgs e) // 저장파일지정
		{
			OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "모든 파일 (*.*) | *.*";
            ofd.ShowDialog();

            fileName = ofd.FileName;
            label2.Text = "현재 선택한 파일 : " + fileName;
		}
		
		void Button3Click(object sender, EventArgs e) //규파일.txt 파일찾기
		{
			OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();

            txtName = ofd.FileName;
            label3.Text = "'규파일.txt'를 찾아 선택해주세요. 현재 선택된 파일 : " + txtName;
            if(txtName.Contains("규파일.txt") == true){
            	MessageBox.Show("선택완료");
            	kyuTxt = File.ReadAllLines(txtName);
            	string[] str = txtName.Split(new string[] {"규파일.txt"}, StringSplitOptions.None);
            	extensionName = str[0];
            	Console.WriteLine(extensionName);
            }
            else{
            	MessageBox.Show("선택하신 파일이 규파일이 맞습니까?", "다시 선택해주십시오");
            }
		}
		
		void Button4Click(object sender, EventArgs e)//이전버젼 불러오기
		{
			Form1 form1 = new Form1();
			form1.kyuTxt = kyuTxt;
			form1.Show();
		}
		
		void Button5Click(object sender, EventArgs e) // 저장시작
		{
			kyuTxt = File.ReadAllLines(txtName);
			FileName = kyuTxt.Length;
			
			string copyFlie = Folderposition + "\\" + FileName + extensionName;
			label5.Text = "저장된 파일 : \n" + copyFlie;
			System.IO.File.Copy(fileName, copyFlie, false);
			
			string today = DateTime.Today.ToString();
			using (StreamWriter outputFile = new StreamWriter(txtName, true))
			{
    			outputFile.WriteLine(FileName + " - " + copyFlie);
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			extensionName = textBox1.Text;
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void Button6Click(object sender, EventArgs e) // 규파일이 처음입니다
		{
			File.CreateText(Folderposition + "//" + "규파일.txt");
		}
		
		void Button7Click(object sender, EventArgs e) // 파일 덮어쓰기
		{
			File.Copy(changeFileName, fileName, true);
		}
		
		void Button8Click(object sender, EventArgs e) // 예전버젼 입력완료
		{
			string str = textBox3.Text;
			try{
				int FileNum = int.Parse(str);
				try{
					changeFileName = kyuTxt[FileNum];
					
					string[] str2 = changeFileName.Split('-');
					changeFileName = str2[1].Trim();
					textBox2.Text = "불러올 이전버젼 : " + changeFileName;
				}
				catch{
					MessageBox.Show("다시입력해주세요", "오류");
					return;
				}
			}
			catch{
				MessageBox.Show("숫자만 입력해주세요", "오류");
				return;
			}			
		}
	}
}
