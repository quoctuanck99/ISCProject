USE [Fotozy]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [account_name], [hashed_password], [salt]) VALUES (1, N'nguyentran123', N'a393206af4b010a96ecb71186afe5826b835f9f896840f0fad44783ce95e622ed8d4820198efc74947b6ac607550f375b739deb446e072332f22becb441dc853', N'E1F53135E559C253')
INSERT [dbo].[Account] ([account_id], [account_name], [hashed_password], [salt]) VALUES (2, N'thang1160', N'5d3aa27e1ceb5ccb406a12d8002f64e77a5ec90bc07310e7c001fde79e535ee07b1f359544f8e33681bc3fd282b7cf7ed5049bbd881735bf200887504670c56c', N'a3563')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
