using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VersionTools
{
    public partial class VersionFrom : Form
    {
        public VersionFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK)
            {
                this.label1.Text = dilog.SelectedPath;
                string filename = dilog.SelectedPath.Replace('\\', '/');
                VersionTool.fileParent = filename;
                VersionTool.ReadOldHash();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckVersion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenVersion();
        }

        private void CheckVersion()
        {
            if (VersionTool.fileParent == "")
            {
                OutputBox.Items.Add("请选择文件夹");
                return;
            }
            VersionTool.GenNewHash();
            foreach (var file in VersionTool.newFileHash)
            {
                AllFileBox.Items.Add(file.Key);
            }
            int delcount = 0;
            int updatecount = 0;
            int addcount = 0;
            foreach (var hash in VersionTool.oldFileHash)
            {
                if (VersionTool.newFileHash.ContainsKey(hash.Key) == false)
                {
                    OutputBox.Items.Add("文件被删除：" + hash.Key);
                    delcount++;
                }
                else
                {
                    if (VersionTool.newFileHash[hash.Key] != hash.Value)
                    {
                        OutputBox.Items.Add("文件更新：" + hash.Key);
                        updatecount++;
                    }
                }
            }
            foreach (var hash in VersionTool.newFileHash)
            {
                if (VersionTool.oldFileHash.ContainsKey(hash.Key) == false)
                {
                    OutputBox.Items.Add("文件增加：" + hash.Key);
                    addcount++;
                }
            }


            if (addcount == 0 && delcount == 0 && updatecount == 0)
            {
                OutputBox.Items.Add("无变化 Version=" + VersionTool.oldVersion);
                currVersionLable.Text = VersionTool.oldVersion.ToString(); 
                nextVersionLable.Text = VersionTool.oldVersion.ToString();
            }
            else
            {
                VersionTool.newVersion = VersionTool.oldVersion + 1;
                OutputBox.Items.Add("检查变化结果 增加:" + addcount + "个 删除:" + delcount + "个 更新:" + updatecount);
                OutputBox.Items.Add("版本号变为:" + VersionTool.newVersion);
                currVersionLable.Text = VersionTool.oldVersion.ToString();
                nextVersionLable.Text = (VersionTool.oldVersion + 1).ToString();
            }
        }

        private void GenVersion()
        {
            if (VersionTool.newFileHash.Count == 0)
            {
                OutputBox.Items.Add("先检查一下版本再生成");
                return;
            }
            else if (VersionTool.oldVersion == VersionTool.newVersion)
            {
                OutputBox.Items.Add("版本无变化");
                return;
            }

            VersionTool.Save();

            OutputBox.Items.Add("生成结束 Version:" + VersionTool.newVersion);
            OutputBox.SelectedIndex = OutputBox.Items.Count - 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VersionTool.newVersion = int.Parse(nextVersionLable.Text);
        }
    }
}
