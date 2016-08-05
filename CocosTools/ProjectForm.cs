using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public partial class CocosToolsForm : Form
{
    private CocosTools.Project currentProject = null;
    private CocosTools.Atlas.Packer packer = new CocosTools.Atlas.Packer();
    private List<CocosTools.Atlas.Sprite> sprites;
    private CocosTools.Atlas.Sprite selectedSprite;

    public CocosToolsForm()
    {
        InitializeComponent();

        var path = GetLastProject();
        if (string.IsNullOrEmpty(path))
            NewProject();
        else
            OpenProject(path);
    }

    private string GetConfigPath()
    {
        var appDataPath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CocosTools");
        if (!System.IO.Directory.Exists(appDataPath))
            System.IO.Directory.CreateDirectory(appDataPath);
        return System.IO.Path.Combine(appDataPath, "config");
    }

    private string GetLastProject()
    {
        var path = GetConfigPath();
        if (!System.IO.File.Exists(path))
            return null;
        var filepath = System.IO.File.ReadAllText(path);
        if (!System.IO.File.Exists(filepath))
            return null;
        return filepath;
    }

    private void SaveLastProject(string path)
    {
        System.IO.File.WriteAllText(GetConfigPath(), path);
    }

    private bool SaveConfirm(string title)
    {
        if (null != currentProject
            && !currentProject.IsClean())
        {
            var confirmResult = MessageBox.Show("Save " + currentProject.GetName() + "?", title, MessageBoxButtons.YesNoCancel);
            if (confirmResult == System.Windows.Forms.DialogResult.Yes)
                SaveProject();
            else if (confirmResult == System.Windows.Forms.DialogResult.Cancel)
                return false;
        }
        return true;
    }

    private void NewProject()
    {
        if (!SaveConfirm("New"))
            return;

        currentProject = new CocosTools.Project();
        imgAtlas.Image = null;
        picktureBoxCenter();
        sprites = null;
        selectedSprite = null;
        UpdateAll();
    }

    private void OpenProject(string filepath)
    {
        if (!SaveConfirm("Open"))
            return;
        
        var json = System.IO.File.ReadAllText(filepath);
        currentProject = Newtonsoft.Json.JsonConvert.DeserializeObject<CocosTools.Project>(json);
        currentProject.SetPath(filepath);
        imgAtlas.Image = null;
        picktureBoxCenter();
        sprites = null;
        selectedSprite = null;
        UpdateAll();
    }

    private void SaveProject()
    {
        if (null == currentProject)
            return;

        SaveLastProject(currentProject.Save());
        Text = currentProject.GetName();
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.All;
        else
            e.Effect = DragDropEffects.None;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        if (null == currentProject)
            return;

        string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        foreach (var path in paths)
        {
            var attr = System.IO.File.GetAttributes(path);
            var ext = System.IO.Path.GetExtension(path);
            if (attr == System.IO.FileAttributes.Directory)
            {
                currentProject.AddDirectory(path);
                UpdateAll();
            }
            else if (ext == CocosTools.Project.kExt)
            {
                OpenProject(path);
                break;
            }
        }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (null == currentProject)
            return;
        selectedSprite = null;
        if (null != sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite.Rect.x < e.Location.X && sprite.Rect.x + sprite.Rect.w > e.Location.X
                    && sprite.Rect.y < e.Location.Y && sprite.Rect.y + sprite.Rect.h > e.Location.Y)
                {
                    selectedSprite = sprite;
                    labelSprite.Text = sprite.ImageName;
                    ShowSelectedSprite();
                    break;
                }
            }
        }
    }

    private void ShowSelectedSprite()
    {
        if (null == selectedSprite)
            return;
        var offset = new CocosTools.AtlasData.Offset();
        var data = currentProject.GetAtlasDataAt(listAtlas.SelectedIndex);
        if (null != data && null != data.Offsets && data.Offsets.ContainsKey(selectedSprite.ImageName))
        {
            offset = data.Offsets[selectedSprite.ImageName];
            numOffsetX.Value = offset.X;
            numOffsetY.Value = offset.Y;
        }
        else
        {
            numOffsetX.Value = 0;
            numOffsetY.Value = 0;
        }
        label1.Focus();

        var copy = new Bitmap(selectedSprite.Image);
        var gr = Graphics.FromImage(copy);
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        var x = (float)((selectedSprite.Image.Width / 2) + offset.X - (imgAnchor.Image.Width / 2));
        var y = (float)((selectedSprite.Image.Height / 2) + offset.Y - (imgAnchor.Image.Height / 2));
        gr.DrawImage(imgAnchor.Image, x - 1, y - 1);
        imgSprite.Image = copy;
    }

    private void picktureBoxCenter()
    {
        imgAtlas.Location = new Point(
            splitContainer1.Panel1.Width / 2 - imgAtlas.Width / 2 + tableAtlasList.Width / 2, 
            splitContainer1.Panel1.Height / 2 - imgAtlas.Height / 2);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (null == currentProject || null == sprites)
            return;
        var dlg = new SaveFileDialog();
        dlg.Filter = "png, plist files|*png, *plist";
        dlg.ShowDialog();
        if (!string.IsNullOrEmpty(dlg.FileName))
        {
            imgAtlas.Image.Save(dlg.FileName + ".png");

            // set offset
            foreach (var sprite in sprites)
            {
                foreach (var atlas in currentProject.Atlas)
                {
                    if (atlas.Offsets != null && atlas.Offsets.ContainsKey(sprite.ImageName))
                    {
                        var offset = atlas.Offsets[sprite.ImageName];
                        sprite.OffsetX = offset.X;
                        sprite.OffsetY = offset.Y;
                        break;
                    }
                }
            }

            packer.GenerateSpriteSheetPlist(sprites, dlg.FileName);
        }
    }

    private void offsetX_ValueChanged(object sender, EventArgs e)
    {
        if (null != selectedSprite)
        {
            selectedSprite.OffsetX = (int)numOffsetX.Value;
            SetOffset();
            ShowSelectedSprite();
        }
    }

    private void offsetY_ValueChanged(object sender, EventArgs e)
    {
        if (null != selectedSprite)
        {
            selectedSprite.OffsetY = (int)numOffsetY.Value;
            SetOffset();
            ShowSelectedSprite();
        }
    }

    private void SetOffset()
    {
        if (null == packer || null == currentProject || null == selectedSprite)
            return;
        var data = currentProject.GetAtlasDataAt(listAtlas.SelectedIndex);
        if (null == data)
            return;
        if (null == data.Offsets)
            data.Offsets = new Dictionary<string, CocosTools.AtlasData.Offset>();
        if (!data.Offsets.ContainsKey(selectedSprite.ImageName))
            data.Offsets.Add(selectedSprite.ImageName, new CocosTools.AtlasData.Offset());
        data.Offsets[selectedSprite.ImageName].X = (int)numOffsetX.Value;
        data.Offsets[selectedSprite.ImageName].Y = (int)numOffsetY.Value;

        if (numOffsetX.Value == 0 && numOffsetY.Value == 0)
            data.Offsets.Remove(selectedSprite.ImageName);
    }

    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
    {
        picktureBoxCenter();
    }

    private void btnAtlasAdd_Click(object sender, EventArgs e)
    {
        var dlg = new FolderBrowserDialog();
        dlg.Description = "Select or Drag & Drop Folder";
        dlg.ShowDialog();
        Console.WriteLine(dlg.SelectedPath);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Control | Keys.N:
                {
                    NewProject();
                    SaveLastProject(currentProject.Save());
                }
                break;
            case Keys.Control | Keys.S:
                {
                    SaveProject();
                }
                break;
            case Keys.Delete:
                {
                    DeleteSelectedAtlas();
                }
                break;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void UpdateAll()
    {
        if (null != currentProject)
            Text = currentProject.GetName();

        listAtlas.Items.Clear();
        if (null != currentProject)
        {
            var list = currentProject.GetAtlasList();
            foreach (var i in list)
                listAtlas.Items.Add(i);
        }

        if (null == selectedSprite)
        {
            labelSprite.Text = "";
            numOffsetX.Value = 0;
            numOffsetY.Value = 0;
            imgSprite.Image = null;
        }
    }

    private void listAtlas_SelectedIndexChanged(object sender, EventArgs e)
    {
        MakeAtlas();
    }

    private void MakeAtlas()
    {
        if (null == currentProject)
            return;
        var data = currentProject.GetAtlasDataAt(listAtlas.SelectedIndex);
        if (null == data)
            return;
        var rootpath = currentProject.MakeAbsolutePath(data.Path);
        var paths = packer.GetImagePaths(rootpath);
        var images = packer.GetImages(rootpath, paths, data.CopyBorder, data.Padding);
        images = packer.SortImages(images);
        var root = packer.PackImages(images);
        sprites = packer.Flatten(root);
        imgAtlas.Image = packer.GenerateSpriteSheetImage(root);
        //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        imgAtlas.Width = imgAtlas.Image.Width;
        imgAtlas.Height = imgAtlas.Image.Height;
        picktureBoxCenter();
        selectedSprite = null;

        numPadding.Value = data.Padding;
        checkBoxCopyBorder.Checked = data.CopyBorder;
    }

    private void DeleteSelectedAtlas()
    {
        if (null == currentProject)
            return;
        currentProject.RemoveAtlasDataAt(listAtlas.SelectedIndex);
        listAtlas.ClearSelected();
        UpdateAll();
    }

    private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        NewProject();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog();
        dlg.Filter = string.Format("{0} files (*{0})|*{0}", CocosTools.Project.kExt);
        dlg.ShowDialog();
        if (string.IsNullOrEmpty(dlg.FileName))
            return;
        OpenProject(dlg.FileName);
    }

    private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        SaveProject();
    }

    private void numPadding_ValueChanged(object sender, EventArgs e)
    {
        if (null == packer || null == currentProject)
            return;
        var data = currentProject.GetAtlasDataAt(listAtlas.SelectedIndex);
        if (null == data)
            return;
        data.Padding = (int)numPadding.Value;
        MakeAtlas();
    }

    private void checkBoxCopyBorder_CheckedChanged(object sender, EventArgs e)
    {
        if (null == packer || null == currentProject)
            return;
        var data = currentProject.GetAtlasDataAt(listAtlas.SelectedIndex);
        if (null == data)
            return;
        data.CopyBorder = checkBoxCopyBorder.Checked;
        MakeAtlas();
    }

    private void atlasListToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new AnimationForm();
        form.Show();
        form.SetProject(currentProject);
        for (var i = 0; i < listAtlas.Items.Count; ++i)
        {
            var atlas = currentProject.GetAtlasDataAt(i);
            if (null == atlas)
                return;
            var rootpath = currentProject.MakeAbsolutePath(atlas.Path);
            var paths = packer.GetImagePaths(rootpath);
            var images = packer.GetImages(rootpath, paths, false, 0);

            form.AddImages(images);

            var dirs = getLastDirs(rootpath, rootpath);
            form.AddDirs(dirs);
        }
        form.UpdateList();
    }

    private List<string> getLastDirs(string path, string rootpath)
    {
        var list = new List<string>();
        var dirs = System.IO.Directory.GetDirectories(path);
        if (dirs.Length > 0)
        {
            foreach (var dir in dirs)
            {
                list.AddRange(getLastDirs(dir, rootpath));
            }
        }
        else
        {
            var len = System.IO.Path.GetFileName(rootpath).Length;
            var basepath = path.Substring(rootpath.Length - len);
            basepath = basepath.Replace("\\", "/");
            list.Add(basepath);
        }
        return list;
    }
}
