# EmployeeManager
 An exercise to demonstrate MVC knowledge.



Assignment
 Required:
  •	Use of C#, ASP.NET MVC, and Entity Framework – Completed.
  •	CRUD for Departments – Completed.
  •	CRUD for Employees (including contact information) – Completed.
  •	Ability to associate an Employee with a Department – Completed, this is a dropdown list on the Create/Edit Employee singleton view.
  •	Ability to view a list of all Employees in a Department – Completed, this is a dropdown filtering list on the Employee Index list view.
  •	Instructions on how to install/run/test the application – Completed. Instructions to follow in this email message.
  Bonus Points (not required):
  •	Use of ASP.NET Core MVC and Entity Framework Core – Used Standard Framework. Have used Core but not with MVC.
  •	A passing test suite – Completed. All controllers have full tests for all actions.
  •	A non-ugly UI – Completed.

Installation Notes and Assumptions
 Note 1: A demonstration version of the MVC web site is available here. http://rkl-lhp-360r-0z.corp.emfbroadcasting.com/ecm
 Note 2: The web server and database server are the same machine for demo purposes.
 Note 3: The solution was written using Visual Studio 2017 Professional, version 15.9.6 and SQL Server 2017

 Assumption 1: The web server and database server are the same machine for demo purposes.
  If this is not true, you may have to change the connection strings for the MVC web app and the Unit Tests projects.
  See the Troubleshooting section below.
 Assumption 2: You are installing the database on a database server with SQL Server (2017 or later) and SSMS installed.
 Assumption 3: You are installing the web site on a web server with IIS10 with ASP.NET 4.7 
  -or- you are running the web site directly from Visual Studio 2017  (using the integrated IIS Express)
  If any of these assumptions are incorrect, I can provide a more detail set of installation instructions.

Download the code
•	Go to this Github link and download the code as a ZIP file: https://dddddd 
•	Unzip the file to a convenient location in your user profile folder.

Installing the database
 •	Open SQL Server Management Studio on a computer with SQL Server installed, connect to localhost and open the Databases folder.
 •	Right-click the Databases folder and select New Database… to bring up the New Database screen.
 •	Enter the database name ECM (abbreviation for Employee Contact Manager) and click OK to create an empty database with all defaults.
 •	Locate the file EmployeeManagerDB.bak in the “Employee Manager” project of the “Employee Manager” solution which you previously unzipped.
 •	Restore the EmployeeManagerDB.bak file over the new empty ECM database using the SSMS GUI. 
  o	Right-click the ECM database, select Tasks | Restore | Database…
  o	In the Restore Database dialog, on the General page, select the Device option, select the ellipses (…) to browse for the file EmployeeManagerDB.bak
  o	In the Restore Database dialog, on the Options page, 
   	Select the Overwrite the existing database checkbox
   	Unselect the Take tail-log backup before restore checkbox
   	Select the Close existing connections to destination database checkbox
   	Click OK
 •	Database security
  o	Create a new login with SQL Server authentication
   	Right-click the folder Security | Logins folder under the localhost instance, select the menu item New Login…
   	On the General page, select the SQL Server authentication option
   	Enter the Login name EcmUser and enter the password p@ssw0rd
   	On the User Mapping page, click the checkbox next to the ECM database, and select db_owner for role membership.
   	Click OK
 •	NOTE: There is some default data in the Department and Employee tables for demonstration purposes.

Running unit tests
 •	You will run the unit tests from Visual Studio, they are currently set up to run under the SQL authentication account EcmUser with password p@ssw0rd
  o	Locate the file Employee Manager.sln in the newly unzipped Employee Manager folder (described above).
  o	Open this solution file with Visual Studio 2017
  o	Right-click the solution and select the Rebuild Solution menu item.
  o	In Visual Studio, navigate the following menus/submenus to see the included unit tests and their statuses in the Test Explorer: View | Other Windows | Test Results
  o	Next, navigate menus to Test | Run | All Tests and select the All Tests menu item to begin running the unit tests.
  o	Results will appear in the Test Explorer.

Installing and/or Running the web site
 •	If you want to run the web site from Visual Studio
  o	Right click the Employee Manager project and select the menu item Set as StartUp Project
  o	Hit the F5 key to start the web site under the integrated Visual Studio IIS Express
 •	If you want to run the web site from IIS 10 with the ASP.NET 4.7 feature installed
  o	Right click the Employee Manager project and select the menu item Publish…
  o	On the Publish screen, select the New Profile… link. 
  o	On the Pick a publish target screen
   	Select the Folder list item on the left. Click the Browse button and select a folder on your local computer to which Visual Studio has access. For example C:\ecm
   	Select the Advanced… link
   	Click the Publish button
   	Copy the C:\ecm folder and its contents to the IIS server
  o	Open the Internet Information Services (IIS) Manager application
  o	Navigate to the Default Web Site in IIS, right-click it and select the menu item Add Application…
  o	In the Add Application dialog
   	Enter ecm for Alias
   	Click the ellipsis (…) and browse to the ecm folder you copied to the IIS server
   	Click OK

Troubleshooting
 •	Can’t connect to database
  o	There are two files you may need to alter for the web site project and for the unit test project to talk to the database, if you did not use the EcmUser login with password p@ssw0rd -or- if you installed the database on a different server
   	Locate the Web.config file in the Employee Manager project
    •	On line #60 is the connection string for the database. Ensure that it reflects the correct User ID and Password for the ECM database
    •	Ensure it reflects the server name of the database server for the property data source. Currently, it is set to localhost
   	Locate the App.config file in the Employee Manager.Tests project
    •	On line #17 is the connection string for the database. Ensure that it reflects the correct User ID and Password for the ECM database
    •	Ensure it reflects the server name of the database server for the property data source. Currently, it is set to localhost



