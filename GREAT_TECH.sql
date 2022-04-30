create database GREAT_TECH
use GREAT_TECH
go

use master
drop database GREAT_TECH
create table Category
(
	Id bigint primary key identity(1,1),
	Name nvarchar(1000) not null
)
create table Producer
(
	Id bigint primary key identity(1,1),
	Name nvarchar(1000) not null,
	Address nvarchar(1000) not null,
	Phone nvarchar(20) not null,
	Email nvarchar(1000) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null
)
create table Account
(
	Id bigint primary key identity(1,1),
	Username nvarchar(50) unique not null,
	Password nvarchar(50) not null,
	AdminCheck bit not null
)
create table Product
(
	Id bigint primary key identity(1,1),
	Name nvarchar(1000) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	CategoryId bigint foreign key references Category(Id) not null,
	ProducerId bigint foreign key references Producer(Id) not null,
	CostPrice float not null,
	SellPrice float not null,
	Amount bigint not null,
	Avatar nvarchar(1000) not null,
	Description nvarchar(1000)
)
create table EndUser
(
	Id bigint primary key identity(1,1),
	Name nvarchar(1000) not null,
	DateOfBirth datetime not null,
	Address nvarchar(1000) not null,
	Phone nvarchar(10) not null,
	Email nvarchar(1000) not null,
	AccountId bigint foreign key references Account(Id) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null
)
create table AppUser
(
	Id bigint primary key identity(1,1),
	Name nvarchar(1000) not null,
	DateOfBirth datetime not null,
	Address nvarchar(1000) not null,
	Phone nvarchar(10) not null,
	Email nvarchar(1000) not null,
	AccountId bigint foreign key references Account(Id) not null
)
create table Cart
(
	Id bigint primary key identity(1,1),
	EndUserId bigint foreign key references EndUser(Id) not null,
	ProductId bigint foreign key references Product(Id) not null,
	Amount bigint not null
)
create table ShopHistory
(
	EndUserId bigint foreign key references EndUser(Id) not null,
	ProductId bigint foreign key references Product(Id) not null,
	CreatedAt datetime not null,
	Amount bigint not null
)
create table ReceiveHistory
(
	Id bigint primary key identity(1,1),
	ProductId bigint foreign key references Product(Id) not null,
	CreatedAt datetime not null,
	Amount bigint not null
)
create table Promotion
(
	Id bigint primary key identity(1,1),
	ProductId bigint foreign key references Product(Id) not null,
	PromotePercent bigint not null,
	CreatedAt datetime not null,
	ExpireAt datetime not null
)