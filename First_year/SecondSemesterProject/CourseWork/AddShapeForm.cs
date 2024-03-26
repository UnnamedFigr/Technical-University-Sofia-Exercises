using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Exceptions;
using WindowsFormsApp1.Shapes;

namespace WindowsFormsApp1
{
    public partial class addShapeForm : Form
    {
        private Shape _shape;
        private Point _initPoint;
        private Color rectangleFillColor;
        private Color rectangleBorderColor;
        private Color squareFillColor;
        private Color squareBorderColor;
        private Color circleFillColor;
        private Color circleBorderColor;

        public addShapeForm(Point initialPoint)
        {
            InitializeComponent();
            _initPoint = initialPoint;
        }
        public Shape newShape
        {
            get { return _shape; }
            private set { _shape = value; }
        }

        private void addShapeForm_Load(object sender, EventArgs e)
        {
            comboBoxShapeType.Items.AddRange(new string[] { "Rectangle", "Circle", "Square" });
        }

        private void comboBoxShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            switch(comboBoxShapeType.SelectedItem)
            {

                case "Rectangle":
                    panelRectangle.Visible = true;
                    panelCircle.Visible = false;
                    panelSquare.Visible = false;

                    if (_initPoint != null)
                    {
                        txtRectPosX.Text = _initPoint.X.ToString();
                        txtRectPosY.Text = _initPoint.Y.ToString();
                    }
                    break;
                case "Circle":
                    panelRectangle.Visible = false;
                    panelCircle.Visible = true;
                    panelSquare.Visible = false;
                    if (_initPoint != null)
                    {
                        txtCirclePosX.Text = _initPoint.X.ToString();
                        txtCirclePosY.Text = _initPoint.Y.ToString();
                    }
                    break;
                case "Square":
                    panelRectangle.Visible = false;
                    panelCircle.Visible = false;
                    panelSquare.Visible = true;
                    if (_initPoint != null)
                    {
                        txtSquarePosX.Text = _initPoint.X.ToString();
                        txtSquarePosY.Text = _initPoint.Y.ToString();
                    }
                    break;
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxShapeType.SelectedItem)
                {
                    case "Rectangle":
                        int rectX, rectY, rectWidth, rectHeight, rectBorderThickness;
                        if (int.TryParse(txtRectPosX.Text, out rectX) &&
                            int.TryParse(txtRectPosY.Text, out rectY) &&
                            int.TryParse(txtRectWidth.Text, out rectWidth) &&
                            int.TryParse(txtRectHeight.Text, out rectHeight) &&
                            int.TryParse(txtRectBordThick.Text, out rectBorderThickness))
                        {
                            newShape = new RectangleShape(rectangleFillColor, new Point(rectX, rectY), rectWidth, rectHeight)
                            {
                                BorderThickness = rectBorderThickness,
                                BorderColor = rectangleBorderColor
                            };
                            //form1.AddShape(new RectangleShape(Color.Blue, new Point(rectX, rectY), rectWidth, rectHeight) { BorderThickness = rectBorderThickness});
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            throw new ArgumentException(ExceptionMessages.argExMessage);
                        }
                        break;

                    case "Circle":
                        int circleX, circleY, circleRadius, circleBorderThickness;
                        if (int.TryParse(txtCirclePosX.Text, out circleX) &&
                            int.TryParse(txtCirclePosY.Text, out circleY) &&
                            int.TryParse(txtCircleRadius.Text, out circleRadius) &&
                            int.TryParse(txtCircleBordThick.Text, out circleBorderThickness))
                        {
                            //form1.AddShape(new Circle(Color.Blue, new Point(circleX, circleY), circleRadius) { BorderThickness = circleBorderThickness});
                            newShape = new Circle(circleFillColor, new Point(circleX, circleY), circleRadius)
                            {
                                BorderThickness = circleBorderThickness,
                                BorderColor = circleBorderColor
                            };
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            throw new ArgumentException(ExceptionMessages.argExMessage);
                        }
                        break;
                    case "Square":
                        {
                            int squareX, squareY, squareSide, squareBorderThickness;
                            if (int.TryParse(txtSquarePosX.Text, out squareX) &&
                                int.TryParse(txtSquarePosY.Text, out squareY) &&
                                int.TryParse(txtSquareSide.Text, out squareSide) &&
                                int.TryParse(txtSquareBordThick.Text, out squareBorderThickness))
                            {
                                newShape = new Square(squareFillColor, new Point(squareX, squareY), squareSide)
                                {
                                    BorderThickness = squareBorderThickness,
                                    BorderColor = squareBorderColor
                                };
                                //form1.AddShape(new Square(Color.Blue, new Point(squareX, squareY), squareSide) { BorderThickness = squareBorderThickness });
                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }

                            else
                            {
                                throw new ArgumentException(ExceptionMessages.argExMessage);
                            }
                            break;
                        }
                }
            }
            catch(ArgumentException AE)
            {
                MessageBox.Show(AE.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rectFillCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorFillDlg = new ColorDialog();
            if(colorFillDlg.ShowDialog() == DialogResult.OK)
            {
                rectangleFillColor = colorFillDlg.Color;
                pnlRectFillCol.BackColor = colorFillDlg.Color;
            }
        }

        private void rectBordCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorBordDlg= new ColorDialog();
            if(colorBordDlg.ShowDialog()==DialogResult.OK)
            {
                rectangleBorderColor = colorBordDlg.Color;
                pnlRectBordCol.BackColor = colorBordDlg.Color;
            }
        }

        private void sqrFillCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorFillDlg= new ColorDialog();
            if(colorFillDlg.ShowDialog() == DialogResult.OK)
            {
                squareFillColor = colorFillDlg.Color;
                pnlSqrFillCol.BackColor = colorFillDlg.Color;
            }
        }

        private void sqrBordColr_Click(object sender, EventArgs e)
        {
            ColorDialog colorBordDlg = new ColorDialog();
            if(colorBordDlg.ShowDialog() == DialogResult.OK)
            {
                squareBorderColor = colorBordDlg.Color;
                pnlSqrBordCol.BackColor = colorBordDlg.Color;
            }
        }

        private void CircleFillCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorFillDlg = new ColorDialog();
            if(colorFillDlg.ShowDialog() == DialogResult.OK)
            {
                circleFillColor = colorFillDlg.Color;
                pnlCircleFillCol.BackColor = colorFillDlg.Color;
            }
        }

        private void CircleBordCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorBordDlg = new ColorDialog();
            if(colorBordDlg.ShowDialog() == DialogResult.OK)
            {
                circleBorderColor = colorBordDlg.Color;
                pnlCircleBordCol.BackColor = colorBordDlg.Color;
            }
        }
    }
}
