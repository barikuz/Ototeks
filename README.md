# 🏭 Ototeks - Smart Textile Production Automation

**Ototeks** is a comprehensive desktop automation system designed to digitize and manage the entire lifecycle of textile production from order intake to final delivery.

The system distinguishes itself with an **AI-powered Quality Control Module** that utilizes **Computer Vision (ML.NET)** to detect fabric defects (such as stains, tears, or weaving errors) automatically via image analysis.

---

## 🚀 Key Features

* **📦 Order Management:** Track customer orders with master-detail structure (Order -> Order Items).
* **🏭 Production Tracking:** Monitor the real-time status of items across stages (Cutting, Sewing, Ironing, Packaging).
* **🧠 AI Quality Control:** Detect defective fabrics using a custom-trained **ML.NET Image Classification** model.
* **🧶 Inventory & Stock:** Manage fabric stocks dynamically with low-stock alerts.
* **📊 Reporting:** Visualize production efficiency and defect rates with **DevExpress** charts.

---

## 📥 Installation (Ready-to-Use)

You don't need to build the source code to run the application. You can download and install the setup file directly.

1.  **Download the Installer:**
    * [👉 **Click here to download Ototeks Setup (v1.0)**](https://drive.google.com/file/d/10nKvNHiSau3Vsx8u0Az62q6lAbcjkatL/view?usp=sharing)

2.  **Run the Setup:**
    * Open the downloaded `.exe` file and follow the installation wizard instructions.

3.  **Launch:**
    * Once installed, start the application from the desktop shortcut.

---

## 🛠️ Technology Stack

* **Platform:** .NET 8.0 (Desktop)
* **Language:** C#
* **Architecture:** N-Tier Architecture (Layered)
* **Database:** Microsoft SQL Server 2022 Express
* **ORM:** Entity Framework Core (Database First approach)
* **UI Library:** DevExpress WinForms (Ribbon Interface)
* **Artificial Intelligence:** ML.NET (Machine Learning for .NET)

---

## 🏗️ Architecture Overview

The solution follows a strict **Separation of Concerns** principle with 4 distinct layers:

1.  **📂 Ototeks.Entities:** Contains POCO classes generated via Reverse Engineering (Scaffolding) from the SQL schema. Represents the database tables.
2.  **📂 Ototeks.DataAccess:** Handles database connectivity.
3.  **📂 Ototeks.Business:** Encapsulates business logic, validations, and AI integration services.
4.  **📂 Ototeks.UI:** The presentation layer.

---

## ⚙️ Developer Setup (Source Code)

If you want to modify or build the project from source, follow these steps:

### 1. Database Initialization
* The project includes a full database creation script.
* Open `OtoteksDB_Installation__Script.sql` (located in `/DatabaseScripts` folder) in **SQL Server Management Studio**.
* Execute the script. It will create the `OtoteksDB` and populate lookup tables (Colors, Types, etc.).

### 2. Configuration
* Navigate to `Ototeks (UI)` folder and open `appsettings.json`.
* Ensure the **Server** parameter matches your local SQL Server instance name (e.g., `.\SQLEXPRESS` or `LOCALHOST`).

### 3. Build
* Open the solution in **Visual Studio 2022**.
* Set **Ototeks.UI** as the Startup Project.
* Press **Run**.

---

## ✅ Project Status

**Completed:** The project has been successfully developed, tested, and the v1.0 release is ready.
