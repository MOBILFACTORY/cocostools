using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocosTools.Atlas
{
    public class ImagePair
    {
        public ImagePair(string path, Bitmap image)
        {
            this.Path = path;
            this.Image = image;
        }

        public string Path { get; set; }
        public Bitmap Image { get; set; }
    }

    public class Rect
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }

        public Rect(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        public Rect Clone()
        {
            return new Rect(this.x, this.y, this.w, this.h);
        }

        public List<Rect> SplitVertical(int y)
        {
            var rects = new List<Rect>();
            rects.Add(new Rect(this.x, this.y, this.w, y));
            rects.Add(new Rect(this.x, this.y + y, this.w, this.h - y));
            return rects;
        }

        public List<Rect> SplitHorizontal(int x)
        {
            var rects = new List<Rect>();
            rects.Add(new Rect(this.x, this.y, x, this.h));
            rects.Add(new Rect(this.x + x, this.y, this.w - x, this.h));
            return rects;
        }

        public int Area()
        {
            return this.w * this.h;
        }

        public int MaxSide()
        {
            return Math.Max(this.w, this.h);
        }

        public bool CanContain(int w, int h)
        {
            return this.w >= w && this.h >= h;
        }

        public bool IsCongruentWith(int w, int h)
        {
            return this.w == w && this.h == h;
        }
        public override string ToString()
        {
            return string.Format("<({0}, {1}) - ({2}, {3})>", this.x, this.y, this.w, this.h);
        }
        public bool ShouldSplitVertically(int w, int h)
        {
            if (this.w == w)
                return true;
            else if (this.h == h)
                return false;
            // TODO: come up with a better heuristic
            var vertRects = SplitVertical(h);
            var horzRects = SplitHorizontal(w);
            return vertRects[1].Area() > horzRects[1].Area();
        }
        public bool ShouldGrowVertically(int w, int h)
        {
            var canGrowVert = this.w >= w;
            var canGrowHorz = this.h >= h;
            if (!canGrowVert && !canGrowHorz)
                throw new Exception("Unable to grow!");
            if (canGrowVert && !canGrowHorz)
                return true;
            if (canGrowHorz && !canGrowVert)
                return false;
            return (this.h + h < this.w + w);
        }
    }

    public class Sprite
    {
        public string ImageName { get; set; }
        public Bitmap Image { get; set; }
        public Rect Rect { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public List<Sprite> Children { get; set; }

        public Sprite(ImagePair imagePair, Rect rect, List<Sprite> children = null)
        {
            if (null != imagePair)
            {
                this.ImageName = imagePair.Path;
                this.Image = imagePair.Image;
            }
            else
            {
                this.ImageName = "";
                this.Image = null;
            }
            this.Rect = rect;
            if (null != children)
                this.Children = children;
            else
                this.Children = new List<Sprite>();
        }

        public Sprite Clone()
        {
            if (this.IsLeaf())
                return new Sprite(new ImagePair(this.ImageName, this.Image), this.Rect.Clone());
            else
            {
                var children = new List<Sprite>();
                children.Add(this.Children[0].Clone());
                children.Add(this.Children[1].Clone());
                return new Sprite(new ImagePair(this.ImageName, this.Image), this.Rect.Clone(), children);
            }
        }

        public bool IsLeaf()
        {
            return this.Children.Count == 0;
        }

        public bool IsEmptyLeaf()
        {
            return (this.IsLeaf() && this.Image == null);
        }

        public void SplitNode(ImagePair imagePair)
        {
            if (!this.IsLeaf())
                throw new Exception("Attempted to split non-leaf");

            var imageW = imagePair.Image.Width;
            var imageH = imagePair.Image.Height;
            if (!this.Rect.CanContain(imageW, imageH))
                throw new Exception("Attempted to place an img in a node it doesn't fit");

            //if it fits exactly then we are done
            if (this.Rect.IsCongruentWith(imageW, imageH))
            {
                this.ImageName = imagePair.Path;
                this.Image = imagePair.Image;
            }
            else
            {
                if (this.Rect.ShouldSplitVertically(imageW, imageH))
                {
                    var vertRects = this.Rect.SplitVertical(imageH);
                    var top = new Sprite(null, vertRects[0]);
                    var bottom = new Sprite(null, vertRects[1]);
                    this.Children.Add(top);
                    this.Children.Add(bottom);
                }
                else
                {
                    var horzRects = this.Rect.SplitHorizontal(imageW);
                    var left = new Sprite(null, horzRects[0]);
                    var right = new Sprite(null, horzRects[1]);
                    this.Children.Add(left);
                    this.Children.Add(right);
                }
                this.Children[0].SplitNode(imagePair);
            }
        }

        public void GrowNode(ImagePair imagePair)
        {
            if (this.IsEmptyLeaf())
                throw new Exception("Attempted to grow an empty leaf");

            var imageW = imagePair.Image.Width;
            var imageH = imagePair.Image.Height;
            var newChild = this.Clone();
            this.Children.Clear();
            this.Children.Add(newChild);
            this.Image = null;
            this.ImageName = "";
            if (this.Rect.ShouldGrowVertically(imageW, imageH))
            {
                this.Children.Add(new Sprite(null, new Rect(this.Rect.x, this.Rect.y + this.Rect.h, this.Rect.w, imageH)));
                this.Rect.h += imageH;
            }
            else
            {
                this.Children.Add(new Sprite(null, new Rect(this.Rect.x + this.Rect.w, this.Rect.y, imageW, this.Rect.h)));
                this.Rect.w += imageW;
            }
            this.Children[1].SplitNode(imagePair);
        }

        public override string ToString()
        {
            if (this.IsLeaf())
                return string.Format("[ {0}: {1} ]", this.ImageName, this.Rect.ToString());
            else
                return string.Format("[ {0}: {1} | {2} {3}]", this.ImageName, this.Rect.ToString(), this.Children[0].ToString(), this.Children[1].ToString());
        }

        public void Render(Graphics gr)
        {
            if (this.IsLeaf())
            {
                if (null != this.Image)
                    gr.DrawImage(this.Image, this.Rect.x, this.Rect.y);
            }
            else
            {
                this.Children[0].Render(gr);
                this.Children[1].Render(gr);
            }
        }

        public string ToXml()
        {
            var xml = new StringBuilder();
            xml.AppendFormat("        <key>{0}</key>\n", ImageName);
            xml.AppendFormat("        <dict>\n");
            xml.AppendFormat("        <key>frame</key>\n");
            xml.AppendFormat("            <string>{{{{{0},{1}}},{{{2},{3}}}}}</string>\n", Rect.x, Rect.y, Rect.w, Rect.h);
            xml.AppendFormat("            <key>offset</key>\n");
            xml.AppendFormat("            <string>{{{0},{1}}}</string>\n", OffsetX, OffsetY);
            xml.AppendFormat("            <key>rotated</key>\n");
            xml.AppendFormat("            <false/>\n");
            xml.AppendFormat("            <key>sourceColorRect</key>\n");
            xml.AppendFormat("            <string>{{{{0,0}},{{{0},{1}}}}}</string>\n", Rect.w, Rect.h);
            xml.AppendFormat("            <key>sourceSize</key>\n");
            xml.AppendFormat("           <string>{{{0},{1}}}</string>\n", Rect.w, Rect.h);
            xml.AppendFormat("        </dict>\n");
            return xml.ToString();
        }

        public string ToChar()
        {
            return string.Format("char id={0}\tx={1}\ty={2}\twidth={3}\theight={4}\txoffset={5}\tyoffset={6}\txadvance={7}\tpage={8}\tchnl={9}\n",
                System.IO.Path.GetFileNameWithoutExtension(ImageName), Rect.x, Rect.y, Rect.w, Rect.h, OffsetX, OffsetY, Rect.w, 0, 15);
        }
    }
}
