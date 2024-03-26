using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Shapes
{
    [Serializable]
    public class Square : Shape, ISerializable
    {
        private int side;
        public Square(Color fillColor, Point position, int side) 
            : base(fillColor, position)
        {
            this.Side = side;
        }
        public Square(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Side = (int)info.GetValue("Side", typeof(int));
            Position = (Point)info.GetValue("Position", typeof(Point));
            BorderThickness = (int)info.GetValue("BordThickness", typeof(int));
            FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            BorderColor = (Color)info.GetValue("BorderColor", typeof(Color));
        }
        public int Side
        {
            get { return side; }
            set { base.Width = value; base.Height = value; this.side = value; }
        }
        public override bool ContainsPoint(Point point)
        {
            return point.X >= position.X && point.X <= position.X + side &&
                   point.Y >= position.Y && point.Y <= position.Y + side;
        }

        public override void Draw(Graphics g)
        {
            Pen borderColorPen = new Pen(new SolidBrush(borderColor), borderThickness);
            g.DrawRectangle(borderColorPen, new Rectangle(Position.X, Position.Y, side, side));
            g.FillRectangle(Brush, new Rectangle(Position.X, Position.Y, side, side));
        }
        public override double CalculateArea(Shape shape)
        {
            return side * side;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Side", Side);
            info.AddValue("BorderColor", BorderColor);
            info.AddValue("FillColor", FillColor);
            info.AddValue("Position", Position);
            info.AddValue("BordThickness", BorderThickness);

        }
    }
}
