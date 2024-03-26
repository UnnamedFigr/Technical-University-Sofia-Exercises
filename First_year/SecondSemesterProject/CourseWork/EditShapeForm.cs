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
    public partial class EditShapeForm : Form
    {
        private Shape _selectedShape;
        private Shape _editedShape;
        //Colors
        private Color rectangleFillColor;
        private Color rectangleBorderColor;
        private Color squareFillColor;
        private Color squareBorderColor;
        private Color circleFillColor;
        private Color circleBorderColor;
        public EditShapeForm(Shape selectedShape)
        {
            InitializeComponent();
            _selectedShape = selectedShape;
        }
        public Shape EditedShape { get { return _editedShape; } }

        private void EditShapeForm_Load(object sender, EventArgs e)
        {
            if (_selectedShape == null) return;

            if(_selectedShape is RectangleShape)
            {
                editPnlRect.Visible = true;
                editPnlCircle.Visible = false;
                editPnlSqr.Visible = false;


                txtRectPosX.Text = _selectedShape.Position.X.ToString();
                txtRectPosY.Text = _selectedShape.Position.Y.ToString();
                txtRectWidth.Text = _selectedShape.Width.ToString();
                txtRectHeight.Text = _selectedShape.Height.ToString();
                txtRectBordThick.Text = _selectedShape.BorderThickness.ToString();

                pnlRectBordCol.BackColor = _selectedShape.BorderColor;
                pnlRectFillCol.BackColor = _selectedShape.FillColor;

                rectangleFillColor = _selectedShape.FillColor;
                rectangleBorderColor = _selectedShape.BorderColor;
            }
            else if(_selectedShape is Circle circle) 
            {
                editPnlRect.Visible = false;
                editPnlCircle.Visible = true;
                editPnlSqr.Visible = false;

                txtCirclePosX.Text = circle.Position.X.ToString();
                txtCirclePosY.Text = circle.Position.Y.ToString();
                txtCircleRadius.Text = circle.Radius.ToString();
                txtCircleBordThick.Text = circle.BorderThickness.ToString();

                pnlCircleFillCol.BackColor = _selectedShape.FillColor;
                pnlCircleBordCol.BackColor = _selectedShape.BorderColor;

                circleFillColor= _selectedShape.FillColor;
                circleBorderColor = _selectedShape.BorderColor;
            }
            else if(_selectedShape is Square sqr)
            {
                editPnlRect.Visible = false;
                editPnlCircle.Visible = false;
                editPnlSqr.Visible = true;

                txtSqrPosX.Text = sqr.Position.X.ToString();
                txtSqrPosY.Text = sqr.Position.Y.ToString();
                txtSqrSide.Text = sqr.Side.ToString();
                txtSqrBordThick.Text = sqr.BorderThickness.ToString();

                pnlSqrFillCol.BackColor = sqr.FillColor;
                pnlSqrBordCol.BackColor = sqr.BorderColor;

                squareBorderColor = sqr.BorderColor;
                squareFillColor = sqr.FillColor;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedShape is RectangleShape)
                {

                    int rectX, rectY, rectWidth, rectHeight, rectBordThick;
                    if (int.TryParse(txtRectPosX.Text, out rectX) &&
                        int.TryParse(txtRectPosY.Text, out rectY) &&
                        int.TryParse(txtRectWidth.Text, out rectWidth) &&
                        int.TryParse(txtRectHeight.Text, out rectHeight) &&
                        int.TryParse(txtRectBordThick.Text, out rectBordThick))
                    {
                        _editedShape = new RectangleShape(rectangleFillColor, new Point(rectX, rectY), rectWidth, rectHeight)
                        {
                            BorderThickness = rectBordThick,
                            BorderColor = rectangleBorderColor
                        };
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                        throw new ArgumentException(ExceptionMessages.argExMessage);
                }
                else if(_selectedShape is Circle) 
                {
                    int circleX, circleY, circleRadius, circleBordThick;
                    if (int.TryParse(txtCirclePosX.Text, out circleX) &&
                        int.TryParse(txtCirclePosY.Text, out circleY) &&
                        int.TryParse(txtCircleRadius.Text, out circleRadius) &&
                        int.TryParse(txtCircleBordThick.Text, out circleBordThick))
                    {
                        _editedShape = new Circle(circleFillColor, new Point(circleX, circleY), circleRadius)
                        {
                            BorderThickness = circleBordThick,
                            BorderColor = circleBorderColor
                        };
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    { throw new ArgumentException(ExceptionMessages.argExMessage); }                
                }
                else if(_selectedShape is Square)
                {
                    int sqrX, sqrY, sqrSide, sqrBordThick;

                    if (int.TryParse(txtSqrPosX.Text, out sqrX) &&
                        int.TryParse(txtSqrPosY.Text, out sqrY) &&
                        int.TryParse(txtSqrSide.Text, out sqrSide) &&
                        int.TryParse(txtSqrBordThick.Text, out sqrBordThick))
                    {
                        _editedShape = new Square(squareFillColor, new Point(sqrX, sqrY), sqrSide)
                        {
                            BorderThickness = sqrBordThick,
                            BorderColor = squareBorderColor
                        };
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        throw new ArgumentException(string.Format(ExceptionMessages.argExMessage));

                }
            }
            catch(ArgumentException AE)
            {
                MessageBox.Show(AE.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCircleFillCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorFillDlg = new ColorDialog();
            if(colorFillDlg.ShowDialog() == DialogResult.OK)
            {
                circleFillColor= colorFillDlg.Color;
                pnlCircleFillCol.BackColor = colorFillDlg.Color;
            }
        }

        private void btnCircleBordCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorBordDlg = new ColorDialog();
            if(colorBordDlg.ShowDialog()==DialogResult.OK)
            {
                circleBorderColor= colorBordDlg.Color;
                pnlCircleBordCol.BackColor = colorBordDlg.Color;
            }
        }

        private void btnRectFillCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorFillDlg = new ColorDialog();
            if(colorFillDlg.ShowDialog() == DialogResult.OK)
            {
                rectangleFillColor= colorFillDlg.Color;
                pnlRectFillCol.BackColor = colorFillDlg.Color;
            }
        }

        private void btnRectBordCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorBordDlg = new ColorDialog();
            if(colorBordDlg.ShowDialog() == DialogResult.OK)
            {
                rectangleBorderColor= colorBordDlg.Color;
                pnlRectBordCol.BackColor = colorBordDlg.Color;
            }
        }

        private void btnSqrFillCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorFillDlg= new ColorDialog();
            if(colorFillDlg.ShowDialog() == DialogResult.OK)
            {
                squareFillColor= colorFillDlg.Color;
                pnlSqrFillCol.BackColor = colorFillDlg.Color;
            }
        }

        private void btnSqrBordCol_Click(object sender, EventArgs e)
        {
            ColorDialog colorBordDlg = new ColorDialog();
            if(colorBordDlg.ShowDialog() == DialogResult.OK)
            {
                squareBorderColor= colorBordDlg.Color;
                pnlSqrBordCol.BackColor = colorBordDlg.Color;
            }
        }
    }
}
