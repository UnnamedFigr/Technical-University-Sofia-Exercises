using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Shapes;

namespace WindowsFormsApp1
{
    [Serializable]
    public abstract class Shape : ISerializable, IDisposable
    {
        protected Point position;
        protected Color borderColor;
        protected int borderThickness;
        protected int width;
        protected int height;      
        protected SolidBrush brush;

        protected Shape(Color fillColor, Point position)
        {
            this.Position = position;
            this.FillColor = fillColor;
            
        }
        protected Shape(SerializationInfo info, StreamingContext context)
        {                     
            Position = (Point)info.GetValue("Position", typeof(Point));
            BorderThickness = (int)info.GetValue("BordThickness", typeof(int));
            FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            BorderColor = (Color)info.GetValue("BorderColor", typeof(Color));
        }
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value ; } }
        public SolidBrush Brush { get { return brush; } protected set { brush = value; } }
        public Color FillColor
        {
            get { return Brush.Color; }
            set { Brush = new SolidBrush(value); }
        }
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = value; }
        }
        public Color BorderColor
        { 
            get { return borderColor; }
            set { borderColor = value; }
        }
        public Point Position
        {
            get { return position; }
            set { position.X = value.X; position.Y = value.Y; }
        }
        public abstract void Draw(Graphics g);
        public abstract double CalculateArea(Shape shape);
        public abstract bool ContainsPoint(Point point);
        public virtual void Dispose()
        {
            Brush.Dispose();
        }
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}
