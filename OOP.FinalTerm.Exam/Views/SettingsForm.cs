using OOP.FinalTerm.Exam.Repository;
using OOP.FinalTerm.Exam.Views;

namespace OOP.FinalTerm.Exam
{
    public partial class SettingsForm : Form
    {
        #region initialization [DON'T TOUCH]

        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly Color _netflixRed = Color.FromArgb(221, 0, 0);
        private readonly Color _darkBackground = Color.FromArgb(20, 20, 20);
        private readonly Color _hoverColor = Color.FromArgb(50, 50, 50);

        public SettingsForm(IMovieRepository movieRepository)
        {
            InitializeComponent();
            _movieRepository = movieRepository;
            _directorRepository = new DirectorRepository();
            ApplyNetflixTheme();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadMoviesToGrid();
            LoadDirectorsToGrid();
        }

        #endregion

        private void LoadMoviesToGrid()
        {
            try
            {
                dgvMovies.DataSource = _movieRepository.GetAllMovies();
                dgvMovies.Columns["Cover"].Visible = false;
                dgvMovies.Columns["Description"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDirectorsToGrid()
        {
            try
            {
                var directors = _directorRepository.GetAllDirectors();
                dgvDirectors.DataSource = directors;

             
                if (dgvDirectors.Columns.Contains("Id"))
                {
                    dgvDirectors.Columns["Id"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading directors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers [DON'T TOUCH]

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new MovieForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var newMovie = addForm.GetMovie();
                    try
                    {
                        _movieRepository.AddMovie(newMovie);
                        LoadMoviesToGrid();
                        MessageBox.Show("✓ Movie added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding movie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMovie = (MovieModel)dgvMovies.SelectedRows[0].DataBoundItem;

            using (var editForm = new MovieForm(selectedMovie))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var updatedMovie = editForm.GetMovie();
                    try
                    {
                        if (_movieRepository.UpdateMovie(updatedMovie))
                        {
                            LoadMoviesToGrid();
                            MessageBox.Show("✓ Movie updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update movie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating movie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMovie = (MovieModel)dgvMovies.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedMovie.Title}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_movieRepository.DeleteMovie(selectedMovie.Id))
                    {
                        LoadMoviesToGrid();
                        MessageBox.Show("✓ Movie deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete movie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting movie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDirectorAdd_Click(object sender, EventArgs e)
        {
            DirectorForm directorForm = new DirectorForm(_directorRepository);
            if (directorForm.ShowDialog() == DialogResult.OK)
            {
                LoadDirectorsToGrid();
            }
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
                        if (button.Text.Contains("Add"))
                            button.BackColor = _netflixRed;
                        else if (button.Text.Contains("Delete"))
                            button.BackColor = Color.FromArgb(120, 0, 0);
                        else
                            button.BackColor = Color.FromArgb(100, 100, 100);
                    };
                }
                else if (control is TabControl tabControl)
                {
                    tabControl.BackColor = Color.FromArgb(30, 30, 30);
                    tabControl.ForeColor = Color.White;
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
        #endregion
    }
}