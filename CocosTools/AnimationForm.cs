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
        btnPause.Enabled = false;
        btnStop.Enabled = false;
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

    private void btnPlay_Click(object sender, EventArgs e)
    {
    }

    private void btnPause_Click(object sender, EventArgs e)
    {

    }

    private void btnStop_Click(object sender, EventArgs e)
    {

    }

    // control end ---------------------------------------

    public void UpdateList()
    {
        listDir.Items.Clear();
        foreach (var dir in allDir)
            listDir.Items.Add(dir);

        listAnimation.Items.Clear();
        foreach (var anim in currentProject.Animations)
        {
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
        var ani = currentProject.GetAnimationAt(listAnimation.SelectedIndex);
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
            foreach (var file in files)
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
