# Introduction
It is a web application where you can list wishes and comment them. 
Additionally you can tag wish as observed. This functionality is based on session per user. 
As logged user you can add new wish. 

It is a final project for DOT subject.

# Technologies
App is based on "ASP.NET MVC". Connection and operations to database are realized by "Entity Framework". 
Data models are realized in "Code first" approach. 

# How to use

As anonymous user you can list latest wishes, comments and full list of wish. 
Also inside which details you can display comments for this wish. 
Additionally not logged users can comment wish. 

As logged user with "User" role you can additionally add new wish. 

As logged user with "Admin" role additionally you can delete wishes and comments.

# Credentials

    login: user@user.user
    password: "ChangeItAsap!"
    Role: "User"

    login: admin@admin.admin
    password: "ChangeItAsap!"
    Role: "Admin"