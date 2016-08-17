using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class FontForm : Form
{
    public FontForm()
    {
        InitializeComponent();
    }

    private void FontForm_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.All;
        else
            e.Effect = DragDropEffects.None;
    }

    private void FontForm_DragDrop(object sender, DragEventArgs e)
    {
        string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        foreach (var path in paths)
        {
            var attr = System.IO.File.GetAttributes(path);
            if (attr == System.IO.FileAttributes.Directory)
            {
                Pack(path);
            }
            break;
        }
    }

    private void Pack(string path)
    {
        var packer = new CocosTools.Atlas.Packer();
        var paths = packer.GetImagePaths(path);
        var images = packer.GetImages(path, paths, false, 0);

        images = packer.SortImages(images);
        var root = packer.PackImages(images);
        var sprites = packer.Flatten(root);
        var img = packer.GenerateSpriteSheetImage(root);

        var dlg = new SaveFileDialog();
        dlg.Filter = "png, plist files|*png, *plist";
        dlg.ShowDialog();
        if (!string.IsNullOrEmpty(dlg.FileName))
        {
            img.Save(dlg.FileName + ".png");
            packer.GenerateFnt(sprites, dlg.FileName, System.IO.Path.GetFileName(dlg.FileName), images[0].Image.Height, img.Width, img.Height);
        }
    }
}
