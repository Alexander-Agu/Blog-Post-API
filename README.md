# Blog App API (ASP.NET)

A simple RESTful Blog API built with **ASP.NET Core** for learning and practicing backend development with a focus on **entity relationships**. This project is beginner-friendly and demonstrates how to create, read, and delete data using **Entity Framework Core**, along with **one-to-many relationships**.

---

## 📘 Project Description

This API simulates a basic blog system with three main entities:

- **User** – the author of blog posts
- **Post** – the blog content written by users
- **Comment** – comments made on blog posts

This project helps reinforce how to:

- Work with one-to-many relationships in ASP.NET Core
- Use Entity Framework Core for modeling data
- Test REST APIs using tools like Postman or Swagger

---

## 🔧 Tech Stack

- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQLite**
- **Postman** (For testing)

---

## 🧱 Entities and Relationships

### 🔹 User Entity
| Property     | Type     | Notes                          |
|--------------|----------|--------------------------------|
| Id           | int      | Primary Key                    |
| FirstName    | string   |                                |
| LastName     | string   |                                |
| Email        | string   |                                |
| Password     | string   |                                |
| Posts        | List<Post> | One user can have many posts |

---

### 🔹 Post Entity
| Property     | Type          | Notes                           |
|--------------|---------------|---------------------------------|
| Id           | int           | Primary Key                     |
| UserId       | int           | Foreign Key (to User)           |
| User         | User          | Navigation property             |
| Title        | string        |                                 |
| Content      | string        |                                 |
| Comments     | List<Comment> | One post can have many comments |

---

### 🔹 Comment Entity
| Property     | Type     | Notes                      |
|--------------|----------|----------------------------|
| Id           | int      | Primary Key                |
| Content      | string   |                            |
| PostId       | int      | Foreign Key (to Post)      |
| Post         | Post     | Navigation property        |

---

## 🔁 Relationships Summary

- **One User → Many Posts**
- **One Post → Many Comments**

---

## 🚀 How to Run the Project

1. **Clone the repo**
   ```bash
   git clone https://github.com/Alexander-Agu/Blog-App-API.git
   cd Blog.App.API
   dotnet run
