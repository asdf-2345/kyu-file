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
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		string Folderposition = "";
		string fileName = "";
		string txtName = "";
		string extensionName = "";
		string kyuTxt = "";
		void Button1Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			Folderposition = dialog.SelectedPath;
			label1.Text = "현재위치 : " + Folderposition;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "모든 파일 (*.*) | *.*";
            ofd.ShowDialog();

            fileName = ofd.FileName;
            label2.Text = "현재 선택한 파일 : " + fileName;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();

            txtName = ofd.FileName;
            label3.Text = "'규파일.txt'를 찾아 선택해주세요. 현재 선택된 파일 : " + txtName;
            if(txtName.Contains("규파일") == true){
            	kyuTxt = File.ReadAllText(@"경로");
            }
            else{
            	MessageBox.Show("선택하신 파일이 규파일이 맞습니까?", "다시 선택해주십시오");
            }
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			string copyFlie = Folderposition + "\\1" + extensionName;
			label5.Text = copyFlie;
			System.IO.File.Copy(fileName, copyFlie, false);
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
	}
}
