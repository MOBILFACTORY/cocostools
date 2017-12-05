using System.Drawing;
using System.Windows.Forms;

namespace CocosTools
{
    public partial class AllyForm : Form
    {
        public AllyForm()
        {
            InitializeComponent();
        }

        public void SetProject(Project proj)
        {
            if (null == listView.LargeImageList)
                listView.LargeImageList = new ImageList();
            
            listView.Items.Clear();
            var dirs = System.IO.Directory.GetDirectories(proj.MakeAbsolutePath("obj\\ally"));
            foreach (var dir in dirs)
            {
                var files = System.IO.Directory.GetFiles(proj.MakeAbsolutePath(dir));
                if (files.Length == 0)
                {
                    var path = proj.MakeAbsolutePath(dir + "\\0\\2\\0.png");
                    if (!System.IO.File.Exists(path))
                        continue;

                    var img = new Bitmap(path);
                    listView.LargeImageList.Images.Add(path, img);
                    listView.Items.Add(new ListViewItem(System.IO.Path.GetFileName(dir), path));
                }
                else
                {
                    foreach (var file in files)
                    {
                        var filename = System.IO.Path.GetFileName(file);
                        var path = dir + "\\" + filename;

                        var img = new Bitmap(path);
                        listView.LargeImageList.Images.Add(path, img);
                        listView.Items.Add(new ListViewItem(System.IO.Path.GetFileName(dir), path));

                        break;
                    }
                }
            }
        }
    }
}
