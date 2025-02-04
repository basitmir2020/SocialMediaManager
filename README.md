# Social Media Auto Poster Application

🚀 **A Scalable and Robust Solution for Automating Social Media Posting**  
Built with cutting-edge technologies like **ASP.NET Core**, **Entity Framework Core**, and **MudBlazor**, this application simplifies social media management by allowing users to schedule and post content across multiple platforms, including **LinkedIn**, **Twitter**, and **Instagram**.

---

## 🌟 Key Features

- **🔐 Secure User Authentication**: Built-in login and registration using **ASP.NET Identity** for robust security.
- **👥 Role-Based Access Control**: Differentiated access for **Admin**, **Agency**, **Client**, and **User** roles.
- **📅 Social Media Scheduling**: Seamlessly schedule and post content to **LinkedIn**, **Twitter**, and **Instagram**.
- **🎨 Modern UI**: A clean, responsive, and interactive interface powered by **MudBlazor** and **Blazor WebAssembly**.
- **💾 Scalable Database**: Utilizes **SQL Server** for persistent storage, ensuring reliability and scalability.
- **🌱 Automatic Data Seeding**: Pre-configured seeding for initial roles, users, and sample data.
- **📱 Responsive Design**: Optimized for all devices, ensuring a smooth user experience.

---

## 🛠️ Technologies Used

### **Frontend**
- **MudBlazor**: For a modern and responsive UI.
- **Blazor WebAssembly**: For building interactive web applications with C#.
- **HTML5, CSS3 (SCSS)**: For advanced styling and layout.
- **JavaScript**: For additional interactivity where needed.

### **Backend**
- **ASP.NET Core 8.0**: For building high-performance APIs and backend services.
- **Entity Framework Core**: For database management and ORM.
- **SQL Server**: For reliable and scalable data storage.
- **ASP.NET Identity**: For secure authentication and authorization.

### **Tools**
- **Visual Studio 2022 / Rider**: For development and debugging.
- **SQL Server Management Studio (SSMS)**: For database management.
- **Git**: For version control and collaboration.
- **Docker**: For containerization and deployment.

---

## 🚀 Getting Started

### **Prerequisites**
- **.NET 8 SDK**: [Download here](https://dotnet.microsoft.com/download/dotnet)
- **SQL Server**: [Download here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Visual Studio 2022 or Rider**: For development.
- **Node.js**: For custom frontend work (optional).
- **Git**: For version control.

### **Installation**

1. **Clone the Repository**:
   ```bash
      git clone https://github.com/your-username/SocialMediaAutoPosterApp.git
    
      cd SocialMediaAutoPosterApp
   ```
2. **Restore NuGet Packages**:
   ```bash
   dotnet restore
   ```
3. **Set Up the Database**:
   - Update the ```appsettings.json``` file with your SQL Server connection string:
   
   ```bash
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost,1433;Database=SocialMediaAutoPoster;User Id=sa;Password=password@1234;TrustServerCertificate=True;"
   }
   ```
4. **Run Database Migrations**:
   ```bash
   dotnet ef database update
   ```
5. **Run the Application**:
   ```bash
   dotnet run
   ```
   - Alternatively, run the application in **Visual Studio** or **Rider** by pressing ```F5```.

6. **Access the Application**:
   - Open your browser and navigate to ```http://localhost:5000```.
---
## 🐳 Docker Support (Optional)
You can containerize the application for easy deployment:
1. **Build the Docker Image**:
   ```bash
   docker build -t socialmediaautoposterapp .
   ```
2. **Run the Docker Container**:
   ```bash
   docker run -d -p 5000:80 socialmediaautoposterapp
   ```
3. **Access the Application**:
   - Open your browser and navigate to ```http://localhost:5000```.
---
## 📂 Directory Structure
   ```
      SocialMediaAutoPosterApp/
      │
      ├── Data/
      │   ├── Contexts/
      │   │   └── ApplicationDbContext.cs
      │   ├── Migrations/
      │   └── DbInitializer.cs
      │
      ├── Models/
      │   ├── Agency.cs
      │   ├── Client.cs
      │   ├── ApplicationUser.cs
      │   ├── ApplicationRole.cs
      │   └── ... (other models)
      │
      ├── Pages/
      │   ├── Auth/
      │   │   ├── AuthLogin.razor
      │   │   └── AuthRegister.razor
      │   ├── Dashboard/
      │   ├── SocialMedia/
      │   └── ... (other pages)
      │
      ├── wwwroot/
      │   ├── css/
      │   ├── js/
      │   └── ... (static files)
      │
      ├── appsettings.json
      ├── Program.cs
      ├── Startup.cs
      └── SocialMediaAutoPosterApp.csproj
   ```
