using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VersionTool
{
    public class VersionTools
    {
        static public int oldVersion;//版本号
        static public int newVersion;//版本号
        static public string fileParent = "";
        static public string[] filePaths;
        static public Dictionary<string, string> oldFileHash = new Dictionary<string, string>();
        static public Dictionary<string, string> newFileHash = new Dictionary<string, string>();
        static private System.Security.Cryptography.SHA1CryptoServiceProvider osha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

        static public void ReadOldHash()
        {
            if (System.IO.File.Exists(System.IO.Path.Combine("./", "Version.txt")))
            {
                string txt = System.IO.File.ReadAllText(System.IO.Path.Combine("./", "Version.txt"), Encoding.UTF8);
                string[] lines = txt.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    if (line.IndexOf("Version:") == 0)
                    {
                        oldVersion = int.Parse(line.Substring(4));
                    }
                    else
                    {
                        var fileName = line.Split('|')[0];
                        var fileHas = line.Split('|')[1];
                        if (System.IO.File.Exists(fileName) == false) return;
                        using (System.IO.Stream s = System.IO.File.OpenRead(fileName))
                        {
                            var rhash = osha1.ComputeHash(s);
                            var shash = Convert.ToBase64String(rhash);
                            if (shash != fileHas) continue;
                        }
                        oldFileHash[fileName] = fileHas;
                    }
                }
            }
        }

        static public void InitFilePath()
        {
            if (System.IO.File.Exists(System.IO.Path.Combine("./", "ResourcePath.txt")))
            {
                string txt = System.IO.File.ReadAllText(System.IO.Path.Combine("./", "ResourcePath.txt"), Encoding.UTF8);
                filePaths = txt.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                FileStream file = new FileStream(System.IO.Path.Combine("./", "ResourcePath.txt") , FileMode.OpenOrCreate);
                file.Close();
            }
        }

        static public void GenNewHash()
        {
            newFileHash.Clear();

            foreach (var filePath in filePaths)
            {
                string[] files = System.IO.Directory.GetFiles(fileParent + "/" + filePath, "*.*", System.IO.SearchOption.AllDirectories);
                foreach (string filename in files)
                {
                    if (filename.IndexOf(".crc.txt") >= 0 || filename.IndexOf(".meta") >= 0 || filename.IndexOf(".db") >= 0) continue;
                    using (System.IO.Stream s = System.IO.File.OpenRead(filename))
                    {
                        var hash = osha1.ComputeHash(s);
                        var shash = Convert.ToBase64String(hash) + "@" + s.Length;
                        newFileHash[filename] = shash;
                    }
                }
            }
        }

        static public void Save()
        {
            string outstr = "Version:" + newVersion + "|FileCount:" + newFileHash.Count + "\n";
            foreach (var hash in newFileHash)
            {
                outstr += hash.Key + "|" + hash.Value + "\n";
            }
            string outfile = System.IO.Path.Combine("./", "Version.txt");
            System.IO.File.WriteAllText(outfile, outstr, Encoding.UTF8);
        }
    }
}