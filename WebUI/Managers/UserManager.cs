using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebUI.DatabaseContext;
using WebUI.Models;

namespace WebUI.Managers
{
    public class UserManager
    {
        public List<User> GetUsers()
        {
            try
            {
                using (var db = new ContextDb())
                {
                    string sql = @"SELECT * FROM Users";

                    var users = db._connection.Query<User>(sql).ToList();

                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                using (var db = new ContextDb())
                {
                    string sql = @"select * from Users where Id=@Id";
                    var user = db._connection.QuerySingleOrDefault<User>(sql, new { Id = id });
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void SetUsers(User model)
        {
            try
            {
                using (var db = new ContextDb())
                {
                    string sql = $@"
                                    INSERT INTO Users (FirstName, LastName, Email, Password, PhoneNumber, DateOfBirth, Gender, City, Website, Adress, IsSubscribed, Photo) 
                                    VALUES ('{model.FirstName}', '{model.LastName}', '{model.Email}', '{model.Password}', '{model.PhoneNumber}', '{model.DateOfBirth}', '{model.Gender}', '{model.City}', '{model.Website}', '{model.Adress}', '{model.IsSubscribed}', '{model.Photo}')";

                    var user = db._connection.Execute(sql);

                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public User UpdateUser(User model)
        {
            try
            {
                using (var db = new ContextDb())
                {
                    string sql = @"
                                   UPDATE Users
                                   SET Firstname=@FirstName, LastName=@LastName, Email=@Email, Password=@Password, PhoneNumber=@PhoneNumber, DateOfBirth=@DateOfBirth, Gender=@Gender, City=@City, Website=@Website, Adress=@Adress, IsSubscribed=@IsSubscribed, Photo=@Photo 
                                   WHERE Id=@Id";
                    int user=db._connection.Execute(sql, model);

                    if (user > 0)
                    {
                        return model;
                    }

                    else
                    {
                        return model;
                    }
                    
                }
                
            }
            catch(Exception)
            {
                throw;
            }
        }

        public User DeleteUser(User model)
        {
            using (var db=new ContextDb())
            {
                string sql = $"delete from Users where Id={model.Id}";
                int sqlRunCommand = db._connection.Execute(sql);
                return model;
            }
        }

    }
}