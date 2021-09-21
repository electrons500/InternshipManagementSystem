using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OnlineInternshipPortal.Models.Data.Services
{
    public class UsersService
    {
        private OnlineInternshipContext.OnlineInternshipContext _Context;
        private readonly IConfiguration _configuration;

        public UsersService(OnlineInternshipContext.OnlineInternshipContext context, IConfiguration configuration = null)
        {
            _Context = context;
            _configuration = configuration;
        }

        //list of Admins
        public List<UserRoleViewModel> GetAdmins()
        {
            string connection = _configuration.GetConnectionString("Conn");
            SqlConnection con = new(connection);
            List<UserRoleViewModel> model = new();
            string sql = " SELECT  UserRoles.UserId,Users.FullName,Users.PhoneNumber, UserRoles.RoleId, Role.Name FROM Role INNER JOIN UserRoles ON Role.Id = UserRoles.RoleId INNER JOIN Users ON UserRoles.UserId = Users.Id where Role.Name ='Admin'  ";
            using (SqlCommand cmd = new(sql, con))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UserRoleViewModel userRole = new()
                        {
                            RoleId = dr["RoleId"].ToString(),
                            RoleName = dr["Name"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            UserFullName = dr["FullName"].ToString(),
                            UserPhone = dr["PhoneNumber"].ToString()

                        };


                        model.Add(userRole);
                    }


                    con.Close();

                }

            }

            return model;
        }
        public List<UserRoleViewModel> GetEmployers()
        {
            string connection = _configuration.GetConnectionString("Conn");
            SqlConnection con = new(connection);
            List<UserRoleViewModel> model = new();
            string sql = " SELECT  UserRoles.UserId,Users.FullName,Users.PhoneNumber, UserRoles.RoleId, Role.Name FROM Role INNER JOIN UserRoles ON Role.Id = UserRoles.RoleId INNER JOIN Users ON UserRoles.UserId = Users.Id where Role.Name ='Employer'  ";
            using (SqlCommand cmd = new(sql, con))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UserRoleViewModel userRole = new()
                        {
                            RoleId = dr["RoleId"].ToString(),
                            RoleName = dr["Name"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            UserFullName = dr["FullName"].ToString(),
                            UserPhone = dr["PhoneNumber"].ToString()

                        };


                        model.Add(userRole);
                    }


                    con.Close();

                }

            }

            return model;
        }
        public List<UserRoleViewModel> GetStudent()
        {
            string connection = _configuration.GetConnectionString("Conn");
            SqlConnection con = new(connection);
            List<UserRoleViewModel> model = new();
            string sql = " SELECT  UserRoles.UserId,Users.FullName,Users.PhoneNumber, UserRoles.RoleId, Role.Name FROM Role INNER JOIN UserRoles ON Role.Id = UserRoles.RoleId INNER JOIN Users ON UserRoles.UserId = Users.Id where Role.Name ='Student'  ";
            using (SqlCommand cmd = new(sql, con))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UserRoleViewModel userRole = new()
                        {
                            RoleId = dr["RoleId"].ToString(),
                            RoleName = dr["Name"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            UserFullName = dr["FullName"].ToString(),
                            UserPhone = dr["PhoneNumber"].ToString()

                        };


                        model.Add(userRole);
                    }


                    con.Close();

                }

            }

            return model;
        }

        //User Details
        public UsersViewModel GetUserDetails(string id)
        {
            ApplicationUser user = _Context.Users.Where(x => x.Id == id).Include(x => x.Gender)
                                                              .Include(x => x.Region)
                                                              .FirstOrDefault();
            UsersViewModel model = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                FullName = user.FullName,
                BirthDate = user.BirthDate,
                GenderId = user.GenderId,
                GenderName = user.Gender.GenderName,
                HomeTown = user.HomeTown,
                RegionId = user.RegionId,
                RegionName = user.Region.RegionName,
                Residence = user.Residence,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ProfilePic = user.ProfilePic,
                RegistrationDate = user.RegistrationDate
            };

            return model;
        }

    }
}
