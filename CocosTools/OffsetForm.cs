using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CocosTools
{
    public partial class OffsetForm : Form
    {
        private Project currentProject;

        public OffsetForm()
        {
            InitializeComponent();
        }

        public void SetProject(Project proj)
        {
            if (null == proj)
                Close();

            currentProject = proj;
        }

        private void ImgForm1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ImgForm1_DragDrop(object sender, DragEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            foreach (var item in listBox1.Items)
            {
                var path = (string)item;
                var ext = System.IO.Path.GetExtension(path);
                if (ext != ".plist")
                    continue;

                XDocument doc = XDocument.Load(path);
                XElement plist = doc.Element("plist");
                XElement dict = plist.Element("dict");
                XElement frames = dict.Element("dict");

                var framesElements = frames.Elements();
                for (int i = 0; i < framesElements.Count(); i += 2)
                {
                    XElement frameKey = framesElements.ElementAt(i);
                    var frameDict = framesElements.ElementAt(i + 1).Elements();
                    for (int j = 0; j < frameDict.Count(); j += 2)
                    {
                        XElement key = frameDict.ElementAt(j);
                        if (key.Value != "spriteOffset")
                            continue;

                        XElement value = frameDict.ElementAt(j + 1);

                        string innerText = "{0,0}";
                        foreach (var atlas in currentProject.Atlas)
                        {
                            if (atlas.Offsets == null)
                                continue;

                            foreach (var pair in atlas.Offsets)
                            {
                                if (pair.Key == frameKey.Value)
                                {
                                    innerText = "{" + pair.Value.X.ToString() + "," + pair.Value.Y.ToString() + "}";
                                }
                            }
                        }
                        value.SetValue(innerText);
                    }
                }

                doc.Save(path);
                MessageBox.Show("complete");
            }
        }
    }
}
