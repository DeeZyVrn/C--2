using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyWPF
{
    class Department
    {
        public string Dep { get; set; }

        List<Department> departments = new List<Department>();
        public void AddDep()
        {
            departments.Add(new Department() { Dep = "Отдел приветствия" });
            departments.Add(new Department() { Dep = "Отдел работы" });
            departments.Add(new Department() { Dep = "Отдел прощания" });
        }
    }
}
