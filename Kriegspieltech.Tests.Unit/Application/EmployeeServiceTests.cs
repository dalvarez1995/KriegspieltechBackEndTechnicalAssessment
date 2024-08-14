using Domain.Entities;
using Kriegspieltech.Application.Services;
using Kriegspieltech.Domain.Repositories;
using Moq;

namespace Kriegspieltech.Tests.Unit.Application
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private EmployeeService _employeeService;

        [TestInitialize]
        public void Setup()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object);
        }

        [TestMethod]
        public void AddEmployee_ShouldCallInsertOnRepository()
        {
            // Arrange
            var employee = new Employee { Id = 1, FullName = "Dominic Alvarez" };

            // Act
            _employeeService.AddEmployee(employee);

            // Assert
            _mockEmployeeRepository.Verify(repo => repo.Insert(employee), Times.Once);
        }

        [TestMethod]
        public void GetByFullName_ShouldReturnEmployees()
        {
            // Arrange
            var fullname = "Dominic Alvarez";
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FullName = fullname },
                new Employee { Id = 2, FullName = fullname }
            };
            _mockEmployeeRepository.Setup(repo => repo.GetByFullName(fullname)).Returns(employees);

            // Act
            var result = _employeeService.GetByFullName(fullname);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(e => e.FullName == fullname));
        }

        [TestMethod]
        public void GetById_ShouldReturnEmployee()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { Id = employeeId, FullName = "Dominic Alvarez" };
            _mockEmployeeRepository.Setup(repo => repo.GetById(employeeId)).Returns(employee);

            // Act
            var result = _employeeService.GetById(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result?.Id);
            Assert.AreEqual("Dominic Alvarez", result?.FullName);
        }

        [TestMethod]
        public void RemoveEmployee_ShouldCallDeleteOnRepository()
        {
            // Arrange
            var employee = new Employee { Id = 1, FullName = "Dominic Alvarez" };

            // Act
            _employeeService.RemoveEmployee(employee);

            // Assert
            _mockEmployeeRepository.Verify(repo => repo.Delete(employee), Times.Once);
        }
    }
}