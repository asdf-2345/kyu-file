﻿/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2020-02-04
 * Time: 오후 2:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace 규파일
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(106, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "저장위치지정";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(124, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(500, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "현재위치 : ";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(106, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "저장할 파일지정";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(124, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(500, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "현재 선택한 파일 : ";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 70);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(106, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "파일찾기";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(124, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(500, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "\'규파일.txt\'를 찾아 선택해주세요";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(703, 262);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MainForm";
			this.Text = "규파일";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}
