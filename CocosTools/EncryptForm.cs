﻿using System;
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
        public EncryptForm()
        {
            InitializeComponent();
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
            foreach (var item in listBox1.Items)
            {
                var path = (string)item;
                var reader = System.IO.File.OpenText(path);
                var res = EncryptOrDecrypt(reader.ReadToEnd(), textBox1.Text);
                reader.Close();
                System.IO.File.WriteAllText(path, res);
            }
        }

        private string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }
    }
}
