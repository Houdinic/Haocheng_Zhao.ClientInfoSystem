using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employees> AddNewEmployee(EmployeeRequestModel model)
        {
            var salt = CreateSalt();
            var hashedPassword = HashPassword(model.Password, salt);
            var employee = new Employees()
            {
                Name = model.Name,
                Password = hashedPassword,
                Salt=salt,
                Designation = model.Designation,
            };
            await _employeeRepository.AddAsync(employee);
            return employee;
        }

        public async Task<List<EmployeeResponseModel>> AllEmployees()
        {
            
            var employees=await _employeeRepository.ListAllAsync();
            var models = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                models.Add(new EmployeeResponseModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Designation = employee.Designation,
                });
            }
            return models;
        }

        public async Task<Employees> DeleteEmployee(EmployeeRequestModel model)
        {
            var employee = new Employees()
            {
                Id = model.Id
            };
            return await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception($"Cannot find client with primary key {id} in DB ");
            }
            var model = new EmployeeResponseModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Designation=employee.Designation
            };
            var interactModels = new List<InteractionResponseModel>();
            foreach (var interaction in employee.Interactions)
            {
                interactModels.Add(new InteractionResponseModel()
                {
                    Id = interaction.Id,
                    EmpId = interaction.EmpId,
                    ClientId = interaction.ClientId,
                    IntDate = interaction.IntDate,
                    IntType = interaction.IntType,
                    Remarks = interaction.Remarks,

                });
            }
            model.InteractionModels = interactModels;
            return model;
        }

        public async Task<Employees> UpdateEmployee(EmployeeRequestModel model)
        {
            var employee = new Employees()
            {
                Id=model.Id,
                Name=model.Name,
                Designation=model.Designation,

            };
            await _employeeRepository.UpdateAsync(employee);
            return employee;
        }

        private string HashPassword(string password, string salt)
        {
            // Aarogon
            // Pbkdf2
            // BCrypt
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                    password: password,
                                                                    salt: Convert.FromBase64String(salt),
                                                                    prf: KeyDerivationPrf.HMACSHA512,
                                                                    iterationCount: 10000,
                                                                    numBytesRequested: 256 / 8));
            return hashed;
        }
        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
    }
}
