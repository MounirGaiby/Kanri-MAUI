### **Prompt: Employee Management App in .NET 9 MAUI (Without MVVM, No External Libraries)**

#### **Objective**
Develop a simple **mobile application** using **.NET 9 MAUI** and **SQLite** to manage employees. The application should allow users to **view, add, edit, delete, and export employee data via email**.  

#### **Application Features**  

1. **Employee List (Grid View)**
   - Display all employees in a **Grid** when the app loads.
   - Refresh the list after each action (add, edit, delete).
   - Clicking a row should allow selecting an employee for modification or deletion.

2. **Add Employee**
   - A form with fields: **First Name, Last Name, Gender, Salary, Birthdate**.
   - Validate inputs before saving (ensure required fields are filled correctly).
   - Show an error message if validation fails.

3. **Edit Employee**
   - Select an employee from the grid, which fills the form with existing data.
   - Allow users to modify details and save changes.

4. **Delete Employee**
   - Select an employee and click "Delete" to remove them from the database.
   - Show a **confirmation dialog** before deletion.

5. **Export Employee Data via Email**
   - A button to send an email with:
     - **Total employees count**  
     - **Average employee age**  
     - **Average salary**  
   - The email should be sent to `admin@app.com`.

---

### **Technical Requirements**  

1. **Use SQLite for Data Storage**  
   - Create a simple **Employee** table:
     ```sql
     CREATE TABLE Employees (
         Id INTEGER PRIMARY KEY AUTOINCREMENT,
         FirstName TEXT NOT NULL,
         LastName TEXT NOT NULL,
         Gender TEXT CHECK(Gender IN ('Homme', 'Femme')) NOT NULL,
         Salary REAL NOT NULL,
         BirthDate TEXT NOT NULL
     );
     ```

2. **Use Simple Code-Behind Approach**  
   - Handle UI logic directly in the code-behind.
   - Use **event handlers** for button clicks.

3. **UI Design**  
   - Use **XAML for UI**.
   - Simple layout with **Entry fields, Buttons, and Grid** for displaying employees.

4. **Email Sending**
   - Implement **email export functionality** using built-in .NET MAUI features (no external SMTP libraries).

---

### **Evaluation Criteria (40 Points)**
| Criteria | Points |
|----------|--------|
| Displaying employees correctly in the Grid | 5 |
| Adding employees with validation | 5 |
| Editing employees with pre-filled form | 5 |
| Deleting employees with confirmation | 5 |
| Exporting data via email | 5 |
| Handling row selection in the Grid | 5 |
| Simple, clean, and maintainable code | 5 |
| Functional and clea