insert into home (Id, Name, Type)
values (NEWID(), 'Home test 2', 'Apartament test 2');

select * from Home;

insert into room (Id, Type, HomeId, Home_id)
values (NEWID(), 'Dormitor', 'D5137C57-24BB-4511-BCF8-7A6CB3CEC747', 'D5137C57-24BB-4511-BCF8-7A6CB3CEC747');

select * from Room;

select * from Room join Home on (Home.Id = Room.HomeId);