use Twitter;

create table Users (
	id int primary key identity(1,1),
	full_name varchar(50) not null,
	user_login varchar(50) not null unique,
	user_password varchar(50) not null,
	birth datetime not null,
	registration_date datetime not null,
	photo_path varchar(50) 
);

create table Tweets(
	id int primary key identity(1,1),
	tweet_description varchar(300) not null,
	creation_date datetime not null,
	creator_id int constraint FK_Tweet_Creator foreign key (creator_id) references Users(id)
);