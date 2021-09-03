# HouseStore

[Live Demo](https://housestore20210806112107.azurewebsites.net)

This is a basic ecommerce app with a real estate theme. It allows the user to perform CRUD actions on the database of houses through a web app. Both the SQL database and the app are hosted on Azure.

I started by creating the database and tables on my local machine in SSMS. I scaffolded the database in a .Net project, which auto-generated the models and database context. The bulk of the project was writing the controllers and views.

There are two controllers, the Storefront, which the customer interacts with, and the Staff Portal, where full CRUD actions can be performed.
