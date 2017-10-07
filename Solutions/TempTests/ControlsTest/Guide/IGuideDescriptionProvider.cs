using System;
using System.Collections.Generic;

namespace DevExpress.Description.Controls
{
    // Token: 0x0200004D RID: 77
    public interface IGuideDescriptionProvider
    {
        // Token: 0x060002F1 RID: 753
        void UpdateDescriptions(List<GuideControlDescription> templates);

        // Token: 0x1700009D RID: 157
        bool Enabled
        {
            // Token: 0x060002F0 RID: 752
            get;
        }
    }
}
