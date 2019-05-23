
create  table [User] (
    ID          int primary key          ,
   email       varchar (30) unique ,
    [password]    varchar (30),
   first_name  varchar (20) ,
   middle_name varchar (20) ,
   last_name   varchar (20) ,
   birth_date  date         ,
   age         as  year(CURRENT_TIMESTAMP)-year(birth_date),
  last_login datetime,
  [status] bit,
  deleted bit
);

 


create table Viewer (
    ID     int primary key ,
    working_place          varchar (30) ,
    working_place_type       varchar (20) ,
    working_place_description varchar (50) ,
    foreign key (ID) references [User] on delete cascade on update cascade
);


create table Notified_Person(
ID int primary key
);


create table Contributor(
ID int primary key,
years_of_experience int ,
portfolio_link varchar(30),
specialization varchar(30),
notified_id int,
foreign key (ID) references [User] on delete cascade on update cascade,
foreign key (notified_id) references Notified_Person on delete cascade on update cascade
);



create table Staff(
ID int primary key ,
hire_date  date ,
working_hours int,
payment_rate decimal(10,5),
total_salary  AS     payment_rate *working_hours,
notified_id int,
foreign key (ID) references [User] on delete cascade on update cascade,
foreign key (notified_id) references Notified_Person on delete cascade on update cascade
);

CREATE table  Content_type (
    [type] varchar (15) primary key ,

);






create table Category(
[type] varchar(15) primary key,
[description] varchar(max)
);






create table Notification_Object(
ID integer primary key
);




create table Sub_Category(
category_type varchar(15) ,
[name] varchar(15)
primary key (category_type,[name]),
foreign key (category_type) references Category on delete cascade on update cascade
);




create table [Event] (
id integer primary key,
[description]  varchar (max),
[location]     varchar (max),
city varchar(15),
[time] datetime ,
entertainer  varchar (30),
notif_obj_id integer,
viewer_id int,
foreign key (notif_obj_id) references Notification_Object on delete cascade on update cascade,
foreign key (viewer_id) references Viewer 

);




create table Event_Photos_link(
event_id int ,
link varchar(30),
primary key (event_id,link),
foreign key (event_id) references [Event] on delete cascade on update cascade
);



create table Event_Videos_link(
event_id int ,
link varchar(30),
primary key (event_id,link),
foreign key (event_id) references [Event] on delete cascade on update cascade
);




create table Advertisement(
id int primary key ,
[description] varchar(max),
[location] varchar(30),
event_id int ,
viewer_id int,
foreign key (viewer_id) references Viewer ,
foreign key (event_id) references [Event] 
);





create table Ads_Photos_Link(
advertisement_id int ,
link varchar(30),
primary key (advertisement_id,link),
foreign key (advertisement_id) references Advertisement on delete cascade on update cascade
);






create table Ads_Video_Link(
advertisement_id int ,
link varchar(30),
primary key (advertisement_id,link),
foreign key (advertisement_id) references Advertisement on delete cascade on update cascade
);





create table Content (
id int primary key,
link varchar(30),
uploaded_at date ,
contributer_id int ,
category_type    varchar (15) ,
subcategory_name varchar (15) ,
[type]           varchar (15) ,
foreign key (contributer_id) references Contributor ,
foreign key ([type]) references Content_type on delete cascade on update cascade,
foreign key (category_type,subcategory_name) references Sub_Category(category_type,[name]) on delete cascade on update cascade
);



x

create table Content_manager(
ID integer primary key,
[type] varchar(15),
foreign key (ID) references Staff ,
foreign key ([type]) references Content_type on delete cascade on update cascade
);

create table Reviewer(
ID integer primary key ,
foreign key (ID) references Staff );


create table Original_Content(
ID int primary key,
content_manager_id int ,
reviewer_id int,
review_status bit,
filter_status bit ,
rating decimal(4,2),
foreign key (ID) references Content on delete cascade on update cascade,
foreign key (content_manager_id) references Content_manager ,
foreign key (reviewer_id) references Reviewer
);




create table Announcement(
ID integer primary key ,
seen_at datetime,
sent_at datetime,
notified_person_id int,
notification_object_id int,
foreign key (notified_person_id) references Notified_Person on delete cascade on update cascade,
foreign key (notification_object_id) references Notification_Object on delete cascade on update cascade
);










create table Comment(
Viewer_id int ,
original_content_id int,
[date]  datetime ,
[text]  varchar(max),
primary key (Viewer_id,original_content_id,[date]),
foreign key (Viewer_id) references Viewer ,
foreign key (original_content_id) references Original_Content on delete cascade on update cascade
);





create table New_Request(
id int primary key,
accept_status bit,
specified  bit,
information varchar (max),
Viewer_id int ,
notif_obj_id int ,
accept_at datetime,
contributer_id int 
foreign key (Viewer_id) references Viewer ,
foreign key (contributer_id) references Contributor ,
foreign key (notif_obj_id) references Notification_Object on delete cascade on update cascade
); 







create table Existing_Request(
id int primary key,
original_content_id int ,
Viewer_id int ,
foreign key (Viewer_id) references Viewer ,
foreign key (original_content_id) references Original_Content on delete cascade on update cascade
); 




create table [Message](
sent_at datetime,
contributer_id  int,
viewer_id int,
sender_type bit,
read_at datetime,
[text] varchar(max),
read_status bit,
primary key(sent_at,contributer_id,viewer_id,sender_type),
foreign key (Viewer_id) references Viewer ,
foreign key (contributer_id) references Contributor
);




create table New_Content(
ID INT primary key,
new_request_id int ,
foreign key (ID) references Content on delete cascade on update cascade,
foreign key (new_request_id) references New_Request on delete cascade on update cascade

);





create table Rate (
Viewer_id int,
original_content_id int,
[date] date ,
rate decimal (10,2),
foreign key (Viewer_id) references Viewer ,
foreign key (original_content_id) references Original_Content on delete cascade on update cascade
);



----drop table [User];
----drop table Viewer;
----drop table Notified_Person;
----drop table Contributor;
----drop table Staff;
----drop table Content_type;
----drop table Category;
----drop table Notification_Object;
----drop table Sub_Category;
----drop table [Event] ;	
----drop table Event_Photos_link;
----drop table Event_Videos_link;
----drop table Advertisement;
----drop table Ads_Photos_Link;
----drop table Ads_Video_Link;
----drop table Content;
----drop table Content_manager;
----drop table  Announcement;
----drop table Comment;
----drop table New_Request;
----drop table Existing_Request;
----drop table [Message];
----drop table New_Content;
----drop table Original_Content;
----drop table Rate;
----drop table Reviewer;