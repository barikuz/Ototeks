# 🏭 Ototeks - Smart Textile Production Automation

**Ototeks** is a comprehensive desktop automation system designed to digitize and manage the entire lifecycle of textile production from order intake to final delivery.

The system distinguishes itself with an **AI-powered Quality Control Module** that utilizes **Computer Vision (ML.NET)** to detect fabric defects (such as stains, tears, or weaving errors) automatically via camera feed or image analysis.

---

## 🚀 Key Features

* **📦 Order Management:** Track customer orders with master-detail structure (Order -> Order Items).
* **🏭 Production Tracking:** Monitor the real-time status of items across stages (Cutting, Sewing, Ironing, Packaging).
* **🧠 AI Quality Control:** Detect defective fabrics using a custom-trained **ML.NET Image Classification** model.
* **🧶 Inventory & Stock:** Manage fabric stocks dynamically with low-stock alerts.
* **📊 Reporting:** Visualize production efficiency and defect rates with **DevExpress** charts.

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

## ⚙️ Quick Setup

Since the project is built on **Database First** approach, setting up the SQL environment is the only requirement.

### 1. Database Initialization
* The project includes a full database creation script.
* Open `TekstilDB_Script.sql` (located in `/Database` folder) in **SQL Server Management Studio**.
* Execute the script. It will create the `OtoteksDB` and populate lookup tables (Colors, Types, etc.).

### 2. Configuration
* Navigate to `Ototeks (UI)` folder and open `appsettings.json`.
* Ensure the **Server** parameter matches your local SQL Server instance name (e.g., `.\SQLEXPRESS` or `LOCALHOST`).

### 3. Build
* Open the solution in **Visual Studio 2022**.
* Set **Ototeks.UI** as the Startup Project.
* Press **Run**.

## 🚧 Project Status

**Work in Progress:** This project is currently under active development.

