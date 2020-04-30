Use booklibrarydatabase;
CREATE TABLE publishers (unique (Publisher)) SELECT Publisher FROM books;

Use booklibrarydatabase;
CREATE TABLE publishers (
	PublisherId INT AUTO_INCREMENT PRIMARY KEY NOT NULL, 
    Publisher varchar(255) default NULL
) ENGINE=MyISAM;

Use booklibrarydatabase;
insert into publishers (Publisher)
SELECT DISTINCT publisher from books WHERE NOT EXISTS (SELECT Publisher FROM publishers);