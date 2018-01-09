using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CocosTools
{
    public partial class EncryptForm : Form
    {
        private Project currentProject;

        public EncryptForm()
        {
            InitializeComponent();

            button1.Enabled = false;
        }

        public void SetProject(Project proj)
        {
            if (null == proj)
                Close();

            currentProject = proj;

            if (currentProject.EncryptKey != null)
                textBox1.Text = currentProject.EncryptKey;
        }

        private void EncryptForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void EncryptForm_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Clear();
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var path in paths)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                var attr = System.IO.File.GetAttributes(path);
                if (attr == System.IO.FileAttributes.Directory)
                {
                    var list = new List<string>();
                    var files = System.IO.Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        listBox1.Items.Add(file);
                    }
                }
                else
                {
                    listBox1.Items.Add(path);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentProject.EncryptKey = textBox1.Text;

            foreach (var item in listBox1.Items)
            {
                var path = (string)item;
                var dir = System.IO.Path.GetDirectoryName(path);
                var idx = dir.LastIndexOf("\\");
                var newpath = dir.Substring(0, idx + 1);
                var oldname = dir.Substring(idx + 1);
                var filename = System.IO.Path.GetFileName(path);
                newpath += "encrypt_" + oldname;
                var reader = System.IO.File.OpenText(path);
                var res = EncryptOrDecrypt(reader.ReadToEnd(), textBox1.Text);
                reader.Close();
                
                if (!System.IO.Directory.Exists(newpath))
                    System.IO.Directory.CreateDirectory(newpath);

                System.IO.File.WriteAllText(System.IO.Path.Combine(newpath, filename), res);
            }
        }

        private string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentProject.EncryptKey = textBox1.Text;

            var dlg = new SaveFileDialog();
            dlg.Filter = "dat files (*dat)|*dat";
            dlg.ShowDialog();
            var savefile = dlg.FileName;
            if (string.IsNullOrEmpty(savefile))
                return;

            if (!System.IO.Path.HasExtension(savefile))
                savefile += ".dat";

            //var savefile = "test.dat";
            System.IO.FileStream fs = new System.IO.FileStream(savefile, System.IO.FileMode.Create);
            foreach (var item in listBox1.Items)
            {
                var path = (string)item;
                var ext = System.IO.Path.GetExtension(path);
                if (ext == ".png")
                    continue;

                var dir = System.IO.Path.GetDirectoryName(path);
                var idx = dir.LastIndexOf("\\");
                var filename = path.Substring(idx + 1);
                filename = filename.Replace("\\", "/");
                
                Byte[] nameBytes = System.Text.Encoding.UTF8.GetBytes(EncryptOrDecrypt(filename, currentProject.EncryptKey));
                Byte[] nameLenBytes = BitConverter.GetBytes(nameBytes.Length);
                fs.Write(nameLenBytes, 0, nameLenBytes.Length);
                fs.Write(nameBytes, 0, nameBytes.Length);

                var itemReader = System.IO.File.OpenText(path);
                var itemStr = itemReader.ReadToEnd();
                itemStr += "\r\n";
                itemReader.Close();

                Byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(EncryptOrDecrypt(itemStr, currentProject.EncryptKey));
                Byte[] strLenBytes = BitConverter.GetBytes(strBytes.Length);
                fs.Write(strLenBytes, 0, strLenBytes.Length);
                fs.Write(strBytes, 0, strBytes.Length);

                // test
                //fs.Position = 0;
                //Byte[] readIntBytes = new Byte[4];
                //fs.Read(readIntBytes, 0, 4);
                //int readInt = BitConverter.ToInt16(readIntBytes, 0);
                //Byte[] readStrBytes = new Byte[readInt];
                //fs.Read(readStrBytes, 0, readInt);
                //string readStr = System.Text.Encoding.UTF8.GetString(readStrBytes);
                //Console.WriteLine(readStr);
                
                //Byte[] readIntBytes2 = new Byte[4];
                //fs.Read(readIntBytes2, 0, 4);
                //int readInt2 = BitConverter.ToInt16(readIntBytes2, 0);
                //Byte[] readStrBytes2 = new Byte[readInt2];
                //fs.Read(readStrBytes2, 0, readInt2);
                //string readStr2 = System.Text.Encoding.UTF8.GetString(readStrBytes2);
                //Console.WriteLine(readStr2);
            }
            fs.Close();
            MessageBox.Show("complete");
        }
    }
}
