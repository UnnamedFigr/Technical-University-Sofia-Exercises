using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Commands;
using WindowsFormsApp1.Shapes;

namespace WindowsFormsApp1
{
    public static class ShapeExtension
    {
        
        public static void HighlightSelectedShape (this List<Shape> _shapes, Graphics g, Shape selectedShape) 
        {
            foreach (var item in _shapes.ToList())
            {
                
                if (item == selectedShape)
                {
                    Pen newPen = new Pen(new SolidBrush(Color.Black), 2f);
                    
                    PointF fullPosition = new PointF(item.Position.X - item.BorderThickness /2 - 0.5f , item.Position.Y - item.BorderThickness / 2 - 0.5f);
                    
                    if (item is Circle circle)
                    {
                        SizeF fullSize = new SizeF((float)circle.Radius * 2 + circle.BorderThickness, (float)circle.Radius * 2 + circle.BorderThickness);
                        g.DrawEllipse(newPen, new RectangleF(fullPosition, fullSize));
                    }
                    else if(item is Square sqr)
                    {
                        SizeF fullSize = new SizeF((float)sqr.Side + sqr.BorderThickness, (float)sqr.Side + sqr.BorderThickness);

                        g.DrawRectangle(newPen, fullPosition.X, fullPosition.Y, fullSize.Width, fullSize.Height);

                    }
                    else
                    {
                        SizeF fullSize = new SizeF((float)item.Width + item.BorderThickness, (float)item.Height + item.BorderThickness);
                        g.DrawRectangle(newPen, fullPosition.X, fullPosition.Y, fullSize.Width, fullSize.Height);
                    }
                    int index = _shapes.FindIndex(i => i == selectedShape);
                    _shapes.RemoveAt(index);
                    _shapes.Add(selectedShape);
                }
            }
        }
        
    }
}
