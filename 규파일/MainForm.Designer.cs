/*
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
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(106, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "저장위치지정";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(124, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(500, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "현재위치 : ";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 69);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(106, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "저장할 파일지정";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(124, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(500, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "현재 선택한 파일 : ";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 98);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(106, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "파일찾기";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(124, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(500, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "\'규파일.txt\'를 찾아 선택해주세요";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(219, 228);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(112, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "전체보기";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(219, 199);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(112, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "저장시작";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 134);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(146, 14);
			this.label4.TabIndex = 8;
			this.label4.Text = "확장자명을 입력해주세요.";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(164, 131);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(301, 21);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "예) .mp4 .txt등";
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 210);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(201, 41);
			this.label5.TabIndex = 10;
			this.label5.Text = "저장시작과 이전버전 불러오기는\r\n다른걸 모두 완료한 뒤 눌러주세요.\r\n그리고 시간이 조금 걸립니다.";
			this.label5.Click += new System.EventHandler(this.Label5Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(12, 9);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(129, 23);
			this.button6.TabIndex = 11;
			this.button6.Text = "규파일이 처음입니다.";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(337, 230);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(259, 21);
			this.textBox2.TabIndex = 12;
			this.textBox2.Text = "불러온 이전버젼 : ";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(454, 201);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(142, 23);
			this.button7.TabIndex = 13;
			this.button7.Text = "예전버젼으로 덮어쓰기";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(608, 260);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MainForm";
			this.Text = "규파일";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}
