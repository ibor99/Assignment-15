﻿// See https://aka.ms/new-console-template for more information

// Client code

using Assignment_15;

var subject = new Subject();
var customer1 = new Customer();
subject.Attach(customer1);

var staff1 = new Staff();
var staff2 = new Staff();
subject.Attach(staff1);
subject.Attach(staff2);

subject.PlaceOrder(customer1, "TV");

subject.Detach(staff1);

subject.PlaceOrder(customer1, "Laptop");

subject.ReadyToShip(staff1, "TV");


subject.FulfillOrder(staff2, "TV");
