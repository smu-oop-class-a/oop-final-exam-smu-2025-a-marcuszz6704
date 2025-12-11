[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/fk9zrUSF)
### ❗❗❗CLONE THIS REPOSITORY BEFORE TAKING THE EXAM❗❗❗
### ❗❗❗CLONE THIS REPOSITORY BEFORE TAKING THE EXAM❗❗❗
### ❗❗❗CLONE THIS REPOSITORY BEFORE TAKING THE EXAM❗❗❗
### ❗❗❗CLONE THIS REPOSITORY BEFORE TAKING THE EXAM❗❗❗
---
# Part 1: Essay
## 👉👉👉 [Essay Questions](https://heartwarming-walrus.static.domains/)

 
# Part 2: Hands-on | Nitplekz Movie Viewer - Director Management System

## 🎬 About

A Windows desktop application for managing and browsing movies and directors. Built with C# and Windows Forms using SQLite for data persistence.

---

## 📋 Exam Task Overview

Implement a **Director Management System** for the Nitplekz application. You will create data models, implement database operations using the repository pattern, and build a UI form. This task builds on the existing Movie management system—follow the same patterns you see there.

---

## 📝 Step-by-Step Implementation Guide for Students

Follow these steps in order to complete the exam task:

### Step 1: Create the Person Model (Base Class)

**File:** `OOP.FinalTerm.Exam\Model\PersonModel.cs`

Create a new C# class called `PersonModel` with the following properties:

- `Id` (int) - Mark with `[PrimaryKey, AutoIncrement]` attributes
- `FirstName` (string)
- `LastName` (string)

**Reference:** Look at `MovieModel.cs` to see how SQLite attributes are used.

### Step 2: Create the Director Model (Inherits from Person)

**File:** `OOP.FinalTerm.Exam\Model\DirectorModel.cs`

1. Make `DirectorModel` inherit from `PersonModel`
2. Add the following properties:
   - `Genres` (string) - Comma-separated list of film genres
   - `TotalMoviesCreated` (int) - Number of movies directed

**Note:** The class skeleton is already in place; you just need to add the properties.

### Step 3: Implement the DirectorRepository

**File:** `OOP.FinalTerm.Exam\Repository\DirectorRepository.cs`

#### Step 3a: Initialize Database Connection

In the constructor, uncomment and implement:

```csharp
_dbConnection = new SQLiteConnection(DatabaseHelper.GetDatabasePath()); 
_dbConnection.CreateTable<DirectorModel>();
```

#### Step 3b: Implement AddDirector()

Add this line inside the method:

```csharp
_dbConnection.Insert(director);
```

#### Step 3c: Implement GetAllDirectors()

Replace the return statement with:

```csharp
return _dbConnection.Table<DirectorModel>().ToList();
```

#### Step 3d: Implement GetDirectorById()

Replace the return statement with:

```csharp
return _dbConnection.Find<DirectorModel>(id);
```

**Reference:** See `MovieRepository.cs` for a complete working example of all these methods.

### Step 4: Implement DirectorForm Methods

**File:** `OOP.FinalTerm.Exam\Views\DirectorForm.cs`

#### Form Controls (Required)

Before implementing the methods, ensure your form has the following controls with the exact property names:

| Label | Control Type | Property Name | Notes |
|-------|--------------|---------------|-------|
| First Name | TextBox | `txtFirstName` | Required field |
| Last Name | TextBox | `txtLastName` | Required field |
| Genres | TextBox | `txtGenres` | Comma-separated values |
| Total Movies | NumericUpDown | `numTotalMovies` | Min: 0, Max: 1000 |
| Save | Button | `btnSave` | Netflix red (#DD0000) |
| Cancel | Button | `btnCancel` | Dark gray (#3C3C3C) |

#### Step 4a: Map Form Controls to Director Properties

In the `GetDirector()` method, add:

```csharp
_director.FirstName = txtFirstName.Text;
_director.LastName = txtLastName.Text;
_director.Genres = txtGenres.Text;
_director.TotalMoviesCreated = (int)numTotalMovies.Value;
return _director;
```

#### Step 4b: Implement Form Validation

In the `BtnSave_Click()` method, add validation before saving:

```csharp
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
```

### Step 5: Load Directors in Settings Form

**File:** `OOP.FinalTerm.Exam\Views\SettingsForm.cs`

In the `LoadDirectorsToGrid()` method, add:

```csharp
var directors = _directorRepository.GetAllDirectors();
dgvDirectors.DataSource = directors;

// Hide the ID column (optional but recommended)
if (dgvDirectors.Columns.Contains("Id"))
{
    dgvDirectors.Columns["Id"].Visible = false;
}
```

**Reference:** The `LoadMoviesToGrid()` method in the same file shows the pattern to follow.

---

## ✅ Testing Checklist

Before submitting, verify the following:

- [ ] DirectorModel inherits from PersonModel
- [ ] DirectorModel has `Genres` and `TotalMoviesCreated` properties
- [ ] DirectorRepository constructor initializes the database connection
- [ ] `AddDirector()` successfully saves directors to the database
- [ ] `GetAllDirectors()` returns all directors from the database
- [ ] `GetDirectorById()` returns the correct director by ID
- [ ] DirectorForm maps all form controls to director properties
- [ ] DirectorForm validates that FirstName and LastName are not empty
- [ ] Directors can be added through the DirectorForm
- [ ] Directors are displayed in the DataGridView in SettingsForm
- [ ] Application compiles without errors
- [ ] Application runs without runtime exceptions

---

## 💡 Tips for Success

1. **Start with the models** - Models must be created first before the repository can use them
2. **Use the Movie system as a reference** - The existing `MovieModel` and `MovieRepository` follow the same patterns you need to implement
3. **Test incrementally** - After each step, compile and test that part works before moving to the next
4. **Read error messages carefully** - They will tell you exactly what's missing or wrong
5. **Keep properties consistent** - Make sure property names match between forms and models
6. **Use the provided hints** - Each TODO comment includes hints about what code to write
7. **Remove TODO comments** - After completing each task, delete the TODO comments from your code to keep it clean and professional

