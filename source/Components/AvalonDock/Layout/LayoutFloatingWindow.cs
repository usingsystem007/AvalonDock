﻿/************************************************************************
   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at https://opensource.org/licenses/MS-PL
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace AvalonDock.Layout
{
	[Serializable]
	public abstract class LayoutFloatingWindow : LayoutElement, ILayoutContainer, IXmlSerializable
	{
		#region Properties

		#region Children

		public abstract IEnumerable<ILayoutElement> Children { get; }

		public abstract int ChildrenCount { get; }

		#endregion Children

		public abstract bool IsValid { get; }

		#endregion Properties

		#region Public Methods

		public abstract void RemoveChild(ILayoutElement element);

		public abstract void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement);

		public XmlSchema GetSchema()
		{
			return null;
		}

		public abstract void ReadXml(XmlReader reader);

		public virtual void WriteXml(XmlWriter writer)
		{
			foreach (var child in Children)
			{
				var type = child.GetType();
				var serializer = new XmlSerializer(type);
				serializer.Serialize(writer, child);
			}
		}

		#endregion Public Methods
	}
}
