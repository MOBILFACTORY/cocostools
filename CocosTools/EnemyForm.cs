using System.Drawing;
using System.Windows.Forms;

namespace CocosTools
{
    public partial class EnemyForm : Form
    {
        public EnemyForm()
        {
            InitializeComponent();
        }

        public void SetProject(Project proj)
        {
            if (null == listView.LargeImageList)
                listView.LargeImageList = new ImageList();
            
            listView.Items.Clear();
            var dirs = System.IO.Directory.GetDirectories(proj.MakeAbsolutePath("obj\\enemy"));
            foreach (var dir in dirs)
            {
                var path = proj.MakeAbsolutePath(dir + "\\0\\2\\0.png");
                if (System.IO.File.Exists(path))
                {
                    var img = new Bitmap(path);
                    listView.LargeImageList.Images.Add(path, img);
                    listView.Items.Add(new ListViewItem(System.IO.Path.GetFileName(dir), path));
                    continue;
                }

                path = proj.MakeAbsolutePath(dir + "\\0\\1\\0.png");
                if (System.IO.File.Exists(path))
                {
                    var img = new Bitmap(path);
                    listView.LargeImageList.Images.Add(path, img);
                    listView.Items.Add(new ListViewItem(System.IO.Path.GetFileName(dir), path));
                }
            }
        }
    }
}
