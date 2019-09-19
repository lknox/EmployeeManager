using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee_Manager;
using Employee_Manager.Controllers;

namespace Employee_Manager.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateRecord()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            int iRecordCountBefore = (result.Model as List<Employee>).Count();

            Employee employee = new Employee();
            employee.DepartmentId = 1;
            employee.DeskLocation = "X999";
            employee.FirstName = "Testy";
            employee.LastName = "McTesterson";
            employee.HomeAddress1 = "123 Banana Boulevard";
            employee.HomeAddress2 = null;
            employee.HomeCity = "Las Vegas";
            employee.HomePhone = "123-456-7890";
            employee.HomeState = "NV";
            employee.HomeZip = "88888";
            employee.WorkPhone = "123-456-0987";
            result = controller.Create(employee) as ViewResult; // Create the DB record.
            result = controller.Index() as ViewResult; // Read a list back.

            List<Employee> employees = result.Model as List<Employee>;
            int iRecordCountAfter = employees.Count();
            bool addedRecord = (iRecordCountBefore + 1 == iRecordCountAfter);
            int employeeId = employees.First(x => (x.LastName == "McTesterson")).EmployeeId;

            // Clean up.
            controller.DeleteConfirmed(employeeId);
            
            // Assert
            Assert.IsTrue(addedRecord);
        }

        [TestMethod]
        public void EditView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditRecord()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            int iRecordCountBefore = (result.Model as List<Employee>).Count();

            Employee employee = new Employee();
            employee.DepartmentId = 1;
            employee.DeskLocation = "X999";
            employee.FirstName = "Testy";
            employee.LastName = "McTesterson";
            employee.HomeAddress1 = "123 Banana Boulevard";
            employee.HomeAddress2 = null;
            employee.HomeCity = "Las Vegas";
            employee.HomePhone = "123-456-7890";
            employee.HomeState = "NV";
            employee.HomeZip = "88888";
            employee.WorkPhone = "123-456-0987";
            result = controller.Create(employee) as ViewResult; // Create the DB record.

            employee.FirstName = "Testarino";
            result = controller.Edit(employee) as ViewResult; // Edit the DB record.

            result = controller.Index() as ViewResult; // Read a list back.
            List<Employee> employees = result.Model as List<Employee>;

            int employeeId = employees.First(x => (x.FirstName == "Testarino")).EmployeeId; // Find the record we added.

            if (employeeId > -1)
                controller.DeleteConfirmed(employeeId); // Clean up.

            // Assert
            Assert.IsTrue((employeeId > -1));
        }

        [TestMethod]
        public void DeleteView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteRecord()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            int iRecordCountBefore = (result.Model as List<Employee>).Count();

            Employee employee = new Employee();
            employee.DepartmentId = 1;
            employee.DeskLocation = "X999";
            employee.FirstName = "Testy";
            employee.LastName = "McTesterson";
            employee.HomeAddress1 = "123 Banana Boulevard";
            employee.HomeAddress2 = null;
            employee.HomeCity = "Las Vegas";
            employee.HomePhone = "123-456-7890";
            employee.HomeState = "NV";
            employee.HomeZip = "88888";
            employee.WorkPhone = "123-456-0987";
            result = controller.Create(employee) as ViewResult; // Create the DB record.
            result = controller.Index() as ViewResult; // Read a list back.

            List<Employee> employees = result.Model as List<Employee>;
            int iRecordCountAfter = employees.Count();
            bool addedRecord = (iRecordCountBefore + 1 == iRecordCountAfter);
            int employeeId = employees.First(x => (x.LastName == "McTesterson")).EmployeeId;

            // Clean up and delete confirmation.
            bool deleteWorked = true; // Assuming true as default for this test.
            try
            {
                result = controller.DeleteConfirmed(employeeId) as ViewResult;
            }
            catch
            {
                deleteWorked = false;
            }

            // Assert
            Assert.IsTrue(deleteWorked);
        }


    }
}
