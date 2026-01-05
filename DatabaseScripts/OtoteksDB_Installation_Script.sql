-- =========================================================
-- 0. TEMÝZLÝK VE KURULUM
-- (Eðer veritabaný varsa siler, sýfýrdan oluþturur)
-- =========================================================
USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'OtoteksDB')
BEGIN
    ALTER DATABASE OtoteksDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE OtoteksDB;
END
GO

CREATE DATABASE OtoteksDB;
GO

USE OtoteksDB;
GO

-- =========================================================
-- 1. TANIM TABLOLARI (LOOKUP TABLES)
-- (Renkler, Tipler, Hatalar burada tutulur)
-- =========================================================

-- Renk Havuzu
CREATE TABLE Colors (
    ColorID INT PRIMARY KEY IDENTITY(1,1),
    ColorName NVARCHAR(50) NOT NULL UNIQUE
);

-- Ürün Tipleri (T-Shirt, Pantolon vb.)
CREATE TABLE ProductTypes (
    TypeID INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(50) NOT NULL UNIQUE
);

-- Hata Türleri (Leke, Yýrtýk vb.)
CREATE TABLE DefectTypes (
    DefectID INT PRIMARY KEY IDENTITY(1,1),
    DefectName NVARCHAR(50) NOT NULL UNIQUE
);

-- =========================================================
-- 2. ANA VARLIK TABLOLARI (MASTER TABLES)
-- =========================================================

-- Kullanýcýlar / Personel
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL, -- (Not: Gerçekte hashlenmeli)
    Role NVARCHAR(20) NOT NULL,     -- 'Admin', 'Operator', 'Kalite'
    FullName NVARCHAR(100)
);

-- Müþteriler
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(250)
);

-- Kumaþ Stoðu (Hammadde)
CREATE TABLE Fabrics (
    FabricID INT PRIMARY KEY IDENTITY(1,1),
    FabricCode NVARCHAR(50) UNIQUE NOT NULL, -- Barkod
    FabricName NVARCHAR(100),                -- Ticari Adý
    ColorID INT FOREIGN KEY REFERENCES Colors(ColorID), -- Renk Tablosuna Baðlý
    StockQuantity DECIMAL(10,2) DEFAULT 0    -- Metre
);

-- =========================================================
-- 3. HAREKET TABLOLARI (TRANSACTION TABLES)
-- =========================================================

-- Sipariþ Baþlýðý (Fiþin Üstü)
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderNumber NVARCHAR(20) UNIQUE NOT NULL,          -- Takip No
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATETIME DEFAULT GETDATE(),
    DueDate DATETIME,                                  -- Teslim Tarihi
    OrderStatus NVARCHAR(20) DEFAULT 'Beklemede'       -- 'Beklemede', 'Tamamlandi'
);

-- Sipariþ Detaylarý ve Üretim Takibi (Fiþin Satýrlarý)
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    FabricID INT FOREIGN KEY REFERENCES Fabrics(FabricID),
    TypeID INT FOREIGN KEY REFERENCES ProductTypes(TypeID), -- Ürün Tipine Baðlý
    
    Quantity INT NOT NULL,
    CurrentStage NVARCHAR(50) DEFAULT 'Planlama', -- 'Kesim', 'Dikim', 'Kalite'
    
    -- Bu satýrdaki son iþlemi yapan personel
    ProcessedByUserID INT FOREIGN KEY REFERENCES Users(UserID) 
);

-- Kalite Kontrol Loglarý (AI Sonuçlarý)
CREATE TABLE QualityLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    OrderItemID INT FOREIGN KEY REFERENCES OrderItems(OrderItemID),
    InspectionDate DATETIME DEFAULT GETDATE(),
    
    IsDefective BIT, -- 0:Saðlam, 1:Hatalý
    DefectID INT FOREIGN KEY REFERENCES DefectTypes(DefectID), -- Hata Tipine Baðlý
    ConfidenceScore FLOAT, -- AI Güven Oraný
    
    ImagePath NVARCHAR(500), -- Resim Dosya Yolu
    OperatorNote NVARCHAR(200)
);

-- =========================================================
-- 4. ÖRNEK VERÝLER (SEED DATA)
-- (Sistem açýldýðýnda boþ gelmesin diye)
-- =========================================================

-- Renkleri Ekle
INSERT INTO Colors (ColorName) VALUES ('Beyaz'), ('Siyah'), ('Lacivert'), ('Kýrmýzý'), ('Yeþil');

-- Ürün Tiplerini Ekle
INSERT INTO ProductTypes (TypeName) VALUES ('Polo Yaka T-Shirt'), ('V Yaka T-Shirt'), ('Kot Pantolon'), ('Sweatshirt');

-- Hata Türlerini Ekle
INSERT INTO DefectTypes (DefectName) VALUES ('Yað Lekesi'), ('Yýrtýk'), ('Dokuma Hatasý'), ('Dikiþ Hatasý');

-- Admin Kullanýcýsý Ekle
INSERT INTO Users (Username, Password, Role, FullName) VALUES ('admin', '12345', 'Admin', 'Sistem Yöneticisi');

-- Bir Müþteri Ekle
INSERT INTO Customers (CustomerName, Phone) VALUES ('Mavi Jeans A.Þ.', '0212-555-0000');