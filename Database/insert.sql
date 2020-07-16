USE [Fotozy]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [account_name], [hashed_password], [salt]) VALUES (1, N'nguyentran123', N'123456', N'')
INSERT [dbo].[Account] ([account_id], [account_name], [hashed_password], [salt]) VALUES (2, N'thang1160', N'thang123456', N'')
SET IDENTITY_INSERT [dbo].[Account] OFF

INSERT [dbo].[User] ([account_id], [username], [email], [phone], [full_name], [dob], [gender], [date_created], [is_active], [avatar], [is_agency], [info]) VALUES (1, N'tttnguyen', N'abc@gmail.com', N'0123456789', N'tran thi thuy nguyen', CAST(N'1999-09-09' AS Date), 0, CAST(N'2020-07-15T00:00:00.000' AS DateTime), 1, N'abc.png', 0, N'Sự im lặng của bầy cừu')
INSERT [dbo].[User] ([account_id], [username], [email], [phone], [full_name], [dob], [gender], [date_created], [is_active], [avatar], [is_agency], [info]) VALUES (2, N'thang1160', N'a3f@gmail.com', N'0526487941', N'doan van thang', CAST(N'1997-11-09' AS Date), 1, CAST(N'2020-07-14T00:00:00.000' AS DateTime), 1, N'xyz.png', 0, N'Backend developer')
INSERT [dbo].[Follow] ([account_id], [following_id]) VALUES (2, 1)
