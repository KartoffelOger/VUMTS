namespace VUMTS
{
    public partial class View : Form, IView
    {
        private IModel model;
        private IController controller;

        IModel IView.Model
        {
            get { return model; }
            set { model = value; }
        }
        IController IView.Controller
        {
            get { return controller; }
            set { controller = value; }
        }
        public View()
        {
            InitializeComponent();
        }

        private void onClickStart(object sender, EventArgs e)
        {
            controller.cycleStart();
        }

        void IView.anzeigen(int distance)
        {
            if (textBox1.InvokeRequired)
            {                
                textBox1.Invoke(new MethodInvoker(() => textBox1.Text = (distance.ToString())));
            }
            else
            {
                textBox1.Text = (distance.ToString());
            }
            textBox1.Text = (distance.ToString());

        }

        private void onClickStop(object sender, EventArgs e)
        {
            controller.cycleStop();
        }
    }
}
