using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{
    /// <summary>
    /// 绘制<see cref="Layer"/>集合
    /// </summary>
    [Serializable]
    public class Layers
    {
        //层列表
        private readonly ArrayList _layerList;

        private bool _isDirty;

        /// <summary>
        /// 任何层中任何对象无效则返回true
        /// </summary>
        public bool Dirty
        {
            get
            {
                if (_isDirty == false)
                {
                    foreach (Layer l in _layerList)
                    {
                        if (l.Dirty)
                        {
                            _isDirty = true;
                            break;
                        }
                    }
                }
                return _isDirty;
            }
        }

        public Layers()
        {
            _layerList = new ArrayList();
        }

        /// <summary>
        /// 当前激活层序号（只会有一个激活层）
        /// </summary>
        public int ActiveLayerIndex
        {
            get
            {
                int i = 0;
                foreach (Layer l in _layerList)
                {
                    if (l.IsActive) break;
                    i++;
                }
                return i;
            }
        }

        /// <summary>
        /// 绘制所有可见层
        /// </summary>
        /// <param name="g"><see cref="Graphics"/>对象</param>
        public void Draw(Graphics g)
        {
            foreach (Layer l in _layerList)
            {
                if (l.IsVisible)
                    l.Draw(g);
            }
        }

        /// <summary>
        /// Clear all objects in the list
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool Clear()
        {
            bool result = (_layerList.Count > 0);
            foreach (Layer l in _layerList)
                l.Graphics.Clear();

            _layerList.Clear();
            // Create a default Layer since there must be at least one Layer at all times
            CreateNewLayer("Default");

            // Set dirty flag based on result. Result is true only if at least one item was cleared and since the list is empty, there can be nothing dirty.
            if (result)
                _isDirty = false;
            return result;
        }

        /// <summary>
        /// Returns number layers in the collection - useful for for loops
        /// </summary>
        public int Count => _layerList.Count;

        /// <summary>
        /// Allows iterating through the list of layers using a for loop
        /// </summary>
        /// <param name="index">the index of the layer to return</param>
        /// <returns>the specified layer object</returns>
        public Layer this[int index]
        {
            get
            {
                if (index < 0 ||
                    index >= _layerList.Count)
                    return null;
                return (Layer)_layerList[index];
            }
        }

        /// <summary>
        /// Adds a new layer to the collection
        /// </summary>
        /// <param name="obj">The layer object to add</param>
        public void Add(Layer obj)
        {
            _layerList.Add(obj);
            // insert to the top of z-order
            //layerList.Insert(0, obj);
        }

        /// <summary>
        /// Create a new layer at the head of the layers list and set it to Active and Visible.
        /// </summary>
        /// <param name="theName">The name to assign to the new layer</param>
        public void CreateNewLayer(string theName)
        {
            // Deactivate the currently active Layer
            if (_layerList.Count > 0)
                ((Layer)_layerList[ActiveLayerIndex]).IsActive = false;
            // Create new Layer, set it visible and active
            Layer l = new Layer();
            l.IsVisible = true;
            l.IsActive = true;
            l.LayerName = theName;
            // Initialize empty GraphicsList for future objects
            l.Graphics = new GraphicsList();
            // Add to Layers collection
            Add(l);
        }

        /// <summary>
        /// Inactivate the active <see cref="Layer"/> by setting all layers to inactive.
        /// Brute force approach
        /// </summary>
        public void InactivateAllLayers()
        {
            foreach (Layer l in _layerList)
            {
                l.IsActive = false;
                // Make sure nothing is selected on the currently active layer before switching layers.
                if (l.Graphics != null)
                    l.Graphics.UnselectAll();
            }
        }

        /// <summary>
        /// 设置层隐藏
        /// </summary>
        /// <param name="layerIndex">层序号</param>
        public void MakeLayerInvisible(int layerIndex)
        {
            if (layerIndex > -1 &&
                layerIndex < _layerList.Count)
                ((Layer)_layerList[layerIndex]).IsVisible = false;
        }

        /// <summary>
        /// 设置层可见
        /// </summary>
        /// <param name="layerIndex">层序号</param>
        public void MakeLayerVisible(int layerIndex)
        {
            if (layerIndex > -1 &&
                layerIndex < _layerList.Count)
                ((Layer)_layerList[layerIndex]).IsVisible = true;
        }

        /// <summary>
        /// 设定激活层
        /// </summary>
        /// <param name="layerIndex">层序号</param>
        public void SetActiveLayer(int layerIndex)
        {
            // 检查序号有效
            if (layerIndex > -1 &&
                layerIndex < _layerList.Count)
            {
                // 确保被切换层无选中绘图对象
                //if (((Layer)layerList[ActiveLayerIndex]).Graphics != null)
                //  ((Layer)layerList[ActiveLayerIndex]).Graphics.UnselectAll();
                //((Layer)layerList[ActiveLayerIndex]).IsActive = false;

                ((Layer)_layerList[layerIndex]).IsActive = true;
                ((Layer)_layerList[layerIndex]).IsVisible = true;
            }
        }

        /// <summary>
        /// 移除层
        /// </summary>
        /// <param name="layerIndex">层序号</param>
        public void RemoveLayer(int layerIndex)
        {
            if (ActiveLayerIndex == layerIndex)
            {
                MessageBox.Show("Cannot Remove the Active Layer");
                return;
            }
            if (_layerList.Count == 1)
            {
                MessageBox.Show("There is only one Layer in this drawing! You Cannot Remove the Only Layer!");
                return;
            }
            // 检查layerIndex有效性
            if (layerIndex > -1 &&
                layerIndex < _layerList.Count)
            {
                ((Layer)_layerList[layerIndex]).Graphics.Clear();
                _layerList.RemoveAt(layerIndex);
            }
        }

    }
}