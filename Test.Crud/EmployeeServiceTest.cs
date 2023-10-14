using Crud.Models;
using Crud.Services;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Test.Crud
{
    public class EmployeeServiceTest
    {
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeService = new EmployeeService
            {
                Employees = new List<Employee>()
            };
        }

        /*
         Crear un metodo privado que retorne una lista 
        cargada con 3 elementos distintos
        donde el segundo elemento de lista el el email nulo
         */

        private List<Employee> ListaCargada()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Address = "cr 25 ·7b bis 04",
                    Email = "carlos.castilla@devzeros.com",
                    Name = "DevZeros S.",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Phone = "3148397980"
                },
                new Employee()
                {
                    Address = "cr 25 ·7b bis 04",
                    Email = null,
                    Name = "DevZeros S.A.S",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Phone = "3148397980"
                },
                new Employee
                {
                    Address = "cr 25 ·7b bis 04",
                    Email = "carlos.castilla@devzeros.com",
                    Name = "DevZeros S.",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Phone = "3148397980"
                },
            };
        }


        [Test]
        public void CreateTestSuccess()
        {

            var employee = ListaCargada()[0];
            var value = _employeeService.Create(employee);
            Assert.That(value, Is.EqualTo(1));
        }

       
        [Test]
        public void CreateTestFailWhenNullEntity()
        {
           
            //este assert me indica que devolvio 0 ya que existe
            var exc = Assert.Throws<Exception>(() =>
            {
                var value2 = _employeeService.Create(null);

            });
            Assert.That(exc.Message, Is.EqualTo("Null entity"));

        }
        [Test]
        public void CreateTestWhereNullEmail()
        {
            var employe = ListaCargada()[1];
            
            var exc = Assert.Throws<Exception>(() =>
            {
                var value2 = _employeeService.Create(employe);

            });
            //
            Assert.That(exc.Message, Is.EqualTo("Null Email"));
        }
        [Test]
        public void CreateTestFailNoCreateWhereExistDuplicate()
        {
            var employee = ListaCargada()[0];
            var value1 = _employeeService.Create(employee);
            //este assert me indica que devolvio 0 ya que existe
            var exc = Assert.Throws<Exception>(() =>
            {
                var value2 = _employeeService.Create(employee);

            });
        Assert.That(value1, Is.EqualTo(1));
            Assert.That(exc.Message, Is.EqualTo("There's exist the mail already"));
        }
        [Test]
        public void EmployeeDoesExist()
        {
            _employeeService.Employees = null;
            var exc = Assert.Throws<Exception>(() =>
            {
                var employee = ListaCargada()[0];
                var value2 = _employeeService.Create(employee);

            });
            Assert.That(exc.Message, Is.EqualTo("There's no employee exist"));
        }

    }
}