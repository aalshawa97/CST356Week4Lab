﻿using Lab4WebApplication.Data;
using Lab4WebApplication.Models.View;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab4WebApplication.Controllers
{
    public class UserController : Controller
    {
        public ActionResult List()
        {
            var users = GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = MapToUser(userViewModel);

                SaveUser(user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var user = GetUser(id);

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteUser(id);

            return RedirectToAction("List");
        }

        private UserViewModel GetUser(int id)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(id);

            return MapToUserViewModel(user);
        }

        private IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();

            var dbContext = new AppDbContext();

            foreach (var user in dbContext.Users)
            {
                var userViewModel = MapToUserViewModel(user);
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        private void SaveUser(Data.Entities.User user)
        {
            var dbContext = new AppDbContext();

            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }

        private void UpdateUser(UserViewModel userViewModel)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(userViewModel.Id);

            CopyToUser(userViewModel, user);

            dbContext.SaveChanges();
        }

        private void DeleteUser(int id)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        private Data.Entities.User MapToUser(UserViewModel userViewModel)
        {
            return new Data.Entities.User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                FavoriteHobby = userViewModel.FavoriteHobby,
                EmailAddress = userViewModel.EmailAddress,
                DateOfBirth = userViewModel.DOB,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }

        private UserViewModel MapToUserViewModel(Data.Entities.User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                FavoriteHobby = user.FavoriteHobby,
                EmailAddress = user.EmailAddress,
                DOB = user.DateOfBirth,
                YearsInSchool = user.YearsInSchool
            };
        }

        private void CopyToUser(UserViewModel userViewModel, Data.Entities.User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.FavoriteHobby = userViewModel.FavoriteHobby;
            user.EmailAddress = userViewModel.EmailAddress;
            user.DateOfBirth = userViewModel.DOB;
            user.YearsInSchool = userViewModel.YearsInSchool;
        }
    }
}
