using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.DLL.DAO
{
    class Department
    {
        public Department(string name, string code):this()
        {
            Name = name;
            Code = code;
        }

        public Department()
        {
        }

        public int DepartmentId { get; set; }
        public string  Name { get; set; }
        public string Code { get; set; }
    }
}
