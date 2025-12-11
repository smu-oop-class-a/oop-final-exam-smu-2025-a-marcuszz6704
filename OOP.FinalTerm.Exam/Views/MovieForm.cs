namespace OOP.FinalTerm.Exam
{
    public partial class MovieForm : Form
    {
        private MovieModel _movie;
        private string _selectedImagePath;

        public MovieForm()
        {
            InitializeComponent();
            _movie = new MovieModel();
            lblTitle.Text = "Add Movie";
        }

        public MovieForm(MovieModel movie)
        {
            InitializeComponent();
            _movie = movie;
            lblTitle.Text = "Edit Movie";
            LoadMovieData();
        }

        private void LoadMovieData()
        {
            txtMovieTitle.Text = _movie.Title;
            txtDescription.Text = _movie.Description;
            cmbGenre.SelectedItem = _movie.Genre;
            dtpDateReleased.Value = _movie.DateReleased;
            numRatings.Value = _movie.Ratings;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            _movie.Title = txtMovieTitle.Text;
            _movie.Description = txtDescription.Text;
            _movie.Genre = cmbGenre.SelectedItem?.ToString() ?? "Action";
            _movie.DateReleased = dtpDateReleased.Value;
            _movie.Ratings = (int)numRatings.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMovieTitle.Text))
            {
                MessageBox.Show("Movie title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMovieTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (cmbGenre.SelectedItem == null)
            {
                MessageBox.Show("Please select a genre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGenre.Focus();
                return false;
            }

            return true;
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.Title = "Select Movie Cover Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;
                    txtCover.Text = Path.GetFileName(_selectedImagePath);

                    if (_movie.SetCoverFromFile(_selectedImagePath))
                    {
                        MessageBox.Show("✓ Image loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("✗ Failed to load image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCover.Clear();
                        _movie.Cover = null;
                    }
                }
            }
        }

        public MovieModel GetMovie()
        {
            return _movie;
        }
    }
}