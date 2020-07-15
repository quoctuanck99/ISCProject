USE [master]
GO
/****** Object:  Database [Fotozy]    Script Date: 15/07/2020 02:40:25 ******/
CREATE DATABASE [Fotozy]
GO
ALTER DATABASE [Fotozy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fotozy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fotozy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fotozy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fotozy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fotozy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fotozy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fotozy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fotozy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fotozy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fotozy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fotozy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fotozy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fotozy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fotozy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Fotozy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fotozy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fotozy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fotozy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fotozy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fotozy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fotozy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fotozy] SET RECOVERY FULL 
GO
ALTER DATABASE [Fotozy] SET  MULTI_USER 
GO
ALTER DATABASE [Fotozy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fotozy] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Fotozy', N'ON'
GO
USE [Fotozy]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 15/07/2020 02:40:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[account_name] [varchar](30) NOT NULL,
	[hashed_password] [varchar](128) NOT NULL,
	[salt] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[account_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account_role]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_role](
	[account_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ads]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ads](
	[post_id] [int] IDENTITY(1,1) NOT NULL,
	[age_from] [int] NOT NULL,
	[age_to] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[post_id] [int] NULL,
	[account_id] [int] NULL,
	[date_created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[post_id] ASC,
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorite_post]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorite_post](
	[post_id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC,
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follow]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follow](
	[account_id] [int] NOT NULL,
	[following_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC,
	[following_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hash_tag]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hash_tag](
	[tag_id] [int] IDENTITY(1,1) NOT NULL,
	[tag_name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tag_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[image_name] [nvarchar](50) NULL,
	[date_uploaded] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[message_id] [int] IDENTITY(1,1) NOT NULL,
	[participant_id] [int] NULL,
	[date_created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participant]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant](
	[participant_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NULL,
	[room_id] [int] NULL,
	[nick_name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[participant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[account_id] ASC,
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[post_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NULL,
	description nvarchar(500) NULL,
	[numb_favorite] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[checkin] [nvarchar](50) NULL,
	[is_ads] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post_image]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post_image](
	[post_id] [int] NOT NULL,
	[image_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC,
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post_tag]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post_tag](
	[post_id] [int] NOT NULL,
	[tag_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC,
	[tag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post_video]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post_video](
	[post_id] [int] NOT NULL,
	[video_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[post_id] ASC,
	[video_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[report_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NULL,
	[reason] [nvarchar](100) NULL,
	[is_closed] [bit] NOT NULL,
	[date_created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report_user]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report_user](
	[report_id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[report_id] ASC,
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report_post]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report_post](
	[report_id] [int] NOT NULL,
	[post_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[report_id] ASC,
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[room_id] [int] IDENTITY(1,1) NOT NULL,
	[room_name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone] [varchar](20) NULL,
	[full_name] [nvarchar](50) NOT NULL,
	[dob] [date] NOT NULL,
	[gender] [bit] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[is_active] [bit] NOT NULL,
	[avatar] [varchar](50) NULL,
	[is_agency] [bit] NOT NULL,
	[info] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Video]    Script Date: 15/07/2020 02:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[video_id] [int] IDENTITY(1,1) NOT NULL,
	[video_name] [nvarchar](50) NULL,
	[date_uploaded] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[video_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account_role]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
ALTER TABLE [dbo].[Account_role]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Ads]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Favorite_post]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Favorite_post]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Follow]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Follow]  WITH CHECK ADD FOREIGN KEY([following_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([participant_id])
REFERENCES [dbo].[Participant] ([participant_id])
GO
ALTER TABLE [dbo].[Participant]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Participant]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[Room] ([room_id])
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Post_image]  WITH CHECK ADD FOREIGN KEY([image_id])
REFERENCES [dbo].[Image] ([image_id])
GO
ALTER TABLE [dbo].[Post_image]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Post_tag]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Post_tag]  WITH CHECK ADD FOREIGN KEY([tag_id])
REFERENCES [dbo].[Hash_tag] ([tag_id])
GO
ALTER TABLE [dbo].[Post_video]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Post_video]  WITH CHECK ADD FOREIGN KEY([video_id])
REFERENCES [dbo].[Video] ([video_id])
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Report_user]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[User] ([account_id])
GO
ALTER TABLE [dbo].[Report_user]  WITH CHECK ADD FOREIGN KEY([report_id])
REFERENCES [dbo].[Report] ([report_id])
GO
ALTER TABLE [dbo].[Report_post]  WITH CHECK ADD FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Report_post]  WITH CHECK ADD FOREIGN KEY([report_id])
REFERENCES [dbo].[Report] ([report_id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
USE [master]
GO
ALTER DATABASE [Fotozy] SET  READ_WRITE 
GO
