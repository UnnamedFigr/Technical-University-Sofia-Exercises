using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.Commands;
using WindowsFormsApp1.Exceptions;
using WindowsFormsApp1.SceneCommands;
using WindowsFormsApp1.Shapes;

namespace WindowsFormsApp1
{
    [Serializable]
    public partial class MainForm : Form
    {
        private readonly ActionHistory _actionHistory;
        private List<ICommandScene> _sceneCommands = new List<ICommandScene>();
        private List<Shape> _shapes;
        private List<Shape> _oldList;
        private Shape selectedShape = null;
        private Point lastMousePos;
        private Point _initialPoint;

        private bool isDragged = false;
        private bool filterApplied = false;
        private bool pnlShapeCollapsed = true;
        private bool pnlFileCollapsed = true;
        private bool pnlFilterCollapsed = true;

        public MainForm()
        {
            InitializeComponent();
            _shapes = new List<Shape>();
            _oldList= new List<Shape>();
            _actionHistory = new ActionHistory();
            _sceneCommands.Add(new SelectShapeCommand());
            _sceneCommands.Add(new MoveShapeCommand());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            _shapes.Add(new Circle(Color.Brown, new Point(10, 20), 100) { BorderColor = Color.Green, BorderThickness = 5 });
            _shapes.Add(new RectangleShape(Color.Green, new Point(30, 50), 200, 300));
            _shapes.Add(new Square(Color.GreenYellow, new Point(70, 30), 250));
        }

        private void Scene_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (_shapes != null)
            {
                for (int i = 0; i < _shapes.Count; i++)
                {
                    _shapes[i].Draw(g);

                }

                _shapes.HighlightSelectedShape(g, selectedShape); // in ShapeExtension as static method

            }

            Invalidate();
        }
        private void Scene_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var cmd in _sceneCommands)
            {
                cmd.OnMouseDown(e);
                if (cmd is ISelectShape _select)
                    _select.OnMouseDown(e, _shapes, ref selectedShape,
                            ref lastMousePos, ref isDragged, surfaceAreaLabel);

            }
            Refresh();

        }

        private void Scene_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (var cmds in _sceneCommands)
            {
                cmds.OnMouseUp(e);
                if (cmds is IMoveShape _move)
                    _move.OnMouseUp(e, ref isDragged);
            }

            Refresh();
        }

        private void Scene_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var cmds in _sceneCommands)
            {
                cmds.OnMouseMove(e);
                if (cmds is IMoveShape _move)
                {
                    _move.OnMouseMove(e, _actionHistory, ref selectedShape, ref lastMousePos, ref isDragged);
                }
            }
            Refresh();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            Invalidate();
        }
        private void Scene_MouseClick(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (isDragged) return;
            _initialPoint = e.Location;
            initPointCoord.Text = string.Format("{0}, {1}", _initialPoint.X, _initialPoint.Y);
            Invalidate();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedShape != null)
                {
                    IAction command = new RemoveShapeAction(selectedShape, _shapes);
                    command.Execute();
                    _actionHistory.AddCommand(command);
                    Refresh();
                }
                else
                    throw new SelectedShapeNullException(ExceptionMessages.selectedShapeNullMsg);
            }
            catch (SelectedShapeNullException SHNull)
            {
                MessageBox.Show(SHNull.Message);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            _actionHistory.Undo();
            Refresh();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {

            _actionHistory.Redo();
            Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedShape != null)
                {
                    EditShapeForm editForm = new EditShapeForm(selectedShape);

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        IAction command = new EditShapeAction(_shapes, selectedShape, editForm.EditedShape);
                        command.Execute();
                        _actionHistory.AddCommand(command);
                    }
                }
                else
                {
                    throw new SelectedShapeNullException(ExceptionMessages.selectedShapeNullMsg);
                }
            }
            catch (SelectedShapeNullException SHNull)
            {
                MessageBox.Show(SHNull.Message);
            }
            selectedShape = null;
            Refresh();
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            addShapeForm addShapeForm = new addShapeForm(_initialPoint);

            addShapeForm.ShowDialog();
            if (addShapeForm.DialogResult == DialogResult.OK)
            {
                var addedShape = addShapeForm.newShape;
                IAction command = new AddShapeAction(addedShape, _shapes);
                command.Execute();
                _actionHistory.AddCommand(command);
                selectedShape = addedShape;
                _initialPoint = Point.Empty;
                initPointCoord.Text = string.Format("Click on the scene");
                Refresh();
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            selectedShape = null;
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
            saveFileDlg.DefaultExt = "png";
            saveFileDlg.Title = "Save image file";

            Bitmap bmp = new Bitmap(Scene.Width, Scene.Height);
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                Scene.DrawToBitmap(bmp, Scene.ClientRectangle);
                bmp.Save(saveFileDlg.FileName, ImageFormat.Png);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
            openFileDlg.DefaultExt = "png";
            openFileDlg.Title = "Load image file";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                Scene.Image = Image.FromFile(openFileDlg.FileName);
            }
        }

        private void btnRmvAll_Click(object sender, EventArgs e)
        {
            IAction command = new RemoveAllShapesAction(_shapes);
            command.Execute();
            _actionHistory.AddCommand(command);
            Refresh();

        }       
        private void btnFilterShapeType_Click(object sender, EventArgs e)
        {

            try
            {
                if (filterApplied)
                {
                    throw new FilterNotClearedException(ExceptionMessages.filterNotClearedMsg);
                }
                else
                {
                    _oldList = _shapes;
                }

                if (selectedShape != null)
                {
                    if (selectedShape is Circle circle)
                    {

                        _shapes = _shapes.Where(i => i is Circle).ToList();

                    }
                    else if (selectedShape is RectangleShape rect)
                    {
                        _shapes = _shapes.Where(i => i is RectangleShape).ToList();
                    }
                    else if (selectedShape is Square sqr)
                    {
                        _shapes = _shapes.Where(i => i is Square).ToList();
                    }
                    filterApplied = true;
                }
                else
                    throw new SelectedShapeNullException(ExceptionMessages.selectedShapeNullMsg);
            } 
            catch (SelectedShapeNullException SHNull)
            {
                MessageBox.Show(SHNull.Message);
            }
            catch(FilterNotClearedException FNC)
            {
                MessageBox.Show(FNC.Message);
            }
            
            Refresh();
        }
        private void clearFilter_Click(object sender, EventArgs e)
        {
            if (_oldList.Count > 0)
            {
                _shapes = _oldList;
                filterApplied = false;
            }
            Refresh();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Data Base|*.db";
            saveFile.DefaultExt = "db";
            saveFile.Title = "Save file";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                IFormatter formater = new BinaryFormatter();
                Stream stream = File.Open(saveFile.FileName, FileMode.Create, FileAccess.Write);
                formater.Serialize(stream, _shapes);
                stream.Close();
            }
            Invalidate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Data Base|*.db";
            openFile.DefaultExt = "db";
            openFile.Title = "Load File";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = File.Open(openFile.FileName, FileMode.Open, FileAccess.Read);
                _shapes = (List<Shape>)formatter.Deserialize(stream);
                stream.Close();
            }
            Scene.Refresh();
        }

        private void timerShapeActions_Tick(object sender, EventArgs e)
        {
            if (pnlShapeCollapsed)
            {
                pnlShapeActionsDropD.Height += 10;
                if (pnlShapeActionsDropD.Size == pnlShapeActionsDropD.MaximumSize)
                {
                    timerShapeActions.Stop();
                    pnlShapeCollapsed = false;
                }
            }
            else
            {
                pnlShapeActionsDropD.Height -= 10;
                if (pnlShapeActionsDropD.Size == pnlShapeActionsDropD.MinimumSize)
                {
                    timerShapeActions.Stop();
                    pnlShapeCollapsed = true;
                }
            }
        }
        private void timerFile_Tick(object sender, EventArgs e)
        {
            if (pnlFileCollapsed)
            {
                pnlFileDropDown.Height += 10;
                if (pnlFileDropDown.Size == pnlFileDropDown.MaximumSize)
                {
                    timerFile.Stop();
                    pnlFileCollapsed = false;
                }
            }
            else
            {
                pnlFileDropDown.Height -= 10;
                if (pnlFileDropDown.Size == pnlFileDropDown.MinimumSize)
                {
                    timerFile.Stop();
                    pnlFileCollapsed = true;
                }
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            if(pnlFilterCollapsed)
            {
                pnlFilterShapes.Height += 10;
                if(pnlFilterShapes.Size == pnlFilterShapes.MaximumSize)
                {
                    timerFilter.Stop();
                    pnlFilterCollapsed = false;
                }
            }
            else
            {
                pnlFilterShapes.Height -= 10;
                if(pnlFilterShapes.Size == pnlFilterShapes.MinimumSize)
                {
                    timerFilter.Stop();
                    pnlFilterCollapsed = true;
                }
            }
        }
        private void btnShapeDropDown_Click(object sender, EventArgs e)
        {
            timerShapeActions.Start();
        }

        private void btnFileDropDown_Click(object sender, EventArgs e)
        {
            timerFile.Start();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!pnlFileCollapsed)
            {
                timerFile.Start();
            }
            if (!pnlShapeCollapsed)
            {
                timerShapeActions.Start();
            }
            if(!pnlFilterCollapsed)
            {
                timerFilter.Start();
            }
        }

        private void btnFilterShapes_Click(object sender, EventArgs e)
        {
            timerFilter.Start();
        }

        private void btnFilterColors_Click(object sender, EventArgs e)
        {
            try
            {
                if (filterApplied)
                {
                    throw new FilterNotClearedException(ExceptionMessages.filterNotClearedMsg);
                }
                else
                {
                    _oldList = _shapes;
                }
                if (selectedShape != null)
                {
                    _shapes = _shapes.Where(i => i.FillColor == selectedShape.FillColor).ToList();
                }
                else
                {
                    throw new SelectedShapeNullException(ExceptionMessages.selectedShapeNullMsg);
                }
                filterApplied = true;
            }
            catch(FilterNotClearedException FNCEx)
            {
                MessageBox.Show(FNCEx.Message);
            }
            catch(SelectedShapeNullException SHNull)
            {
                MessageBox.Show(SHNull.Message);
            }

            Refresh();
        }
    }
}