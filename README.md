Blogfolio API 📝🚀
This is my personal project to learn and practice ASP.NET Core by building a blogging platform API. The project includes user authentication, role-based access control (RBAC), blog management, comments, and more.

🚀 Features
User Authentication & Authorization (JWT + Role-Based Access Control)

CRUD Operations for Blogs & Comments

Policies for User & Blog Ownership (Users can only edit/delete their own content)

Pagination, Filtering, and Sorting for better API performance

Error Handling & Validation for a smooth experience

SQLite Database (for simplicity)

🛠️ Technologies Used
ASP.NET Core (C#)

Entity Framework Core (SQLite as the database)

AutoMapper (to map between DTOs and Entities)

JWT Authentication

Authorization Policies (for role-based access)

📌 Installation & Setup
Clone the repository


git clone https://github.com/yourusername/blogfolio-api.git  
cd blogfolio-api
Install dependencies


dotnet restore
Update database & apply migrations


dotnet ef database update
Run the API


dotnet run
🔐 Authentication & Roles
The API uses JWT Authentication. Users can have different roles:

Admin – Can manage everything

User – Can create, update, and delete their own blogs

Guest – Can only read public content

📡 API Endpoints
🧑‍💻 User Management
POST /api/auth/register – Register a new user

POST /api/auth/login – Login and get a JWT token

GET /api/users – Get all users (Admin only)

PUT /api/users/{id}/role – Update a user's role (Admin only)

✍️ Blog Management
POST /api/blogs – Create a new blog (Authenticated users only)

GET /api/blogs – Get all blogs (Public)

GET /api/blogs/{id} – Get a single blog

PUT /api/blogs/{id} – Update a blog (Only the owner or Admin)

DELETE /api/blogs/{id} – Delete a blog (Only the owner or Admin)

💬 Comment System
POST /api/blogs/{id}/comments – Add a comment to a blog

GET /api/blogs/{id}/comments – Get all comments for a blog

DELETE /api/comments/{id} – Delete a comment (Only the owner or Admin)

📌 Future Improvements
Implementing Unit Tests

Adding CI/CD pipelines

Improving security measures

Adding real-time notifications
