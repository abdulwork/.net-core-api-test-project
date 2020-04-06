using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodosDBContext db;
        public TodosController(TodosDBContext _db)
        {
            db = _db;
        }



        /// <summary>
        /// LogIn Method is use for Authenticating User
        /// </summary>
        /// <param name="User Name"></param>
        /// <param name="Password"></param>
        /// <returns>Success Message User Logined Successfully or not</returns>
        [HttpPost("~/LogIn")]
        public ResponseData LogIn(LoginModel objuserlogin)
        {
            LoginModel loginModel = new LoginModel();
            ResponseData responseData = new ResponseData();
            var display = loginModel.Userloginvalues()
                .Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword)
                .FirstOrDefault();

            if (display != null)
            {
                responseData.IsSuccess = true;
                responseData.ResponseMessage = "CORRECT Username and Password";
            }
            else
            {
                responseData.IsSuccess = false;
                responseData.ResponseMessage = "INCORRECT Username or Password";
            }

            return responseData;
        }



        /// <summary>
        /// GetTodos is Get Method it will return all Todos List
        /// </summary>
        /// <returns>List of All Todos</returns>
        [HttpGet("~/GetTodos")]
        public ResponseData GetTodos()
        {
            ResponseData respnonse = new ResponseData();
            try
            {
                var result= db.Todo.ToList();
                respnonse.Todos = result;
                respnonse.IsSuccess = true;
                return respnonse;
            }
            catch (Exception exe)
            {
                respnonse.IsSuccess = false;
                respnonse.ResponseMessage = exe.Message + "\n" + exe.StackTrace;
                return respnonse;
            }

        }

        /// <summary>
        /// CreateTodos is a post method for creation of new Todos
        /// </summary>
        /// <param name="todos"></param>
        /// <returns>Return Success message on successful creation otherwise return Fails message </returns>
        [HttpPost("~/CreateTodos")]
        public ResponseData CreateTodos(Todos todos)
        {
            ResponseData respnonse = new ResponseData();
            if (ModelState.IsValid)
            {
                db.Todo.Add(todos);
                db.SaveChanges();
                respnonse.IsSuccess = true;
                respnonse.ID = todos.ID;
                respnonse.ResponseMessage = "Successfully Created";
            }
            else
            {
                respnonse.IsSuccess = false;
                respnonse.ResponseMessage = "Unable To Create";
            }
            return respnonse;
        }

        /// <summary>
        /// EditTodos is a post method for Updating of a Todos record
        /// </summary>
        /// <param name="todos"></param>
        /// <returns> Return success message on updating record otherwise fail message</returns>
        [HttpPost("~/EditTodos")]
        public ResponseData EditTodos(Todos todos)
        {
            ResponseData respnonse = new ResponseData();
            if (ModelState.IsValid)
            {
                Todos todosreult = db.Todo.Find(todos.ID);
                if (todosreult != null)
                {
                    todosreult.Name = todos.Name;
                    todosreult.IsDone = todos.IsDone;
                    db.Entry(todosreult).State = EntityState.Modified;
                    db.SaveChanges();
                    respnonse.IsSuccess = true;
                    respnonse.ResponseMessage = "Successfully updated";
                }
                else
                {
                    respnonse.IsSuccess = false;
                    respnonse.ResponseMessage = "Unable To update";
                }
            }
            else
            {
                respnonse.IsSuccess = false;
                respnonse.ResponseMessage = "Unable To update";
            }
            return respnonse;
        }

        /// <summary>
        /// DeleteTodos is a post method for Deleting a Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return success message on Deleting record otherwise fail message</returns>
        [HttpPost("~/DeleteTodos")]
        public ResponseData DeleteTodos(int id)
        {
            ResponseData respnonse = new ResponseData();
            Todos todos = db.Todo.Find(id);
            if (todos != null)
            {
                db.Todo.Remove(todos);
                db.SaveChanges();
                respnonse.IsSuccess = true;
                respnonse.ResponseMessage = "Record Deleted Successfully";
            }
            else
            {
                respnonse.IsSuccess = false;
                respnonse.ResponseMessage = "Unable to Delete Record";
            }

            return respnonse;
        }
    }
}