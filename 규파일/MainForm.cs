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
		string fileName ="";
		string txtName ="";
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
            label2.Text = "현재 선택한 파일 : " + fileName;
		}
	}
}
