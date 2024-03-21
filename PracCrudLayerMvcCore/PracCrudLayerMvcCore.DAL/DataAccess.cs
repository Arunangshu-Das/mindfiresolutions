using Microsoft.EntityFrameworkCore;
using PracCrudLayerMvcCore.DAL.Models;
using PracCrudLayerMvcCore.Models;
using PracCrudLayerMvcCore.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracCrudLayerMvcCore.DAL
{
    public class DataAccess : IDataAccess
    {

        private readonly PracticeContext context;

        private readonly ILogger logger;

        public DataAccess(PracticeContext context,ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<bool> UpdateData(StudentModel s)
        {
            bool flag = false;
            try
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    var studentToUpdate = await context.Students.FirstOrDefaultAsync(stu => stu.StudentId == s.StudentId);
                    if (studentToUpdate != null)
                    {
                        studentToUpdate.Name = s.Name;
                        studentToUpdate.Email = s.Email;
                        studentToUpdate.Salaryamt = s.Salaryamt;

                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        flag = true;
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                    }
                    logger.AddException(new Exception("Hello"));
                }
            }
            catch (Exception ex)
            {
                logger.AddException(ex);
            }
            return flag;
        }

        public async Task<bool> DeleteData(StudentModel s)
        {
            bool flag = false;
            try
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    var studentToUpdate = await context.Students.FirstOrDefaultAsync(stu => stu.StudentId == s.StudentId);
                    if (studentToUpdate != null)
                    {
                        context.Students.Remove(studentToUpdate);
                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        flag = true;
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                logger.AddException(ex);
            }
            return flag;
        }

        public async Task<bool> AddData(StudentModel s)
        {
            bool flag = false;
            try
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var newStudent = new Student
                        {
                            Name = s.Name,
                            Email = s.Email,
                            Salaryamt = s.Salaryamt
                        };
                        await context.Students.AddAsync(newStudent);
                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        logger.AddException(ex);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.AddException(ex);
            }
            return flag;
        }

        public async Task<List<StudentModel>> ListData()
        {
            var alldata = new List<StudentModel>();

            try
            {
                var result = await context.Students.ToListAsync();

                foreach (var student in result)
                {
                    alldata.Add(new StudentModel
                    {
                        Name = student.Name,
                        Email = student.Email,
                        Salaryamt = student.Salaryamt,
                        StudentId = student.StudentId
                    });
                }
            }
            catch(Exception ex)
            {
                logger.AddException(ex);
            }

            return alldata;
        }

        public string GettestData()
        {
            return DateTime.Now.ToString();
        }
    }
}
