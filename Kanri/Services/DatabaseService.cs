using SQLite;
using Kanri.Models;

namespace Kanri.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        private const string DbName = "employees.db3";

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DbName);
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>().Wait();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _database.Table<Employee>().ToListAsync();
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            return await _database.InsertAsync(employee);
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return await _database.UpdateAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return await _database.DeleteAsync(employee);
        }

        public async Task<(int totalCount, double averageAge, double averageSalary)> GetStatisticsAsync()
        {
            var employees = await GetEmployeesAsync();
            if (!employees.Any())
                return (0, 0, 0);
                
            return (
                employees.Count,
                employees.Average(e => e.Age),
                employees.Average(e => e.Salary)
            );
        }
    }
} 