using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VersionTool
{
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            InitializeComponent();
        }

        private void Version_Load(object sender, EventArgs e)
        {
            VersionTools.ReadOldHash();
            VersionTools.InitFilePath();
            foreach (var file in VersionTools.filePaths)
            {
                listBoxGroup.Items.Add(file);
            }
        }     
       
        private void button1_Click(object sender, EventArgs e)
        {
            CheckVersion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenVersion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBoxConsole.Items.Clear();
        }
        
        private void CheckVersion()
        {
            if (VersionTools.fileParent == "")
            {
                listBoxConsole.Items.Add("请选择文件夹");
                return;
            }
            VersionTools.GenNewHash();
            foreach (var file in VersionTools.newFileHash)
            {
                listBoxFiles.Items.Add(file.Key);
            }
            int delcount = 0;
            int updatecount = 0;
            int addcount = 0;
            foreach (var hash in VersionTools.oldFileHash)
            {
                if (VersionTools.newFileHash.ContainsKey(hash.Key) == false)
                {
                    listBoxConsole.Items.Add("文件被删除：" + hash.Key);
                    delcount++;
                }
                else
                {
                    if (VersionTools.newFileHash[hash.Key] != hash.Value)
                    {
                        listBoxConsole.Items.Add("文件更新：" + hash.Key);
                        updatecount++;
                    }
                }
            }
            foreach (var hash in VersionTools.newFileHash)
            {
                if (VersionTools.oldFileHash.ContainsKey(hash.Key) == false)
                {
                    listBoxConsole.Items.Add("文件增加：" + hash.Key);
                    addcount++;
                }
            }

            if (addcount == 0 && delcount == 0 && updatecount == 0)
            {
                listBoxConsole.Items.Add("无变化 Version=" + VersionTools.oldVersion);
            }
            else
            {
                VersionTools.newVersion = VersionTools.oldVersion + 1;
                listBoxConsole.Items.Add("检查变化结果 增加:" + addcount + "个 删除:" + delcount + "个 更新:" + updatecount);
                listBoxConsole.Items.Add("版本号变为:" + VersionTools.newVersion);
            }
        }

        private void GenVersion()
        {
            if (VersionTools.newFileHash.Count == 0)
            {
                listBoxConsole.Items.Add("先检查一下版本再生成");
                return;
            }
            else if (VersionTools.oldVersion == VersionTools.newVersion)
            {
                listBoxConsole.Items.Add("版本无变化");
                return;
            }

            VersionTools.Save();

            listBoxConsole.Items.Add("生成结束 Version:" + VersionTools.newVersion);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK)
            {
                this.label1.Text = dilog.SelectedPath;
                string filename = dilog.SelectedPath.Replace('\\', '/');
                VersionTools.fileParent = filename;
            }
        }
    }
}
