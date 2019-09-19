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
    public class DepartmentsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateView()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateRecord()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            int iRecordCountBefore = (result.Model as List<Department>).Count();

            Department department = new Department();
            department.Name = "TestDepartment";
            department.Description = "TestDepartment";

            result = controller.Create(department) as ViewResult; // Create the DB record.
            result = controller.Index() as ViewResult; // Read a list back.

            List<Department> departments = result.Model as List<Department>;
            int iRecordCountAfter = departments.Count();
            bool addedRecord = (iRecordCountBefore + 1 == iRecordCountAfter);
            int departmentId = departments.First(x => (x.Name == "TestDepartment")).DepartmentId;

            // Clean up.
            controller.DeleteConfirmed(departmentId);

            // Assert
            Assert.IsTrue(addedRecord);
        }

        [TestMethod]
        public void EditView()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditRecord()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            int iRecordCountBefore = (result.Model as List<Department>).Count();

            Department department = new Department();
            department.Name = "TestDepartment";
            department.Description = "TestDepartment";
            result = controller.Create(department) as ViewResult; // Create the DB record.

            department.Name = "TestarinoDepartment";
            result = controller.Edit(department) as ViewResult; // Edit the DB record.

            result = controller.Index() as ViewResult; // Read a list back.
            List<Department> departments = result.Model as List<Department>;

            int departmentId = departments.First(x => (x.Name == "TestarinoDepartment")).DepartmentId; // Find the record we added.

            if (departmentId > -1)
                controller.DeleteConfirmed(departmentId); // Clean up.

            // Assert
            Assert.IsTrue((departmentId > -1));
        }

        [TestMethod]
        public void DeleteView()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteRecord()
        {
            // Arrange
            DepartmentsController controller = new DepartmentsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            int iRecordCountBefore = (result.Model as List<Department>).Count();

            Department department = new Department();
            department.Name = "TestDepartment";
            department.Description = "TestDepartment";
            result = controller.Create(department) as ViewResult; // Create the DB record.
            result = controller.Index() as ViewResult; // Read a list back.

            List<Department> departments = result.Model as List<Department>;
            int iRecordCountAfter = departments.Count();
            bool addedRecord = (iRecordCountBefore + 1 == iRecordCountAfter);
            int departmentId = departments.First(x => (x.Name == "TestDepartment")).DepartmentId;

            // Clean up and delete confirmation.
            bool deleteWorked = true; // Assuming true as default for this test.
            try
            {
                result = controller.DeleteConfirmed(departmentId) as ViewResult;
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
