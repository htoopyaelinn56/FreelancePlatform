CREATE DATABASE IF NOT EXISTS freelance_platform;

-- 1. Users Table (Base Table)
CREATE TABLE Users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    type ENUM('freelancer', 'client') NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(150)
);

-- 2. Clients Table (Extends Users)
CREATE TABLE Clients (
    user_id INT PRIMARY KEY,
    address VARCHAR(255),
    company_name VARCHAR(150),
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE
);

-- 3. Freelancers Table (Extends Users)
CREATE TABLE Freelancers (
    user_id INT PRIMARY KEY,
    skills VARCHAR(255),
    expertise VARCHAR(255),
    portfolio VARCHAR(255),
    pastwork VARCHAR(255),
    FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE
);
