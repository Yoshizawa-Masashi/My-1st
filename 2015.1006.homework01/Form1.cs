using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2015._1006.homework01
{
    public partial class Form1 : Form
    {
        int DelayedMsgCounter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //テキストボックスからファイル名，ファイルパスを取得
            string path = textBox1.Text;
            //ファイルが存在しなかったら？
            if (System.IO.File.Exists(path)==false)
            {
                MessageBox.Show("ファイルが見つかりません", "おしらせ");
                return;
            }
            //以降はファイルが存在していたときだけ処理される
            System.IO.StreamReader textFile;
            textFile = new System.IO.StreamReader(path, System.Text.Encoding.Default);
            //ラベル1はプロパティより”テキストボックスに読み込みたいファイル名を入力してください”を入力している
            label1.Text = textFile.ReadToEnd(); //テキストファイルの終わりまで流し込む
            textFile.Close(); //クローズ処理は忘れずに．
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //テキストボックスからファイル名，ファイルパスを取得
            string path = textBox1.Text;
            string text = textBox2.Text;
            System.IO.StreamWriter textFile;
            textFile = new System.IO.StreamWriter(
                path, false, System.Text.Encoding.Default);
      

            textFile.WriteLine(string.Format("ファイル作成時の時刻は {0} です", DateTime.Now.ToLongTimeString()));
            textFile.Close();
            //うまく作成したらステータスラベルにメッセージ
            label2.Text = "引き続き新たなテキストファイルを作成する場合は新記";
            toolStripStatusLabel1.Text = "新規作成しました: " + path;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //時計を更新
            toolStripStatusLabel1.Text = string.Format("現在の時刻は {0} です", DateTime.Now.ToShortTimeString());
            switch (DelayedMsgCounter)
            {
                case 3:
                    toolStripStatusLabel1.Text = "ファイルを新規作成するプログラム";
                    break;
                case 10:
                    DelayedMsgCounter = 0;
                    break;
                default:
                    DelayedMsgCounter++;
                    break;
            }

        }


    }
        }


 

