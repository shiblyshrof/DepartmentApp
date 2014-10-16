using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentApp.DLL.DAO;
using DepartmentApp.DLL.Gateway;

namespace DepartmentApp.BLL
{
    class DepartmentBLL
    {
        DepartmentGetway aDepartmentGetway = new DepartmentGetway();
        public string Save(Department aDepartment)
        {

            if (aDepartment.Name == string.Empty || aDepartment.Code == string.Empty)
            {
                return "pls fill up the box";
            }
            else
            {
                if ((HasThisNameValid(aDepartment.Name)) || (HasThisCodeValid(aDepartment.Code)))
                {
                    string msg = "";
                    if (HasThisNameValid(aDepartment.Name))
                    {
                        msg += "name already in system";
                    }
                    if (HasThisCodeValid(aDepartment.Code))
                    {
                        msg += "code already in system";
                    }
                    return msg;
                    
                }
                else
                {
                    return aDepartmentGetway.Save(aDepartment);
                }

            }

        }

        private bool HasThisNameValid(string name)
        {
            return aDepartmentGetway.HasThisNameValid(name);
        }

        private bool HasThisCodeValid(string code)
        {
            return aDepartmentGetway.HasThisCodeValid(code);
        }

        public List<Department> GetAllDepartment()
        {
            return aDepartmentGetway.GetAllStudent();
        }
    }
}
