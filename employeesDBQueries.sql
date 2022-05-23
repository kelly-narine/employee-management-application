CREATE DATABASE EmployeeDB;

CREATE TABLE dbo.Department(
DepartmentId INT IDENTITY(1,1),
DepartmentName VARCHAR(500)
);

SELECT * FROM dbo.Department;

INSERT INTO dbo.Department 
 VALUES('Support'); /* DepartmentId is already autoincremented, so no value needs to be inserted for it*/

CREATE TABLE dbo.Employee(
EmployeeId INT IDENTITY(1,1),
EmployeeName VARCHAR(500),
Department VARCHAR(500),
DateOfJoining DATE,
PhotoFileName VARCHAR(500)
);

SELECT * FROM dbo.Employee;

INSERT INTO dbo.Employee
 VALUES('Sam', 'IT', '2020-06-01', 'anonymous.png');