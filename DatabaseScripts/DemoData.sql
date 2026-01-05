-- =====================================================
-- OTOTEKS - TEKSTÝL OTOMASYON SÝSTEMÝ
-- Demo Veri Scripti (Sunum için)
-- =====================================================
-- Bu script tüm tablolarý temizler (Users hariç) ve
-- gerçekçi demo verileri ekler.
-- =====================================================

-- Referential integrity için foreign key kontrollerini geçici kapat
SET NOCOUNT ON;

PRINT '=== VERÝ TEMÝZLÝÐÝ BAÞLIYOR ===';

-- 1. ADIM: Tüm verileri sil (doðru sýrada - child tablolardan baþla)
-- Users tablosu HARÝÇ

-- QualityLogs (en alt seviye - baðýmlýlýk yok)
DELETE FROM QualityLogs;
PRINT 'QualityLogs temizlendi.';

-- OrderItems (QualityLogs temizlendikten sonra)
DELETE FROM OrderItems;
PRINT 'OrderItems temizlendi.';

-- Orders (OrderItems temizlendikten sonra)
DELETE FROM Orders;
PRINT 'Orders temizlendi.';

-- Customers (Orders temizlendikten sonra)
DELETE FROM Customers;
PRINT 'Customers temizlendi.';

-- Fabrics (OrderItems temizlendikten sonra)
DELETE FROM Fabrics;
PRINT 'Fabrics temizlendi.';

-- Colors (Fabrics temizlendikten sonra)
DELETE FROM Colors;
PRINT 'Colors temizlendi.';

-- ProductTypes (OrderItems temizlendikten sonra)
DELETE FROM ProductTypes;
PRINT 'ProductTypes temizlendi.';

-- DefectTypes (QualityLogs temizlendikten sonra)
DELETE FROM DefectTypes;
PRINT 'DefectTypes temizlendi.';

PRINT '';
PRINT '=== VERÝ TEMÝZLÝÐÝ TAMAMLANDI ===';
PRINT '';

-- Identity sütunlarýný sýfýrla
DBCC CHECKIDENT ('QualityLogs', RESEED, 0);
DBCC CHECKIDENT ('OrderItems', RESEED, 0);
DBCC CHECKIDENT ('Orders', RESEED, 0);
DBCC CHECKIDENT ('Customers', RESEED, 0);
DBCC CHECKIDENT ('Fabrics', RESEED, 0);
DBCC CHECKIDENT ('Colors', RESEED, 0);
DBCC CHECKIDENT ('ProductTypes', RESEED, 0);
DBCC CHECKIDENT ('DefectTypes', RESEED, 0);

PRINT 'Identity deðerleri sýfýrlandý.';
PRINT '';
PRINT '=== DEMO VERÝLERÝ EKLENÝYOR ===';
PRINT '';

-- =====================================================
-- 2. ADIM: REFERANS VERÝLERÝ EKLE (Lookup Tables)
-- =====================================================

-- RENKLER (Colors)
INSERT INTO Colors (ColorName) VALUES 
    ('Beyaz'),
    ('Siyah'),
    ('Lacivert'),
    ('Kýrmýzý'),
    ('Yeþil'),
    ('Gri'),
    ('Bej'),
    ('Kahverengi'),
    ('Bordo'),
    ('Mavi'),
    ('Pembe'),
    ('Sarý'),
    ('Turuncu'),
    ('Mor'),
    ('Krem');

PRINT 'Renkler eklendi (15 adet).';

-- ÜRÜN TÝPLERÝ (ProductTypes) - Gerçekçi tekstil ürünleri
INSERT INTO ProductTypes (TypeName, RequiredFabricAmount) VALUES 
    ('T-Shirt', 1.20),
    ('Gömlek', 1.80),
    ('Pantolon', 2.50),
    ('Elbise', 3.00),
    ('Etek', 1.50),
    ('Ceket', 2.80),
    ('Mont', 3.50),
    ('Þort', 1.00),
    ('Bluz', 1.40),
    ('Yelek', 1.60),
    ('Pijama Takýmý', 2.20),
    ('Eþofman Altý', 1.80),
    ('Sweatshirt', 1.90),
    ('Hýrka', 2.30),
    ('Kaban', 4.00);

PRINT 'Ürün tipleri eklendi (15 adet).';

-- HATA TÝPLERÝ (DefectTypes) - Tekstil kalite kontrol hatalarý
INSERT INTO DefectTypes (DefectName) VALUES 
    ('Leke'),
    ('Ýplik Çýkmasý'),
    ('Dikiþ Hatasý'),
    ('Renk Farký'),
    ('Yýrtýk'),
    ('Delik'),
    ('Kumaþ Hatasý'),
    ('Düðme Eksik'),
    ('Fermuar Arýzasý'),
    ('Ölçü Hatasý'),
    ('Etiket Hatasý'),
    ('Kesim Hatasý'),
    ('Ütü Yanýðý'),
    ('Ýðne Ýzi'),
    ('Baský Hatasý');

PRINT 'Hata tipleri eklendi (15 adet).';

-- =====================================================
-- 3. ADIM: KUMAÞLAR (Fabrics)
-- =====================================================

INSERT INTO Fabrics (FabricCode, FabricName, ColorID, StockQuantity) VALUES 
    ('KUM-001', 'Pamuklu Penye', 1, 1500.00),      -- Beyaz
    ('KUM-002', 'Pamuklu Penye', 2, 1200.00),      -- Siyah
    ('KUM-003', 'Pamuklu Penye', 3, 800.00),       -- Lacivert
    ('KUM-004', 'Poplin', 1, 950.00),              -- Beyaz
    ('KUM-005', 'Poplin', 10, 720.00),             -- Mavi
    ('KUM-006', 'Denim', 3, 600.00),               -- Lacivert
    ('KUM-007', 'Denim', 2, 450.00),               -- Siyah
    ('KUM-008', 'Gabardin', 7, 380.00),            -- Bej
    ('KUM-009', 'Gabardin', 8, 420.00),            -- Kahverengi
    ('KUM-010', 'Viskon', 4, 550.00),              -- Kýrmýzý
    ('KUM-011', 'Viskon', 5, 480.00),              -- Yeþil
    ('KUM-012', 'Polar', 6, 320.00),               -- Gri
    ('KUM-013', 'Polar', 3, 290.00),               -- Lacivert
    ('KUM-014', 'Keten', 1, 410.00),               -- Beyaz
    ('KUM-015', 'Keten', 7, 380.00),               -- Bej
    ('KUM-016', 'Kadife', 9, 250.00),              -- Bordo
    ('KUM-017', 'Kadife', 5, 180.00),              -- Yeþil
    ('KUM-018', 'Þifon', 11, 200.00),              -- Pembe
    ('KUM-019', 'Þifon', 15, 230.00),              -- Krem
    ('KUM-020', 'Saten', 2, 280.00),               -- Siyah
    ('KUM-021', 'Saten', 4, 190.00),               -- Kýrmýzý
    ('KUM-022', 'Tweed', 6, 350.00),               -- Gri
    ('KUM-023', 'Tweed', 8, 300.00),               -- Kahverengi
    ('KUM-024', 'Flanel', 4, 420.00),              -- Kýrmýzý
    ('KUM-025', 'Flanel', 10, 380.00);             -- Mavi

PRINT 'Kumaþlar eklendi (25 adet).';

-- =====================================================
-- 4. ADIM: MÜÞTERÝLER (Customers)
-- =====================================================

INSERT INTO Customers (CustomerName, Phone, Email, Address) VALUES 
    ('Modaevi Tekstil A.Þ.', '0212 555 1001', 'siparis@modaevi.com.tr', 'Merter Tekstil Merkezi, Ýstanbul'),
    ('Trend Giyim Ltd.', '0212 555 1002', 'satis@trendgiyim.com', 'Osmanbey Cad. No:45, Þiþli/Ýstanbul'),
    ('Elegance Moda', '0216 555 1003', 'info@elegancemoda.com', 'Baðdat Cad. No:120, Kadýköy/Ýstanbul'),
    ('Zara Tekstil', '0212 555 1004', 'orders@zaratekstil.com.tr', 'Laleli, Fatih/Ýstanbul'),
    ('Mango Fashion', '0312 555 1005', 'siparis@mangofashion.com.tr', 'Tunalý Hilmi Cad., Çankaya/Ankara'),
    ('Koton Maðazalarý', '0232 555 1006', 'tedarik@koton.com.tr', 'Alsancak, Konak/Ýzmir'),
    ('LC Waikiki Tedarik', '0212 555 1007', 'supply@lcwaikiki.com', 'Ýkitelli OSB, Baþakþehir/Ýstanbul'),
    ('DeFacto Üretim', '0212 555 1008', 'uretim@defacto.com.tr', 'Esenyurt Sanayi, Ýstanbul'),
    ('Boyner Grup', '0212 555 1009', 'tekstil@boyner.com.tr', 'Maslak, Sarýyer/Ýstanbul'),
    ('Vakko Tekstil', '0212 555 1010', 'production@vakko.com', 'Nakkaþtepe, Üsküdar/Ýstanbul'),
    ('Mavi Jeans', '0212 555 1011', 'orders@mavi.com', 'Tuzla Deri OSB, Ýstanbul'),
    ('Colin''s Giyim', '0262 555 1012', 'siparis@colins.com', 'Gebze OSB, Kocaeli'),
    ('Pierre Cardin TR', '0216 555 1013', 'supply@pierrecardin.com.tr', 'Ataþehir, Ýstanbul'),
    ('US Polo Assn.', '0212 555 1014', 'orders@uspolo.com.tr', 'Güneþli, Baðcýlar/Ýstanbul'),
    ('Kigili Giyim', '0312 555 1015', 'tedarik@kigili.com', 'Siteler, Ankara');

PRINT 'Müþteriler eklendi (15 adet).';

-- =====================================================
-- 5. ADIM: SÝPARÝÞLER (Orders)
-- =====================================================

-- Farklý durumlarý gösteren sipariþler:
-- 0-Pending, 1-Cutting, 2-Sewing, 3-Ironing, 4-QualityControl, 5-Completed, 99-Cancelled

INSERT INTO Orders (OrderNumber, CustomerID, OrderDate, DueDate, OrderStatus) VALUES 
    -- Tamamlanmýþ sipariþler (geçmiþ tarihli)
    ('SIP-2024-0001', 1, '2024-11-01', '2024-11-15', 5),
    ('SIP-2024-0002', 2, '2024-11-05', '2024-11-20', 5),
    ('SIP-2024-0003', 3, '2024-11-10', '2024-11-25', 5),
    ('SIP-2024-0004', 4, '2024-11-15', '2024-11-30', 5),
    ('SIP-2024-0005', 5, '2024-11-18', '2024-12-02', 5),
    
    -- Kalite kontrolde olan sipariþler
    ('SIP-2024-0006', 6, '2024-11-20', '2024-12-05', 4),
    ('SIP-2024-0007', 7, '2024-11-22', '2024-12-07', 4),
    
    -- Ütü/Paketleme aþamasýnda
    ('SIP-2024-0008', 8, '2024-11-25', '2024-12-10', 3),
    ('SIP-2024-0009', 9, '2024-11-26', '2024-12-11', 3),
    
    -- Dikim aþamasýnda
    ('SIP-2024-0010', 10, '2024-11-28', '2024-12-13', 2),
    ('SIP-2024-0011', 11, '2024-11-29', '2024-12-14', 2),
    ('SIP-2024-0012', 12, '2024-11-30', '2024-12-15', 2),
    
    -- Kesimhanede
    ('SIP-2024-0013', 13, '2024-12-01', '2024-12-16', 1),
    ('SIP-2024-0014', 14, '2024-12-02', '2024-12-17', 1),
    
    -- Bekleyen (yeni) sipariþler
    ('SIP-2024-0015', 15, '2024-12-03', '2024-12-18', 0),
    ('SIP-2024-0016', 1, '2024-12-04', '2024-12-19', 0),
    ('SIP-2024-0017', 2, '2024-12-05', '2024-12-20', 0),
    
    -- Ýptal edilmiþ sipariþ
    ('SIP-2024-0018', 3, '2024-11-12', '2024-11-27', 99);

PRINT 'Sipariþler eklendi (18 adet).';

-- =====================================================
-- 6. ADIM: SÝPARÝÞ KALEMLERÝ (OrderItems)
-- =====================================================

-- Not: ProcessedByUserID deðerleri Users tablosundaki mevcut kullanýcýlara göre ayarlanmalý
-- Eðer user yoksa NULL býrakýlýr

INSERT INTO OrderItems (OrderID, FabricID, TypeID, Quantity, CurrentStage, ProcessedByUserID) VALUES 
    -- Sipariþ 1 (Tamamlanmýþ)
    (1, 1, 1, 500, 5, NULL),    -- 500 adet Beyaz Pamuklu Penye T-Shirt
    (1, 2, 1, 300, 5, NULL),    -- 300 adet Siyah Pamuklu Penye T-Shirt
    (1, 4, 2, 200, 5, NULL),    -- 200 adet Beyaz Poplin Gömlek
    
    -- Sipariþ 2 (Tamamlanmýþ)
    (2, 6, 3, 400, 5, NULL),    -- 400 adet Lacivert Denim Pantolon
    (2, 7, 3, 250, 5, NULL),    -- 250 adet Siyah Denim Pantolon
    
    -- Sipariþ 3 (Tamamlanmýþ)
    (3, 10, 4, 150, 5, NULL),   -- 150 adet Kýrmýzý Viskon Elbise
    (3, 18, 4, 100, 5, NULL),   -- 100 adet Pembe Þifon Elbise
    (3, 19, 9, 200, 5, NULL),   -- 200 adet Krem Þifon Bluz
    
    -- Sipariþ 4 (Tamamlanmýþ)
    (4, 5, 2, 350, 5, NULL),    -- 350 adet Mavi Poplin Gömlek
    (4, 1, 13, 280, 5, NULL),   -- 280 adet Beyaz Pamuklu Penye Sweatshirt
    
    -- Sipariþ 5 (Tamamlanmýþ)
    (5, 12, 7, 120, 5, NULL),   -- 120 adet Gri Polar Mont
    (5, 13, 6, 150, 5, NULL),   -- 150 adet Lacivert Polar Ceket
    
    -- Sipariþ 6 (Kalite Kontrolde)
    (6, 2, 1, 600, 4, NULL),    -- 600 adet Siyah Pamuklu T-Shirt
    (6, 3, 1, 400, 4, NULL),    -- 400 adet Lacivert Pamuklu T-Shirt
    (6, 1, 13, 300, 4, NULL),   -- 300 adet Beyaz Sweatshirt
    
    -- Sipariþ 7 (Kalite Kontrolde)
    (7, 8, 3, 350, 4, NULL),    -- 350 adet Bej Gabardin Pantolon
    (7, 9, 3, 250, 4, NULL),    -- 250 adet Kahverengi Gabardin Pantolon
    
    -- Sipariþ 8 (Ütü/Paketlemede)
    (8, 4, 2, 400, 3, NULL),    -- 400 adet Beyaz Poplin Gömlek
    (8, 5, 2, 300, 3, NULL),    -- 300 adet Mavi Poplin Gömlek
    (8, 14, 2, 150, 3, NULL),   -- 150 adet Beyaz Keten Gömlek
    
    -- Sipariþ 9 (Ütü/Paketlemede)
    (9, 16, 5, 200, 3, NULL),   -- 200 adet Bordo Kadife Etek
    (9, 17, 5, 150, 3, NULL),   -- 150 adet Yeþil Kadife Etek
    
    -- Sipariþ 10 (Dikim Aþamasýnda)
    (10, 20, 4, 180, 2, NULL),  -- 180 adet Siyah Saten Elbise
    (10, 21, 4, 120, 2, NULL),  -- 120 adet Kýrmýzý Saten Elbise
    
    -- Sipariþ 11 (Dikim Aþamasýnda)
    (11, 6, 8, 500, 2, NULL),   -- 500 adet Lacivert Denim Þort
    (11, 7, 8, 350, 2, NULL),   -- 350 adet Siyah Denim Þort
    
    -- Sipariþ 12 (Dikim Aþamasýnda)
    (12, 22, 6, 100, 2, NULL),  -- 100 adet Gri Tweed Ceket
    (12, 23, 6, 80, 2, NULL),   -- 80 adet Kahverengi Tweed Ceket
    (12, 22, 15, 60, 2, NULL),  -- 60 adet Gri Tweed Kaban
    
    -- Sipariþ 13 (Kesimhanede)
    (13, 24, 2, 250, 1, NULL),  -- 250 adet Kýrmýzý Flanel Gömlek
    (13, 25, 2, 200, 1, NULL),  -- 200 adet Mavi Flanel Gömlek
    
    -- Sipariþ 14 (Kesimhanede)
    (14, 12, 11, 300, 1, NULL), -- 300 adet Gri Polar Pijama Takýmý
    (14, 13, 12, 400, 1, NULL), -- 400 adet Lacivert Polar Eþofman Altý
    
    -- Sipariþ 15 (Bekliyor)
    (15, 1, 1, 800, 0, NULL),   -- 800 adet Beyaz Pamuklu T-Shirt
    (15, 2, 1, 600, 0, NULL),   -- 600 adet Siyah Pamuklu T-Shirt
    (15, 3, 1, 400, 0, NULL),   -- 400 adet Lacivert Pamuklu T-Shirt
    
    -- Sipariþ 16 (Bekliyor)
    (16, 15, 14, 150, 0, NULL), -- 150 adet Bej Keten Hýrka
    (16, 14, 10, 200, 0, NULL), -- 200 adet Beyaz Keten Yelek
    
    -- Sipariþ 17 (Bekliyor)
    (17, 11, 4, 250, 0, NULL),  -- 250 adet Yeþil Viskon Elbise
    (17, 10, 9, 300, 0, NULL),  -- 300 adet Kýrmýzý Viskon Bluz
    
    -- Sipariþ 18 (Ýptal Edilmiþ)
    (18, 1, 1, 1000, 99, NULL), -- 1000 adet Beyaz T-Shirt (ÝPTAL)
    (18, 2, 1, 500, 99, NULL);  -- 500 adet Siyah T-Shirt (ÝPTAL)

PRINT 'Sipariþ kalemleri eklendi (44 adet).';

-- =====================================================
-- 7. ADIM: KALÝTE KONTROL KAYITLARI (QualityLogs)
-- =====================================================

-- Tamamlanmýþ ve kalite kontrol aþamasýndaki sipariþler için kayýtlar
INSERT INTO QualityLogs (OrderItemID, InspectionDate, IsDefective, DefectID, ConfidenceScore, ImagePath, OperatorNote) VALUES 
    -- Sipariþ 1 - Kalite kontrol geçmiþ (hatasýz)
    (1, '2024-11-13 09:15:00', 0, NULL, 0.98, 'images/qc/2024/11/item1_001.jpg', 'Kalite kontrol baþarýlý.'),
    (1, '2024-11-13 09:30:00', 0, NULL, 0.97, 'images/qc/2024/11/item1_002.jpg', 'Tüm ürünler standartlara uygun.'),
    (2, '2024-11-13 10:00:00', 0, NULL, 0.96, 'images/qc/2024/11/item2_001.jpg', 'Kontrol tamamlandý.'),
    (3, '2024-11-13 10:30:00', 1, 3, 0.89, 'images/qc/2024/11/item3_001.jpg', '2 üründe dikiþ hatasý tespit edildi. Tamir edildi.'),
    (3, '2024-11-13 11:00:00', 0, NULL, 0.95, 'images/qc/2024/11/item3_002.jpg', 'Tamir sonrasý kontrol baþarýlý.'),
    
    -- Sipariþ 2 - Kalite kontrol geçmiþ
    (4, '2024-11-18 14:00:00', 0, NULL, 0.99, 'images/qc/2024/11/item4_001.jpg', 'Mükemmel kalite.'),
    (5, '2024-11-18 14:30:00', 1, 4, 0.85, 'images/qc/2024/11/item5_001.jpg', '3 üründe renk farký. Ayrýþtýrýldý.'),
    (5, '2024-11-18 15:00:00', 0, NULL, 0.94, 'images/qc/2024/11/item5_002.jpg', 'Kalan ürünler onaylandý.'),
    
    -- Sipariþ 3 - Kalite kontrol geçmiþ
    (6, '2024-11-23 09:00:00', 0, NULL, 0.97, 'images/qc/2024/11/item6_001.jpg', 'Elbiseler kontrol edildi.'),
    (7, '2024-11-23 10:00:00', 1, 1, 0.92, 'images/qc/2024/11/item7_001.jpg', '1 üründe leke tespit edildi.'),
    (8, '2024-11-23 11:00:00', 0, NULL, 0.96, 'images/qc/2024/11/item8_001.jpg', 'Bluzlar onaylandý.'),
    
    -- Sipariþ 4 - Kalite kontrol geçmiþ
    (9, '2024-11-28 13:00:00', 0, NULL, 0.98, 'images/qc/2024/11/item9_001.jpg', 'Gömlekler standartlara uygun.'),
    (10, '2024-11-28 14:00:00', 0, NULL, 0.95, 'images/qc/2024/11/item10_001.jpg', 'Sweatshirtler onaylandý.'),
    
    -- Sipariþ 5 - Kalite kontrol geçmiþ
    (11, '2024-12-01 10:00:00', 1, 8, 0.88, 'images/qc/2024/12/item11_001.jpg', '5 montta düðme eksik. Tamamlandý.'),
    (12, '2024-12-01 11:00:00', 0, NULL, 0.97, 'images/qc/2024/12/item12_001.jpg', 'Ceketler onaylandý.'),
    
    -- Sipariþ 6 - Þu an kalite kontrolde (devam eden kontroller)
    (13, '2024-12-03 08:30:00', 0, NULL, 0.96, 'images/qc/2024/12/item13_001.jpg', 'Ýlk parti kontrol edildi. Sorun yok.'),
    (13, '2024-12-03 09:00:00', 1, 2, 0.91, 'images/qc/2024/12/item13_002.jpg', 'Ýkinci partide iplik çýkmasý.'),
    (14, '2024-12-03 09:30:00', 0, NULL, 0.94, 'images/qc/2024/12/item14_001.jpg', 'Kontrol devam ediyor.'),
    (15, '2024-12-03 10:00:00', 1, 10, 0.87, 'images/qc/2024/12/item15_001.jpg', 'Bazý sweatshirtlerde ölçü hatasý.'),
    
    -- Sipariþ 7 - Þu an kalite kontrolde
    (16, '2024-12-03 11:00:00', 0, NULL, 0.98, 'images/qc/2024/12/item16_001.jpg', 'Gabardin pantolonlar kontrol ediliyor.'),
    (17, '2024-12-03 11:30:00', 1, 12, 0.84, 'images/qc/2024/12/item17_001.jpg', 'Kesim hatasý tespit edildi. Ýnceleniyor.'),
    
    -- Geçmiþ kontroller - çeþitli hatalar
    (1, '2024-11-14 08:00:00', 0, NULL, 0.99, 'images/qc/2024/11/item1_final.jpg', 'Son kontrol. Sevkiyata hazýr.'),
    (4, '2024-11-19 08:00:00', 0, NULL, 0.98, 'images/qc/2024/11/item4_final.jpg', 'Son kontrol tamamlandý.'),
    (6, '2024-11-24 08:00:00', 0, NULL, 0.97, 'images/qc/2024/11/item6_final.jpg', 'Elbiseler sevkiyata hazýr.'),
    
    -- Daha fazla çeþitlilik için ek kayýtlar
    (2, '2024-11-14 09:00:00', 1, 6, 0.82, 'images/qc/2024/11/item2_defect.jpg', 'Bir üründe delik tespit edildi.'),
    (9, '2024-11-29 08:00:00', 1, 9, 0.79, 'images/qc/2024/11/item9_defect.jpg', 'Fermuar arýzasý. Deðiþtirildi.'),
    (10, '2024-11-29 09:00:00', 1, 7, 0.86, 'images/qc/2024/11/item10_defect.jpg', 'Kumaþ hatasý tespit edildi.'),
    (11, '2024-12-02 08:00:00', 0, NULL, 0.96, 'images/qc/2024/12/item11_final.jpg', 'Tüm düðmeler tamamlandý. Onaylandý.'),
    (12, '2024-12-02 09:00:00', 0, NULL, 0.98, 'images/qc/2024/12/item12_final.jpg', 'Son kontrol baþarýlý.');

PRINT 'Kalite kontrol kayýtlarý eklendi (29 adet).';

-- =====================================================
-- ÖZET RAPOR
-- =====================================================

PRINT '';
PRINT '=== DEMO VERÝLERÝ BAÞARIYLA YÜKLENDÝ ===';
PRINT '';
PRINT 'Yüklenen Veri Özeti:';
PRINT '--------------------';

SELECT 'Colors' AS Tablo, COUNT(*) AS [Kayýt Sayýsý] FROM Colors
UNION ALL
SELECT 'ProductTypes', COUNT(*) FROM ProductTypes
UNION ALL
SELECT 'DefectTypes', COUNT(*) FROM DefectTypes
UNION ALL
SELECT 'Fabrics', COUNT(*) FROM Fabrics
UNION ALL
SELECT 'Customers', COUNT(*) FROM Customers
UNION ALL
SELECT 'Orders', COUNT(*) FROM Orders
UNION ALL
SELECT 'OrderItems', COUNT(*) FROM OrderItems
UNION ALL
SELECT 'QualityLogs', COUNT(*) FROM QualityLogs
UNION ALL
SELECT 'Users (KORUNDU)', COUNT(*) FROM Users;

PRINT '';
PRINT 'Sipariþ Durumu Daðýlýmý:';
PRINT '-----------------------';

SELECT 
    CASE OrderStatus 
        WHEN 0 THEN 'Bekliyor'
        WHEN 1 THEN 'Kesimhanede'
        WHEN 2 THEN 'Dikimde'
        WHEN 3 THEN 'Ütü/Paketleme'
        WHEN 4 THEN 'Kalite Kontrol'
        WHEN 5 THEN 'Tamamlandý'
        WHEN 99 THEN 'Ýptal'
    END AS [Sipariþ Durumu],
    COUNT(*) AS [Sipariþ Sayýsý]
FROM Orders
GROUP BY OrderStatus
ORDER BY OrderStatus;

PRINT '';
PRINT '=== SCRIPT TAMAMLANDI ===';
