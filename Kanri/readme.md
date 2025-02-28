### **Prompt: Employee Management Application in .NET MAUI (MVVM Architecture)**  

#### **Project Overview**  
Develop a **mobile application** using **.NET MAUI** and **SQLite** to manage employees. The application should follow the **MVVM (Model-View-ViewModel) architecture** for clean separation of concerns and maintainability.  

#### **Core Features**  

1. **Employee List (Grid View)**
   - Display all employees in a **Grid** on application load.
   - Ensure the list updates dynamically after any CRUD operation.
   - Clicking on a row should trigger an event to select the employee for modification or deletion.

2. **Add Employee**
   - Implement an "Add" button to insert a new employee.
   - Validate all input fields before adding (no empty values, correct data types).
   - Show an error message if validation fails.

3. **Edit Employee**
   - Implement an "Edit" button to modify employee details.
   - When an employee is selected, populate the form fields with existing data.
   - Allow modifications and save the updated data.

4. **Delete Employee**
   - Implement a "Delete" button to remove an employee from the database.
   - Require the user to select an employee before deletion.
   - Show a confirmation dialog before proceeding.

5. **Export Employee Data via Email**
   - Implement an "Export" button to send an email to `admin@app.com` containing:
     - Total number of employees.
     - Average age of employees.
     - Average salary.
   - Dynamically calculate these values before sending.

---

### **Technical Requirements**  

#### **1. Model (Data Layer)**
   - Create an **Employee model** with the following properties:
     ```csharp
     public class Employee
     {
         public int Id { get; set; } // Auto-increment
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Gender { get; set; } // "Homme" or "Femme"
         public decimal Salary { get; set; }
         public DateTime BirthDate { get; set; }
     }
     ```
   - Use **SQLite** for local data storage.

#### **2. ViewModel (Business Logic Layer)**
   - Implement **`EmployeeViewModel`** to manage UI logic and interact with the database.
   - Use **ObservableCollection** for real-time UI updates.
   - Implement **Commands** for Add, Edit, Delete, and Export functionalities.

#### **3. View (UI Layer)**
   - Implement UI in XAML.
   - Use **Data Binding** to connect ViewModel properties to UI elements.
   - Design a **clean and responsive interface**.

#### **Evaluation Criteria (40 Points)**
| Criteria | Points |
|----------|--------|
| Correct display of employee data in Grid | 5 |
| Adding employees with input validation | 5 |
| Editing employees with pre-filled form | 5 |
| Deleting employees with confirmation | 5 |
| Exporting data via email | 5 |
| Handling row click events in Grid | 5 |
| Clean and well-structured code (MVVM adherence) | 5 |
| Clear and functional user interface | 5 |