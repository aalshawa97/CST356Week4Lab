﻿using Lab4WebApplication.Data;
using Lab4WebApplication.Data.Entities;
using Lab4WebApplication.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4WebApplication.Controllers
{
    public class PetController : Controller
    {
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var pets = GetPetsForUser(userId);

            return View(pets);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(petViewModel);
                return RedirectToAction("List", new { UserId = petViewModel.UserId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = GetPet(id);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdatePet(petViewModel);

                return RedirectToAction("List",new { userid =  petViewModel.UserId});
            }

            return View();
        }

        private void UpdatePet(PetViewModel petViewModel)
        {
            var dbContext = new AppDbContext();

            var pet = dbContext.Pets.Find(petViewModel.Id);

            CopyToPet(petViewModel, pet);

            dbContext.SaveChanges();
        }

        private void CopyToPet(PetViewModel petViewModel, Pet pet)
        {
            pet.Name = petViewModel.Name;
            pet.Age = petViewModel.Age;
            pet.NextCheckup = petViewModel.NextCheckup;
            pet.VetName = pet.VetName;
        }

        public ActionResult Delete(int id)
        {
            var pet = GetPet(id);

            DeletePet(id);

            return RedirectToAction("List", new { UserId = pet.UserId });
        }

        private PetViewModel GetPet(int petId)
        {
            var dbContext = new AppDbContext();

            var pet = dbContext.Pets.Find(petId);

            return MapToPetViewModel(pet);
        }

        private ICollection<PetViewModel> GetPetsForUser(int userId)
        {
            var petViewModels = new List<PetViewModel>();

            var dbContext = new AppDbContext();

            var pets = dbContext.Pets.Where(pet => pet.UserId == userId).ToList();

            foreach (var pet in pets)
            {
                var petViewModel = MapToPetViewModel(pet);
                petViewModels.Add(petViewModel);
            }

            return petViewModels;
        }

        private void Save(PetViewModel petViewModel)
        {
            var dbContext = new AppDbContext();

            var pet = MapToPet(petViewModel);

            dbContext.Pets.Add(pet);

            dbContext.SaveChanges();
        }

        private void DeletePet(int id)
        {
            var dbContext = new AppDbContext();

            var pet = dbContext.Pets.Find(id);

            if (pet != null)
            {
                dbContext.Pets.Remove(pet);
                dbContext.SaveChanges();
            }
        }

        private Pet MapToPet(PetViewModel petViewModel)
        {
            return new Pet
            {
                Id = petViewModel.Id,
                Name = petViewModel.Name,
                Age = petViewModel.Age,
                NextCheckup = petViewModel.NextCheckup,
                VetName = petViewModel.VetName,
                UserId = petViewModel.UserId
            };
        }

        private PetViewModel MapToPetViewModel(Pet pet)
        {
            return new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                NextCheckup = pet.NextCheckup,
                VetName = pet.VetName,
                UserId = pet.UserId
            };
        }
    }
}
