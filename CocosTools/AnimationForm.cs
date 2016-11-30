using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class AnimationForm : Form
{
    private CocosTools.Project currentProject = null;
    private List<string> allDir = new List<string>();

    public AnimationForm()
    {
        InitializeComponent();

        //btnMovePrev.Enabled = false;
        //btnMoveNext.Enabled = false;
        //btnDeleteFrame.Enabled = false;
        //btnCopyFrame.Enabled = false;

        btnAddAnimation.Enabled = false;
        btnRemoveAnimation.Enabled = false;
    }

    public void SetProject(CocosTools.Project proj)
    {
        if (null == proj)
            Close();
        currentProject = proj;
        UpdateList();
        //if (listAnimation.Items.Count > 0)
        //    listAnimation.SelectedIndex = 0;
    }

    public void AddImages(List<CocosTools.Atlas.ImagePair> images)
    {
        if (null == listFrames.LargeImageList)
            listFrames.LargeImageList = new ImageList();
        foreach (var img in images)
        {
            listFrames.LargeImageList.Images.Add(img.Path, img.Image);
        }
    }

    public void AddDirs(List<string> dirs)
    {
        allDir.AddRange(dirs);
    }

    //

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Control | Keys.S:
                {
                    FromForm();
                    currentProject.Save();
                    UpdateList();
                }
                break;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    //

    private void btnAddAnimation_Click(object sender, EventArgs e)
    {
        AddAnimation();
    }

    private void btnRemoveAnimation_Click(object sender, EventArgs e)
    {
        DeleteSelectedAnimation();
    }
    
    private void listDir_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAddAnimation.Enabled = listDir.SelectedItems.Count > 0;

        if (listDir.SelectedItems.Count == 0)
            return;

        txtDelay.Enabled = false;
        txtLoops.Enabled = false;
        checkBoxLoop.Enabled = false;
        checkBoxRestoreOriginalFrame.Enabled = false;

        labelName.Text = "";
        txtDelay.Text = "1.0";
        txtLoops.Text = "1";
        checkBoxLoop.Checked = false;
        checkBoxRestoreOriginalFrame.Checked = false;

        listFrames.Items.Clear();
        var dir = (string)listDir.SelectedItems[0];
        var files = System.IO.Directory.GetFiles(currentProject.MakeAbsolutePath(dir));
        foreach (var file in files)
        {
            var filename = System.IO.Path.GetFileName(file);
            var path = dir + "/" + filename;
            listFrames.Items.Add(new ListViewItem(path, path));
        }
    }

    private void listAnimation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ToForm();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        currentProject.ExportAnimationsPlist();
    }

    private void listFrames_SelectedIndexChanged(object sender, EventArgs e)
    {
        //currentList = listFrames;
        //if (listFrames.SelectedIndices.Count == 1)
        //{
        //    var idx = listFrames.SelectedIndices[0];
        //}
    }

    private void txtDelay_TextChanged(object sender, EventArgs e)
    {
        if (txtDelay.Enabled)
            FromForm();
    }

    private void txtLoops_TextChanged(object sender, EventArgs e)
    {
        if (txtLoops.Enabled)
            FromForm();
    }

    private void checkBoxLoop_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxLoop.Enabled)
            FromForm();
    }

    private void checkBoxRestoreOriginalFrame_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxRestoreOriginalFrame.Enabled)
            FromForm();
    }

    // control end ---------------------------------------

    public void UpdateList()
    {
        listDir.Items.Clear();
        foreach (var dir in allDir)
        {
            if (!dir.Contains(txtFilter.Text))
                continue;

            listDir.Items.Add(dir);
        }

        listAnimation.Items.Clear();
        foreach (var anim in currentProject.Animations)
        {
            if (!anim.name.Contains(txtFilter.Text))
                continue;

            listAnimation.Items.Add(anim);
            listDir.Items.Remove(anim.name);
        }
    }

    private void FromForm()
    {
        if (listAnimation.SelectedItems.Count == 0)
            return;

        foreach (var item in listAnimation.SelectedItems)
        {
            //var ani = currentProject.GetAnimationAt(listAnimation.SelectedIndex);
            var ani = (CocosTools.Animation)item;
            if (null == ani)
                return;

            //ani.name = labelName.Text;
            float delay = 0.0f;
            if (float.TryParse(txtDelay.Text, out delay))
                ani.DelayPerUnit = delay;
            else
                txtDelay.Text = ani.DelayPerUnit.ToString();
            ani.RestoreOriginalFrame = checkBoxRestoreOriginalFrame.Checked;

            if (checkBoxLoop.Checked)
            {
                ani.Loops = int.MaxValue;
                txtLoops.Text = ani.Loops.ToString();
            }
            else
            {
                int loops = 1;
                if (int.TryParse(txtLoops.Text, out loops))
                    ani.Loops = loops;
                else
                    txtLoops.Text = ani.Loops.ToString();
            }
        }
    }

    private void ToForm()
    {
        txtDelay.Enabled = false;
        txtLoops.Enabled = false;
        checkBoxLoop.Enabled = false;
        checkBoxRestoreOriginalFrame.Enabled = false;

        label1.Focus();
        checkBoxLoop.Checked = false;

        if (listAnimation.SelectedItems.Count == 0)
            return;

        var item = listAnimation.SelectedItems[0];
        var ani = currentProject.FindAnimation(item.ToString());
        if (null == ani)
        {
            labelName.Text = "";
            txtDelay.Text = "1.0";
            txtLoops.Text = "1";
            checkBoxLoop.Checked = false;
            checkBoxRestoreOriginalFrame.Checked = false;
            return;
        }

        labelName.Text = ani.name;
        if (ani.DelayPerUnit == 0f)
            ani.DelayPerUnit = 1f;
        txtDelay.Text = ani.DelayPerUnit.ToString();
        checkBoxRestoreOriginalFrame.Checked = ani.RestoreOriginalFrame;
        if (ani.Loops == 0)
            ani.Loops = 1;
        txtLoops.Text = ani.Loops.ToString();
        btnAddAnimation.Enabled = listDir.SelectedItems.Count > 0;
        btnRemoveAnimation.Enabled = listAnimation.SelectedItems.Count > 0;

        listFrames.Items.Clear();
        if (null != ani.Frames)
        {
            foreach (var frame in ani.Frames)
            {
                listFrames.Items.Add(new ListViewItem(frame, frame));
            }
        }
        
        txtDelay.Enabled = true;
        txtLoops.Enabled = true;
        checkBoxLoop.Enabled = true;
        checkBoxRestoreOriginalFrame.Enabled = true;
    }

    private void AddAnimation()
    {
        if (listDir.SelectedItems.Count == 0)
            return;

        foreach (var item in listDir.SelectedItems)
        {
            var name = (string)item;
            var idx = currentProject.CreateAnimation();
            var ani = currentProject.GetAnimationAt(idx);
            if (null == ani)
                return;

            ani.name = name;

            var files = System.IO.Directory.GetFiles(currentProject.MakeAbsolutePath(name));
            var filesList = new List<string>(files);
            filesList.Sort((a, b) => {
                var aname = System.IO.Path.GetFileNameWithoutExtension(a);
                var anum = int.Parse(aname);
                var bname = System.IO.Path.GetFileNameWithoutExtension(b);
                var bnum = int.Parse(bname);
                return anum.CompareTo(bnum);
            });
            foreach (var file in filesList)
            {
                var filename = System.IO.Path.GetFileName(file);
                ani.Frames.Add(name + "/" + filename);
            }

            listAnimation.Items.Add(name);
        }
        UpdateList();
    }

    private void DeleteSelectedAnimation()
    {
        foreach (var item in listAnimation.SelectedItems)
            currentProject.RemoveAnimation((CocosTools.Animation)item);

        UpdateList();
        ToForm();
    }

    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
        UpdateList();
    }

    private void btnMovePrev_Click(object sender, EventArgs e)
    {
        if (listFrames.SelectedIndices.Count != 1)
            return;

        int idx = listFrames.SelectedIndices[0];
        if (idx == 0)
            return;

        var item = listAnimation.SelectedItems[0];
        var ani = currentProject.FindAnimation(item.ToString());
        if (null == ani)
            return;

        var selected = ani.Frames[idx];
        ani.Frames.RemoveAt(idx);
        ani.Frames.Insert(idx - 1, selected);

        ToForm();
    }

    private void btnMoveNext_Click(object sender, EventArgs e)
    {
        if (listFrames.SelectedIndices.Count != 1)
            return;

        int idx = listFrames.SelectedIndices[0];
        if (idx == listFrames.Items.Count - 1)
            return;

        var item = listAnimation.SelectedItems[0];
        var ani = currentProject.FindAnimation(item.ToString());
        if (null == ani)
            return;

        var selected = ani.Frames[idx];
        ani.Frames.RemoveAt(idx);
        ani.Frames.Insert(idx + 1, selected);

        ToForm();
    }

    private void btnCopyFrame_Click(object sender, EventArgs e)
    {
        if (listFrames.SelectedIndices.Count != 1)
            return;

        int idx = listFrames.SelectedIndices[0];
        var item = listAnimation.SelectedItems[0];
        var ani = currentProject.FindAnimation(item.ToString());
        if (null == ani)
            return;

        var selected = ani.Frames[idx];
        ani.Frames.Insert(idx + 1, selected);

        ToForm();
    }

    private void btnDeleteFrame_Click(object sender, EventArgs e)
    {
        if (listFrames.SelectedIndices.Count != 1)
            return;

        int idx = listFrames.SelectedIndices[0];
        var item = listAnimation.SelectedItems[0];
        var ani = currentProject.FindAnimation(item.ToString());
        if (null == ani)
            return;
        
        ani.Frames.RemoveAt(idx);

        ToForm();
    }

    //private void DeleteSelectedFrame()
    //{
    //    var ani = currentProject.GetAnimationAt(listAnimation.SelectedIndex);
    //    if (null == ani || null == ani.Frames || 0 == ani.Frames.Count)
    //        return;
    //    if (listFrames.SelectedIndices.Count == 1)
    //    {
    //        ani.Frames.RemoveAt(listFrames.SelectedIndices[0]);
    //        ToForm();
    //    }
    //}
}
