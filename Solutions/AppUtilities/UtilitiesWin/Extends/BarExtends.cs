#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System.Windows.Forms;
using DevExpress.Utils.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// Bar扩展类
    /// </summary>
    public static class BarExtends
    {

        /// <summary>
        /// 停靠到GroupControl
        /// </summary>
        public static void DockToGroup(this Bar bar, GroupControl group, DockStyle dock = DockStyle.Top)
        {
            DockToContainer(bar, group, dock);
        }

        /// <summary>
        /// 停靠到PanelControl
        /// </summary>
        /// <param name="bar">Toolbar控件</param>
        /// <param name="panel">Panel控件</param>
        /// <param name="dock">Dock位置</param>
        public static void DockToPanel(this Bar bar, PanelControl panel, DockStyle dock = DockStyle.Top)
        {
            DockToContainer(bar, panel, dock);
        }
        /// <summary>
        /// 设置Bar样式
        /// </summary>
        /// <param name="bar"><see cref="Bar"/>控件</param>
        public static void SetStandaloneStyle(this Bar bar)
        {
            if (bar == null)  return;
            bar.CanDockStyle = BarCanDockStyle.Standalone;
            bar.DockStyle = BarDockStyle.Standalone;
            bar.OptionsBar.AllowQuickCustomization = false;
            bar.OptionsBar.DrawDragBorder = false;
            bar.OptionsBar.MultiLine = true;
            bar.OptionsBar.UseWholeRow = true;
            if (bar.Manager != null) bar.Manager.AllowShowToolbarsPopup = false;
        }

        /// <summary>
        /// 停靠到容器
        /// </summary>
        private static void DockToContainer(this Bar bar, PanelBase panel, DockStyle dock)
        {
            //Bar样式设置
            bar.OptionsBar.AllowQuickCustomization = false;
            bar.OptionsBar.DrawDragBorder = false;
            bar.OptionsBar.MultiLine = true;
            bar.OptionsBar.UseWholeRow = true;
            //创建DockControl
            bar.Manager.BeginUpdate();
            var barDock = new StandaloneBarDockControl { Dock = dock };
            bar.StandaloneBarDockControl = barDock;
            bar.Manager.DockControls.Add(barDock);
            panel.Controls.Add(barDock);
            bar.Manager.EndUpdate();
        }

    }
}
