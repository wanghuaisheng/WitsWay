using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{
	//[Serializable]
	/// <summary>
	/// Each <see cref="Layer"/> contains a list of Graphic Objects <see cref="GraphicsList"/>.
	/// Each <see cref="Layer"/> is contained in the <see cref="Layers"/> collection.
	/// Properties:
	///	LayerName		User-defined name of the Layer
	///	Graphics			Collection of <see cref="DrawObject"/>s in the Layer
	///	IsVisible			True if the <see cref="Layer"/> is visible
	///	IsActive			True if the <see cref="Layer"/> is the active <see cref="Layer"/> (only one <see cref="Layer"/> may be active at a time)
	///	Dirty				True if any object in the <see cref="Layer"/> is dirty
	/// </summary>
	public class Layer
	{
		//private string _name;
		private bool _isDirty;
		//private bool _visible;
		//private bool _active;
		//private GraphicsList _graphicsList;

		/// <summary>
		/// <see cref="Layer"/> Name (User-defined)
		/// </summary>
		public string LayerName { get; set; }

		/// <summary>
		/// List of Graphic objects (derived from <see cref="DrawObject"/>) contained by this <see cref="Layer"/>
		/// </summary>
		public GraphicsList Graphics { get; set; }

		/// <summary>
		/// Returns True if this <see cref="Layer"/> is visible, else False
		/// </summary>
		public bool IsVisible { get; set; }

		/// <summary>
		/// Returns True if this is the active <see cref="Layer"/>, else False
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// Dirty is True if any elements in the contained <see cref="GraphicsList"/> are dirty, else False
		/// </summary>
		public bool Dirty
		{
			get
			{
				if (_isDirty == false)
					_isDirty = Graphics.Dirty;
				return _isDirty;
			}
			set
			{
			    Graphics.Dirty = false;
				_isDirty = false;
			}
		}

		private const string EntryLayerName = "LayerName";
		private const string EntryLayerVisible = "LayerVisible";
		private const string EntryLayerActive = "LayerActive";
		private const string EntryObjectType = "ObjectType";
		private const string EntryGraphicsCount = "GraphicsCount";

		public void SaveToStream(SerializationInfo info, int orderNumber)
		{
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryLayerName, orderNumber),
				LayerName);

			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryLayerVisible, orderNumber),
				IsVisible);

			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryLayerActive, orderNumber),
				IsActive);

			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryGraphicsCount, orderNumber),
				Graphics.Count);

			for (int i = 0; i < Graphics.Count; i++)
			{
				object o = Graphics[i];
				info.AddValue(
					String.Format(CultureInfo.InvariantCulture,
					              "{0}{1}-{2}",
					              EntryObjectType, orderNumber, i),
					o.GetType().FullName);

				((DrawObject)o).SaveToStream(info, orderNumber, i);
			}
		}

		public void LoadFromStream(SerializationInfo info, int orderNumber)
		{
		    Graphics = new GraphicsList();

			LayerName = info.GetString(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryLayerName, orderNumber));

			IsVisible = info.GetBoolean(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryLayerVisible, orderNumber));

			IsActive = info.GetBoolean(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryLayerActive, orderNumber));

			int n = info.GetInt32(
				String.Format(CultureInfo.InvariantCulture,
				              "{0}{1}",
				              EntryGraphicsCount, orderNumber));

			for (int i = 0; i < n; i++)
			{
				string typeName;
				typeName = info.GetString(
					String.Format(CultureInfo.InvariantCulture,
					              "{0}{1}-{2}",
					              EntryObjectType, orderNumber, i));

				object drawObject;
				drawObject = Assembly.GetExecutingAssembly().CreateInstance(typeName);

				((DrawObject)drawObject).LoadFromStream(info, orderNumber, i);

                // Thanks to Member 3272353 for this fix to object ordering problem.
                // _graphicsList.Add((DrawObject)drawObject);
			    Graphics.Append((DrawObject) drawObject);
			}
		}

		internal void Draw(Graphics g)
		{
		    Graphics.Draw(g);
		}
	}
}