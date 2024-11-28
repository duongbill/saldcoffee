use master
go
drop database  if EXISTS quanly_sald;
go
CREATE DATABASE quanly_sald;

go

USE quanly_sald;
GO

-- Table: TableFood
CREATE TABLE TableFood(
    TableId INT IDENTITY PRIMARY KEY,
    TableName NVARCHAR(100),
    TrangThai NVARCHAR(100) -- Trống, có khách, đã được đặt
);
GO

-- Table: AccRole
CREATE TABLE AccRole(
    RoleId INT IDENTITY PRIMARY KEY,
    RoleName NVARCHAR(100) NOT NULL
);
GO

-- Table: Account
CREATE TABLE Account (
    AccountId INT IDENTITY PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL,
    UserName NVARCHAR(50) NOT NULL,
    PassWord NVARCHAR(50) NOT NULL,
    RoleName NVARCHAR(50) not null
);
GO

-- Table: Category
CREATE TABLE Category (
    CategoryId INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(100) NOT NULL
);
GO

-- Table: Ingredient
CREATE TABLE Ingredient (
    IngredientId INT PRIMARY KEY IDENTITY,
    IngredientName NVARCHAR(100) NOT NULL,
    SoLuong INT NOT NULL DEFAULT 0,
	PhanLoai Nvarchar(50) not null,
    LastUpdated DATE NOT NULL DEFAULT GETDATE()
);
GO

-- Table: Food
CREATE TABLE Food (
    FoodId INT PRIMARY KEY IDENTITY,
    FoodName NVARCHAR(100) NOT NULL,
    CategoryId INT,
    IngredientId INT,
    Price DECIMAL(18, 3) NOT NULL DEFAULT 0,
	ImageURL VARCHAR(255) NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
    FOREIGN KEY (IngredientId) REFERENCES Ingredient(IngredientId)
);
GO

-- Table: Invoice
CREATE TABLE Invoice (
    InvoiceId INT PRIMARY KEY IDENTITY,
    TableId INT,
    DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATE,
    TrangThai INT, -- 1 là thanh toán, 0 là chưa thanh toán
    TotalPrice DECIMAL(18, 3) NOT NULL DEFAULT 0,
    FOREIGN KEY (TableId) REFERENCES TableFood(TableId)
);
GO

-- Table: Payment
CREATE TABLE Payment (
    PaymentId INT PRIMARY KEY IDENTITY,
    PaymentMethod NVARCHAR(50) NOT NULL,
    InvoiceId INT,
    FOREIGN KEY (InvoiceId) REFERENCES Invoice(InvoiceId)
);
GO


-- Table: InvoiceDetail
CREATE TABLE InvoiceDetail(
    InvoiceDetailId INT PRIMARY KEY IDENTITY,
    InvoiceId INT,
    FoodId INT,
    SoLuong INT NOT NULL DEFAULT 0,
    Price DECIMAL(18, 3) NOT NULL,
    FOREIGN KEY (InvoiceId) REFERENCES Invoice(InvoiceId),
    FOREIGN KEY (FoodId) REFERENCES Food(FoodId)
);
GO

-- Table: Staff
CREATE TABLE Staff (
    StaffId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    DateOfBirth DATE NULL,
    Email NVARCHAR(50) NULL,
    Gender NVARCHAR(50) null,
    AccountId INT,
    RoleId INT,
    FOREIGN KEY (AccountId) REFERENCES Account(AccountId),
    FOREIGN KEY (RoleId) REFERENCES AccRole(RoleId)
);
GO
UPDATE Staff
SET Gender = CASE 
    WHEN Gender = 'True' THEN 'Nam'
    WHEN Gender = 'False' THEN 'Nữ'
END






-- Table: Warehouse
CREATE TABLE Warehouse (
    WarehouseId INT PRIMARY KEY IDENTITY,
    IngredientId INT,
    SoLuong INT NOT NULL DEFAULT 0,
    DateUpdate DATE NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IngredientId) REFERENCES Ingredient(IngredientId)
);
GO

-- Table: Orders
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY,
    InvoiceDetailId INT,
    Status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (InvoiceDetailId) REFERENCES InvoiceDetail(InvoiceDetailId)
);
GO

-- nhieu nguyen lieu
CREATE TABLE FoodIngredient (
    FoodIngredientId INT PRIMARY KEY IDENTITY,
    FoodId INT,
    IngredientId INT,
    Quantity INT NOT NULL, -- Số lượng nguyên liệu cho món ăn này
    FOREIGN KEY (FoodId) REFERENCES Food(FoodId),
    FOREIGN KEY (IngredientId) REFERENCES Ingredient(IngredientId)
);
GO

INSERT INTO TableFood (TableName, TrangThai)
VALUES
('Table 1', N'Bàn Trống'),
('Table 2', N'Đã có khách');

INSERT INTO AccRole (RoleName)
VALUES
(N'Quản lý'),
(N'Pha chế'),
(N'Phục vụ');

INSERT INTO Account (DisplayName, UserName, PassWord, RoleName)
VALUES
('Admin ', 'admin', '1', 'Admin');



INSERT INTO Category (CategoryName)
VALUES
(N'Cà phê'),
(N'Trà sữa'),
(N'Thức uống đá xay'),
(N'Bánh & Snack'),
(N'Trà trái cây');


INSERT INTO Ingredient (IngredientName, SoLuong, PhanLoai, LastUpdated)
VALUES
(N'Coffee', 100, N'gói', '2024-08-05'),
(N'Sữa', 500, N'chai', '2024-08-05'),
(N'Đường', 200, N'gói', '2024-08-05'),
(N'Trà', 75, N'quả', '2024-08-05'),
(N'Táo', 50, N'quả', '2024-08-05'),
(N'Trân châu', 100, N'bịch', '2024-08-05'),
(N'Matcha', 120, N'gói', '2024-08-05'),
(N'Yến mạch', 130, N'gói', '2024-08-05'),
(N'Caramel', 140, N'cái', '2024-08-05'),
(N'Muối', 125, N'gói', '2024-08-05'),
(N'Hạnh nhân', 115, N'quả', '2024-08-05'),
(N'Bơ', 120, N'quả', '2024-08-05'),
(N'Kem', 150, N'cây', '2024-08-05'),
(N'Chip', 130, N'gói', '2024-08-05'),
(N'Mochi kem phúc bồn tử', 120, N'cái', '2024-08-05'),
(N'Mochi kem việt quất', 120, N'cái', '2024-08-05'),
(N'Mochi kem chocolate', 120, N'cái', '2024-08-05'),
(N'Mousse gấu chocolate', 110, N'cái', '2024-08-05'),
(N'Bánh mì', 150, N'ổ', '2024-08-05'),
(N'Sữa đặc', 160, N'lọ', '2024-08-05'),
(N'Cam', 135, N'quả', '2024-08-05'),
(N'Sả', 125, N'cây', '2024-08-05'),
(N'Hạt sen', 115, N'bịch', '2024-08-05'),
(N'Vải', 140, N'quả', '2024-08-05'),
(N'Yuzu', 120, N'quả', '2024-08-05'),
(N'Đào', 120, N'quả', '2024-08-05'),
(N'Bánh Gấu', 120, N'bịch', '2024-08-05'),
(N'Sương Sáo', 120, N'cốc', '2024-08-05'),
(N'Dâu', 120, N'quả', '2024-08-05'),
(N'Bim Bim Ngô', 120, N'gói', '2024-08-05'),
(N'Bim Bim Sữa Dừa', 120, N'gói', '2024-08-05');


INSERT INTO Food (FoodName, CategoryId, IngredientId, Price,ImageURL)
VALUES
(N'Trà xanh espresso marble', 1, 1, 45000,'/img/Cafe/bacxiulacsua.png'),
(N'Bạc xỉu lắc sữa yến mạch', 1, 1, 50000,'/img/Cafe/bacxiulacsua.png'),
(N'Bạc xỉu lắc caramel muối', 1, 1, 55000,'/img/Cafe/bacxiulacsua.png'),
(N'Bạc xỉu lắc hạnh nhân nướng', 1, 1, 55000,'/img/Cafe/bacxiulacsua.png'),
(N'Bơ arabica', 1, 1, 60000,'/img/Cafe/bacxiulacsua.png'),
(N'Đường đen sữa đá', 1, 1, 30000,'/img/Cafe/bacxiulacsua.png'),
(N'Cà phê sữa đá', 1, 1, 25000,'/img/Cafe/bacxiulacsua.png'),
(N'Cà phê sữa nóng', 1, 1, 25000,'/img/Cafe/bacxiulacsua.png'),
(N'Bạc xỉu', 1, 1, 30000,'/img/Cafe/bacxiulacsua.png'),
(N'Cà phê đen', 1, 1, 20000,'/img/Cafe/bacxiulacsua.png'),


(N'Trà sữa trân châu đường đen', 2, 2, 35000,'/img/cafe/traxanh(1)(1).png'),
(N'Trà sữa olong', 2, 2, 30000,'/img/cafe/traxanh(1)(1).png'),
(N'Trà sữa olong tứ quý bơ', 2, 2, 35000,'/img/cafe/traxanh(1)(1).png'),
(N'Trà sữa olong nướng sương sáo', 2, 2, 35000,'/img/cafe/traxanh(1)(1).png'),
(N'Trà đen macchito', 2, 2, 30000,'/img/cafe/traxanh(1)(1).png'),
(N'Hồng trà sữa trân châu', 2, 2, 30000,'/img/cafe/traxanh(1)(1).png'),

(N'Frosty phin-gato', 3, 3, 40000,'/img/cafe/traxanh(1)(1).png'),
(N'Frosty cà phê đường đen', 3, 3, 40000,'/img/cafe/traxanh(1)(1).png'),
(N'Frosty bánh kem dâu', 3, 3, 45000,'/img/cafe/traxanh(1)(1).png'),
(N'Frosty choco chip', 3, 3, 45000,'/img/cafe/traxanh(1)(1).png'),
(N'Frosty caramel', 3, 3, 45000,'/img/cafe/traxanh(1)(1).png'),

(N'Butter croissant', 4, 4, 25000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Mochi kem phúc bồn tử', 4, 4, 30000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Mochi kem việt quất', 4, 4, 30000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Mochi kem chocolate', 4, 4, 30000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Mousse gấu chocolate', 4, 4, 35000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Bánh mì Việt Nam', 4, 4, 15000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Bim bim ngô', 4, 4, 10000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Bim bim sữa dừa', 4, 4, 10000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Bánh gấu', 4, 4, 15000,'\\img\\cafe\\traxanh(1)(1).png'),

(N'Trà đào cam xả', 5, 5, 40000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Olong tứ quý sen', 5, 5, 35000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Đào kombucha', 5, 5, 45000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Trà vải', 5, 5, 35000,'\\img\\cafe\\traxanh(1)(1).png'),
(N'Trà yuzu kombucha', 5, 5, 50000,'\\img\\cafe\\traxanh(1)(1).png');

-- Ingredients for Trà xanh espresso marble
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(1, 1, 1), -- Coffee
(1, 2, 1), -- Milk
(1, 7, 1); -- Matcha

-- Ingredients for Bạc xỉu lắc sữa yến mạch
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(2, 1, 1), -- Coffee
(2, 2, 1), -- Milk
(2, 8, 1); -- Yến mạch

-- Ingredients for Bạc xỉu lắc caramel muối
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(3, 1, 1), -- Coffee
(3, 2, 1), -- Milk
(3, 9, 1), -- Caramel
(3, 10, 1); -- Salt

-- Ingredients for Bạc xỉu lắc hạnh nhân nướng
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(4, 1, 1), -- Coffee
(4, 2, 1), -- Milk
(4, 11, 1); -- Almond

-- Ingredients for Bơ arabica
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(5, 1, 1), -- Coffee
(5, 2, 1), -- Milk
(5, 12, 1); -- Butter

-- Ingredients for Đường đen sữa đá
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(6, 1, 1), -- Coffee
(6, 3, 1), -- Sugar
(6, 2, 1); -- Milk

-- Ingredients for Cà phê sữa đá
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(7, 1, 1), -- Coffee
(7, 2, 1); -- Milk

-- Ingredients for Cà phê sữa nóng
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(8, 1, 1), -- Coffee
(8, 2, 1); -- Milk

-- Ingredients for Bạc xỉu
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(9, 1, 1), -- Coffee
(9, 2, 1); -- Milk

-- Ingredients for Cà phê đen
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(10, 1, 1), -- Coffee
(10, 3, 1); -- Sugar

-- Ingredients for Trà sữa trân châu đường đen
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(11, 4, 1), -- Tea
(11, 2, 1), -- Milk
(11, 6, 1), -- Tapioca pearls
(11, 3, 1); -- Sugar

-- Ingredients for Trà sữa olong
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(12, 4, 1), -- Tea
(12, 2, 1); -- Milk

-- Ingredients for Trà sữa olong tứ quý bơ
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(13, 4, 1), -- Tea
(13, 2, 1), -- Milk
(13, 12, 1); -- Butter

-- Ingredients for Trà sữa olong nướng sương sáo
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(14, 4, 1), -- Tea
(14, 2, 1), -- Milk
(14, 28, 1); -- sương sáo

-- Ingredients for Trà đen macchito
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(15, 4, 1), -- Tea
(15, 2, 1); -- Milk

-- Ingredients for Hồng trà sữa trân châu
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(16, 4, 1), -- Tea
(16, 2, 1), -- Milk
(16, 6, 1); -- Tapioca pearls

-- Continue similarly for other food items in each category.

-- Ingredients for Frosty phin-gato
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(17, 4, 1), -- Tea
(17, 2, 1), -- Milk
(17, 13, 1), -- Cream
(17, 6, 1); -- Tapioca pearls

-- Ingredients for Frosty cà phê đường đen
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(18, 4, 1), -- Tea
(18, 2, 1), -- Milk
(18, 13, 1), -- Cream
(18, 3, 1); -- Sugar

-- Ingredients for Frosty bánh kem dâu
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(19, 4, 1), -- Tea
(19, 2, 1), -- Milk
(19, 13, 1), -- Cream
(19, 29, 1); -- Strawberry

-- Ingredients for Frosty choco chip
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(20, 4, 1), -- Tea
(20, 2, 1), -- Milk
(20, 13, 1), -- Cream
(20, 14, 1); -- Chocolate chip

-- Ingredients for Frosty caramel
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(21, 4, 1), -- Tea
(21, 2, 1), -- Milk
(21, 13, 1), -- Cream
(21, 9, 1); -- Caramel

-- Bánh & Snack (Pastry & Snack)

-- Ingredients for Butter croissant
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(22, 19, 1), -- Bread
(22, 20, 1); -- Condensed milk

-- Ingredients for Mochi kem phúc bồn tử
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(23, 15, 1); -- Mochi raspberry ice cream

-- Ingredients for Mochi kem việt quất
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(24, 16, 1); -- Mochi blueberry ice cream

-- Ingredients for Mochi kem chocolate
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(25, 17, 1); -- Mochi chocolate ice cream

-- Ingredients for Mousse gấu chocolate
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(26, 18, 1); -- Chocolate mousse bear

-- Ingredients for Bánh mì Việt Nam
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(27, 19, 1); -- Bread

-- Ingredients for Bim bim ngô
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(28, 30, 1); -- Corn snack

-- Ingredients for Bim bim sữa dừa
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(29, 31, 1); -- Coconut milk snack                                            

-- Ingredients for Bánh gấu
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(30, 27, 1); -- Bear biscuit

-- Trà trái cây (Fruit tea)

-- Ingredients for Trà đào cam xả
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(31, 4, 1), -- Tea
(31, 26, 1), -- đào
(31, 22, 1), -- Sả
(31, 21, 1); -- cam

-- Ingredients for Olong tứ quý sen
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(32, 4, 1), -- Tea
(32, 23, 1); -- Lotus seed

-- Ingredients for Đào kombucha
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(33, 4, 1), -- Tea
(33, 26, 1); -- Peach

-- Ingredients for Trà vải
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(34, 4, 1), -- Tea
(34, 24, 1); -- Lychee

-- Ingredients for Trà yuzu kombucha
INSERT INTO FoodIngredient (FoodId, IngredientId, Quantity)
VALUES 
(35, 4, 1), -- Tea
(35, 25, 1); -- Orange (Yuzu)




-- Insert vào Invoice
INSERT INTO Invoice (TableId, DateCheckIn, DateCheckOut, TrangThai, TotalPrice)
VALUES
(1, '2024-08-06', '2024-08-06', 0, 70000.000),
(2, '2024-08-06', '2024-08-06', 0, 40000.000);

-- Insert vào InvoiceDetail
INSERT INTO InvoiceDetail (InvoiceId, FoodId, SoLuong, Price)
VALUES
(1, 1, 2, 40000.000),
(1, 2, 1, 30000.000),
(2, 3, 1, 25000.000),
(2, 4, 2, 15000.000);

-- Insert vào Payment
INSERT INTO Payment (PaymentMethod, InvoiceId)
VALUES
(N'Tiền mặt', 1),
(N'Thẻ tín dụng', 2);



-- Bảng Staff
INSERT INTO Staff (FullName, Phone, DateOfBirth, Email, Gender, AccountId, RoleId) 
VALUES
(N'Nguyen Hai Duong', '0985082004', '2004-08-05', 'billduongg@gmail.com', 'Nam', 1, 1),
(N'Nguyen Minh Hoang', '0985082005', '2004-08-06', 'staff2@gmail.com', 'Nam', null, 2),
(N'Nguyen Bao Han', '0985082029', '2004-08-16', 'staff1@gmail.com', 'Nam', null, 2),
(N'Nguyen Thi Hoai Suong', '0985082006', '2004-08-07', 'staff3@gmail.com', 'Nam', null, 3),
(N'Dieu Thuy Lien', '0985082007', '2004-08-08', 'staff4@gmail.com', 'Nam', null, 3),
(N'Vu Hoang Anh', '0985082008', '2004-08-09', 'staff5@gmail.com', 'Nam', null, 3),
(N'Vu Hoang Em', '0985082009', '2004-08-10', 'staff6@gmail.com', N'Nữ', null, 3);




-- Bảng Warehouse
INSERT INTO Warehouse (IngredientId, SoLuong, DateUpdate)
VALUES
(1, 100, GETDATE()),
(2, 50, GETDATE()),
(3, 200, GETDATE()),
(4, 75, GETDATE());

-- Bảng Orders
INSERT INTO Orders (InvoiceDetailId, Status)
VALUES
(1, N'Hoàn thành'),
(2, N'Chưa hoàn thành');










SELECT * FROM dbo.Account

SELECT * FROM Staff[QLSanpham]

SELECT s.StaffId, s.FullName, s.Phone, s.DateOfBirth, s.Email, s.Gender, a.RoleName, s.ImageStaff
FROM Staff s
INNER JOIN AccRole a ON s.RoleId = a.RoleId;

SELECT * FROM dbo.Food

select * from dbo.Ingredient

CREATE PROCEDURE GetFoodDetailsByName
    @FoodName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        FoodName, 
        Price, 
        ImageURL
    FROM 
        Food
    WHERE 
        FoodName = @FoodName;
END;
go
EXEC GetFoodDetailsByName @FoodName = N'Bạc xỉu';



SELECT 
    FoodName, 
    Price, 
    ImageURL
FROM 
    Food
WHERE 
    FoodName = N'Bạc xỉu';

select * from staff

SELECT FoodName, Price, ImageURL FROM Food

CREATE PROCEDURE GetTop10FoodsByCategory
    @CategoryId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 100
        FoodName, 
        Price, 
        ImageURL
    FROM 
        Food
    WHERE 
        CategoryId = @CategoryId
END
GO

EXEC GetTop10FoodsByCategory @CategoryId = 1

--DROP PROCEDURE GetTop10FoodsByCategory;

select foodname, price, imageURL from food
role id => chuc vu
chuc vu => id 