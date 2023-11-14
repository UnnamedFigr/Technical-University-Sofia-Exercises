using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [Serializable]
    public class RectangleShape : Shape, ISerializable
    {
        
        public RectangleShape(Color fillColor, Point position, int width, int height)
            : base(fillColor,position)
        {
            base.Width = width;
            base.Height = height;
        }
        public RectangleShape(SerializationInfo info, StreamingContext context) : base(info,context)
        {
            Width = (int)info.GetValue("Width", typeof(int));
            Height = (int)info.GetValue("Height", typeof(int));
            Position = (Point)info.GetValue("Position", typeof(Point));
            BorderThickness = (int)info.GetValue("BordThickness", typeof(int));
            FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            BorderColor = (Color)info.GetValue("BorderColor", typeof(Color));
        }

        public override void Draw(Graphics g)
        {
            Pen borderColorPen = new Pen(new SolidBrush(borderColor), borderThickness);
            g.DrawRectangle(borderColorPen, new Rectangle(Position.X, Position.Y, width, height));
            g.FillRectangle(Brush, new Rectangle(Position.X, Position.Y, width, height));
        }
        public override double CalculateArea(Shape shape)
        {
            return (double)Width * Height; 
        }
        public override bool ContainsPoint(Point point)
        {
            return point.X >= position.X && point.X <= position.X + width &&
                   point.Y >= position.Y && point.Y <= position.Y + height;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
            info.AddValue("BorderColor", BorderColor);
            info.AddValue("FillColor", FillColor);
            info.AddValue("Position", Position);
            info.AddValue("BordThickness", BorderThickness);
        }
    }
}
