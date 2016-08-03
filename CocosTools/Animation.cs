using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocosTools
{
    public class Animation
    {
        public string name { get; set; }
        public float DelayPerUnit { get; set; }
        public bool RestoreOriginalFrame { get; set; }
        public int Loops { get; set; }
        public List<string> Frames { get; set; }

        public Animation()
        {
            name = "noname";
            DelayPerUnit = 1f;
            RestoreOriginalFrame = false;
            Loops = 1;
            Frames = new List<string>();
        }

        public string ToXml(string space = "")
        {
            var xml = new StringBuilder();
            xml.AppendFormat("{0}<key>{1}</key>\n", space, name);
            xml.AppendFormat("{0}    <dict>\n", space);

            xml.AppendFormat("{0}        <key>delayPerUnit</key>\n", space);
            xml.AppendFormat("{0}        <real>{1}</real>\n", space, DelayPerUnit);

            xml.AppendFormat("{0}        <key>restoreOriginalFrame</key>\n", space);
            xml.AppendFormat("{0}        <{1}/>\n", space, RestoreOriginalFrame.ToString().ToLower());

            xml.AppendFormat("{0}        <key>loops</key>\n", space);
            xml.AppendFormat("{0}        <integer>{1}</integer>\n", space, Loops);

            xml.AppendFormat("{0}        <key>frames</key>\n", space);
            xml.AppendFormat("{0}        <array>\n", space);
            if (Frames != null)
            {
                foreach (var i in Frames)
                {
                    xml.AppendFormat("{0}            <dict>\n", space);
                    xml.AppendFormat("{0}                <key>spriteframe</key>\n", space);
                    xml.AppendFormat("{0}                <string>{1}</string>\n", space, i);
                    xml.AppendFormat("{0}                <key>delayUnits</key>\n", space);
                    xml.AppendFormat("{0}                <integer>1</integer>\n", space);
                    xml.AppendFormat("{0}            </dict>\n", space);
                } // TODO collapse delayUnits
            }
            xml.AppendFormat("{0}        </array>\n", space);

            xml.AppendFormat("{0}    </dict>\n", space);
            return xml.ToString();
        }
    }
}
