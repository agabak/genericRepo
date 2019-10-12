using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kabunga.Models;
using Kabunga.Repositories;
using Kabunga.Repositories.Interface;
using Kabunga.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kabunga.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(UserRepository repository)
        {
            _repository = repository;
        }

        private readonly UserRepository _repository;

        public async Task<IActionResult> Index()
        {
            var users = await _repository.GetAll();

            var viewModel = mapViewModel(users);
        
            return View(viewModel);
        }

        private List<UserViewModel> mapViewModel(IEnumerable<User> users)
        {
           // var user = new UserViewModel();
            var newUserList = new List<UserViewModel>();
            foreach(var us in users)
            {
                var user = new UserViewModel
                            {
                                Id = us.Id,
                                FirstName = us.FirstName,
                                Username = us.UserName,
                                LastName = us.LastName
                            };
                
                newUserList.Add(user);
            }
            return newUserList;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new User
                            {
                                Email = model.Email,
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                UserName = model.Username
                            };

                await _repository.Insert(user);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "something went wrong");
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var user = await _repository.GetById(id);
            if(user != null)
            {
                var model = new UpdateUserModel
                            {   Id = user.Id,
                                Email = user.Email,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Username = user.UserName
                            };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id,UpdateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _repository.GetById(id);
                if(user != null && id == user.Id)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    await _repository.Update(user);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _repository.GetById(id);
            if (user != null)
            {
                var model = new UserViewModel
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName
                };
                return View(model);
            }
            return View();
        }
    }
}