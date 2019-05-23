create proc Apply_Existing_Request 
@viewer_id int ,
@original_content_id int 
as 
declare @tid int
declare @rid  int
declare @trate decimal(5,2)

select @tid=id ,@trate=rating
from [Original_Content]
where id=@original_content_id
if(@tid is not null and ( @trate>=4 and @trate <=5))begin 
select @rid=count(*)
from Existing_Request 
set @rid= @rid+1
Insert into Existing_Request  ([id],original_content_id,viewer_id)  values (@rid,@original_content_id,@viewer_id) 
end


go

------------------------------------------------------------
create proc Apply_New_Request 
@information varchar(30), @contributor_id int, @viewer_id int
as
if(@contributor_id is not null) begin
declare @tid int
select @tid=count(*)
from New_Request
set @tid=@tid+1

declare @tnid int
select @tnid=count(*)
from Notification_Object
set @tnid=@tnid+1
Insert into New_Request (id,information,specified,viewer_id,notif_obj_id,[contributer_id]) values (@tid,@information,1,@viewer_id,@tnid,@contributor_id)
end 
else 
begin


declare @c int 
 declare @f int 

 select @c =count(*) 
 from Contributor 
 
 select * into r
 from Contributor 
 set @f=1

declare @tn int
select @tn=count(*)
from Notification_Object
set @tn=@tn+1

--declare @tid int
select @tid=count(*)
from New_Request
set @tid=@tid+1

 Insert into New_Request (id,information,specified,viewer_id,notif_obj_id,[contributer_id]) values (@tid,@information,0,@viewer_id,@tn,null)
 while (@f<=@c)begin
 declare @e int 
 declare @e1 int 
 
 select top 1 @e =notified_id ,@e1=ID from r
 
 delete r 
 where notified_id=@e 
 
 if(@e is null)
 begin 

 declare @tid2 int 

 select @tid2 =count(*)
 from Notified_Person
 set @tid2 =@tid2+1
 INSERT INTO Notified_Person Values (@tid2)

 update Contributor
 set notified_id=@tid2
 where ID=@e1
 end 

 declare @w int 
 select @w =count(*) 
 from Announcement
 set @w=@w+1


 INSERT INTO Announcement values (@W,null,CURRENT_TIMESTAMP,@e,@tn)
SET @f=@f+1
 end
end
go
---------------------------------------------------
create proc Check_Type
@typename varchar (15),
@content_manager_id integer
as
declare @er varchar(15)
SELECT @er=[type] FROM Content_type  WHERE [type]=@typename
IF (@er is not null)
BEGIN
     print @er +' '+convert (varchar(30),@content_manager_id)
    update Content_manager
	set [type]=@er
    where ID=@content_manager_id
END
else
BEGIN
insert into Content_type values(@typename)
    update Content_manager
	set [type]=@typename
	where ID=@content_manager_id
END
---------------------------------------------------
go
CREATE PROCEDURE Cont_info
	@contributor_id INT 
AS
	SELECT * FROM dbo.[User] u , dbo.Contributor C
	WHERE u.ID = @contributor_id AND C.ID = @contributor_id
------------------------------------
---------------------------
go
CREATE PROCEDURE contributor_newContent
	@contributor_id INT
AS
	SELECT *
	FROM New_Content N , Content C , dbo.[User] u
	WHERE N.ID=C.id AND C.contributer_id = @contributor_id AND u.ID = @contributor_id
------------------------------
go
create proc Contributor_Search
@fullname Varchar(63)
As
select C1.ID,c1.email,C1.birth_date,C1.age,C1.last_login,C1.[status],C1.deleted,C2.years_of_experience,C2.portfolio_link,C2.specialization,C2.notified_id
from [User] C1 inner join Contributor C2 ON  C1.ID = C2.ID
where first_name+' '+middle_name+' '+last_name like @fullname
------------------------------------------
go
create proc Create_Ads 
@viewer_id  int,
@description text,
@location varchar(15)
as
declare @tid int
Select @tid=count(*)
from [Advertisement]
set @tid=@tid+1
Insert into [Advertisement] ([id],[description],[location],[viewer_id]) values (@tid,@description,@location,@viewer_id)
--------------------------------------------------------------------------------------
 go
 create proc Deactivate_Proﬁle 
 @user_id integer 
 as
 if(@user_id is not null) begin
 update [User]
 set [status]= 1,last_login=Current_timestamp
 where ID=@user_id
 end
-----------------------------------------------------
go
create proc Delete_Ads 
 @ad_id int
as
delete  from [Advertisement]
where id=@ad_id
-------------------------------------------

----------------------------------------
go

create proc Delete_New_Content
@content_id integer
as
delete from New_Content
where ID=@content_id
-----------------------------------------
go

create proc Delete_New_Request 
@request_id int
as
declare @state bit
select @state=[accept_status]
from New_Request
where [id]=@request_id

if(@state!= 1)begin
delete New_Request
where [id]=@request_id
end
-----------------------------------------
go
create proc Delete_Original_Content
@content_id integer
as
delete from Original_Content
where ID=@content_id
delete from Content
where ID=@content_id
-------------------------------------
go
create proc Edit_Ad 
 @ad_id  int,
@description text,
@location varchar(15)
as
update [Advertisement]
Set [description]=@description ,[location]=@location
where [id]=@ad_id
-----------------------------------------
go
create proc Edit_Comment
@comment_text text,
@viewer_id int, 
@original_content_id int, 
@last_written_time datetime, 
@updated_written_time datetime
as
update Comment
Set [date]=@updated_written_time ,[text]=@comment_text
where [Viewer_id]=@viewer_id and[original_content_id]=@original_content_id and [date] =@last_written_time
------------------------------------------------
go
CREATE PROC Edit_Profile 
 @user_id integer, 
 @email varchar(30) , 
 @password varchar(20) , 
 @ﬁrstname varchar(20) , 
 @middlename varchar(20) , 
 @lastname varchar(20) , 
 @birth_date date , 
 @working_place_name varchar(30) , 
 @working_place_type varchar(20), 
 @wokring_place_description varchar (50) ,
 
 @specilization varchar(20), 
 @portofolio_link varchar (30) ,
 @years_experience integer  ,

 @hire_date date  ,
 @working_hours integer , 
 @payment_rate  float 
 As
declare @id integer 
declare @vid integer 
declare @cid integer 
declare @sid integer 

 select @id=ID
 From [User]
 where ID=@user_id
 if(@id is not null)
 begin
 if(@email is not null)begin 
 UPDATE [User] 
 SET email = @email
 WHERE ID=@user_id ;
 end
  if(@password is not null)begin 
 UPDATE [User] 
 SET [password] = @password
 WHERE ID=@user_id ;
 end
 if(@birth_date is not null)begin 
 UPDATE [User] 
 SET  birth_date = @birth_date
 WHERE ID=@user_id ;
 end 
 if(@ﬁrstname is not null)begin 
 UPDATE [User] 
 SET  first_name=@ﬁrstname
 WHERE ID=@user_id ;
 end 
 if(@middlename is not null)begin 
 UPDATE [User] 
 SET middle_name=@middlename
 WHERE ID=@user_id ;
 end 
 if(@lastname is not null)begin 
 UPDATE [User] 
 SET  last_name=@lastname
 WHERE ID=@user_id ;
 end 

 select @vid=ID
 From [Viewer]
 where ID=@user_id
 if(@vid is not null)
 begin

 if(@working_place_name is not null)begin 
  UPDATE Viewer 
 SET working_place= @working_place_name
 WHERE ID=@user_id ;
 end
  if(@working_place_type is not null)begin 
  UPDATE Viewer 
 SET working_place_type=@working_place_type
 WHERE ID=@user_id ;
 end
  if(@wokring_place_description is not null)begin 
  UPDATE Viewer 
 SET  working_place_description= @wokring_place_description
 WHERE ID=@user_id ;
 end
 end 


 select @cid=ID
 From [Contributor]
 where ID=@user_id
 if(@cid is not null)
 begin

if(@years_experience is not null)begin 
  UPDATE [Contributor] 
 SET years_of_experience =@years_experience
 WHERE ID=@user_id ;
 end
 if(@specilization is not null)begin 
  UPDATE [Contributor] 
 SET  specialization=@specilization
 WHERE ID=@user_id ;
 end
 if(@portofolio_link is not null)begin 
  UPDATE [Contributor] 
 SET portfolio_link=@portofolio_link
 WHERE ID=@user_id ;
 end
 end
 
 select @sid=ID
 From Staff 
 where ID=@user_id

  if(@sid is not null)
 begin


  if(@hire_date is not null)begin 
  UPDATE Staff 
 SET   hire_date=@hire_date , working_hours= @working_hours , payment_rate= @payment_rate
 WHERE ID=@user_id ;
 end
   if(@working_hours is not null)begin 
  UPDATE Staff 
 SET    working_hours= @working_hours 
 WHERE ID=@user_id ;
 end
   if(@payment_rate is not null)begin 
  UPDATE Staff 
 SET   payment_rate= @payment_rate
 WHERE ID=@user_id ;
 end

 end

 end
-----------------------------------------

go

CREATE PROCEDURE event_viewer
	
AS
	SELECT * FROM dbo.[User] u, dbo.Event e WHERE u.ID=e.viewer_id
-----------------------------------------------------
go
create proc get_status
@t3 varchar(30) output,
@original_content integer
as
select @t3=o.review_status
from Original_Content o
where o.ID=@original_content


--------------

go
CREATE PROC Original_Content_Search
@typename varchar(15),
@categoryname varchar(15)
As
select C1.rating,C.category_type,C.subcategory_name,C.[type],C.link,C.uploaded_at,U1.first_name,U1.last_name,U1.email,U2.first_name,U2.last_name,U2.email,U3.first_name,U3.last_name,U3.email
from Content C , original_content C1 ,[User] U1 ,[User] U2,[User] U3
where (C.category_type=@categoryname or C.[type]=@typename) and C1.filter_status=1 and C1.review_status=1 and C1.ID=C.ID and U1.ID=C.contributer_id and U2.ID=C1.content_manager_id and U3.ID=C1.reviewer_id
-------------------------------------
go
create proc Rating_Original_Content
@orignal_content_id int ,
@rating_value int, 
@viewer_id int
as
declare @date date
declare @avarage decimal(10,2)
set @date =getdate()
Insert Into Rate Values (@viewer_id,@orignal_content_id,@date,@rating_value)
declare @srate int
declare @scount int
select @srate=sum(rate),@scount=count(*)
from Rate
where [original_content_id]=@orignal_content_id
set @avarage=@srate/@scount
if(@avarage>5)begin
set @avarage=5
end
update Original_Content
set rating=@avarage
where ID =@orignal_content_id
-------------------------------------------

go


 create proc Receive_New_Request
	@contributor_id integer ,
	@can_receive bit OUTPUT
	as
	declare @allrequest integer,
	 @acceptedrequest integer
	select @allrequest = count(*)
	from New_Request N 
	where N.contributer_id=@contributor_id 
	select @acceptedrequest = count(*)
	from New_Request N1,New_Content C1
	where ( N1.contributer_id=@contributor_id  and N1.accept_status=1 and  N1.ID = C1.new_request_id)
	if((@allrequest - @acceptedrequest)>= 3)
	begin
	set @can_receive = 0
	print('There are 3 or more new requests that are still in process')
	end
	else
	set @can_receive = 1
-------------------------------------------------------------------------------------

go

create proc Receive_New_Requests
@request_id integer ,
@contributor_id integer
as

if(@request_id is null)
begin
select  *
from New_Request N,dbo.[User] u
where  ( N.contributer_id=@contributor_id ) AND n.Viewer_id=u.ID
declare @tid int
select @tid=notified_id
from Contributor
where ID =@contributor_id
UPDATE Announcement
set seen_at=CURRENT_TIMESTAMP
where notified_person_id=@tid
end
else
begin 
select *
from New_Request N1 , dbo.[User] u1
where @request_id = N1.id AND N1.Viewer_id=u1.ID
declare @tid1 int
select @tid1=notified_id
from Contributor
where ID =@contributor_id
UPDATE Announcement
set seen_at=CURRENT_TIMESTAMP
where notified_person_id=@tid1
END
--------------------------------------------
go
CREATE proc Register_User
@usertype varchar(15),
@email varchar(30),
@password varchar (30),
@firstname varchar(20),
@middlename varchar(20),
@lastname   varchar(20),
@birth_date date,
@working_place_name varchar(30),
@working_place_type varchar(30),
@wokring_place_description  varchar (50),
@specilization varchar(20),
@portofolio_link varchar(30),
@years_experience integer,		
@hire_date date,
@working_hours integer,	
@payment_rate decimal(10,5),
@user_id integer output
AS
declare @user_id1 integer
select @user_id1=count(*)
from [User]
set @user_id=@user_id1+1
insert into [User] (ID,email,[password],first_name,middle_name,last_name,birth_date) values(@user_id,@email,@password,@firstname,@middlename,@lastname,@birth_date)
if @usertype = 'Viewer' insert into Viewer(ID,working_place,working_place_type,working_place_description) values (@user_id,@working_place_name,@working_place_type,@wokring_place_description)
if @usertype = 'Contributor' insert into Contributor(ID,years_of_experience,specialization,portfolio_link) values (@user_id,@years_experience,@specilization,@portofolio_link)
if (@usertype = 'Authorized Reviewer'or @usertype = 'Content Manager' ) insert into Staff(ID,hire_date,working_hours,payment_rate) values(@user_id,@hire_date,@working_hours,@payment_rate)
------------------------------------------------------------------

go

create proc Respond_New_Request
@contributor_id	integer ,
@accept_status bit ,
@request_id integer 
As

if @accept_status =1
begin
declare @a bit 
declare @a1 bit 

select @a=specified ,@a1=accept_status
from New_Request
where id = @request_id
if((@a is null or @a =0)and @a1 is null)begin
update New_Request
set accept_status =1,contributer_id=@contributor_id
where id = @request_id
END
END
ELSE 

BEGIN
update New_Request
set accept_status = NULL
where id = @request_id
END
------------------------------------------------------
go
CREATE PROC reviewer_filter_content
@reviewer_id integer,
@original_content integer,
@status bit
As
update Original_Content 
set review_status= @status,reviewer_id=@reviewer_id
where ID=@original_content
-------------------------------------------
go
create proc Send_Message 
@msg_text text, 
@viewer_id int,
@contributor_id int , 
@sender_type bit,
@sent_at datetime
as
Insert into [Message] ([text],[viewer_id],[contributer_id],[sender_type],[sent_at]) values (@msg_text,@viewer_id,@contributor_id,@sender_type,@sent_at)
-------------------------------------

go


CREATE PROCEDURE Show_Adv
	
AS
	SELECT DISTINCT a.description,a.location,u.email FROM dbo.Advertisement a, dbo.[User] u,dbo.Event e
	WHERE  a.viewer_id=u.ID
--------------------------------------------------------
go
 CREATE PROC Show_Event 
 @event_id int
 as
 if (@event_id is null)begin
  select  * 
 from [Event]
 where year([time]) >=  year(Current_timestamp ) and month([time]) >=  month(Current_timestamp ) and day([time]) >=  day(Current_timestamp ) end 
 else begin
   select  * 
 from [Event]
 where id=@event_id
 end
-------------------------------
go
create proc Staff_Create_Subcategory
@category_name varchar(15), 
@subcategory_name varchar(15)
as
insert into Sub_Category values (@category_name,@subcategory_name)
---------------------------------------------------
go
create proc Staff_Create_Type
@type_name varchar(15)
as
insert into Content_type values (@type_name)
-----------------------------------------------
go
create proc type_content_helper
@t varchar(30) output,
@original_content integer
as
select @t=c.type
from Content c
where c.id=@original_content
-----------------------------------------------------
go
create proc type_content_manager_helper
@t1 varchar(30) output,
@content_manager_id integer
as
select @t1=m.type
from Content_manager m 
where m.ID=@content_manager_id
--------------------------------------------------------
go
create proc Upload_New_Content
@new_request_id integer , 
@contributor_id integer ,
@subcategory_name varchar (15), 
@category_id varchar (15),
@link varchar(30),
@type varchar(15)
as 
declare @content_id integer 
select @content_id = count(*)
from Content 
set @content_id = @content_id +1
insert into Content(id,link,contributer_id,category_type,subcategory_name,type) values(@content_id,@link,@contributor_id,@category_id,@subcategory_name,@type)
insert into New_Content(ID,new_request_id)values(@content_id,@new_request_id)
go
----------------------------------------------------------------
	
create proc Upload_Original_Content
@type_id varchar (15) ,
@subcategory_name varchar (15), 
@category_id varchar (15) , 
@contributor_id integer , 
@link varchar(30)
As
declare @content_id integer 
select @content_id = count(*)
from Content 
set @content_id = @content_id +1
insert into Content(id,link,contributer_id,category_type,subcategory_name,[type]) values(@content_id,@link,@contributor_id,@category_id,@subcategory_name,@type_id)
insert into Original_Content(ID)values(@content_id)
-------------------------------------
go

CREATE PROC User_login 
 @email varchar(30),
 @password varchar(30),
 @user_id  integer OUTPUT
 As
 declare @t integer
 select @t=ID 
 From [User]
 where email=@email AND [password]=@password
 if(@t is null) begin
set @user_id = -1 
end
else 
begin
declare @tl datetime
declare @st bit
declare @dl bit
select @t=ID ,@tl=last_login, @st=[status],@dl=deleted
from [User]
where email=@email AND [password]=@password
if(((year(Current_timestamp)-year(@tl )>1 or month(Current_timestamp) - month(@tl )>1 or day(Current_timestamp) -  day( @tl)>14 )and @st=1)or  @dl=1  )
begin
set @user_id = -1
update [User]
set deleted=1 
where ID= @t
end
else begin
if(@st=1)begin 
set @user_id = 0
update [User]
set last_login=Current_timestamp ,[status]= 0
where ID= @t
end
else
begin
set @user_id = @t
end
update [User]
set last_login=Current_timestamp ,[status]= 0
where ID= @t
end
end
-------------------------------------------
go
create proc usert
@userid int ,
@type int output
as
declare @id int
select @id=ID
from Viewer 
where ID =@userid;
 if(@id is not null) begin
 set @type=0;
 end
 else begin
 select @id=ID
from Contributor 
where ID =@userid;
 if(@id is not null) begin
 set @type=1;
 end else begin
 select @id=ID
from Staff 
where ID =@userid;
 if(@id is not null) begin
 set @type=2;
 end
 end
 end
--------------------------------
go
create proc Viewer_Create_Ad_From_Event
@event_id int
as
declare @tdescription  varchar (30)
declare @tlocation VARCHAR (15)
declare @tvid int
declare @tevid int
declare @tadid int
select @tdescription=[description],@tlocation=[location],@tvid=[viewer_id],@tevid=id
from [Event]
where id=@event_id
if(@tevid is not null)begin
select @tadid=count(*)
from [Advertisement]
set @tadid= @tadid+1
INSERT INTO [Advertisement] ([id],[description],[location],[event_id],[viewer_id]) Values (@tadid,@tdescription,@tlocation,@event_id,@tevid)
end
--------------------------------------
go
 create proc Viewer_Create_Event 
 @city varchar(15) , 
 @event_date_time datetime, 
 @description varchar(30), 
 @entartainer varchar(15), 
 @viewer_id  int , 
 @location varchar (15),
 @event_id int OUTPUT
 as
 declare @tid int 
 select @tid =count(id)
 from [Event]

 declare @tid1 int 
 select @tid1 =count(*)
 from Notification_Object
 set @tid1 =@tid1+1
 INSERT INTO Notification_Object Values (@tid1)
 set @event_id=@tid+1
 INSERT INTO [Event] (id,[description],[location] ,city,[time],[entertainer],[viewer_id],[notif_obj_id]) Values (@event_id,@description, @location,@city,@event_date_time,@entartainer,@viewer_id,@tid1)
 declare @c int 
 declare @f int 

 select @c =count(*) 
 from Contributor 
  select * into r
 from Contributor 
 set @f=1

 while (@f<=@c)begin
 declare @e int 
  declare @e1 int 
 select top 1 @e =notified_id ,@e1=ID from r
 delete r 
 where notified_id=@e  
 if(@e is null)
 begin 
 declare @tid2 int 
 select @tid2 =count(*)
 from Notified_Person
 set @tid2 =@tid2+1
 INSERT INTO Notified_Person Values (@tid2)
 update Contributor
 set notified_id=@tid2
 where ID=@e1
 end 

 declare @w int 
 select @w =count(*) 
 from Announcement
 set @w=@w+1
 INSERT INTO Announcement values (@w,null,CURRENT_TIMESTAMP,@e,@tid1)
SET @f=@f+1
 end

 select @c =count(*) 
 from Staff 

 select * into r
 from Staff
 
 set @f=1

 while (@f<=@c)begin
 declare @e2 int 
 declare @e3 int 
 select top 1 @e =notified_id ,@e3=ID from r

 delete r 
 where notified_id=@e2
 if(@e2 is null)
 begin 
 declare @tid5 int 
 select @tid5 =count(*)
 from Notified_Person
 set @tid5 =@tid5+1
 INSERT INTO Notified_Person Values (@tid5)
 update Staff
 set notified_id=@tid5
 where ID=@e3
 end 
 declare @w1 int 
 select @w1 =count(*) 
 from Announcement
set @w1=@w1+1
INSERT INTO Announcement values (@w1,null,CURRENT_TIMESTAMP,@e2,@tid1)
SET @f=@f+1
end
---------------------------------------------
go
create proc Viewer_Upload_Event_Photo
@event_id int ,
@link varchar(30)
as
if(@event_id is not null)
INSERT INTO Event_Photos_link (event_id,link) Values (@event_id,@link)
---------------------------------------------
go
create proc Viewer_Upload_Event_Video
@event_id int ,
@link varchar(30)
as
if(@event_id is not null)
INSERT INTO Event_Videos_link (event_id,link) Values (@event_id,@link)
-------------------------------------------------
go
 create proc Workingplace_Category_Relation
 as
 
 SELECT working_place_type,category_type into m
 from (
 select C.category_type      ,V.working_place_type ,ER.id
 from (Existing_Request ER inner join Content C on ER. original_content_id=C.ID ) INNER JOIN Viewer V on V.ID=ER.viewer_id
 UNION
 select C.category_type,    V.working_place_type ,NR.id
 from ((New_Request  NR inner join New_Content  NC on NR.id=NC.new_request_id ) inner join Content C on C.ID=NC.ID)INNER JOIN Viewer V on V.ID=NR.viewer_id 
 )t1

 select working_place_type,category_type ,count(id)
 from m
 group by category_type
 order by working_place_type
----------------------------------------------
go
create proc Write_Comment
@comment_text text,
@viewer_id int, 
@original_content_id int, 
@written_time datetime
as
Insert Into Comment values (@viewer_id,@original_content_id,@written_time,@comment_text)
------------------------------------------------------

-------------------------------------------









go
create proc Content_manager_filter_content
@content_manager_id integer,
@original_content integer,
@status bit
AS
declare @o varchar(30)
declare @o1 varchar(30)
declare @o2 varchar(30)
exec type_content_helper  @o output,@original_content
exec type_content_manager_helper @o1 output,@content_manager_id 
exec get_status @o2 output,@original_content
if @o=@o1 and @o2=1
update Original_Content 
set filter_status= @status,content_manager_id=@content_manager_id
where  id=@original_content 








go
create proc Delete_Comment
@viewer_id integer,
@original_content_id integer,
@comment_time datetime
as
Delete from Comment 
where Viewer_id=@viewer_id and original_content_id=@original_content_id and  [date]=@comment_time
 

 go
 create proc Assign_New_Request
@request_id int ,
@contributor_id int
as
declare @a bit 
declare @cid int
select @a =     accept_status ,@cid=contributer_id
from New_Request 
where id=@request_id 
if(@a   is  null and @cid is null)begin
update New_Request
set contributer_id=@contributor_id ,specified=1
where id=@request_id
end
else
begin
print 'You can not assign the contributor to this Request '
end


go

create proc Assign_Contributor_Request
@contributor_id integer,
@new_request_id integer
as
declare @a bit 
declare @cid int
select @a =accept_status ,@cid=contributer_id
from New_Request 
where id=@new_request_id 
if(@a   is  null and @cid is null)begin
update New_Request
set contributer_id=@contributor_id ,accept_status=1,accept_at=1
where id=@new_request_id
end
else
begin
print 'You can not assign the contributor to this Request '
end




go
create procedure Show_Possible_Contributors
as
select Content.contributer_id,new_request_id,DATEDIFF(s,accept_at,uploaded_at) diff
into temp
from (New_Request nr inner join New_Content nc on nr.id=nc.new_request_id) inner join Content on Content.ID=nc.ID
select * from temp

select contributer_id, count(new_request_id) requests
from temp t
group by contributer_id
order by avg(diff) desc
drop table temp;
