/* If you want to drop the whole database and create a new one, 
	make sure:
		- Change to other database (ex: master)
		- Set the database to delete to single user mode to prevent other users' connection
		- Delete all connection to the database: 
			+ Run 'EXEC sp_who2;'
			+ Find which process using 'want to delete' database in DBName column
			+ Run 'KILL <PID>'
*/

-- Tạo CSDL

GO
USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Cinema')
BEGIN
    ALTER DATABASE Cinema SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	-- KILL <PID>
    DROP DATABASE Cinema;
END

GO
CREATE DATABASE Cinema
GO

-- Dùng CSDL vừa tạo

GO
USE Cinema;
GO

-- Đổi collation sang Vietnamese_CI_AS để lưu trữ và hiển thị tiếng Việt

ALTER DATABASE Cinema COLLATE Vietnamese_CI_AS;

-- Tạo các bảng
CREATE TABLE movie(
	id INT PRIMARY KEY IDENTITY,
	movie_name NVARCHAR(255) NOT NULL,
	director NVARCHAR(255) NOT NULL DEFAULT 'Unknown',
	movie_cast NVARCHAR(255) NOT NULL DEFAULT 'Unknown',
	genre NVARCHAR(255) NOT NULL DEFAULT 'Unknown',
	release_date DATE NOT NULL DEFAULT GETDATE(),
	running_time INT NOT NULL DEFAULT 0,
	movie_description NVARCHAR(MAX) NOT NULL DEFAULT 'Unknown',
	poster NVARCHAR(100) NOT NULL DEFAULT 'Unknown',
);

CREATE TABLE rated(
	id INT PRIMARY KEY IDENTITY,
	rated_code VARCHAR(3) NOT NULL DEFAULT 'P',
	rated_description NVARCHAR(255) NOT NULL DEFAULT 'Unknown',
);

CREATE TABLE is_rated(
	movie_id INT NOT NULL,
	rated_id INT NOT NULL,
	PRIMARY KEY (movie_id, rated_id),
	FOREIGN KEY (movie_id) REFERENCES movie(id),
	FOREIGN KEY (rated_id) REFERENCES rated(id),
);

CREATE TABLE theater(
	id INT PRIMARY KEY IDENTITY,
	theater_name NVARCHAR(100) NOT NULL DEFAULT 'Unknown',
);

CREATE TABLE SEAT(
	ID INT PRIMARY KEY IDENTITY,
	THEATER_ID INT NOT NULL,
	SEAT_CODE VARCHAR(4) NOT NULL,
	FOREIGN KEY (THEATER_ID) REFERENCES THEATER(ID),
	UNIQUE (THEATER_ID, SEAT_CODE),
);

-- Giờ bắt đầu và kết thúc để DATETIME để phân biệt suất chiếu của các ngày
-- ví dụ suất chiếu phim A, 7:00 tới 9:00, của ngày 01/01/2025 và ngày 02/01/2025

CREATE TABLE SCHEDULE(
    ID INT IDENTITY PRIMARY KEY,
	MOVIE_ID INT NOT NULL,
	THEATER_ID INT NOT NULL,
	START_TIME DATETIME NOT NULL,
	END_TIME DATETIME NOT NULL,
	FOREIGN KEY (MOVIE_ID) REFERENCES MOVIE(ID),
	FOREIGN KEY (THEATER_ID) REFERENCES THEATER(ID),
);

CREATE TABLE THEATER_MEM(
	ID INT IDENTITY PRIMARY KEY,
	FULL_NAME NVARCHAR(255) NOT NULL,
	PHONE CHAR(10) NOT NULL UNIQUE,
	EMAIL VARCHAR(100) NOT NULL UNIQUE,
	BIRTHDATE DATE NOT NULL DEFAULT GETDATE(),
	PASS CHAR(60) NOT NULL, 
	SPENDING INT NOT NULL,
	MEM_ROLE INT NOT NULL DEFAULT 1,
);

CREATE TABLE MEMBER_RANK(
	ID INT PRIMARY KEY IDENTITY,
	RANK_NAME NVARCHAR(100) NOT NULL,
	THRESHOLD INT NOT NULL UNIQUE,
	DISCOUNT DECIMAL(3,2) NOT NULL UNIQUE,
	RANK_DESCRIPTION NVARCHAR(255) NOT NULL DEFAULT 'Unknown',
);

CREATE TABLE TICKET(
	ID INT PRIMARY KEY IDENTITY,
	MEM_ID INT NOT NULL,
	SCHEDULE_ID INT NOT NULL,
	SEAT_CODE INT NOT NULL,
	FIRST_AMOUNT INT NOT NULL,
	DISCOUNT INT NOT NULL DEFAULT 0,
	CREATED_DATE DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (MEM_ID) REFERENCES THEATER_MEM(ID),
	FOREIGN KEY (SCHEDULE_ID) REFERENCES SCHEDULE(ID),
);

-- Thêm dữ liệu vào bảng 'Rated' (giới hạn độ tuổi)

INSERT INTO RATED VALUES ('P', 'Movies are permitted for viewers of all ages.');
INSERT INTO RATED VALUES ('T13', 'Movies are permitted for viewers aged 13 and above.');
INSERT INTO RATED VALUES ('T16', 'Movies are permitted for viewers aged 16 and above.');
INSERT INTO RATED VALUES ('T18', 'Movies are permitted for viewers aged 18 and above.');
INSERT INTO RATED VALUES ('K', 'Movies are permitted for viewers under 13, provided they are accompanied by a parent or guardian.');

-- Thêm dữ liệu vào bảng 'Movie' - đang chiếu
-- Dữ liệu lấy từ rạp CGV, ngày 10/03/2025

INSERT INTO MOVIE VALUES ('FLOW', 'Gints Zilbalodis', default, 'Adventure, Animation, Fantasy', '2025/03/07', 89, 
'In a post-apocalyptic world, a timid gray cat that is scared of water is forced to leave his safe haven when a violent flood destroys 
its beloved home. On their adventure across the great ocean, the cat and his friends 
(a capybara, a Labrador dog, a lemur, and a secretary bird) must learn to conquer their anxieties and accept their differences in order to survive.', 'assets/poster/FLOW.jpg');

INSERT INTO MOVIE VALUES (N'NHÀ GIA TIÊN', N'Huỳnh Lập', N'Huỳnh Lập, Phương Mỹ Chi, NSƯT Hạnh Thuý, NSƯT Huỳnh Đông, Puka,...', 'Comedy, Family', '2025/02/21', 117, 
N'Nhà Gia Tiên xoay quanh câu chuyện đa góc nhìn về các thế hệ khác nhau trong một gia đình, có hai nhân vật chính là Gia Minh (Huỳnh Lập) và Mỹ Tiên (Phương 
Mỹ Chi). Trở về căn nhà gia tiên để quay các video “triệu view” trên mạng xã hội, Mỹ Tiên - một nhà sáng tạo nội dung thuộc thế hệ Z vốn không tin vào chuyện tâm linh, hoàn toàn 
mất kết nối với gia đình, bất ngờ nhìn thấy Gia Minh - người anh trai đã mất từ lâu. Để hồn ma của Gia Minh có thể siêu thoát và không tiếp tục làm phiền 
mình, Mỹ Tiên bắt tay cùng Gia Minh lên kế hoạch giữ lấy căn nhà gia tiên đang bị họ hàng tranh chấp, đòi ông nội chia tài sản. Đứng trước hàng loạt bí mật động trời trong căn nhà gia tiên, liệu 
Mỹ Tiên có vượt qua được tất cả để hoàn thành di nguyện của Gia Minh?', 'assets/poster/NHA_GIA_TIEN.jpg');

INSERT INTO MOVIE VALUES ('INTERSTELLAR (RERUN)', 'Christopher Nolan', 'Matthew McConaughey, Anne Hathaway, Jessica Chastain', 'Science Fiction', '2025/02/28', 169, 
'In a future where Earth is on the brink of collapse, ex-NASA pilot Cooper joins a daring space mission through a wormhole to find a new habitable planet for humanity. Facing unknown
worlds, time dilation, and the pull of family, he must make impossible choices to save the future.', 'assets/poster/INTERSTELLAR_(RERUN).jpg');

INSERT INTO MOVIE VALUES ('MOBILE SUIT GUNDAM GQUUUUUUX -BEGINNING-', 'Kazuya Tsurumaki', 'Tomoyo Kurosawa, Yui Ishikawa, Shimba Tsuchiya', 'Action, Adventure, Animation, Drama, Science Fiction', '2025/03/07', 82, 
'The Principality of Zeon is at war with the Earth Federation. On September 18, 0079, Zeon''s Lt. Commander Char Aznable leads a raid on space colony Side 7. There, he discovers the Earth Federation''s 
new weapon, the RX-78-2 Gundam, abandoned. He then decides steal it for himself, setting in motion a domino effect that forever changes history as we know it. 
Five years later, on independent colony Side 6, a young Newtype girl finds herself caught up in the hunt for the missing RX-78-2 Gundam. 
Before long, events conspire to put her in the pilot seat of the new prototype Gundam GQuuuuuuX and taking part in underground mobile suit fighting competitions. Surrounded 
by new friends, she attempts to understand her strange powers and find her place in the world dreaming of skies where she can fly free.', 'assets/poster/MOBILE_SUIT_GUNDAM_GQUUUUUUX_BEGINNING.jpg');

INSERT INTO MOVIE VALUES ('DARK NUNS', 'Hyeok-jae Kwon', 'Song Hye-kyo; Jeon Yeo-been; Lee Jin-wook;...', 'Horror, Mystery, Thriller', '2025/02/21', 114, 
'Hee Joon gets possessed by an evil spirit. Sister Junia takes it upon herself to save the boy aided along the way by Sister Michaela who decides to help her even though chaos 
surrounds them. Father Paolo, a psychiatrist, believes that he can cure Hee Joon with medical intervention while Father Andrea performs exorcisms on the boy.', 'assets/poster/DARK_NUNS.jpg');

INSERT INTO MOVIE VALUES ('THE SUBSTANCE (RERUN)', 'Coralie Fargeat', 'Demi Moore, Margaret Qualley, Dennis Quaid,...', 'Horror', '2025/03/01', 139, 
'Elizabeth Sparkle, a star with captivating beauty and passionate talent. When her beauty has passed its peak, she seeks out smugglers to buy a mysterious drug in
an attempt to “change her skin and fate”, creating a younger version of herself.', 'assets/poster/THE_SUBSTANCE_(RERUN).jpg');

INSERT INTO MOVIE VALUES ('NOSFERATU', 'Robert Eggers', 'Lily-Rose Depp, Nicholas Hoult, Bill Skarsgard,...', 'Thriller', '2025/02/28', 130, 
'A gothic tale of obsession between a haunted young woman and the terrifying vampire infatuated with her, causing untold horror in its wake.', 'assets/poster/NOSFERATU.jpg');

INSERT INTO MOVIE VALUES ('CAPTAIN AMERICA: BRAVE NEW WORLD', 'Julius Onah', 'Harrison Ford, Anthoy Mackie, Giancarlo Esposito, Rosa Salazar, Seth Rollins, Shira Haas',
'Action, Science Fiction', '2025/02/14', 118, 'Anthony Mackie returns as the high-flying hero Sam Wilson, who’s officially taken up the mantle of Captain America. After 
meeting with newly elected U.S. President Thaddeus Ross, Sam finds himself in the middle of an international incident. He must discover the reason behind a nefarious global 
plot before the true mastermind has the entire world seeing red.', 'assets/poster/CAPTAIN_AMERICA_BRAVE_NEW_WORLD.jpg');

INSERT INTO MOVIE VALUES ('ATTACK ON TITAN: THE LAST ATTACK', 'Yuichiro Hayashi', 'Yuki Kaji, Yui Ishikawa, Marina Inoue, Hiroshi Kamiya,...', 'Action, Animation, Drama',
'2025/02/07', 144, 'The fate of the world hangs in the balance as Eren unleashes the ultimate power of the Titans. With a burning determination to 
eliminate all who threaten Eldia, he leads an unstoppable army of Colossal Titans towards Marley.', 'assets/poster/ATTACK_ON_TITAN_THE_LAST_ATTACK.jpg');

INSERT INTO MOVIE VALUES ('PADDINGTON IN PERU', 'Dougal Wilson', 'Hugh Bonneville, Emily Mortimer, Ben Whishaw', 'Animation, Family', '2025/01/29', 106, 
'Full of Paddington’s signature blend of wit, charm, and laugh-out-loud humor, Paddington in Peru finds the beloved, marmalade-loving bear lost in the jungle on an 
exciting, high-stakes adventure. When Paddington discovers his beloved Aunt Lucy has gone missing from the Home for Retired Bears, he and the Brown family head to 
the wilds of Peru to look for her, the only clue to her whereabouts a spot marked on an enigmatic map. Determined to solve the mystery, Paddington embarks on a thrilling 
quest through the rainforests of the Amazon to find his aunt…and may also uncover one of the world’s most legendary treasures.', 'assets/poster/PADDINGTON_IN_PERU.jpg');

INSERT INTO MOVIE VALUES ('FLIGHT RISK', 'Mel Gibson', 'Mark Wahlberg, Michelle Dockery, Topher Grace, ...', 'Action, Crime, Thriller', '2025/02/28', 92, 
'A pilot transports an Air Marshal accompanying a fugitive to trial. As they cross the Alaskan wilderness, tensions soar and trust is tested, 
as not everyone on board is who they seem.', 'assets/poster/FLIGHT_RISK.jpg');

INSERT INTO MOVIE VALUES ('ANH TRAI "SAY HI”: VILLAINS MADE THE HERO', N'Lê Hoàng Tuấn (Jason) & Nguyễn Duy Anh (Mr Blue)', default, 'Concert, Documentary', '2025/02/26', 120, 
N'Anh trai "say hi" không chỉ là một chương trình âm nhạc thực tế sống còn thuần Việt mà còn là bước ngoặt của nền công nghiệp giải trí Việt Nam. Đối 
mặt với “kẻ phản diện” mang tên hoài nghi, định kiến về thần tượng nội địa, chương trình đã chinh phục khán giả với format, âm nhạc và thần tượng hoàn toàn mới. Chuỗi 
concert lập kỷ lục cháy vé hơn 178,000 vé mà không cần idol quốc tế. Hành trình của “Anh trai ‘say hi’” chứng minh: không có người hùng vĩ đại nếu thiếu kẻ phản diện 
đáng gờm — và chương trình này đã thay đổi văn hóa thần tượng Việt mãi mãi.', 'assets/poster/ANH_TRAI_SAY_HI_VILLAINS_MADE_THE_HERO.jpg');

-- Thêm dữ liệu vào bảng 'Movie' - sắp chiếu

INSERT INTO MOVIE VALUES 

	('JURASSIC WORLD: REBIRTH','Gareth Edwards','Scarlett Johansson, Mahershala Ali, Jonathan Bailey,...','Action, Adventure, Fantasy','2025/07/04',DEFAULT,
	'Jurassic World: Rebirth is set five years after Jurassic World: Dominion, where Earth''s environment has largely proven unsuitable for dinosaurs. Many 
	resurrected prehistoric reptiles have perished. Those that survived have retreated to a remote tropical area near a laboratory. This very location is where 
	the trio—Scarlett Johansson, Mahershala Ali, and Jonathan Bailey—embark on an extremely perilous mission.','assets/poster/JURASSIC_WORLD_REBIRTH.jpg'),

	('SUPERMAN','James Gunn','David Corenswet, Rachel Brosnahan, Nicholas Hoult,...','Action, Adventure','2025/07/11',DEFAULT,'“Superman,” DC Studios’ first feature film to 
	hit the big screen, is set to soar into theaters worldwide this summer from Warner Bros. Pictures. In his signature style, James Gunn takes on the original 
	superhero in the newly imagined DC universe with a singular blend of epic action, humor and heart, delivering a Superman who’s driven by compassion and an 
	inherent belief in the goodness of humankind.','assets/poster/SUPERMAN.jpg'),

	('M3GAN 2.0','Gerard Johnstone','Jemaine Clement; Amie Donald; Allison Williams','Horror, Science Fiction','2025/06/27',DEFAULT,'The film is set 2 years after the events 
	in part 1. At this time, Gemma discovers that the MEGAN production technology has been stolen. The crooks have created another AI robot with similar functions to MEGAN, 
	but equipped with "greater" fighting power called Amelia. To "confront" Amelia, Gemma is forced to "revive" and improve MEGAN, promising a "fiery" battle on screen in 2025.',
	'assets/poster/M3GAN_2.0.jpg'),

	('28 YEARS LATER','Danny Boyle','Aaron Taylor-Johnson, Ralph Fiennes, Jodie Comer, Cillian Murphy','Horror, Thriller','2025/06/20',DEFAULT,
	'28 Years Later is an upcoming post-apocalyptic horror film produced and directed by Danny Boyle from a screenplay by Alex Garland. It is the third installment 
	in the 28 Days Later film series, following 28 Days Later and 28 Weeks Later.','assets/poster/28_YEARS_LATER.jpg'),

	('THE BAD GUYS 2','Pierre Perifel, JP Sans',DEFAULT,'Animation, Comedy','2025/08/01',DEFAULT,'The Bad Guys team is trying to regain the trust of others after 
	going straight, but all their efforts crumble when they are pulled into "one last job" led by the Bad Girls. Will they stay true to their ideals of justice, or 
	will they be dragged back into the criminal path they once tried to escape?','assets/poster/THE_BAD_GUYS_2.png'),

	('THE SMURFS MOVIE','Chris Miller','Rihanna, James Corden, Nick Offerman, Natasha Lyonne, Amy Sedaris, Nick Kroll, Daniel Levy, Octavia Spencer,...',
	'Adventure, Animation, Comedy, Family','2025/07/18',DEFAULT,'When Papa Smurf (John Goodman) is mysteriously taken by evil wizards, Razamel and Gargamel, Smurfette 
	(Rihanna) leads the Smurfs on a mission into the real world to save him. With the help of new friends, the Smurfs must discover what defines their destiny to save 
	the universe.','assets/poster/THE_SMURFS_MOVIE.jpg'),

	('PANOR','Putipong Saisikaew','Cherprang Areekul, Jackrin Kungwankiatichai, Chalita Suansane', 'Horror, Thriller','2025/04/11',118,
	'The story centers on PANOR, an innocent young woman who was born on the dark day when someone in the village unleashes a curse of black magic. Panor is regarded 
	as a bad omen, a jinxed woman who brings bad luck to the village, and anyone who spends time with her risk falling prey to black magic. Panor soon finds out that 
	something dark and powerful has stalked her since the day she was born, cursing her to a life of misery.','assets/poster/PANOR.jpg');

SELECT * FROM MOVIE;

-- Thêm dữ liệu vào bảng 'is_rated' (được xếp loại)

SELECT * FROM RATED;

INSERT INTO is_rated VALUES (1,1);
INSERT INTO is_rated VALUES (2,4);
INSERT INTO is_rated VALUES (3,2);
INSERT INTO is_rated VALUES (4,2);
INSERT INTO is_rated VALUES (5,3);
INSERT INTO is_rated VALUES (6,4);
INSERT INTO is_rated VALUES (7,4);
INSERT INTO is_rated VALUES (8,2);
INSERT INTO is_rated VALUES (9,3);
INSERT INTO is_rated VALUES (10,1);
INSERT INTO is_rated VALUES (11,3);
INSERT INTO is_rated VALUES (12,5);

SELECT MV.movie_name, R.rated_code FROM is_rated IR JOIN MOVIE MV ON IR.movie_id=MV.id JOIN RATED R ON R.ID=IR.rated_id;

-- Thêm dữ liệu vào bảng 'theater'

INSERT INTO theater VALUES('Screen 1');
INSERT INTO theater VALUES('Screen 2');

SELECT * FROM theater;

-- Thêm dữ liệu vào bảng 'seat', mỗi rạp 8 hàng 12 cột tổng cộng 192 ghế cho hai rạp

INSERT INTO SEAT (THEATER_ID, SEAT_CODE)
SELECT T.ID, CONCAT(R.Letter, FORMAT(C.Number, '00')) -- SEAT_CODE: A01 ... A12 ... H12
FROM (VALUES (1), (2)) AS T(ID)  -- Danh sách rạp 1 & 2
CROSS JOIN (VALUES ('A'), ('B'), ('C'), ('D'), ('E'), ('F'), ('G'), ('H')) AS R(Letter) -- Hàng A → H
CROSS JOIN (VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12)) AS C(Number); -- Cột 01 → 12

SELECT * FROM SEAT;

 -- Thêm dữ liệu vào bảng 'MEMBER_RANK' (phân hạng thành viên)

INSERT INTO MEMBER_RANK (RANK_NAME, THRESHOLD, DISCOUNT, RANK_DESCRIPTION)  
VALUES  
    (N'Bronze', 0, 0.00, N'Đây là hạng thành viên cơ bản, chưa tích lũy đủ chi tiêu để nhận ưu đãi. Hãy tiếp tục đồng hành cùng rạp để nâng hạng và nhận nhiều ưu đãi hơn!'),  
    (N'Silver', 1000000, 0.05, N'Chúc mừng! Bạn đã đạt hạng Silver với tổng chi tiêu từ 1 triệu. Tận hưởng ưu đãi giảm 5% khi mua vé xem phim cho mỗi lần giao dịch.'),  
    (N'Gold', 3000000, 0.10, N'Bạn đã đạt hạng Gold với tổng chi tiêu đạt 3 triệu. Mọi giao dịch mua vé sẽ được giảm ngay 10% - một đặc quyền dành riêng cho khách hàng thân thiết!'),  
    (N'Platinum', 10000000, 0.20, N'Hạng cao nhất - Platinum! Với tích lũy chi tiêu vượt mốc 10 triệu, bạn nhận được ưu đãi giảm 20% khi mua vé và bắp nước. Trải nghiệm xem phim thoải mái hơn với những đặc quyền dành riêng cho bạn.');  

-- Thêm dữ liệu mẫu vào bảng 'Schedule', thêm lịch chiếu cho 2 ngày

INSERT INTO SCHEDULE (MOVIE_ID, THEATER_ID, START_TIME, END_TIME)
VALUES
-- Ngày 11/03/2025
(1, 1, '2025-03-11 07:00', '2025-03-11 08:29'),
(3, 1, '2025-03-11 08:45', '2025-03-11 11:34'),
(5, 1, '2025-03-11 12:00', '2025-03-11 13:54'),
(7, 1, '2025-03-11 14:15', '2025-03-11 16:25'),
(9, 1, '2025-03-11 17:00', '2025-03-11 18:44'),
(2, 1, '2025-03-11 19:15', '2025-03-11 21:12'),

(4, 2, '2025-03-11 07:15', '2025-03-11 08:37'),
(6, 2, '2025-03-11 09:00', '2025-03-11 11:19'),
(8, 2, '2025-03-11 12:00', '2025-03-11 13:58'),
(10, 2, '2025-03-11 14:30', '2025-03-11 16:16'),
(11, 2, '2025-03-11 17:00', '2025-03-11 18:32'),
(12, 2, '2025-03-11 19:00', '2025-03-11 21:00'),

-- Ngày 12/03/2025
(2, 1, '2025-03-12 07:00', '2025-03-12 08:57'),
(4, 1, '2025-03-12 09:15', '2025-03-12 10:37'),
(6, 1, '2025-03-12 11:00', '2025-03-12 13:19'),
(8, 1, '2025-03-12 14:00', '2025-03-12 15:58'),
(10, 1, '2025-03-12 16:30', '2025-03-12 18:16'),
(12, 1, '2025-03-12 19:00', '2025-03-12 21:00'),

(1, 2, '2025-03-12 07:30', '2025-03-12 08:59'),
(3, 2, '2025-03-12 09:30', '2025-03-12 12:19'),
(5, 2, '2025-03-12 12:45', '2025-03-12 14:39'),
(7, 2, '2025-03-12 15:00', '2025-03-12 17:10'),
(9, 2, '2025-03-12 17:45', '2025-03-12 19:29'),
(11, 2, '2025-03-12 20:00', '2025-03-12 21:32');

-- Bảng THEATER_MEM thêm qua code vì cần hash mật khẩu bằng BCRYPT
-- Bảng Ticket thêm qua code vì chưa có member