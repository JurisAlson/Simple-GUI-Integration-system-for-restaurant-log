-- Create Customer table
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR2(50),
    LastName VARCHAR2(50),
    Address VARCHAR2(80),
    PhoneNumber VARCHAR2(15),
    Email VARCHAR2(80)
);

-- Create Product table
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR2(100),
    Description VARCHAR2(200),  
    Price NUMBER(10,2),
    Category VARCHAR2(20) CHECK (Category IN ('BreakFast', 'Lunch', 'Dinner'))
);

-- Create Orders2 table with foreign key to Customer (with ON DELETE CASCADE)
CREATE TABLE Orders2 (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount NUMBER(10, 2),
    OrderStatus VARCHAR2(20) CHECK (OrderStatus IN ('preparing', 'order out', 'receive')),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE
);

-- Create OrderItem table with foreign key to Orders2 and Product (ON DELETE CASCADE on OrderID)
CREATE TABLE OrderItem (
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    ItemPrice NUMBER(10,2),
    FOREIGN KEY (OrderID) REFERENCES Orders2(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Create Payment table with foreign key to Orders2 (ON DELETE CASCADE)
CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY,
    OrderID INT,
    PaymentDate DATE,
    PaymentMethod VARCHAR2(20) CHECK (PaymentMethod IN ('Cash', 'Credit Card', 'Debit Card')),
    PaymentStatus VARCHAR2(20) CHECK (PaymentStatus IN ('Pending', 'Completed')),
    FOREIGN KEY (OrderID) REFERENCES Orders2(OrderID) ON DELETE CASCADE
);


-- Insert into Customer
INSERT INTO Customer (CustomerID, FirstName, LastName, Address, PhoneNumber, Email) VALUES
(1, 'John', 'Doe', '123 Main St', '123-456-7890', 'john.doe@example.com');

INSERT INTO Customer (CustomerID, FirstName, LastName, Address, PhoneNumber, Email) VALUES
(2, 'Jane', 'Smith', '456 Oak Ave', '987-654-3210', 'jane.smith@example.com');

INSERT INTO Customer (CustomerID, FirstName, LastName, Address, PhoneNumber, Email) VALUES
(3, 'Bob', 'Brown', '789 Pine Rd', '555-123-4567', 'bob.brown@example.com');

-- Insert into Product
INSERT INTO Product (ProductID, ProductName, Description, Price, Category)
VALUES (1, 'Pancakes', 'Fluffy pancakes with syrup', 5.99, 'BreakFast');

INSERT INTO Product (ProductID, ProductName, Description, Price, Category)
VALUES (2, 'Omelette', 'Three-egg omelette with cheese', 6.99, 'BreakFast');

INSERT INTO Product (ProductID, ProductName, Description, Price, Category)
VALUES (3, 'Burger', 'Beef burger with fries', 8.99, 'Lunch');

INSERT INTO Product (ProductID, ProductName, Description, Price, Category)
VALUES (4, 'Salad', 'Caesar salad with chicken', 7.99, 'Lunch');

INSERT INTO Product (ProductID, ProductName, Description, Price, Category)
VALUES (5, 'Steak', 'Grilled steak with veggies', 14.99, 'Dinner');

INSERT INTO Product (ProductID, ProductName, Description, Price, Category)
VALUES (6, 'Pasta', 'Creamy Alfredo pasta', 11.99, 'Dinner');

INSERT INTO Orders2 (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus)
VALUES (101, 1, TO_DATE('2025-06-20', 'YYYY-MM-DD'), 17.98, 'preparing');

INSERT INTO Orders2 (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus)
VALUES (102, 2, TO_DATE('2025-06-21', 'YYYY-MM-DD'), 23.98, 'order out');

INSERT INTO Orders2 (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus)
VALUES (103, 3, TO_DATE('2025-06-22', 'YYYY-MM-DD'), 14.99, 'receive');

INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, ItemPrice) VALUES (1001, 101, 1, 2, 11.98);
INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, ItemPrice) VALUES (1002, 101, 2, 1, 6.99);
INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, ItemPrice) VALUES (1003, 102, 3, 1, 8.99);
INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, ItemPrice) VALUES (1004, 102, 4, 1, 7.99);
INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, ItemPrice) VALUES (1005, 103, 5, 1, 14.99);


INSERT INTO Payment (PaymentID, OrderID, PaymentDate, PaymentMethod, PaymentStatus) 
VALUES (501, 101, TO_DATE('2025-06-20', 'YYYY-MM-DD'), 'Credit Card', 'Pending');

INSERT INTO Payment (PaymentID, OrderID, PaymentDate, PaymentMethod, PaymentStatus) 
VALUES (502, 102, TO_DATE('2025-06-21', 'YYYY-MM-DD'), 'Debit Card', 'Completed');

INSERT INTO Payment (PaymentID, OrderID, PaymentDate, PaymentMethod, PaymentStatus) 
VALUES (503, 103, TO_DATE('2025-06-22', 'YYYY-MM-DD'), 'Cash', 'Completed');

SELECT * FROM Payment
SELECT * FROM Product
SELECT * FROM OrderItem
SELECT * FROM Orders2
SELECT * FROM Customer
SELECT * FROM Payment

DELETE FROM Payment;
COMMIT;

DELETE FROM Customer
COMMIT;

DELETE FROM Order2
COMMIT;

DELETE FROM OrderItem
COMMIT;


SELECT COUNT(*) FROM Payment;
SELECT COUNT(*) FROM Customer;
SELECT COUNT(*) FROM Order2;
SELECT COUNT(*) FROM OrderItem;

DROP TABLE Payment;
DROP TABLE OrderItem;
DROP TABLE Orders2;
DROP TABLE Customer;
DROP TABLE Product






