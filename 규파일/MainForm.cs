﻿/*
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
		
		// 뭔 확장자인지 알아냄
		string getExtension(string _fileName){
			int extensionPoint = _fileName.LastIndexOf("."); // (전체길이) - (뒤에서 '.' 찾은값)
			string output = _fileName.Substring(extensionPoint);
			return output;
		}
		
		// 가지입력 완료
		void Button1Click(object sender, EventArgs e) 
		{
			if(textBox7.Text.ToString() == ""){
				return;
			}
			
			try{
				branch = int.Parse(textBox7.Text.ToString());
			}
			catch{
				MessageBox.Show("가지위치를 다시 입력해주세요.");
			}
			
			try{
				kyuTxt = File.ReadAllLines(txtName);
				
				int[] Branch = new int[kyuTxt.Length];
				for(int a = 0; a < kyuTxt.Length; a++){
					string[] str = kyuTxt[a].Split(new string[] {@"!%("}, StringSplitOptions.None);
					string[] str2 = str[1].Split(new string[] {@"$%^"}, StringSplitOptions.None);
					
					Branch[a] = int.Parse(str2[0]);
					Console.WriteLine(Branch[a]);
				}
				
				for(int a = 0; a < kyuTxt.Length; a++){
					if(Branch[a] == branch){
						label8.Text = "현재 가지 : " + branch;
						return;
					}
				}
				MessageBox.Show("없는 가지번호입니다.");
				branch = 0;
				return;
			}
			catch{
				MessageBox.Show("규파일을 선택하지 않으셨거나 다른 오류가 발생하였습니다.", "오류");
				textBox7.Text = "0";
				branch = 0;
			}
		}
		
		// 저장파일지정
		void Button2Click(object sender, EventArgs e) 
		{
			OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "모든 파일 (*.*) | *.*";
            ofd.ShowDialog();

            fileName = ofd.FileName;
            Properties.Settings1.Default.filePosition = fileName;
            Properties.Settings1.Default.Save();
            label2.Text = "현재 선택한 파일 : " + fileName;
		}
		
		//규파일.txt 파일찾기
		void Button3Click(object sender, EventArgs e) 
		{
			OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();

            txtName = ofd.FileName;
            label3.Text = "현재 선택된 파일 : " + txtName;
            if(txtName.Contains("규파일.txt") == true){
            	try{ // 아무것도 안쓰여있으면 에러가 남
            		kyuTxt = File.ReadAllLines(txtName);
            	}
            	catch{}
            	string[] str = txtName.Split(new string[] {"규파일.txt"}, StringSplitOptions.None);
            	Folderposition = str[0];
            	label1.Text = Folderposition;
            	Properties.Settings1.Default.kyuFilePosition = txtName; // 규파일.txt의 위치를 저장함
            	Properties.Settings1.Default.FolderPosition = Folderposition; // 저장소위치를 저장함
            	Properties.Settings1.Default.Save();
            }
            else{
            	MessageBox.Show("선택하신 파일이 규파일이 맞습니까?", "다시 선택해주십시오");
            }
		}
		
		//버젼 전체보기
		void Button4Click(object sender, EventArgs e)
		{
			try{
				kyuTxt = File.ReadAllLines(txtName);
				Form1 form1 = new Form1();
				form1.kyuTxt = kyuTxt;
				form1.Show();
			}
			catch{
				MessageBox.Show("규파일.txt를 선택하지 않았습니다.","오류");
			}
		}
		
		// 저장시작
		void Button5Click(object sender, EventArgs e) 
		{
			kyuTxt = File.ReadAllLines(txtName);
			FileName = kyuTxt.Length;
			
			extensionName = getExtension(fileName);
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
		
		void Label5Click(object sender, EventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			txtName = Properties.Settings1.Default.kyuFilePosition;
			try{
				kyuTxt = File.ReadAllLines(txtName);
				label3.Text = "현재 선택된 파일 : " + txtName;
			}
			catch{
				MessageBox.Show("규파일이 처음이거나 잘못 설정된 것 같습니다.");
			}
            Folderposition = Properties.Settings1.Default.FolderPosition;
            label1.Text = Folderposition;
            
            fileName = Properties.Settings1.Default.filePosition;
            label2.Text = "현재 선택된 파일 : " + fileName;
            
            Properties.Settings1.Default.Save();
            Console.WriteLine("저장되었습니다.");
		}
		
		// 저장소생성
		void Button6Click(object sender, EventArgs e) 
		{
			MessageBox.Show("저장소위치를 지정해주세요.");
			
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			Folderposition = dialog.SelectedPath;
			
			File.CreateText(Folderposition + "\\" + "규파일.txt");
			Folderposition = Folderposition + "\\";
			label1.Text = "현재위치 : " + Folderposition;
			txtName = Folderposition + "규파일.txt";
			label3.Text = "현재 선택된 파일 : " + Folderposition + "규파일.txt";
			
			Properties.Settings1.Default.FolderPosition = Folderposition;
			Properties.Settings1.Default.kyuFilePosition = txtName;
			Properties.Settings1.Default.Save();
			
			MessageBox.Show("규파일.txt가 지정하신 위치에 생성되었습니다.");
		}
		
		// 예전버젼 파일 덮어쓰기
		void Button7Click(object sender, EventArgs e) 
		{
			try{
				File.Copy(changeFileName, fileName, true);
			}
			catch{
				MessageBox.Show("저정할 파일을 지정하지 않았거나 불러올 이전버젼을 입력하지 않았습니다.", "오류");
			}
		}
		
		// 예전버젼 입력완료
		void Button8Click(object sender, EventArgs e) 
		{
			string str = textBox3.Text;
			try{
				int FileNum = int.Parse(str);
				try{
					changeFileName = kyuTxt[FileNum];
					
					string[] str2 = changeFileName.Split('-');
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
		
		// 새로운 가지 생성
		void Button9Click(object sender, EventArgs e) 
		{
			kyuTxt = File.ReadAllLines(txtName);
			FileName = kyuTxt.Length;
			
			Form2 form2 = new Form2();
			form2.kyuTxt = kyuTxt;
			form2.ShowDialog();
			int newBranch = form2.NewBranch;
			fileNum = form2.FileName;
			extensionName = getExtension(fileName);
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
		
		// 코멘트
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			comment = textBox4.Text;
		}
		
		void TextBox7TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}