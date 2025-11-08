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

-- 4. Projects Table
CREATE TABLE Projects (
    id INT AUTO_INCREMENT PRIMARY KEY,
    client_id INT NOT NULL,
    freelancer_id INT NULL,
    name VARCHAR(150) NOT NULL,
    description VARCHAR(500),
    budget DECIMAL(10, 2),
    deadline DATE,
    skills VARCHAR(255),
    status ENUM('posted', 'in_progress', 'completed', 'closed') DEFAULT 'posted',
    FOREIGN KEY (client_id) REFERENCES Clients(user_id) ON DELETE CASCADE,
    FOREIGN KEY (freelancer_id) REFERENCES Freelancers(user_id) ON DELETE SET NULL
);

-- 5. Bids Table
CREATE TABLE Bids (
    id INT AUTO_INCREMENT PRIMARY KEY,
    project_id INT NOT NULL,
    freelancer_id INT NOT NULL,
    bid_amount DECIMAL(10, 2) NOT NULL,
    status ENUM('bid', 'approved', 'rejected') DEFAULT 'bid',
    FOREIGN KEY (project_id) REFERENCES Projects(id) ON DELETE CASCADE,
    FOREIGN KEY (freelancer_id) REFERENCES Freelancers(user_id) ON DELETE CASCADE
);

-- 6. Reviews Table
CREATE TABLE Reviews (
    id INT AUTO_INCREMENT PRIMARY KEY,
    project_id INT NOT NULL,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    comment VARCHAR(255),
    FOREIGN KEY (project_id) REFERENCES Projects(id) ON DELETE CASCADE
);