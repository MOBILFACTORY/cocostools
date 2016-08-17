using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CocosTools.Atlas
{
    class Packer
    {
        public List<string> GetImagePaths(string rootpath, string path = null)
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(path))
                path = rootpath;
            var dirs = System.IO.Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                list.AddRange(GetImagePaths(rootpath, dir));
            }
            var files = System.IO.Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (!file.EndsWith(".png"))
                    continue;
                list.Add(file);
            }
            return list;
        }

        public List<ImagePair> GetImages(string rootpath, List<string> paths, bool copyBorder, int padding)
        {
            var images = new List<ImagePair>();
            foreach (var file in paths)
            {
                if (!file.EndsWith(".png"))
                    continue;
                
                var pad = padding;
                if (copyBorder)
                    pad += 1;

                var len = System.IO.Path.GetFileName(rootpath).Length;
                var basepath = rootpath.Substring(0, rootpath.Length - len);

                // TODO PADDING
                var img = new Bitmap(file);
                var copy = new Bitmap(img.Width + (pad * 2), img.Height + (pad * 2));
                var gr = Graphics.FromImage(copy);
                gr.DrawImage(img, pad, pad);
                if (copyBorder)
                    CopyBorder(copy, pad);
                images.Add(new ImagePair(file.Substring(basepath.Length).Replace('\\', '/'), copy));
            }
            return images;
        }

        private void CopyBorder(Bitmap img, int pad)
        {
            int x, y;

            // top
            for (x = pad; x < img.Width - pad; ++x)
            {
                var color = img.GetPixel(x, pad);
                img.SetPixel(x, pad - 1, color);
            }

            // left
            for (y = pad; y < img.Height - pad; ++y)
            {
                var color = img.GetPixel(pad, y);
                img.SetPixel(pad - 1, y, color);
            }

            // right
            for (y = pad; y < img.Height - pad; ++y)
            {
                var color = img.GetPixel(img.Width - pad - 1, y);
                img.SetPixel(img.Width - pad, y, color);
            }

            // bottom
            for (x = pad; x < img.Width - pad; ++x)
            {
                var color = img.GetPixel(x, img.Height - pad - 1);
                img.SetPixel(x, img.Height - pad, color);
            }
        }

        public List<ImagePair> SortImages(List<ImagePair> images)
        {
            // sort by area
            images.Sort((a, b) => {
                return (b.Image.Width * b.Image.Height).CompareTo((a.Image.Width * a.Image.Height));
            });
            // sort by max dimension
            images.Sort((a, b) => {
                return Math.Max(b.Image.Width, b.Image.Height).CompareTo(Math.Max(a.Image.Width, a.Image.Height));
            });
            return images;
        }

        private Sprite FindEmptyLeaf(Sprite node, Bitmap image)
        {
            var imageW = image.Width;
            var imageH = image.Height;
            if (node.IsEmptyLeaf())
            {
                if (node.Rect.CanContain(imageW, imageH))
                    return node;
                else
                    return null;
            }
            else
            {
                if (node.IsLeaf())
                    return null;
                var leaf = FindEmptyLeaf(node.Children[0], image);
                if (leaf != null)
                    return leaf;
                else
                    return FindEmptyLeaf(node.Children[1], image);
            }
        }

        public Sprite PackImages(List<ImagePair> images)
        {
            var root = new Sprite(null, new Rect(0, 0, images[0].Image.Width, images[0].Image.Height));
            for (int i = 0; i < images.Count; ++i)
            {
                var imagePair = images[i];
                var leaf = FindEmptyLeaf(root, imagePair.Image);
                if (leaf != null)
                    leaf.SplitNode(imagePair);
                else
                    root.GrowNode(imagePair);
            }
            return root;
        }

        private int NearestPowerOfTwo(int n)
        {
            var log2 = Math.Log(n) / Math.Log(2);
            return (int)Math.Pow(2, (Math.Ceiling(log2)));
        }

        public List<Sprite> Flatten(Sprite node)
        {
            var nodes = new List<Sprite>();
            if (node.IsLeaf())
            {
                if (null != node.Image)
                    nodes.Add(node);
                return nodes;
            }
            else
            {
                var left = Flatten(node.Children[0]);
                var right = Flatten(node.Children[1]);
                left.AddRange(right);
                return left;
            }
        }

        public string GetPlistHead()
        {
            var xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
            xml.Append("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n");
            xml.Append("<plist version=\"1.0\">\n<dict>\n    <key>frames</key>\n    <dict>\n");
            return xml.ToString();
        }

        public string GetPlistTail(int size)
        {
            var xml = new StringBuilder();
            xml.Append("    </dict>\n    <key>metadata</key>\n    <dict>\n");
            xml.Append("        <key>format</key>\n");
            xml.Append("        <integer>2</integer>\n");
            xml.Append("        <key>size</key>\n");
            xml.AppendFormat("        <string>{{{0},{0}}}</string>\n", size);
            xml.Append("    </dict>\n</dict>\n</plist>\n");
            return xml.ToString();
        }

        public Bitmap GenerateSpriteSheetImage(Sprite root)
        {
            var size = NearestPowerOfTwo(Math.Max(root.Rect.w, root.Rect.h));
            var sprite_sheet = new Bitmap(size, size);
            var gr = Graphics.FromImage(sprite_sheet);
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            root.Render(gr);
            //sprite_sheet.save(image_filename, 'PNG')
            //pictureBox1.Image = sprite_sheet;
            //sprite_sheet.Save("test.png");
            return sprite_sheet;
        }

        public void GenerateSpriteSheetPlist(List<Sprite> sprites, string path)
        {
            if (null == sprites)
                return;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + ".plist"))
            {
                file.Write(GetPlistHead());
                foreach (var sprite in sprites)
                {
                    file.Write(sprite.ToXml());
                }
                file.Write(GetPlistTail(256));
            }
        }

        /*
         * 
         * f = open('_output/' + filename + '.fnt','w')
    f.write('info face="%s" size=%s bold=0 italic=0 charset="" unicode=0 stretchH=100 smooth=1 aa=1 padding=0,0,0,0 spacing=1,1\n' % (filename, fontsize))
    f.write('common lineHeight=%d base=28 scaleW=%d scaleH=%d pages=1 packed=0\n' % (line_height, sheet_size, sheet_size))
    f.write('page id=0 file="%s.png"\n' % (filename))
    f.write('chars count=%d\n' % (len(chars)))
    for c in chars:
        f.write(c.to_str())
    f.write('kernings count=-1')
         * */
        public void GenerateFnt(List<Sprite> sprites, string path, string filename, int fontsize, int sheetWidth, int sheetHeight)
        {
            if (null == sprites)
                return;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + ".fnt"))
            {
                var sb = new StringBuilder();
                sb.AppendFormat("info face=\"{0}\" size={1} bold=0 italic=0 charset=\"\" unicode=0 stretchH=100 smooth=1 aa=1 padding=0,0,0,0 spacing=1,1\n", filename, fontsize);
                sb.AppendFormat("common lineHeight={0} base=28 scaleW={1} scaleH={2} pages=1 packed=0\n", fontsize, sheetWidth, sheetHeight);
                sb.AppendFormat("page id=0 file=\"{0}.png\"\n", filename);
                sb.AppendFormat("chars count={0}\n", sprites.Count);
                file.Write(sb.ToString());
                foreach (var sprite in sprites)
                {
                    file.Write(sprite.ToChar());
                }
                file.Write("kernings count=-1");
            }
        }
    }
}
