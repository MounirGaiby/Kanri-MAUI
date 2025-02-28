using Kanri.Models;
using Kanri.Services;
using System.Collections.ObjectModel;

namespace Kanri;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private ObservableCollection<Employee> _employees;
    private Employee _selectedEmployee;
    public bool IsEmployeeSelected => _selectedEmployee != null;

    public MainPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
        _employees = new ObservableCollection<Employee>();
        EmployeesCollection.ItemsSource = _employees;
        LoadEmployees();
    }

    private async void LoadEmployees()
    {
        var employees = await _databaseService.GetEmployeesAsync();
        _employees.Clear();
        foreach (var employee in employees)
        {
            _employees.Add(employee);
        }
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedEmployee = e.CurrentSelection.FirstOrDefault() as Employee;
        if (_selectedEmployee != null)
        {
            FirstNameEntry.Text = _selectedEmployee.FirstName;
            LastNameEntry.Text = _selectedEmployee.LastName;
            GenderPicker.SelectedItem = _selectedEmployee.Gender;
            SalaryEntry.Text = _selectedEmployee.Salary.ToString();
            BirthDatePicker.Date = _selectedEmployee.BirthDate;
        }
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        _selectedEmployee = null;
        ClearForm();
        EmployeeForm.IsVisible = true;
    }

    private void OnEditClicked(object sender, EventArgs e)
    {
        if (_selectedEmployee != null)
        {
            EmployeeForm.IsVisible = true;
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selectedEmployee == null) return;

        bool answer = await DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer cet employé ?", "Oui", "Non");
        if (answer)
        {
            await _databaseService.DeleteEmployeeAsync(_selectedEmployee);
            LoadEmployees();
            _selectedEmployee = null;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        var employee = new Employee
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            Gender = GenderPicker.SelectedItem?.ToString(),
            Salary = double.Parse(SalaryEntry.Text),
            BirthDate = BirthDatePicker.Date
        };

        if (_selectedEmployee != null)
        {
            employee.Id = _selectedEmployee.Id;
            await _databaseService.UpdateEmployeeAsync(employee);
        }
        else
        {
            await _databaseService.AddEmployeeAsync(employee);
        }

        LoadEmployees();
        ClearForm();
        EmployeeForm.IsVisible = false;
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        ClearForm();
        EmployeeForm.IsVisible = false;
    }

    private async void OnExportClicked(object sender, EventArgs e)
    {
        var stats = await _databaseService.GetStatisticsAsync();
        
        try
        {
            var message = new EmailMessage
            {
                Subject = "Statistiques des Employés",
                Body = $"Nombre total d'employés: {stats.totalCount}\n" +
                      $"Moyenne d'âge des employés: {stats.averageAge:F1} ans\n" +
                      $"Moyenne des salaires: {stats.averageSalary:N2} DH",
                To = new List<string> { "admin@app.com" }
            };
            
            await Email.Default.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'envoyer l'email: " + ex.Message, "OK");
        }
    }

    private void ClearForm()
    {
        FirstNameEntry.Text = string.Empty;
        LastNameEntry.Text = string.Empty;
        GenderPicker.SelectedItem = null;
        SalaryEntry.Text = string.Empty;
        BirthDatePicker.Date = DateTime.Today;
    }

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text))
        {
            DisplayAlert("Erreur", "Le prénom est obligatoire", "OK");
            return false;
        }

        if (string.IsNullOrWhiteSpace(LastNameEntry.Text))
        {
            DisplayAlert("Erreur", "Le nom est obligatoire", "OK");
            return false;
        }

        if (GenderPicker.SelectedItem == null)
        {
            DisplayAlert("Erreur", "Le genre est obligatoire", "OK");
            return false;
        }

        if (!double.TryParse(SalaryEntry.Text, out _))
        {
            DisplayAlert("Erreur", "Le salaire doit être un nombre valide", "OK");
            return false;
        }

        return true;
    }
}
