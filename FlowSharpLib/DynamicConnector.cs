﻿using System.Drawing;

namespace FlowSharpLib
{
	public abstract class DynamicConnector : Connector
	{
		public DynamicConnector(Canvas canvas) : base(canvas)
		{
			HasCornerAnchors = false;
			HasCenterAnchors = false;
			HasTopBottomAnchors = false;
			HasLeftRightAnchors = false;
		}

		public override ElementProperties CreateProperties()
		{
			return new DynamicConnectorProperties(this);
		}

		public override bool SnapCheck(ShapeAnchor anchor, Point delta)
		{
			bool ret = canvas.Controller.Snap(anchor.Type, ref delta);

			if (ret)
			{
				MoveAnchor(anchor.Type, delta);
			}
			else
			{
				ret = base.SnapCheck(anchor, delta);
			}

			return ret;
		}


		public override void MoveElementOrAnchor(GripType gt, Point delta)
		{
			MoveAnchor(gt, delta);
		}
	}
}
