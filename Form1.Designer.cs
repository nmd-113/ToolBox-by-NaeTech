using System;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ToolBox_by_NaeTech
{
    partial class toolbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(toolbox));
            this.installbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.check1 = new System.Windows.Forms.CheckBox();
            this.check2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check5 = new System.Windows.Forms.CheckBox();
            this.check6 = new System.Windows.Forms.CheckBox();
            this.check7 = new System.Windows.Forms.CheckBox();
            this.check8 = new System.Windows.Forms.CheckBox();
            this.check9 = new System.Windows.Forms.CheckBox();
            this.check10 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.check11 = new System.Windows.Forms.CheckBox();
            this.check13 = new System.Windows.Forms.CheckBox();
            this.check12 = new System.Windows.Forms.CheckBox();
            this.check14 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.check16 = new System.Windows.Forms.CheckBox();
            this.check15 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.check18 = new System.Windows.Forms.CheckBox();
            this.check17 = new System.Windows.Forms.CheckBox();
            this.check4 = new System.Windows.Forms.CheckBox();
            this.check3 = new System.Windows.Forms.CheckBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.exitbtn = new System.Windows.Forms.Button();
            this.minimizebtn = new System.Windows.Forms.Button();
            this.installationProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadingback = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingback)).BeginInit();
            this.SuspendLayout();
            // 
            // installbtn
            // 
            this.installbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.installbtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.installbtn.FlatAppearance.BorderSize = 0;
            this.installbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.installbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.installbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.installbtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installbtn.ForeColor = System.Drawing.Color.White;
            this.installbtn.Location = new System.Drawing.Point(21, 446);
            this.installbtn.Margin = new System.Windows.Forms.Padding(0);
            this.installbtn.Name = "installbtn";
            this.installbtn.Size = new System.Drawing.Size(353, 33);
            this.installbtn.TabIndex = 0;
            this.installbtn.Text = "INSTALL";
            this.installbtn.UseVisualStyleBackColor = false;
            this.installbtn.Click += new System.EventHandler(this.installbtn_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(124, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quick Installer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Check the boxes and click install (*Internet connection is required):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.AliceBlue;
            this.label3.Location = new System.Drawing.Point(1, 116);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(135, 0, 135, 0);
            this.label3.Size = new System.Drawing.Size(396, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tools and Multimedia";
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.BackColor = System.Drawing.Color.Black;
            this.check1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check1.ForeColor = System.Drawing.Color.White;
            this.check1.Location = new System.Drawing.Point(20, 139);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(142, 20);
            this.check1.TabIndex = 7;
            this.check1.Text = "K-Lite Codec Pack";
            this.check1.UseVisualStyleBackColor = false;
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.BackColor = System.Drawing.Color.Black;
            this.check2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check2.ForeColor = System.Drawing.Color.White;
            this.check2.Location = new System.Drawing.Point(199, 139);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(140, 20);
            this.check2.TabIndex = 8;
            this.check2.Text = "VLC media player";
            this.check2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1, 189);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(172, 0, 172, 0);
            this.label4.Size = new System.Drawing.Size(397, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gaming:";
            // 
            // check5
            // 
            this.check5.AutoSize = true;
            this.check5.BackColor = System.Drawing.Color.Black;
            this.check5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check5.ForeColor = System.Drawing.Color.White;
            this.check5.Location = new System.Drawing.Point(20, 212);
            this.check5.Name = "check5";
            this.check5.Size = new System.Drawing.Size(67, 20);
            this.check5.TabIndex = 10;
            this.check5.Text = "Steam";
            this.check5.UseVisualStyleBackColor = false;
            // 
            // check6
            // 
            this.check6.AutoSize = true;
            this.check6.BackColor = System.Drawing.Color.Black;
            this.check6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check6.ForeColor = System.Drawing.Color.White;
            this.check6.Location = new System.Drawing.Point(199, 212);
            this.check6.Name = "check6";
            this.check6.Size = new System.Drawing.Size(101, 20);
            this.check6.TabIndex = 11;
            this.check6.Text = "Epic Games";
            this.check6.UseVisualStyleBackColor = false;
            // 
            // check7
            // 
            this.check7.AutoSize = true;
            this.check7.BackColor = System.Drawing.Color.Black;
            this.check7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check7.ForeColor = System.Drawing.Color.White;
            this.check7.Location = new System.Drawing.Point(20, 238);
            this.check7.Name = "check7";
            this.check7.Size = new System.Drawing.Size(125, 20);
            this.check7.TabIndex = 12;
            this.check7.Text = "Ubisoft Connect";
            this.check7.UseVisualStyleBackColor = false;
            // 
            // check8
            // 
            this.check8.AutoSize = true;
            this.check8.BackColor = System.Drawing.Color.Black;
            this.check8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check8.ForeColor = System.Drawing.Color.White;
            this.check8.Location = new System.Drawing.Point(199, 238);
            this.check8.Name = "check8";
            this.check8.Size = new System.Drawing.Size(71, 20);
            this.check8.TabIndex = 13;
            this.check8.Text = "EA app";
            this.check8.UseVisualStyleBackColor = false;
            // 
            // check9
            // 
            this.check9.AutoSize = true;
            this.check9.BackColor = System.Drawing.Color.Black;
            this.check9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check9.ForeColor = System.Drawing.Color.White;
            this.check9.Location = new System.Drawing.Point(20, 264);
            this.check9.Name = "check9";
            this.check9.Size = new System.Drawing.Size(105, 20);
            this.check9.TabIndex = 14;
            this.check9.Text = "GOG Galaxy";
            this.check9.UseVisualStyleBackColor = false;
            // 
            // check10
            // 
            this.check10.AutoSize = true;
            this.check10.BackColor = System.Drawing.Color.Black;
            this.check10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check10.ForeColor = System.Drawing.Color.White;
            this.check10.Location = new System.Drawing.Point(200, 264);
            this.check10.Name = "check10";
            this.check10.Size = new System.Drawing.Size(108, 20);
            this.check10.TabIndex = 15;
            this.check10.Text = "Geforce Now";
            this.check10.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1, 290);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(172, 0, 172, 0);
            this.label5.Size = new System.Drawing.Size(397, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "System:";
            // 
            // check11
            // 
            this.check11.AutoSize = true;
            this.check11.BackColor = System.Drawing.Color.Black;
            this.check11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check11.ForeColor = System.Drawing.Color.White;
            this.check11.Location = new System.Drawing.Point(21, 312);
            this.check11.Name = "check11";
            this.check11.Size = new System.Drawing.Size(72, 20);
            this.check11.TabIndex = 17;
            this.check11.Text = "DirectX";
            this.check11.UseVisualStyleBackColor = false;
            // 
            // check13
            // 
            this.check13.AutoSize = true;
            this.check13.BackColor = System.Drawing.Color.Black;
            this.check13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check13.ForeColor = System.Drawing.Color.White;
            this.check13.Location = new System.Drawing.Point(21, 338);
            this.check13.Name = "check13";
            this.check13.Size = new System.Drawing.Size(123, 20);
            this.check13.TabIndex = 18;
            this.check13.Text = "Visual C++ (All)";
            this.check13.UseVisualStyleBackColor = false;
            // 
            // check12
            // 
            this.check12.AutoSize = true;
            this.check12.BackColor = System.Drawing.Color.Black;
            this.check12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check12.ForeColor = System.Drawing.Color.White;
            this.check12.Location = new System.Drawing.Point(200, 312);
            this.check12.Name = "check12";
            this.check12.Size = new System.Drawing.Size(162, 20);
            this.check12.TabIndex = 19;
            this.check12.Text = ".NET Runtime (Latest)";
            this.check12.UseVisualStyleBackColor = false;
            // 
            // check14
            // 
            this.check14.AutoSize = true;
            this.check14.BackColor = System.Drawing.Color.Black;
            this.check14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check14.ForeColor = System.Drawing.Color.White;
            this.check14.Location = new System.Drawing.Point(200, 338);
            this.check14.Name = "check14";
            this.check14.Size = new System.Drawing.Size(164, 20);
            this.check14.TabIndex = 20;
            this.check14.Text = ".NET Framework 4.8.1";
            this.check14.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Location = new System.Drawing.Point(526, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 22);
            this.label7.TabIndex = 21;
            this.label7.Text = "Windows Tweaker";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(487, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(248, 14);
            this.label8.TabIndex = 22;
            this.label8.Text = "*Proceed with caution. Actions cannot be undone.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(684, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "APPLY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(425, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Classic Context Menu (Win11):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(425, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Disable Windows Ads:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(684, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "APPLY";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(684, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "APPLY";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(425, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(229, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "Disable Web Search in Start Menu:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(684, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 23);
            this.button4.TabIndex = 34;
            this.button4.Text = "APPLY";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(425, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(181, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Disable Automatic Updates:";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(684, 251);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 23);
            this.button5.TabIndex = 36;
            this.button5.Text = "APPLY";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(425, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 16);
            this.label13.TabIndex = 35;
            this.label13.Text = "Optimized Visual Effects:";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(684, 285);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 23);
            this.button6.TabIndex = 40;
            this.button6.Text = "APPLY";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(425, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 16);
            this.label14.TabIndex = 38;
            this.label14.Text = "Disable Hibernation:";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(684, 353);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 23);
            this.button8.TabIndex = 42;
            this.button8.Text = "APPLY";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(425, 356);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(241, 16);
            this.label16.TabIndex = 41;
            this.label16.Text = "Enable Windows Photo Viewer (Old):";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(684, 387);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 23);
            this.button9.TabIndex = 46;
            this.button9.Text = "APPLY";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(425, 390);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(181, 16);
            this.label17.TabIndex = 44;
            this.label17.Text = "Disable FSO and GameBar:";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(684, 421);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(94, 23);
            this.button10.TabIndex = 48;
            this.button10.Text = "APPLY";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(425, 424);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(182, 16);
            this.label18.TabIndex = 47;
            this.label18.Text = "Enable DirectPlay (Legacy):";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(684, 319);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 23);
            this.button7.TabIndex = 51;
            this.button7.Text = "APPLY";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(425, 322);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(257, 16);
            this.label15.TabIndex = 50;
            this.label15.Text = "Add Ultimate Performance Power Plan:";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(684, 455);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(94, 23);
            this.button11.TabIndex = 54;
            this.button11.Text = "APPLY";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.Control;
            this.label19.Location = new System.Drawing.Point(425, 458);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(237, 16);
            this.label19.TabIndex = 53;
            this.label19.Text = "Add Run with Priority context menu:";
            // 
            // check16
            // 
            this.check16.AutoSize = true;
            this.check16.BackColor = System.Drawing.Color.Black;
            this.check16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check16.ForeColor = System.Drawing.Color.White;
            this.check16.Location = new System.Drawing.Point(200, 387);
            this.check16.Name = "check16";
            this.check16.Size = new System.Drawing.Size(71, 20);
            this.check16.TabIndex = 58;
            this.check16.Text = "Firefox";
            this.check16.UseVisualStyleBackColor = false;
            // 
            // check15
            // 
            this.check15.AutoSize = true;
            this.check15.BackColor = System.Drawing.Color.Black;
            this.check15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check15.ForeColor = System.Drawing.Color.White;
            this.check15.Location = new System.Drawing.Point(21, 387);
            this.check15.Name = "check15";
            this.check15.Size = new System.Drawing.Size(76, 20);
            this.check15.TabIndex = 57;
            this.check15.Text = "Chrome";
            this.check15.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1, 364);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(142, 0, 142, 0);
            this.label6.Size = new System.Drawing.Size(397, 15);
            this.label6.TabIndex = 56;
            this.label6.Text = "Internet Browsers:";
            // 
            // check18
            // 
            this.check18.AutoSize = true;
            this.check18.BackColor = System.Drawing.Color.Black;
            this.check18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check18.ForeColor = System.Drawing.Color.White;
            this.check18.Location = new System.Drawing.Point(200, 412);
            this.check18.Name = "check18";
            this.check18.Size = new System.Drawing.Size(63, 20);
            this.check18.TabIndex = 60;
            this.check18.Text = "Brave";
            this.check18.UseVisualStyleBackColor = false;
            // 
            // check17
            // 
            this.check17.AutoSize = true;
            this.check17.BackColor = System.Drawing.Color.Black;
            this.check17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check17.ForeColor = System.Drawing.Color.White;
            this.check17.Location = new System.Drawing.Point(21, 412);
            this.check17.Name = "check17";
            this.check17.Size = new System.Drawing.Size(65, 20);
            this.check17.TabIndex = 59;
            this.check17.Text = "Opera";
            this.check17.UseVisualStyleBackColor = false;
            // 
            // check4
            // 
            this.check4.AutoSize = true;
            this.check4.BackColor = System.Drawing.Color.Black;
            this.check4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check4.ForeColor = System.Drawing.Color.White;
            this.check4.Location = new System.Drawing.Point(199, 164);
            this.check4.Name = "check4";
            this.check4.Size = new System.Drawing.Size(93, 20);
            this.check4.TabIndex = 62;
            this.check4.Text = "qBittorrent";
            this.check4.UseVisualStyleBackColor = false;
            // 
            // check3
            // 
            this.check3.AutoSize = true;
            this.check3.BackColor = System.Drawing.Color.Black;
            this.check3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check3.ForeColor = System.Drawing.Color.White;
            this.check3.Location = new System.Drawing.Point(20, 164);
            this.check3.Name = "check3";
            this.check3.Size = new System.Drawing.Size(56, 20);
            this.check3.TabIndex = 61;
            this.check3.Text = "7-Zip";
            this.check3.UseVisualStyleBackColor = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.loadingLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loadingLabel.Location = new System.Drawing.Point(200, 225);
            this.loadingLabel.Margin = new System.Windows.Forms.Padding(0);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(273, 22);
            this.loadingLabel.TabIndex = 63;
            this.loadingLabel.Text = "Installing apps, please wait...";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadingLabel.UseWaitCursor = true;
            this.loadingLabel.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(395, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 500);
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 46);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.label20.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(297, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(210, 22);
            this.label20.TabIndex = 67;
            this.label20.Text = "ToolBox by NaeTech.eu";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.pictureBox3.Image = global::ToolBox_by_NaeTech.Properties.Resources.naetech_logo_small;
            this.pictureBox3.Location = new System.Drawing.Point(22, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(151, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 68;
            this.pictureBox3.TabStop = false;
            // 
            // exitbtn
            // 
            this.exitbtn.BackColor = System.Drawing.Color.Crimson;
            this.exitbtn.FlatAppearance.BorderSize = 0;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitbtn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.ForeColor = System.Drawing.Color.White;
            this.exitbtn.Location = new System.Drawing.Point(707, 10);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(71, 25);
            this.exitbtn.TabIndex = 69;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // minimizebtn
            // 
            this.minimizebtn.BackColor = System.Drawing.Color.Crimson;
            this.minimizebtn.FlatAppearance.BorderSize = 0;
            this.minimizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizebtn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizebtn.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.Location = new System.Drawing.Point(620, 10);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.Size = new System.Drawing.Size(71, 25);
            this.minimizebtn.TabIndex = 70;
            this.minimizebtn.Text = "MINIMIZE";
            this.minimizebtn.UseVisualStyleBackColor = false;
            this.minimizebtn.Click += new System.EventHandler(this.minimizebtn_Click);
            // 
            // installationProgressBar
            // 
            this.installationProgressBar.Location = new System.Drawing.Point(199, 192);
            this.installationProgressBar.Name = "installationProgressBar";
            this.installationProgressBar.Size = new System.Drawing.Size(400, 25);
            this.installationProgressBar.TabIndex = 71;
            this.installationProgressBar.Visible = false;
            // 
            // loadingback
            // 
            this.loadingback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.loadingback.Location = new System.Drawing.Point(-2, 44);
            this.loadingback.Name = "loadingback";
            this.loadingback.Size = new System.Drawing.Size(804, 456);
            this.loadingback.TabIndex = 72;
            this.loadingback.TabStop = false;
            this.loadingback.Visible = false;
            // 
            // toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.installationProgressBar);
            this.Controls.Add(this.loadingback);
            this.Controls.Add(this.minimizebtn);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.check4);
            this.Controls.Add(this.check3);
            this.Controls.Add(this.check18);
            this.Controls.Add(this.check17);
            this.Controls.Add(this.check16);
            this.Controls.Add(this.check15);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.check14);
            this.Controls.Add(this.check12);
            this.Controls.Add(this.check13);
            this.Controls.Add(this.check11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.check10);
            this.Controls.Add(this.check9);
            this.Controls.Add(this.check8);
            this.Controls.Add(this.check7);
            this.Controls.Add(this.check6);
            this.Controls.Add(this.check5);
            this.Controls.Add(this.check2);
            this.Controls.Add(this.check1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.installbtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "toolbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToolBox by NaeTech";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox check1;
        private System.Windows.Forms.CheckBox check2;
        private System.Windows.Forms.CheckBox check3;
        private System.Windows.Forms.CheckBox check4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check5;
        private System.Windows.Forms.CheckBox check6;
        private System.Windows.Forms.CheckBox check7;
        private System.Windows.Forms.CheckBox check8;
        private System.Windows.Forms.CheckBox check9;
        private System.Windows.Forms.CheckBox check10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox check11;
        private System.Windows.Forms.CheckBox check13;
        private System.Windows.Forms.CheckBox check12;
        private System.Windows.Forms.CheckBox check14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox check15;
        private System.Windows.Forms.CheckBox check16;
        private System.Windows.Forms.CheckBox check17;
        private System.Windows.Forms.CheckBox check18;
        private System.Windows.Forms.Button installbtn;
        // Windows Tweaker
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button minimizebtn;
        private ProgressBar installationProgressBar;
        private PictureBox loadingback;
    }
}
