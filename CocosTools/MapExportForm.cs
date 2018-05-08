using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace CocosTools
{
    public partial class MapExportForm : Form
    {
        public MapExportForm()
        {
            InitializeComponent();
        }

        private void MapExportForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MapExportForm_DragDrop(object sender, DragEventArgs e)
        {
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
                        ParseXml(file);
                    }
                }
                else
                {
                    ParseXml(path);
                }
            }
        }

        private void ParseXml(string path)
        {
            string filename = System.IO.Path.GetFileNameWithoutExtension(path);
            if (!filename.StartsWith("battle"))
                return;

            var filenamesplit = filename.Split('_');

            int stage;
            if (!int.TryParse(filenamesplit[1], out stage))
                return;

            int num;
            if (!int.TryParse(filenamesplit[2], out num))
            {
                if (filenamesplit.Length <= 3)
                    return;

                if (!int.TryParse(filenamesplit[3], out num))
                    return;
            }

            int monsterCount = 0;
            int boxCount = 0;

            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList objectgroupList = xml.SelectNodes("/map/objectgroup");
            foreach (XmlNode xn in objectgroupList)
            {
                if (xn.Attributes["name"].InnerText == "object")
                {
                    foreach (XmlNode cn in xn.ChildNodes)
                    {
                        if (cn.Attributes["type"] == null)
                            continue;
                        //textBox1.AppendText("");
                        if (cn.Attributes["type"].InnerText == "3")
                            monsterCount++;
                        else if (cn.Attributes["type"].InnerText == "5")
                            boxCount++;
                    }
                }
            }

            textBox1.AppendText(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\n", filename, stage, num, monsterCount, boxCount));
        }
    }
}
