using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using StarTED.Data.Entities;
using StarTEDSystem.DAL;
using System.Data.SqlClient;
#endregion
namespace StarTEDSystem.BLL
{
   public class ProgramsController
    {
        public List<Programs> Programs_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.Programs.ToList();
            }
        }
        public Programs Programs_FindByProgramID(int programid)
        {
            using (var context = new StarTEDContext())
            {
                return context.Programs.Find(programid);
            }
        }

        //public List<Programs> Programs_FindByProgramName(string programname)
        //{
        //    using (var context = new StarTEDContext())
        //    {
        //        IEnumerable<Programs> results =
        //            context.Database.SqlQuery<Programs>("Programs_FindByProgramName @programname",
        //                             new SqlParameter("programname", programname));
        //        return results.ToList();
        //    }
        //}
    }
}
