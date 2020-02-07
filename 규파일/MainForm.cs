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
		string comment;
		int fileNum = 0;
		int branch = 0;
		
		void Button1Click(object sender, EventArgs e) // 새로운 분기 생성 - 입력완료
		{
			
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
            	kyuTxt = File.ReadAllLines(txtName);
            	string[] str = txtName.Split(new string[] {"규파일.txt"}, StringSplitOptions.None);
            	Folderposition = str[0];
            	label1.Text = Folderposition;
            }
            else{
            	MessageBox.Show("선택하신 파일이 규파일이 맞습니까?", "다시 선택해주십시오");
            }
		}
		
		void Button4Click(object sender, EventArgs e)//버젼 전체보기
		{
			try{
				Form1 form1 = new Form1();
				form1.kyuTxt = kyuTxt;
				form1.Show();
			}
			catch{
				MessageBox.Show("규파일.txt를 선택하지 않았습니다.","오류");
			}
		}
		
		void Button5Click(object sender, EventArgs e) // 저장시작
		{
			kyuTxt = File.ReadAllLines(txtName);
			FileName = kyuTxt.Length;
			
			string copyFlie = Folderposition + FileName + extensionName;
			Console.WriteLine(copyFlie);
			label5.Text = "저장된 파일 : \n" + copyFlie;
			System.IO.File.Copy(fileName, copyFlie, false);
			
			using (StreamWriter outputFile = new StreamWriter(txtName, true))
			{
    			outputFile.Write(FileName + " - " + copyFlie + @"!%(" + branch + @"$%^" + comment);
    			outputFile.WriteLine();
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
			MessageBox.Show("저장소위치를 지정해주세요.");
			
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			Folderposition = dialog.SelectedPath;
			
			File.CreateText(Folderposition + "\\" + "규파일.txt");
			Folderposition = Folderposition + "\\";
			label1.Text = "현재위치 : " + Folderposition;
			MessageBox.Show("규파일.txt가 지정하신 위치에 생성되었습니다.");
		}
		
		void Button7Click(object sender, EventArgs e) // 예전버젼 파일 덮어쓰기
		{
			try{
				File.Copy(changeFileName, fileName, true);
			}
			catch{
				MessageBox.Show("저정할 파일을 지정하지 않았거나 불러올 이전버젼을 입력하지 않았습니다.", "오류");
			}
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
		
		void Button9Click(object sender, EventArgs e) // 새로운 가지 생성
		{
			kyuTxt = File.ReadAllLines(txtName);
			FileName = kyuTxt.Length;
			
			Form2 form2 = new Form2();
			form2.kyuTxt = kyuTxt;
			form2.ShowDialog();
			int newBranch = form2.NewBranch;
			fileNum = form2.FileName;
			string copyFlie = Folderposition + FileName + extensionName;
			
			try{
				System.IO.File.Copy(fileName, copyFlie, false);
			}
			catch{
				MessageBox.Show("저장할파일을 먼저 선택해주세요");
				return;
			}
			
			using (StreamWriter outputFile = new StreamWriter(txtName, true))
			{
				outputFile.Write(FileName + " - " + copyFlie + @"!%(" + newBranch + @"$%^" + comment + @"&*(" + fileNum);
    			outputFile.WriteLine();
			}
		}
		
		void TextBox4TextChanged(object sender, EventArgs e) // 코멘트
		{
			comment = textBox4.Text;
		}
		
		void TextBox7TextChanged(object sender, EventArgs e)
		{
			try{
				branch = int.Parse(textBox7.Text.ToString());
			}
			catch{
				MessageBox.Show("가지위치를 다시 입력해주세요.");
			}
		}
	}
}