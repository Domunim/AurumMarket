
using AurumMarket.Domain.Models;
using AurumMarket.Domain.Services;
using AurumMarket.EntityFramework;
using AurumMarket.EntityFramework.Services;
using System;
using System.Globalization;

IDataServices<UserModel> userService = new GenericDataServices<UserModel>(new AurumMarketDbContextFactory());

Console.WriteLine(userService.GetAll().Result.Count());

//Console.WriteLine(userService.GetById(3).Result);

//Console.WriteLine(userService.Update(3, new UserModel() { Name = "Mr Tester", Email = "joe@test.com", Password = "ziemniaczek"}).Result);

//Console.WriteLine(userService.Delete(3).Result);

Console.ReadLine();

//userService.Create(new UserModel { Name = "test" , Email = "test@test.com" , Password = "ziemniak"}).Wait();