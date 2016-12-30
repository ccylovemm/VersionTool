using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VersionTools
{
    public class VersionTool
    {
        static public int oldVersion;//版本号
        static public int newVersion;//版本号
        static public string fileParent = "";
        static public Dictionary<string, string> oldFileHash = new Dictionary<string, string>();
        static public Dictionary<string, string> newFileHash = new Dictionary<string, string>();
        static private System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

        static public void ReadOldHash()
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(fileParent, "Version.txt")))
            {
                string txt = System.IO.File.ReadAllText(System.IO.Path.Combine(fileParent, "Version.txt"), Encoding.UTF8);
                string[] lines = txt.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    if (line.IndexOf("VersionNumber|") == 0)
                    {
                        oldVersion = int.Parse(line.Split('|')[1]);
                    }
                    else if (line.IndexOf("FileCount|") == 0)
                    {

                    }
                    else
                    {
                        var fileName = line.Split('|')[0];
                        var fileHas = line.Split('|')[1];
                        if (System.IO.File.Exists(fileParent + "/" + fileName) == false) continue;
                        oldFileHash[fileName] = fileHas;
                    }
                }
            }
        }

        static public void GenNewHash()
        {
            newFileHash.Clear();

            string[] files = System.IO.Directory.GetFiles(fileParent, "*.*", System.IO.SearchOption.AllDirectories);
            foreach (string filename in files)
            {
                if (filename.IndexOf(".crc.txt") >= 0 || filename.IndexOf(".meta") >= 0 || filename.IndexOf(".db") >= 0) continue;
                using (System.IO.Stream s = System.IO.File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(s);
                    var shash = Convert.ToBase64String(hash) + "@" + s.Length;
                    newFileHash[filename.Replace(fileParent + "\\", "").Replace("\\" , "/")] = shash;
                }
            }
        }

        static public void Save()
        {
            string outstr = "VersionNumber|" + newVersion + "\n" + "FileCount|" + newFileHash.Count + "\n";
            foreach (var hash in newFileHash)
            {
                outstr += hash.Key + "|" + hash.Value + "\n";
            }
            string outfile = System.IO.Path.Combine(fileParent, "Version.txt");
            System.IO.File.WriteAllText(outfile, outstr, Encoding.ASCII);
        }
    }
}
