using System.Data.Entity;
using System.Threading.Tasks;
using ErrorAPI.DB;

namespace ErrorAPI.Repositories
{
    public class ProgramRepository
    {
        public async Task<string> GetContactEmail(string programName)
        {
            using (var dbContext = new ErrorAppContext())
            {
                var program = await dbContext.Programs.FirstOrDefaultAsync(p => p.Name == programName);
                return program?.ContactEmail;
            }
        }
    }
}