using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class AnimationForm : Form
{
    private CocosTools.Project currentProject = null;
    private Control currentList = null;
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
            //case Keys.Delete:
            //    {
            //        if (null != currentList)
            //        {
            //            if (currentList == listAnimation)
            //                DeleteSelectedAnimation();
            //            else if (currentList == listFrames)
            //                DeleteSelectedFrame();
            //        }
            //    }
            //    break;
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

    private void listAnimation_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentList = listAnimation;
        ToForm();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        currentProject.ExportAnimationsPlist();
    }

    private void listFrames_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentList = listFrames;
        if (listFrames.SelectedIndices.Count == 1)
        {
            var idx = listFrames.SelectedIndices[0];
        }
    }

    private void listDir_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAddAnimation.Enabled = listDir.SelectedItem != null;
    }

    private void txtDelay_TextChanged(object sender, EventArgs e)
    {
    }

    private void numericLoops_ValueChanged(object sender, EventArgs e)
    {
    }

    private void checkBoxRestoreOriginalFrame_CheckedChanged(object sender, EventArgs e)
    {
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
        var list = currentProject.GetAnimationList();
        foreach (var name in list)
        {
            listAnimation.Items.Add(name);
            listDir.Items.Remove(name);
        }
    }

    private void FromForm()
    {
        var ani = currentProject.GetAnimationAt(listAnimation.SelectedIndex);
        if (null == ani)
            return;
        ani.name = labelName.Text;
        float delay = 0.0f;
        if (float.TryParse(txtDelay.Text, out delay))
            ani.DelayPerUnit = delay;
        else
            txtDelay.Text = ani.DelayPerUnit.ToString();
        ani.RestoreOriginalFrame = checkBoxRestoreOriginalFrame.Checked;
        ani.Loops = (int)numericLoops.Value;
    }

    private void ToForm()
    {
        var ani = currentProject.GetAnimationAt(listAnimation.SelectedIndex);
        if (null == ani)
        {
            labelName.Text = "";
            txtDelay.Text = "1.0";
            checkBoxRestoreOriginalFrame.Checked = false;
            numericLoops.Value = 1;
            return;
        }
        labelName.Text = ani.name;
        if (ani.DelayPerUnit == 0f)
            ani.DelayPerUnit = 1f;
        txtDelay.Text = ani.DelayPerUnit.ToString();
        checkBoxRestoreOriginalFrame.Checked = ani.RestoreOriginalFrame;
        if (ani.Loops == 0)
            ani.Loops = 1;
        numericLoops.Value = ani.Loops;

        btnAddAnimation.Enabled = listDir.SelectedItem != null;
        btnRemoveAnimation.Enabled = listAnimation.SelectedItem != null;

        listFrames.Items.Clear();
        if (null != ani.Frames)
        {
            foreach (var frame in ani.Frames)
            {
                listFrames.Items.Add(new ListViewItem(frame, frame));
            }
        }
    }

    private void AddAnimation()
    {
        if (listDir.SelectedItem == null)
            return;

        var name = (string)listDir.SelectedItem;
        var idx = currentProject.AddAnimation();
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
        UpdateList();
        listAnimation.SelectedIndex = idx;
    }

    private void DeleteSelectedAnimation()
    {
        if (currentProject.RemoveAnimationAt(listAnimation.SelectedIndex))
        {
            UpdateList();
            ToForm();
        }
    }

    private void DeleteSelectedFrame()
    {
        var ani = currentProject.GetAnimationAt(listAnimation.SelectedIndex);
        if (null == ani || null == ani.Frames || 0 == ani.Frames.Count)
            return;
        if (listFrames.SelectedIndices.Count == 1)
        {
            ani.Frames.RemoveAt(listFrames.SelectedIndices[0]);
            ToForm();
        }
    }
}
