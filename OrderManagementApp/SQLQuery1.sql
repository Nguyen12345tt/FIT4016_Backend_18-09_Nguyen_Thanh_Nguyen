USE master;
GO

-- 1. Xóa Database cũ nếu tồn tại (Để làm sạch 100%)
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'OrderExamDB_Final')
BEGIN
    ALTER DATABASE [OrderExamDB_Final] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [OrderExamDB_Final];
END
GO

-- 2. Tạo Database Mới
CREATE DATABASE [OrderExamDB_Final];
GO

USE [OrderExamDB_Final];
GO

-- 3. Tạo bảng Products
CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(450) NOT NULL,
    [Sku] nvarchar(450) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Price] decimal(18,2) NOT NULL,
    [StockQuantity] int NOT NULL,
    [Category] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

-- 4. Tạo bảng Orders
CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [OrderNumber] nvarchar(450) NOT NULL,
    [CustomerName] nvarchar(100) NOT NULL,
    [CustomerEmail] nvarchar(450) NOT NULL,
    [Quantity] int NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [DeliveryDate] datetime2 NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

-- 5. Tạo Index (Ràng buộc Unique)
CREATE UNIQUE INDEX [IX_Orders_CustomerEmail] ON [Orders] ([CustomerEmail]);
CREATE UNIQUE INDEX [IX_Orders_OrderNumber] ON [Orders] ([OrderNumber]);
CREATE INDEX [IX_Orders_ProductId] ON [Orders] ([ProductId]);
CREATE UNIQUE INDEX [IX_Products_Name] ON [Products] ([Name]);
CREATE UNIQUE INDEX [IX_Products_Sku] ON [Products] ([Sku]);
GO

-- 6. Tạo bảng Lịch sử Migration (Để đánh lừa EF là đã chạy rồi)
CREATE TABLE [__EFMigrationsHistory] (
    [MigrationId] nvarchar(150) NOT NULL,
    [ProductVersion] nvarchar(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
);
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260117000000_InitialCreate', N'9.0.0');
GO

-- 7. Thêm dữ liệu mẫu (Seed Data)
SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Name], [Sku], [Price], [StockQuantity], [Category], [CreatedAt])
VALUES 
(1, N'iPhone 15', N'IP15-001', 1000.0, 50, N'Phone', GETDATE()),
(2, N'Samsung S24', N'SS24-002', 900.0, 40, N'Phone', GETDATE()),
(3, N'MacBook Pro', N'MAC-003', 2000.0, 20, N'Laptop', GETDATE());
SET IDENTITY_INSERT [Products] OFF;
GO