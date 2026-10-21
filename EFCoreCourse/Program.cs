namespace EFCoreCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CRUD Operations - Query Object Model
            //using CompanyDbContext dbContext = new CompanyDbContext();

            //Employee employee = new Employee()
            //{
            //    EmpName = "Omar",
            //    Age = 25,
            //    Email = "OmarTarek@gmail.com",
            //    Password = "P@ssw0rd",
            //    PhoneNumber = "012345678",
            //    Salary = 6000
            //};
            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            //Console.WriteLine(dbContext.Entry(employee).State); // Detached
            //Console.WriteLine(employee.EmpId); // 0

            #region Add New Row In Table Employees In Database
            //dbContext.Employees.Add(employee);
            ////dbContext.Set<Employee>().Add(employee);
            ////dbContext.Add(employee);
            ////dbContext.Entry(employee).State = EntityState.Added;
            //Console.WriteLine("After Adding In DbSet ");
            //Console.WriteLine(dbContext.Entry(employee).State); // Added
            //Console.WriteLine($"Emp01 Id : {employee.EmpId}"); // 0
            //dbContext.SaveChanges();
            //Console.WriteLine("After Save Changes");
            //Console.WriteLine(dbContext.Entry(employee).State); // UnChanged
            //Console.WriteLine($"Emp01 Id : {employee.EmpId}"); // 20

            #endregion

            #region Retrieve Data From Database 
            ////dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            //var employee01 = dbContext.Set<Employee>().AsNoTracking().FirstOrDefault(E => E.EmpName == "Omar");
            //if (employee01 is not null)
            //{
            //	Console.WriteLine(dbContext.Entry(employee01).State);// Detached
            //	Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}");
            //}

            //var employee02 = dbContext.Employees.FirstOrDefault(E => E.EmpName == "Aliaa");

            //if (employee02 is not null)
            //{
            //	Console.WriteLine(dbContext.Entry(employee02).State);// UnChanged
            //	Console.WriteLine($"{employee02.EmpId} - {employee02.EmpName} - {employee02.Email}");
            //}

            #endregion

            #region Modify Data In Database 

            //var employee01 = dbContext.Employees.AsNoTracking().FirstOrDefault(E => E.EmpId == 20);
            //if (employee01 is not null)
            //{
            //    Console.WriteLine($"Employee01 State = {dbContext.Entry(employee01).State}"); // Detached
            //    Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}"); // 20 - Omar - Omar@gmail.com
            //    employee01.EmpName = "Ahmed";

            //    Console.WriteLine("After Changing Name ");
            //    Console.WriteLine($"Employee01 State = {dbContext.Entry(employee01).State}"); // Detached
            //    Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}"); // 10 - Ahmed - Aliaatarek@gmail.com
            //    dbContext.SaveChanges();
            //    Console.WriteLine("After SaveChanges()");
            //    Console.WriteLine($"Employee01 State = {dbContext.Entry(employee01).State}"); // Detached
            //    Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}"); // 10 - Ahmed - Aliaatarek@gmail.com
            //}

            #endregion

            #region Remove Data from Database 

            //var employee01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 20);
            //if(employee01 is not null)
            //{
            //	Console.WriteLine($"Employee01 State = {dbContext.Entry(employee01).State}"); // Unchanged
            //	Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}"); // 20 - Omar - Omar@gmail.com


            //	dbContext.Employees.Remove(employee01);
            //	//dbContext.Set<Employee>().Remove(employee01);
            //	//dbContext.Remove(employee01);
            //	//dbContext.Entry(employee01).State = EntityState.Deleted;


            //	Console.WriteLine("After Removing Employee01 From Dbset");
            //	Console.WriteLine($"Employee01 State = {dbContext.Entry(employee01).State}"); // Deleted
            //	Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}"); // 20 - Omar - Omar@gmail.com

            //	dbContext.SaveChanges();
            //	Console.WriteLine("After SaveChanges()");
            //	Console.WriteLine($"Employee01 State = {dbContext.Entry(employee01).State}"); // Detached
            //	Console.WriteLine($"{employee01.EmpId} - {employee01.EmpName} - {employee01.Email}"); // 20 - Omar - Omar@gmail.com


            //}

            #endregion

            #region Bulk Operations

            ////var employees = dbContext.Employees.Where(e => e.Salary >= 5000).ToList();
            ////foreach (var employee in employees)
            ////{
            ////    employee.Salary *= 1.2m;
            ////}
            ////dbContext.SaveChanges();


            //dbContext.Employees.Where(e => e.Salary >= 5000)
            //    .ExecuteUpdate(e => e.SetProperty(emp => emp.Salary, emp => emp.Salary * 1.2m));
            #endregion

            #endregion

            #region Data Seeding 

            //if (!dbContext.Set<Customer>().Any())
            //{
            //    dbContext.Set<Customer>().AddRange(
            //        new Customer { Name = "Ahmed Mohamed" },
            //        new Customer { Name = "Salma Osama" },
            //        new Customer { Name = "Mariam Ahmed" }
            //    );

            //    //// Data From File
            //    //List<Customer> Customers = new()
            //    //{
            //    //    new Customer { Name = "Ahmed Mohamed" },
            //    //    new Customer { Name = "Salma Osama" },
            //    //    new Customer { Name = "Mariam Ahmed" }
            //    //};

            //    //dbContext.AddRange(Customers);

            //    dbContext.SaveChanges();

            //    Console.WriteLine("Customers Data Seeded");
            //}

            #endregion
        }
    }
}
