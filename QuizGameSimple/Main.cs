using QuizGameSimple.Logic;
using QuizGameSimple.Properties;
using System.Runtime.InteropServices;

namespace QuizGameSimple
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddPlayerPanel.Hide();
            
        }

        //Necessary variables for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CloseOnEnter(object sender, EventArgs e)
        {
            Closepb.Image = Resources.Close_Hover;
        }
        private void CloseOnExit(object sender, EventArgs e)
        {
            Closepb.Image = Resources.Close;
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeOnEnter(object sender, EventArgs e)
        {
            MinimizePb.Image = Resources.Minimize_Hover;
        }
        private void MinimizeOnExit(object sender, EventArgs e)
        {
            MinimizePb.Image = Resources.Minimize;
        }

        private void CreateQuizPb_Click(object sender, EventArgs e)
        {

        }

        private void PlayQuizPb_Click(object sender, EventArgs e)
        {

        }

        private void AddPlayerPb_Click(object sender, EventArgs e)
        {
            AddPlayerPanel.Show();
        }

        private void CreatePb_Click(object sender, EventArgs e)
        {
            Player p = new();
            p.Name = PlayerTb.Text;
            p.New();
            
        }

        private void RefreshPlayerListView()
        {
            PlayersLv.Items.Clear();
            Player p = new();
            foreach(Player player in p.GetAll())
            {
                PlayersLv.Items.Add(p.ToString());
            }
        }

        private void AddPlayerPanel_Paint(object sender, PaintEventArgs e)
        {
            RefreshPlayerListView();
        }
    }
}