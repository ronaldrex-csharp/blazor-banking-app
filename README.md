# CoreBankingApplication

A Blazor-based web application for managing accounts and transactions with a simple authentication system.

## 🚀 Features

* User login/logout (custom AuthService)
* Account overview page
* Transactions page
* Navigation menu with responsive layout
* Styled UI with custom CSS

## 🛠️ Tech Stack

* ASP.NET Core Blazor (.NET 10)
* C#
* Bootstrap (for base styling)
* Custom CSS (`app.css`)

## 📸 Screenshots

<!-- Add screenshots later -->

<!-- Example:
![Dashboard](screenshots/dashboard.png)
-->

## ⚙️ Getting Started

### Prerequisites

* .NET 10 SDK
* Visual Studio 2026

### Run the project

```bash
git clone https://github.com/yourusername/core-banking-app.git
cd core-banking-app
dotnet run
```

Then open:

```
https://localhost:xxxx
```

## 🔐 Authentication

This project uses a simple in-memory authentication service:

```csharp
username: admin
password: password
```

> Note: This is for demo purposes only (not production-ready).

## 📁 Project Structure

```
/Components
  /Layouts
    NavMenu.razor
/Application
  Services/
    AuthService.cs
/wwwroot
  app.css
```

## 🧠 Notes

* CSS is currently handled globally via `app.css`
* Component CSS isolation is not used in this version
* Authentication is state-based (no database yet)

## 📌 Future Improvements

* Add real authentication (ASP.NET Identity / JWT)
* Persist user sessions
* Improve UI/UX styling
* Add database (SQL Server / EF Core)
* Add account creation and transfer features

## 🤝 Contributing

Pull requests are welcome. For major changes, open an issue first.

## 📄 License

This project is for learning/demo purposes.
