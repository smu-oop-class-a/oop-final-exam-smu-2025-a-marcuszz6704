using OOP.FinalTerm.Exam.Model;
using OOP.FinalTerm.Exam.Repository;

namespace OOP.FinalTerm.Exam.Views
{
    public partial class DirectorForm : Form
    {
        #region fields [DON'T TOUCH]
        private DirectorModel _director;
        private readonly IDirectorRepository _directorRepository;
        private readonly Color _netflixRed = Color.FromArgb(221, 0, 0);
        private readonly Color _darkBackground = Color.FromArgb(20, 20, 20);
        private readonly Color _hoverColor = Color.FromArgb(50, 50, 50);

      
        public DirectorForm(IDirectorRepository directorRepository)
        {
            InitializeComponent();
            _director = new DirectorModel();
            lblTitle.Text = "Add Director";
            _directorRepository = directorRepository;
        }

        public DirectorForm(DirectorModel director)
        {

            InitializeComponent();
            _director = director;
            lblTitle.Text = "Edit Director";
        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            ApplyNetflixTheme();
        }
        #endregion

      
        public DirectorModel GetDirector()
        {

            _director.FirstName = txtFirstName.Text;
            _director.LastName = txtLastName.Text;
            _director.Genres = txtGenres.Text;
            _director.TotalMoviesCreated = (int)numTotalMovies.Value;
            return _director;

      
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtGenres.Text))
            {
                MessageBox.Show("Genres is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenres.Focus();
                return;
            }
           


            _directorRepository.AddDirector(GetDirector());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


     
        private void ApplyNetflixTheme()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;

 
            foreach (Control control in GetAllControls(this))
            {
                if (control is Button button)
                {
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Cursor = Cursors.Hand;

                    button.MouseEnter += (s, e) =>
                    {
                        if (button.BackColor != _netflixRed)
                        {
                            button.BackColor = _hoverColor;
                        }
                        else
                        {
                            button.BackColor = Color.FromArgb(190, 0, 0);
                        }
                    };

                    button.MouseLeave += (s, e) =>
                    {
                        if (button.Text.Contains("Save"))
                            button.BackColor = _netflixRed;
                        else
                            button.BackColor = Color.FromArgb(60, 60, 60);
                    };
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.FromArgb(40, 40, 40);
                    textBox.ForeColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is Label label && label != lblTitle)
                {
                    label.BackColor = Color.FromArgb(30, 30, 30);
                    label.ForeColor = Color.White;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.FromArgb(40, 40, 40);
                    numericUpDown.ForeColor = Color.White;
                }
            }
        }


        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                {
                    yield return child;
                }
            }
        }
     
    }
}