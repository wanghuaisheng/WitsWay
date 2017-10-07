using System;
using System.Drawing;

namespace DevExpress.Description.Controls.Windows
{
    // Token: 0x02000056 RID: 86
    public class DXGuideLayeredWindow : DXLayeredWindowAlt
    {
        // Token: 0x0600034F RID: 847 RVA: 0x00010875 File Offset: 0x0000EA75
        public DXGuideLayeredWindow(GuideControl owner)
        {
            this.owner = owner;
        }

        // Token: 0x06000353 RID: 851 RVA: 0x000108A1 File Offset: 0x0000EAA1
        protected override void DrawBackground(Graphics g)
        {
        }

        // Token: 0x170000B0 RID: 176
        protected override IntPtr InsertAfterWindow
        {
            // Token: 0x06000351 RID: 849 RVA: 0x0001088C File Offset: 0x0000EA8C
            get
            {
                return this.Owner.Root.Handle;
            }
        }

        // Token: 0x170000AF RID: 175
        public GuideControl Owner
        {
            // Token: 0x06000350 RID: 848 RVA: 0x00010884 File Offset: 0x0000EA84
            get
            {
                return this.owner;
            }
        }

        // Token: 0x170000B1 RID: 177
        protected override bool UseDoubleBuffer
        {
            // Token: 0x06000352 RID: 850 RVA: 0x0001089E File Offset: 0x0000EA9E
            get
            {
                return true;
            }
        }

        // Token: 0x04000140 RID: 320
        private GuideControl owner;
    }
}
