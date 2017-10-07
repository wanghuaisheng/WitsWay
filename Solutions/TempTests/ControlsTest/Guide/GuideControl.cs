using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.Utils.Text;

namespace DevExpress.Description.Controls
{
    // Token: 0x02000051 RID: 81
    public class GuideControlDescription : IStringImageProvider
    {
        // Token: 0x06000300 RID: 768 RVA: 0x0000F4B1 File Offset: 0x0000D6B1
        public GuideControlDescription()
        {
            this.AllowParseChildren = true;
        }

        // Token: 0x0600031B RID: 795 RVA: 0x0000F688 File Offset: 0x0000D888
        internal GuideControlDescription Clone()
        {
            return new GuideControlDescription
            {
                ControlName = this.ControlName,
                ControlTypeName = this.ControlTypeName,
                ControlType = this.ControlType,
                Description = this.Description,
                DescriptionPicture = this.DescriptionPicture,
                HighlightUseInsideBounds = this.HighlightUseInsideBounds,
                AllowParseChildren = this.AllowParseChildren
            };
        }

        // Token: 0x0600031D RID: 797 RVA: 0x0000F74D File Offset: 0x0000D94D
        Image IStringImageProvider.GetImage(string id)
        {
            if (this.DescriptionPicture != null)
            {
                return this.DescriptionPicture;
            }
            return null;
        }

        // Token: 0x0600031C RID: 796 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
        internal string GetTypeName()
        {
            if (!string.IsNullOrEmpty(this.ControlTypeName))
            {
                return this.ControlTypeName;
            }
            if (this.AssociatedControl != null)
            {
                return this.AssociatedControl.GetType().FullName;
            }
            if (this.ControlType != null)
            {
                return this.ControlType.FullName;
            }
            return "";
        }

        // Token: 0x06000317 RID: 791 RVA: 0x0000F57C File Offset: 0x0000D77C
        public override string ToString()
        {
            string text = this.GetTypeName();
            string text2 = (this.AssociatedControl != null && !string.IsNullOrEmpty(this.AssociatedControl.Name)) ? this.AssociatedControl.Name : this.ControlName;
            if (!string.IsNullOrEmpty(text2))
            {
                text += string.Format(" [{0}]", text2);
            }
            return text;
        }

        // Token: 0x1700009F RID: 159
        [DefaultValue(true)]
        public bool AllowParseChildren
        {
            // Token: 0x06000303 RID: 771 RVA: 0x0000F4D1 File Offset: 0x0000D6D1
            get;
            // Token: 0x06000304 RID: 772 RVA: 0x0000F4D9 File Offset: 0x0000D6D9
            set;
        }

        // Token: 0x170000A5 RID: 165
        [Browsable(false), XmlIgnore]
        public Control AssociatedControl
        {
            // Token: 0x0600030F RID: 783 RVA: 0x0000F537 File Offset: 0x0000D737
            get;
            // Token: 0x06000310 RID: 784 RVA: 0x0000F53F File Offset: 0x0000D73F
            set;
        }

        // Token: 0x170000A6 RID: 166
        [XmlIgnore]
        internal Rectangle ControlBounds
        {
            // Token: 0x06000311 RID: 785 RVA: 0x0000F548 File Offset: 0x0000D748
            get;
            // Token: 0x06000312 RID: 786 RVA: 0x0000F550 File Offset: 0x0000D750
            set;
        }

        // Token: 0x170000A0 RID: 160
        [DefaultValue(null)]
        public string ControlName
        {
            // Token: 0x06000305 RID: 773 RVA: 0x0000F4E2 File Offset: 0x0000D6E2
            get;
            // Token: 0x06000306 RID: 774 RVA: 0x0000F4EA File Offset: 0x0000D6EA
            set;
        }

        // Token: 0x170000A2 RID: 162
        [Browsable(false), XmlIgnore]
        public Type ControlType
        {
            // Token: 0x06000309 RID: 777 RVA: 0x0000F504 File Offset: 0x0000D704
            get;
            // Token: 0x0600030A RID: 778 RVA: 0x0000F50C File Offset: 0x0000D70C
            set;
        }

        // Token: 0x170000A1 RID: 161
        [DefaultValue(null)]
        public string ControlTypeName
        {
            // Token: 0x06000307 RID: 775 RVA: 0x0000F4F3 File Offset: 0x0000D6F3
            get;
            // Token: 0x06000308 RID: 776 RVA: 0x0000F4FB File Offset: 0x0000D6FB
            set;
        }

        // Token: 0x170000A8 RID: 168
        [XmlIgnore]
        internal bool ControlVisible
        {
            // Token: 0x06000315 RID: 789 RVA: 0x0000F56A File Offset: 0x0000D76A
            get;
            // Token: 0x06000316 RID: 790 RVA: 0x0000F572 File Offset: 0x0000D772
            set;
        }

        // Token: 0x170000A3 RID: 163
        public string Description
        {
            // Token: 0x0600030B RID: 779 RVA: 0x0000F515 File Offset: 0x0000D715
            get;
            // Token: 0x0600030C RID: 780 RVA: 0x0000F51D File Offset: 0x0000D71D
            set;
        }

        // Token: 0x170000A4 RID: 164
        [DefaultValue(null), XmlIgnore]
        public Image DescriptionPicture
        {
            // Token: 0x0600030D RID: 781 RVA: 0x0000F526 File Offset: 0x0000D726
            get;
            // Token: 0x0600030E RID: 782 RVA: 0x0000F52E File Offset: 0x0000D72E
            set;
        }

        // Token: 0x170000AA RID: 170
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), XmlElement("DescriptionPicture")]
        public byte[] DescriptionPictureSerialized
        {
            // Token: 0x06000319 RID: 793 RVA: 0x0000F5EC File Offset: 0x0000D7EC
            get
            {
                if (this.DescriptionPicture == null)
                {
                    return null;
                }
                byte[] result;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    this.DescriptionPicture.Save(memoryStream, ImageFormat.Png);
                    result = memoryStream.ToArray();
                }
                return result;
            }
            // Token: 0x0600031A RID: 794 RVA: 0x0000F640 File Offset: 0x0000D840
            set
            {
                if (value == null)
                {
                    this.DescriptionPicture = null;
                    return;
                }
                using (MemoryStream memoryStream = new MemoryStream(value))
                {
                    this.DescriptionPicture = new Bitmap(memoryStream);
                }
            }
        }

        // Token: 0x1700009E RID: 158
        [DefaultValue(false)]
        public bool HighlightUseInsideBounds
        {
            // Token: 0x06000301 RID: 769 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
            get;
            // Token: 0x06000302 RID: 770 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
            set;
        }

        // Token: 0x170000A9 RID: 169
        [Browsable(false), XmlIgnore]
        public virtual bool IsValidNow
        {
            // Token: 0x06000318 RID: 792 RVA: 0x0000F5D9 File Offset: 0x0000D7D9
            get
            {
                return this.AssociatedControl != null && this.ControlVisible;
            }
        }

        // Token: 0x170000A7 RID: 167
        [XmlIgnore]
        internal Rectangle ScreenBounds
        {
            // Token: 0x06000313 RID: 787 RVA: 0x0000F559 File Offset: 0x0000D759
            get;
            // Token: 0x06000314 RID: 788 RVA: 0x0000F561 File Offset: 0x0000D761
            set;
        }
    }
}
