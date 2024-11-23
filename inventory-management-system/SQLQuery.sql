-- Enable IDENTITY_INSERT for InventoryTransactions table
SET IDENTITY_INSERT [InventoryDb].[dbo].[InventoryTransactions] ON;

-- Insert data into InventoryTransactions table
INSERT INTO [InventoryDb].[dbo].[InventoryTransactions] 
([TransactionId], [ItemId], [SupplierId], [TransactionType], [Quantity], [TransactionDate])
VALUES
(5, 2, 1, 'Purchase', 15, '2024-11-25 00:00:00.0000000'),
(6, 3, 2, 'Purchase', 40, '2024-11-25 00:00:00.0000000'),
(7, 2, NULL, 'Sale', 7, '2024-11-26 00:00:00.0000000'),
(8, 3, NULL, 'Sale', 30, '2024-11-26 00:00:00.0000000'),
(9, 2, 1, 'Purchase', 25, '2024-11-27 00:00:00.0000000'),
(10, 3, 2, 'Purchase', 60, '2024-11-27 00:00:00.0000000'),
(11, 4, 3, 'Purchase', 10, '2024-11-28 00:00:00.0000000'),
(12, 5, 4, 'Purchase', 20, '2024-11-28 00:00:00.0000000'),
(13, 4, NULL, 'Sale', 5, '2024-11-29 00:00:00.0000000'),
(14, 5, NULL, 'Sale', 10, '2024-11-29 00:00:00.0000000'),
(15, 6, 5, 'Purchase', 50, '2024-11-30 00:00:00.0000000'),
(16, 7, 3, 'Purchase', 25, '2024-11-30 00:00:00.0000000'),
(17, 6, NULL, 'Sale', 20, '2024-12-01 00:00:00.0000000'),
(18, 7, NULL, 'Sale', 15, '2024-12-01 00:00:00.0000000'),
(19, 8, 4, 'Purchase', 30, '2024-12-02 00:00:00.0000000');

-- Disable IDENTITY_INSERT for InventoryTransactions table
SET IDENTITY_INSERT [InventoryDb].[dbo].[InventoryTransactions] OFF;

-- Enable IDENTITY_INSERT for Items table
SET IDENTITY_INSERT [InventoryDb].[dbo].[Items] ON;

-- Insert data into Items table
INSERT INTO [InventoryDb].[dbo].[Items] 
([ItemId], [ItemName], [ItemDescription], [Quantity], [UnitPrice])
VALUES
(4, 'Keyboard', 'Wireless Keyboard, Black', 150, 1200.00),
(5, 'Headphones', 'Noise-cancelling Headphones, Over-ear', 75, 8000.00),
(6, 'USB Cable', 'Fast Charging USB-C Cable, 1m', 300, 150.00),
(7, 'Laptop Bag', 'Waterproof Laptop Bag, 15 inch', 50, 2500.00),
(8, 'Webcam', 'HD Webcam for Video Calls', 40, 5000.00),
(9, 'Smartphone Stand', 'Adjustable Stand for Smartphones', 200, 800.00),
(10, 'Mousepad', 'Ergonomic Mousepad with Wrist Support', 500, 450.00),
(11, 'Laptop Sleeve', 'Slim Laptop Sleeve, 13 inch', 150, 1000.00),
(12, 'Bluetooth Speaker', 'Portable Bluetooth Speaker, 20W', 100, 3000.00),
(13, 'Charger Adapter', 'Fast Charging Power Adapter', 200, 600.00),
(14, 'Power Bank', '20000mAh Power Bank, Portable', 120, 4000.00),
(15, 'Portable Hard Drive', '1TB External USB Hard Drive', 60, 6500.00),
(16, 'Monitor Stand', 'Adjustable Monitor Stand, Aluminum', 80, 2000.00),
(17, 'Docking Station', 'USB-C Docking Station for Laptops', 30, 12000.00),
(18, 'Gaming Mouse', 'RGB Gaming Mouse with Adjustable DPI', 100, 1500.00);

-- Disable IDENTITY_INSERT for Items table
SET IDENTITY_INSERT [InventoryDb].[dbo].[Items] OFF;

-- Enable IDENTITY_INSERT for Suppliers table
SET IDENTITY_INSERT [InventoryDb].[dbo].[Suppliers] ON;

-- Insert data into Suppliers table
INSERT INTO [InventoryDb].[dbo].[Suppliers] 
([SupplierId], [SupplierName], [ContactInfo])
VALUES
(3, 'Tech World', '123 Tech Street, Colombo, 0771234567'),
(4, 'Gadget Galaxy', '456 Gadget Avenue, Kandy, 0782345678'),
(5, 'Hardware Hub', '789 Hardware Blvd, Gampaha, 0793456789'),
(6, 'Digital Supplies', '101 Digital Street, Colombo, 0715678901'),
(7, 'ElectroMart', '202 Electro Way, Galle, 0726789012'),
(8, 'FutureTech', '303 Future Lane, Jaffna, 0737890123'),
(9, 'Office Essentials', '404 Office Blvd, Anuradhapura, 0748901234'),
(10, 'TechnoMart', '505 Techno Road, Matara, 0759012345'),
(11, 'PC Solutions', '606 PC Street, Nuwara Eliya, 0760123456'),
(12, 'SmartTech', '707 Smart Way, Kandy, 0771234567'),
(13, 'CircuitWorld', '808 Circuit Rd, Colombo, 0782345678'),
(14, 'Laptop Pro', '909 Laptop Avenue, Negombo, 0793456789'),
(15, 'Device Mart', '1001 Device Blvd, Moratuwa, 0704567890'),
(16, 'Gizmo World', '1102 Gizmo Park, Galle, 0715678901'),
(17, 'Techno Supplies', '1203 Techno Drive, Kurunegala, 0726789012');

-- Disable IDENTITY_INSERT for Suppliers table
SET IDENTITY_INSERT [InventoryDb].[dbo].[Suppliers] OFF;


-- Check existing ItemIds in Items table
SELECT [ItemId], [ItemName] FROM [InventoryDb].[dbo].[Items];

-- Insert missing items into Items table
INSERT INTO [InventoryDb].[dbo].[Items] 
([ItemId], [ItemName], [ItemDescription], [Quantity], [UnitPrice])
VALUES
(4, 'Keyboard', 'Wireless Keyboard, Black', 150, 1200.00),
(5, 'Headphones', 'Noise-cancelling Headphones, Over-ear', 75, 8000.00),
(6, 'USB Cable', 'Fast Charging USB-C Cable, 1m', 300, 150.00),
(7, 'Laptop Bag', 'Waterproof Laptop Bag, 15 inch', 50, 2500.00),
(8, 'Webcam', 'HD Webcam for Video Calls', 40, 5000.00);

-- Enable IDENTITY_INSERT for InventoryTransactions table
SET IDENTITY_INSERT [InventoryDb].[dbo].[InventoryTransactions] ON;

-- Insert data into InventoryTransactions table
INSERT INTO [InventoryDb].[dbo].[InventoryTransactions] 
([TransactionId], [ItemId], [SupplierId], [TransactionType], [Quantity], [TransactionDate])
VALUES
(5, 2, 1, 'Purchase', 15, '2024-11-25 00:00:00.0000000'),
(6, 3, 2, 'Purchase', 40, '2024-11-25 00:00:00.0000000'),
(7, 2, NULL, 'Sale', 7, '2024-11-26 00:00:00.0000000'),
(8, 3, NULL, 'Sale', 30, '2024-11-26 00:00:00.0000000'),
(9, 2, 1, 'Purchase', 25, '2024-11-27 00:00:00.0000000'),
(10, 3, 2, 'Purchase', 60, '2024-11-27 00:00:00.0000000'),
(11, 4, 3, 'Purchase', 10, '2024-11-28 00:00:00.0000000'),
(12, 5, 4, 'Purchase', 20, '2024-11-28 00:00:00.0000000'),
(13, 4, NULL, 'Sale', 5, '2024-11-29 00:00:00.0000000'),
(14, 5, NULL, 'Sale', 10, '2024-11-29 00:00:00.0000000'),
(15, 6, 5, 'Purchase', 50, '2024-11-30 00:00:00.0000000'),
(16, 7, 3, 'Purchase', 25, '2024-11-30 00:00:00.0000000'),
(17, 6, NULL, 'Sale', 20, '2024-12-01 00:00:00.0000000'),
(18, 7, NULL, 'Sale', 15, '2024-12-01 00:00:00.0000000'),
(19, 8, 4, 'Purchase', 30, '2024-12-02 00:00:00.0000000');

-- Disable IDENTITY_INSERT for InventoryTransactions table
SET IDENTITY_INSERT [InventoryDb].[dbo].[InventoryTransactions] OFF;
