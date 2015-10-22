#region using

using System.Windows.Forms;
using Galaxy.Core.Engine;
using Galaxy.Environments;

#endregion

namespace Galaxy
{
  public partial class MainForm : Form
  {
    #region Private fields

    private readonly Engine m_engine;

    #endregion

    #region Constructors

    public MainForm()
    {
      InitializeComponent();
     
      
      
     // timer1.Tick += button1_Click;
//
      m_engine = new Engine(canvas, typeof (LevelOne));

      FormClosing += (o, e) => m_engine.Stop();

      m_engine.Start();
    }

    #endregion

   
  }
}
