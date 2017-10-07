using System;

namespace DevExpress.Description.Controls
{
    // Token: 0x02000052 RID: 82
    public interface IGuideForm
    {
        // Token: 0x0600031E RID: 798
        void Dispose();

        // Token: 0x06000323 RID: 803
        bool IsHandle(IntPtr intPtr);

        // Token: 0x06000320 RID: 800
        void Show(GuideControl owner, GuideControlDescription description);

        // Token: 0x170000AB RID: 171
        bool Visible
        {
            // Token: 0x0600031F RID: 799
            get;
        }

        // Token: 0x1400000A RID: 10
        // Token: 0x06000321 RID: 801
        // Token: 0x06000322 RID: 802
        event EventHandler FormClosed;
    }
}
