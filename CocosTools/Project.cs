using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace CocosTools
{
    public class AtlasData
    {
        public class Offset
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public string Path { get; set; }
        public Dictionary<string, Offset> Offsets { get; set; }
        public int Padding { get; set; }
        public bool CopyBorder { get; set; }
    }

    public class Project
    {
        static public string kExt = ".ccp";
        static private string kNoname = "Noname" + kExt;
        
        public List<AtlasData> Atlas { get; set; }
        public List<Animation> Animations { get; set; }
        public string EncryptKey { get; set; }
        
        private string path = "";

        public void SetPath(string path)
        {
            this.path = path;
        }

        public Project()
        {
        }

        public bool IsClean()
        {
            return null == Atlas || Atlas.Count == 0;
        }

        public AtlasData GetAtlasDataAt(int index)
        {
            if (null == Atlas || Atlas.Count <= index || index < 0)
                return null;
            return Atlas[index];
        }

        public bool RemoveAtlasDataAt(int index)
        {
            if (null == Atlas || Atlas.Count <= index || index < 0)
                return false;
            Atlas.RemoveAt(index);
            return true;
        }

        public List<string> GetAtlasList()
        {
            var list = new List<string>();
            if (null != Atlas)
            {
                foreach (var data in Atlas)
                    list.Add(System.IO.Path.GetFileName(data.Path));
            }
            return list;
        }

        public string MakeAbsolutePath(string toPath)
        {
            var absolutePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), toPath);
            return absolutePath;
        }
        
        private string MakeRelativePath(string toPath)
        {
            if (string.IsNullOrEmpty(path))
                return toPath;

            var fromUri = new System.Uri(path);
            var toUri = new System.Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

            var relativeUri = fromUri.MakeRelativeUri(toUri);
            var relativePath = System.Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.Equals("file", System.StringComparison.InvariantCultureIgnoreCase))
                relativePath = relativePath.Replace(System.IO.Path.AltDirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar);

            return relativePath;
        }

        public string GetName()
        {
            if (string.IsNullOrEmpty(path))
                return kNoname;
            return System.IO.Path.GetFileName(path);
        }

        public string Save()
        {
            if (string.IsNullOrEmpty(path))
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = string.Format("{0} files (*{0})|*{0}", kExt);
                dlg.ShowDialog();
                path = dlg.FileName;
                if (string.IsNullOrEmpty(path))
                    return "";
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
                file.Write(json);
            }

            return path;
        }

        public void AddDirectory(string path)
        {
            if (null == Atlas)
                Atlas = new List<AtlasData>();
            var newData = new AtlasData();
            newData.Path = MakeRelativePath(path);
            foreach (var data in Atlas)
            {
                // check duplicate
                if (data.Path == newData.Path)
                    return;
            }
            Atlas.Add(newData);
        }

        public int CreateAnimation()
        {
            if (null == Animations)
                Animations = new List<Animation>();
            var ani = new CocosTools.Animation();
            Animations.Add(ani);
            return Animations.IndexOf(ani);
        }

        public Animation GetAnimationAt(int index)
        {
            if (null == Animations || Animations.Count == 0
                || Animations.Count <= index || index < 0)
                return null;
            return Animations[index];
        }

        public Animation FindAnimation(string name)
        {
            foreach (var anim in Animations)
            {
                if (name == anim.name)
                    return anim;
            }
            return null;
        }

        public bool RemoveAnimationAt(int index)
        {
            if (null == Animations || Animations.Count == 0 || index < 0)
                return false;
            Animations.RemoveAt(index);
            return true;
        }

        public void RemoveAnimation(Animation item)
        {
            Animations.Remove(item);
        }

        public void ExportAnimationsPlist()
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "plist files (*plist)|*plist";
            dlg.ShowDialog();
            var filename = dlg.FileName;
            if (string.IsNullOrEmpty(filename))
                return;

            var xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n");
            xml.Append("<plist version=\"1.0\">\n");
            xml.Append("<dict>\n");
            xml.Append("    <key>animations</key>\n");
            xml.Append("    <dict>\n");
            // animations
            foreach (var i in Animations)
            {
                xml.Append(i.ToXml("        "));
            }
            xml.Append("    </dict>\n");
            xml.Append("    <key>properties</key>\n");
            xml.Append("    <dict>\n");
            xml.Append("        <key>spritesheets</key>\n");
            xml.Append("        <array>\n");
            // spritesheets
            foreach (var i in Atlas)
            {
                xml.AppendFormat("            <string>{0}.plist</string>\n", System.IO.Path.GetFileName(i.Path));
            }
            xml.Append("        </array>\n");
            xml.Append("        <key>format</key>\n");
            xml.Append("        <integer>2</integer>\n");
            xml.Append("    </dict>\n");
            xml.Append("</dict>\n");
            xml.Append("</plist>\n");

            if (!filename.EndsWith(".plist"))
                filename = filename + ".plist";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
            {
                file.Write(xml.ToString());
            }
        }
    }
}
