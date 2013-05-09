using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyboardCtrl_V3
{
    public partial class KeyboardCtrl : UserControl
    {
        //===提前从硬盘中读入图片放入内存中，这样不用每次击键都读硬盘了===//
      
        #region
        /*
        Bitmap keyA;
        Bitmap keyA_1;
        Bitmap keyB;
        Bitmap keyB_1;
        Bitmap keyC;
        Bitmap keyC_1;
        Bitmap keyD;
        Bitmap keyD_1;
        Bitmap keyE;
        Bitmap keyE_1;
        Bitmap keyF;
        Bitmap keyF_1;
        Bitmap keyG;
        Bitmap keyG_1;
        Bitmap keyH;
        Bitmap keyH_1;
        Bitmap keyI;
        Bitmap keyI_1;
        Bitmap keyJ;
        Bitmap keyJ_1;
        Bitmap keyK;
        Bitmap keyK_1;
        Bitmap keyL;
        Bitmap keyL_1;
        Bitmap keyM;
        Bitmap keyM_1;
        Bitmap keyN;
        Bitmap keyN_1;
        Bitmap keyO;
        Bitmap keyO_1;
        Bitmap keyP;
        Bitmap keyP_1;
        Bitmap keyQ;
        Bitmap keyQ_1;
        Bitmap keyR;
        Bitmap keyR_1;
        Bitmap keyS;
        Bitmap keyS_1;
        Bitmap keyT ;
        Bitmap keyT_1;
        Bitmap keyU  ;
        Bitmap keyU_1 ;
        Bitmap keyV ;
        Bitmap keyV_1;
        Bitmap keyW ;
        Bitmap keyW_1 ;
        Bitmap keyX  ;
        Bitmap keyX_1 ;
        Bitmap keyY  ;
        Bitmap keyY_1 ;
        Bitmap keyZ  ;
        Bitmap keyZ_1 ;
         
        Bitmap key0   ;
        Bitmap key0_1 ;
        Bitmap key1   ;
        Bitmap key1_1 ;
        Bitmap key2  ;
        Bitmap key2_1 ;
        Bitmap key3  ;
        Bitmap key3_1 ;
        Bitmap key4   ;
        Bitmap key4_1 ;
        Bitmap key5  ;
        Bitmap key5_1;
        Bitmap key6   ;
        Bitmap key6_1 ;
        Bitmap key7   ;
        Bitmap key7_1;
        Bitmap key8  ;
        Bitmap key8_1 ;
        Bitmap key9 ;
        Bitmap key9_1 ;

        Bitmap mykeySpace       ;
        Bitmap mykeySpace_1    ;
        Bitmap mykeyEnter      ;
        Bitmap mykeyEnter_1    ;
        Bitmap mykeyBackspace   ;
        Bitmap mykeyBackspace_1;
        */
        #endregion
            #region
            private Bitmap keyA   = new Bitmap(".\\keyboardResource\\keyA.gif"); //如果没有点号。则从跟目录开始
            private Bitmap keyA_1 = new Bitmap(".\\keyboardResource\\keyA-1.gif");
            private Bitmap keyB   = new Bitmap(".\\keyboardResource\\keyB.gif");
            private Bitmap keyB_1 = new Bitmap(".\\keyboardResource\\keyB-1.gif");
            private Bitmap keyC   = new Bitmap(".\\keyboardResource\\keyC.gif");
            private Bitmap keyC_1 = new Bitmap(".\\keyboardResource\\keyC-1.gif");
            private Bitmap keyD   = new Bitmap(".\\keyboardResource\\keyD.gif");
            private Bitmap keyD_1 = new Bitmap(".\\keyboardResource\\keyD-1.gif");
            private Bitmap keyE   = new Bitmap(".\\keyboardResource\\keyE.gif");
            private Bitmap keyE_1 = new Bitmap(".\\keyboardResource\\keyE-1.gif");
            private Bitmap keyF   = new Bitmap(".\\keyboardResource\\keyF.gif");
            private Bitmap keyF_1 = new Bitmap(".\\keyboardResource\\keyF-1.gif");
            private Bitmap keyG   = new Bitmap(".\\keyboardResource\\keyG.gif");
            private Bitmap keyG_1 = new Bitmap(".\\keyboardResource\\keyG-1.gif");
            private Bitmap keyH   = new Bitmap(".\\keyboardResource\\keyH.gif");
            private Bitmap keyH_1 = new Bitmap(".\\keyboardResource\\keyH-1.gif");
            private Bitmap keyI   = new Bitmap(".\\keyboardResource\\keyI.gif");
            private Bitmap keyI_1 = new Bitmap(".\\keyboardResource\\keyI-1.gif");
            private Bitmap keyJ   = new Bitmap(".\\keyboardResource\\keyJ.gif");
            private Bitmap keyJ_1 = new Bitmap(".\\keyboardResource\\keyJ-1.gif");
            private Bitmap keyK   = new Bitmap(".\\keyboardResource\\keyK.gif");
            private Bitmap keyK_1 = new Bitmap(".\\keyboardResource\\keyK-1.gif");
            private Bitmap keyL   = new Bitmap(".\\keyboardResource\\keyL.gif");
            private Bitmap keyL_1 = new Bitmap(".\\keyboardResource\\keyL-1.gif");
            private Bitmap keyM   = new Bitmap(".\\keyboardResource\\keyM.gif");
            private Bitmap keyM_1 = new Bitmap(".\\keyboardResource\\keyM-1.gif");
            private Bitmap keyN   = new Bitmap(".\\keyboardResource\\keyN.gif");
            private Bitmap keyN_1 = new Bitmap(".\\keyboardResource\\keyN-1.gif");
            private Bitmap keyO   = new Bitmap(".\\keyboardResource\\keyO.gif");
            private Bitmap keyO_1 = new Bitmap(".\\keyboardResource\\keyO-1.gif");
            private Bitmap keyP   = new Bitmap(".\\keyboardResource\\keyP.gif");
            private Bitmap keyP_1 = new Bitmap(".\\keyboardResource\\keyP-1.gif");
            private Bitmap keyQ   = new Bitmap(".\\keyboardResource\\keyQ.gif");
            private Bitmap keyQ_1 = new Bitmap(".\\keyboardResource\\keyQ-1.gif");
            private Bitmap keyR   = new Bitmap(".\\keyboardResource\\keyR.gif");
            private Bitmap keyR_1 = new Bitmap(".\\keyboardResource\\keyR-1.gif");
            private Bitmap keyS   = new Bitmap(".\\keyboardResource\\keyS.gif");
            private Bitmap keyS_1 = new Bitmap(".\\keyboardResource\\keyS-1.gif");
            private Bitmap keyT   = new Bitmap(".\\keyboardResource\\keyT.gif");
            private Bitmap keyT_1 = new Bitmap(".\\keyboardResource\\keyT-1.gif");
            private Bitmap keyU   = new Bitmap(".\\keyboardResource\\keyU.gif");
            private Bitmap keyU_1 = new Bitmap(".\\keyboardResource\\keyU-1.gif");
            private Bitmap keyV   = new Bitmap(".\\keyboardResource\\keyV.gif");
            private Bitmap keyV_1 = new Bitmap(".\\keyboardResource\\keyV-1.gif");
            private Bitmap keyW   = new Bitmap(".\\keyboardResource\\keyW.gif");
            private Bitmap keyW_1 = new Bitmap(".\\keyboardResource\\keyW-1.gif");
            private Bitmap keyX   = new Bitmap(".\\keyboardResource\\keyX.gif");
            private Bitmap keyX_1 = new Bitmap(".\\keyboardResource\\keyX-1.gif");
            private Bitmap keyY   = new Bitmap(".\\keyboardResource\\keyY.gif");
            private Bitmap keyY_1 = new Bitmap(".\\keyboardResource\\keyY-1.gif");
            private Bitmap keyZ   = new Bitmap(".\\keyboardResource\\keyZ.gif");
            private Bitmap keyZ_1 = new Bitmap(".\\keyboardResource\\keyZ-1.gif");

            private Bitmap key0   = new Bitmap(".\\keyboardResource\\key0.gif");
            private Bitmap key0_1 = new Bitmap(".\\keyboardResource\\key0-1.gif");
            private Bitmap key1   = new Bitmap(".\\keyboardResource\\key1.gif");
            private Bitmap key1_1 = new Bitmap(".\\keyboardResource\\key1-1.gif");
            private Bitmap key2   = new Bitmap(".\\keyboardResource\\key2.gif");
            private Bitmap key2_1 = new Bitmap(".\\keyboardResource\\key2-1.gif");
            private Bitmap key3   = new Bitmap(".\\keyboardResource\\key3.gif");
            private Bitmap key3_1 = new Bitmap(".\\keyboardResource\\key3-1.gif");
            private Bitmap key4   = new Bitmap(".\\keyboardResource\\key4.gif");
            private Bitmap key4_1 = new Bitmap(".\\keyboardResource\\key4-1.gif");
            private Bitmap key5   = new Bitmap(".\\keyboardResource\\key5.gif");
            private Bitmap key5_1 = new Bitmap(".\\keyboardResource\\key5-1.gif");
            private Bitmap key6   = new Bitmap(".\\keyboardResource\\key6.gif");
            private Bitmap key6_1 = new Bitmap(".\\keyboardResource\\key6-1.gif");
            private Bitmap key7   = new Bitmap(".\\keyboardResource\\key7.gif");
            private Bitmap key7_1 = new Bitmap(".\\keyboardResource\\key7-1.gif");
            private Bitmap key8   = new Bitmap(".\\keyboardResource\\key8.gif");
            private Bitmap key8_1 = new Bitmap(".\\keyboardResource\\key8-1.gif");
            private Bitmap key9   = new Bitmap(".\\keyboardResource\\key9.gif");
            private Bitmap key9_1 = new Bitmap(".\\keyboardResource\\key9-1.gif");

            private Bitmap keyPoint = new Bitmap(".\\keyboardResource\\keyPoint.gif");
            private Bitmap keyPoint_1 = new Bitmap(".\\keyboardResource\\keyPoint-1.gif");

            private Bitmap mykeySpace       = new Bitmap(".\\keyboardResource\\mykeySpace.gif");
            private Bitmap mykeySpace_1     = new Bitmap(".\\keyboardResource\\mykeySpace-1.gif");
            private Bitmap mykeyEnter       = new Bitmap(".\\keyboardResource\\mykeyEnter.gif");
            private Bitmap mykeyEnter_1     = new Bitmap(".\\keyboardResource\\mykeyEnter-1.gif");
            private Bitmap mykeyBackspace   = new Bitmap(".\\keyboardResource\\mykeyBackspace.gif");
            private Bitmap mykeyBackspace_1 = new Bitmap(".\\keyboardResource\\mykeyBackspace-1.gif");
            #endregion
        int currMethodIndex = 0; //当前输入法索引值
        BackgroundWorker bgWorker = new BackgroundWorker();
        public bool IsShow = false;
        public KeyboardCtrl()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;

            bgWorker.DoWork += DoWork_Hander;
            bgWorker.ProgressChanged += ProgressChanged_Hander;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;

        }
        private void DoWork_Hander(object sender,DoWorkEventArgs args)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 0; i <= 25;i++ )
            {
                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    break;
                }
                else
                {
                    if (IsShow)
                        worker.ReportProgress(i*4);
                    else
                        worker.ReportProgress(100- i * 4);
                    Thread.Sleep(20);
                }
            }
        }

        private void ProgressChanged_Hander(object sender, ProgressChangedEventArgs args)
        {
            Rectangle screenRect = Screen.AllScreens[0].Bounds;
            int y = screenRect.Height;


            int dy = this.Height;
            float x = (float)dy*((float)args.ProgressPercentage / 100);
            int yy = y - (int)x;
            this.Location = new Point(this.Location.X, yy);
          
        }

        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs args)
        {

        }

        public void ShowKeyBoard(bool bShow)
        {
            if (bShow)
            {
                Rectangle screenRect = Screen.AllScreens[0].Bounds;
                this.Location = new Point(screenRect.Width / 2 - this.Width / 2, screenRect.Height);
                IsShow = true;
            }

            else
            {
                Rectangle screenRect = Screen.AllScreens[0].Bounds;
                this.Location = new Point(screenRect.Width / 2 - this.Width / 2, screenRect.Height-this.Height);
                IsShow = false;
            }

            if(!bgWorker.IsBusy)
                 bgWorker.RunWorkerAsync();
        }
        private void KeyboardCtrl_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = keyQ;
            this.pictureBox2.Image = keyA;
            this.pictureBox3.Image = keyZ;

            this.pictureBox4.Image = keyW;
            this.pictureBox5.Image = keyS;
            this.pictureBox6.Image = keyX;

            this.pictureBox7.Image = keyE;
            this.pictureBox8.Image = keyD;
            this.pictureBox9.Image = keyC;

            this.pictureBox10.Image = keyR;
            this.pictureBox11.Image = keyF;
            this.pictureBox12.Image = keyV;

            this.pictureBox13.Image = keyT;
            this.pictureBox14.Image = keyG;
            this.pictureBox15.Image = keyB;

            this.pictureBox16.Image = keyY;
            this.pictureBox17.Image = keyH;
            this.pictureBox18.Image = keyN;

            this.pictureBox19.Image = keyU;
            this.pictureBox20.Image = keyJ;
            this.pictureBox21.Image = keyM;

            this.pictureBox22.Image = keyI;
            this.pictureBox23.Image = keyK;

            this.pictureBox24.Image = keyO;
            this.pictureBox25.Image = keyL;
            this.pictureBox26.Image = keyP;

            this.pictureBox33.Image = key1;
            this.pictureBox34.Image = key2;
            this.pictureBox35.Image = key3;
            this.pictureBox30.Image = key4;
            this.pictureBox31.Image = key5;
            this.pictureBox32.Image = key6;
            this.pictureBox27.Image = key7;
            this.pictureBox28.Image = key8;
            this.pictureBox29.Image = key9;
            this.pictureBox39.Image = key0;

            this.pictureBox37.Image = mykeySpace;
            this.pictureBox36.Image = mykeyEnter;
            this.pictureBox38.Image = mykeyBackspace;
            //this.pictureBox40.Image = keyPoint;
            //====current input method=====//
            //获取当前输入法信息
            InputLanguage CurrentInput = InputLanguage.CurrentInputLanguage;
            this.label1.Text = CurrentInput.LayoutName;

        }
 
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(
            byte bVk,                          //定义一个虚据拟键码。键码值必须在1～254之间。
            byte bScan,                        //定义该键的硬件扫描码
            int dwFlags,
            int dwExtraInfo
        );

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(81, 0, 0, 0);                      //Q压下
            keybd_event(81, 0, 0x02, 0);                   //Q弹起
            pictureBox1.Image = keyQ_1;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = keyQ;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = keyQ;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
           
            keybd_event(65, 0, 0, 0);                      //A压下
            keybd_event(65, 0, 0x02, 0);                   //A弹起
            pictureBox2.Image = keyA_1;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = keyA;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = keyA;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
           
            keybd_event(90, 0, 0, 0);                      //Z压下
            keybd_event(90, 0, 0x02, 0);                   //Z弹起
            pictureBox3.Image = keyZ_1;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = keyZ;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = keyZ;
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(87, 0, 0, 0);                      //W压下
            keybd_event(87, 0, 0x02, 0);                   //W弹起
            pictureBox4.Image = keyW_1;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = keyW;
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(83, 0, 0, 0);                      //S压下
            keybd_event(83, 0, 0x02, 0);                   //S弹起
            pictureBox5.Image = keyS_1;
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = keyS;
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(88, 0, 0, 0);                      //X压下
            keybd_event(88, 0, 0x02, 0);                   //X弹起
            pictureBox6.Image = keyX_1;
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox6.Image = keyX;
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(69, 0, 0, 0);                      //E压下
            keybd_event(69, 0, 0x02, 0);                   //E弹起
            pictureBox7.Image = keyE_1;
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox7.Image = keyE;
        }

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(68, 0, 0, 0);                      //D压下
            keybd_event(68, 0, 0x02, 0);                   //D弹起
            pictureBox8.Image = keyD_1;
        }

        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox8.Image = keyD;
        }

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(67, 0, 0, 0);                      //C压下
            keybd_event(67, 0, 0x02, 0);                   //C弹起
            pictureBox9.Image = keyC_1;

        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox9.Image = keyC;
        }

        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(82, 0, 0, 0);                      //R压下
            keybd_event(82, 0, 0x02, 0);                   //R弹起
            pictureBox10.Image = keyR_1;

        }

        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox10.Image = keyR;
        }

        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(70, 0, 0, 0);                      //F压下
            keybd_event(70, 0, 0x02, 0);                   //F弹起
            pictureBox11.Image = keyF_1;
        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox11.Image = keyF;
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(86, 0, 0, 0);                      //V压下
            keybd_event(86, 0, 0x02, 0);                   //V弹起
            pictureBox12.Image = keyV_1;
        }

        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox12.Image = keyV;
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(84, 0, 0, 0);                      //T压下
            keybd_event(84, 0, 0x02, 0);                   //T弹起
            pictureBox13.Image = keyT_1;
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox13.Image = keyT;
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(71, 0, 0, 0);                      //G压下
            keybd_event(71, 0, 0x02, 0);                   //G弹起
            pictureBox14.Image = keyG_1;

        }

        private void pictureBox14_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox14.Image = keyG;
        }

        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(66, 0, 0, 0);                      //B压下
            keybd_event(66, 0, 0x02, 0);                   //B弹起
            pictureBox15.Image = keyB_1;
        }

        private void pictureBox15_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox15.Image = keyB;
        }

        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(89, 0, 0, 0);                      //Y压下
            keybd_event(89, 0, 0x02, 0);                   //Y弹起
            pictureBox16.Image = keyY_1;
        }

        private void pictureBox16_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox16.Image = keyY;
        }

        private void pictureBox17_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(72, 0, 0, 0);                      //H压下
            keybd_event(72, 0, 0x02, 0);                   //H弹起
            pictureBox17.Image = keyH_1;
        }

        private void pictureBox17_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox17.Image = keyH;
        }

        private void pictureBox18_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(78, 0, 0, 0);                      //N压下
            keybd_event(78, 0, 0x02, 0);                   //N弹起
            pictureBox18.Image = keyN_1;
        }

        private void pictureBox18_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox18.Image = keyN;
        }

        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(85, 0, 0, 0);                      //U压下
            keybd_event(85, 0, 0x02, 0);                   //U弹起
            pictureBox19.Image = keyU_1;
        }

        private void pictureBox19_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox19.Image = keyU;
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(74, 0, 0, 0);                      //J压下
            keybd_event(74, 0, 0x02, 0);                   //J弹起
            pictureBox20.Image = keyJ_1;
        }

        private void pictureBox20_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox20.Image = keyJ;
        }

        private void pictureBox21_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(77, 0, 0, 0);                      //M压下
            keybd_event(77, 0, 0x02, 0);                   //M弹起
            pictureBox21.Image = keyM_1;

        }

        private void pictureBox21_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox21.Image = keyM;
        }

        private void pictureBox22_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(73, 0, 0, 0);                      //I压下
            keybd_event(73, 0, 0x02, 0);                   //I弹起
            pictureBox22.Image = keyI_1;
        }
          private void pictureBox22_MouseUp(object sender, MouseEventArgs e)
        {
              pictureBox22.Image = keyI;
        }

        private void pictureBox23_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(75, 0, 0, 0);                      //K压下
            keybd_event(75, 0, 0x02, 0);                   //K弹起
            pictureBox23.Image = keyK_1;
        }

        private void pictureBox23_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox23.Image = keyK;
        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(79, 0, 0, 0);                      //O压下
            keybd_event(79, 0, 0x02, 0);                   //O弹起
            pictureBox24.Image = keyO_1;
        }
        private void pictureBox24_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox24.Image = keyO;
        }


        private void pictureBox25_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(76, 0, 0, 0);                      //L压下
            keybd_event(76, 0, 0x02, 0);                   //L弹起
            pictureBox25.Image = keyL_1;

        }

        private void pictureBox25_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox25.Image = keyL;
        }

        private void pictureBox26_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(80, 0, 0, 0);                      //P压下
            keybd_event(80, 0, 0x02, 0);                   //P弹起
            pictureBox26.Image = keyP_1;
        }

        private void pictureBox26_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox26.Image = keyP;
        }

        private void pictureBox27_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(55, 0, 0, 0);                      //7压下
            keybd_event(55, 0, 0x02, 0);                   //7弹起
            pictureBox27.Image = key7_1;
        }

        private void pictureBox27_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox27.Image = key7;
        }

        private void pictureBox28_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(56, 0, 0, 0);                      //8压下
            keybd_event(56, 0, 0x02, 0);                   //8弹起
            pictureBox28.Image = key8_1;
        }

        private void pictureBox28_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox28.Image = key8;
        }

        private void pictureBox29_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(57, 0, 0, 0);                      //9压下
            keybd_event(57, 0, 0x02, 0);                   //9弹起
            pictureBox29.Image = key9_1;

        }

        private void pictureBox29_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox29.Image = key9;
    
        }

        private void pictureBox30_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(52, 0, 0, 0);                      //4压下
            keybd_event(52, 0, 0x02, 0);                   //4弹起
            pictureBox30.Image = key4_1;
        }

        private void pictureBox30_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox30.Image = key4;
        }

        private void pictureBox31_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(53, 0, 0, 0);                      //5压下
            keybd_event(53, 0, 0x02, 0);                   //5弹起
            pictureBox31.Image = key5_1;

        }

        private void pictureBox31_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox31.Image = key5;
        }

        private void pictureBox32_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(54, 0, 0, 0);                      //6压下
            keybd_event(54, 0, 0x02, 0);                   //6弹起
            pictureBox32.Image = key6_1;
        }

        private void pictureBox32_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox32.Image = key6;
        }

        private void pictureBox33_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(49, 0, 0, 0);                      //1压下
            keybd_event(49, 0, 0x02, 0);                   //1弹起
            pictureBox33.Image = key1_1;
        }
        private void pictureBox33_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox33.Image = key1;
        }

        private void pictureBox34_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(50, 0, 0, 0);                      //2压下
            keybd_event(50, 0, 0x02, 0);                   //2弹起
            pictureBox34.Image = key2_1;
        }



        private void pictureBox34_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox34.Image = key2;
        }

        private void pictureBox35_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(51, 0, 0, 0);                      //3压下
            keybd_event(51, 0, 0x02, 0);                   //3弹起
            pictureBox35.Image = key3_1;
        }

        private void pictureBox35_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox35.Image = key3;
        }

        private void pictureBox36_MouseDown(object sender, MouseEventArgs e)
        {
            
           // keybd_event(13, 0, 0, 0);                      //ENTER压下
           // keybd_event(13, 0, 0x02, 0);                   //弹起
            keybd_event(32, 0, 0, 0);                      //SPACE压下
            keybd_event(32, 0, 0x02, 0);                   //弹起
            pictureBox36.Image = mykeyEnter_1;
        }

        private void pictureBox36_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox36.Image = mykeyEnter;
        }

        private void pictureBox37_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(32, 0, 0, 0);                      //SPACE压下
            keybd_event(32, 0, 0x02, 0);                   //弹起
            pictureBox37.Image = mykeySpace_1;
        }

        private void pictureBox37_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox37.Image = mykeySpace;
        }

        private void pictureBox38_MouseDown(object sender, MouseEventArgs e)
        {
            
            keybd_event(8, 0, 0, 0);                      //BACKSPACE压下
            keybd_event(8, 0, 0x02, 0);                   //弹起
            pictureBox38.Image = mykeyBackspace_1;
        }

        private void pictureBox38_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox38.Image = mykeyBackspace;
        }

        private void pictureBox39_MouseDown(object sender, MouseEventArgs e)
        {
            keybd_event(48, 0, 0, 0);                      //0压下
            keybd_event(48, 0, 0x02, 0);                   //0弹起
            pictureBox39.Image = key0_1;

        }

        private void pictureBox39_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox39.Image = key0;
        }

        //=========change the input method=======//
        private void button3_Click(object sender, EventArgs e)
        {
            currMethodIndex++;
            if (currMethodIndex >= InputLanguage.InstalledInputLanguages.Count)
                currMethodIndex = 0;

            //设置当前输入法
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[currMethodIndex];
            this.label1.Text = InputLanguage.CurrentInputLanguage.LayoutName;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            currMethodIndex++;
            if (currMethodIndex >= InputLanguage.InstalledInputLanguages.Count)
                currMethodIndex = 0;

            //设置当前输入法
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[currMethodIndex];
            this.label1.Text = InputLanguage.CurrentInputLanguage.LayoutName;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            currMethodIndex++;
            if (currMethodIndex >= InputLanguage.InstalledInputLanguages.Count)
                currMethodIndex = 0;

            //设置当前输入法
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[currMethodIndex];
            this.label1.Text = InputLanguage.CurrentInputLanguage.LayoutName;

        }



    
    }

}
