using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsFormsApp1.Shapes
{
    [Serializable]
    public class Circle : Shape, ISerializable
    {
        private int radius;
        public Circle(SerializationInfo info, StreamingContext context): base(info, context)
        {
            Radius = (int)info.GetValue("Radius", typeof(int));
            Position = (Point)info.GetValue("Position", typeof(Point));
            BorderThickness = (int)info.GetValue("BordThickness", typeof(int));
            FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            BorderColor = (Color)info.GetValue("BorderColor", typeof(Color));
        }
        public Circle(Color fillColor, Point position, int radius)
                        : base(fillColor,position)
        {
            this.Radius= radius;
        }
        public int Radius
        {
            get { return radius; }
            set { base.Width = radius * 2; base.Height = radius * 2; this.radius = value; }
        }
        public override void Draw(Graphics g)
        {
            Pen newBorderColorPen = new Pen(new SolidBrush(borderColor), borderThickness);
            g.DrawEllipse(newBorderColorPen, new Rectangle(Position.X, Position.Y, radius * 2, radius * 2));
            g.FillEllipse(Brush, new Rectangle(Position.X, Position.Y,radius * 2, radius * 2));

        }
        
        public override double CalculateArea(Shape shape)
        {
            return (double)Math.PI * radius * radius;
        }
        public override bool ContainsPoint(Point point)
        {
            Point center = new Point(Position.X + radius, Position.Y + radius);

            int dx = (int)Math.Abs(point.X - center.X);
            int dy = Math.Abs(point.Y - center.Y);

            int sumOfSquares = dx * dx + dy * dy;
            int distance = sumOfSquares;
            return (double)radius * radius >= distance; 
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Radius", Radius);
            info.AddValue("BorderColor", BorderColor);
            info.AddValue("FillColor", FillColor);
            info.AddValue("Position", Position);
            info.AddValue("BordThickness", BorderThickness);
        }
    }
}
