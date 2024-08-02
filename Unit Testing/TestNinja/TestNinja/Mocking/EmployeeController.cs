using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IEmployeeRepo _repo;
        private EmployeeContext _db;

        public EmployeeController(IEmployeeRepo repo = null)
        {
            _repo = repo ?? new EmployeeRepo();
            _db = new EmployeeContext();
        }

        public ActionResult DeleteEmployee(int id)
        {
            _repo.DeleteByID(id,_db);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    

    
}