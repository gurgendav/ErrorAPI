using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ErrorAPI.DB;
using ErrorAPI.DB.Entities;

namespace ErrorAPI.Repositories
{
    public class ErrorRepository
    {
        /// <summary>
        /// Add error record into database
        /// </summary>
        /// <param name="errorDetails"></param>
        /// <returns>Whether this is new error or not</returns>
        public async Task<bool> AddErrorDetails(DTO.ErrorDetails errorDetails)
        {
            using (var dbContext = new ErrorAppContext())
            {
                var program = await dbContext.Programs.FirstOrDefaultAsync(p => p.Name == errorDetails.ProgramName);
                if (program == null)
                {
                    program = new Program
                    {
                        Name = errorDetails.ProgramName
                    };
                    dbContext.Programs.Add(program);
                }

                var isNewError = false;
                var error = await dbContext.Errors.FirstOrDefaultAsync(e => e.Program.Name == errorDetails.ProgramName &&
                                                                 e.ExceptionType == errorDetails.ExceptionDetails
                                                                     .ExceptionType &&
                                                                 e.ExceptionMessage == errorDetails.ExceptionDetails
                                                                     .ExceptionMessage &&
                                                                 e.StackTrace == errorDetails.ExceptionDetails
                                                                     .StackTrace);
                if (error == null)
                {
                    isNewError = true;
                    error = new Error
                    {
                        Program = program,
                        ExceptionMessage = errorDetails.ExceptionDetails.ExceptionMessage,
                        ExceptionName = errorDetails.ExceptionDetails.ExceptionName,
                        ExceptionType = errorDetails.ExceptionDetails.ExceptionType,
                        StackTrace = errorDetails.ExceptionDetails.StackTrace
                    };
                    dbContext.Errors.Add(error);
                }

                var errorDetailsEntity = new ErrorDetails
                {
                    CanUserContinue = errorDetails.ExceptionHandlingDetails.CanContinue,
                    DidUserContinue = errorDetails.ExceptionHandlingDetails.UserContinues,
                    DateUtc = errorDetails.EnvironmentDetails.DateUtc,
                    FaultingContextDetails = errorDetails.FaultingContextDetails,
                    MachineName = errorDetails.EnvironmentDetails.MachineName,
                    MachineOsVersion = errorDetails.EnvironmentDetails.MachineOsVersion,
                    UsedMemoryMb = errorDetails.EnvironmentDetails.UsedMemoryMb,
                    UserName = errorDetails.EnvironmentDetails.UserName,
                    Version = errorDetails.EnvironmentDetails.Version,
                    Error = error
                };
                error.ErrorDetails.Add(errorDetailsEntity);

                await dbContext.SaveChangesAsync();

                return isNewError;
            }
        }

        public async Task<List<Models.Error>> GetErrors()
        {
            using (var dbContext = new ErrorAppContext())
            {
                return await dbContext.Errors
                    .OrderByDescending(e => e.ErrorDetails.Select(d => d.DateUtc).Max())
                    .Select(e => new Models.Error
                    {
                        Id = e.Id,
                        ExceptionName = e.ExceptionName,
                        ExceptionMessage = e.ExceptionMessage,
                        ExceptionType = e.ExceptionType,
                        ProgramName = e.Program.Name,
                        StackTrace = e.StackTrace,
                        OccurenceCount = e.ErrorDetails.Count
                    }).ToListAsync();
            }
        }

        public async Task<Models.Error> GetError(int id)
        {
            using (var dbContext = new ErrorAppContext())
            {
                return await dbContext.Errors.Select(e => new Models.Error
                {
                    Id = e.Id,
                    ExceptionName = e.ExceptionName,
                    ExceptionMessage = e.ExceptionMessage,
                    ExceptionType = e.ExceptionType,
                    ProgramName = e.Program.Name,
                    StackTrace = e.StackTrace,
                    OccurenceCount = e.ErrorDetails.Count,
                    ErrorDetails = e.ErrorDetails
                        .OrderBy(d => d.DateUtc)
                        .Select(d => new Models.ErrorDetails
                        {
                            CanUserContinue = d.CanUserContinue,
                            DateUtc = d.DateUtc,
                            DidUserContinue = d.DidUserContinue,
                            FaultingContextDetails = d.FaultingContextDetails,
                            MachineOsVersion = d.MachineOsVersion,
                            MachineName = d.MachineName,
                            UsedMemoryMb = d.UsedMemoryMb,
                            UserName = d.UserName,
                            Version = d.Version
                        }).ToList()
                }).FirstAsync(e => e.Id == id);
            }
        }
    }
}