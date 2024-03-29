USE [GIRASSOL]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Nuit] [nvarchar](max) NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Cell] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clothing]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clothing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SimpleEntityId] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clothing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[EntryDate] [datetime2](7) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[ClothingsId] [int] NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PriceWithIva] [decimal](18, 2) NOT NULL,
	[Tiket] [nvarchar](max) NULL,
	[IvaValue] [decimal](18, 2) NOT NULL,
	[Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SimpleEntity]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimpleEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[statusCode] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_SimpleEntity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/4/2022 11:48:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Initials] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[Blocked] [bit] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedUserID] [int] NOT NULL,
	[UpdatedUserID] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220316210915_FirstOne', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220321211921_updateModels', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220329181326_priceWithIva', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406100954_testone', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406101136_Removetestone', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406102907_statuscodes', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220410173144_ClothingsId', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220410173238_ClothingsIdj', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220412102951_role', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422035618_tket', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422040908_IvaValue', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504064323_code', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504065555_cell', N'5.0.15')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'02e782ae-012a-4d4d-8912-ceaafa7aaf48', N'admin', N'Admin', N'Admin@email.com', NULL, 0, N'admin', N'4946a0c7-071e-497f-942a-46ade8485438', N'206101c9-5209-48fe-ab93-ce45bdb3bc35', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a7a9d7e7-befd-45aa-aa1e-eb99ab0d6c71', N'Normal', N'Normal', N'Admin@email.com', NULL, 0, N'giraso1122', N'fc0ab0bb-07d6-4037-8f13-0ca9d155f214', N'8005e1bd-8b34-4679-b6cf-a52007b6b785', NULL, 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (2, N'Carlos', N'34567', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (3, N'Rabeca', N'123456Y12', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (4, N'com nome', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (5, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (6, N'Edmilson', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (7, N'Ed', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (8, N'fausio', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (9, N'Edilson x', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (10, N'Ed fff', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (11, N'asdadasd', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (12, N'mauro', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (13, N'Joãna', N'123456', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (14, N'Joãna langa', N'123456', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (15, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (16, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (17, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (18, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (19, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (20, NULL, NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (21, N'yfyvg', N'uybuyb', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (22, N'aaaaaaaaaa', N'nnnnnnnnnnnnnn', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (23, N'fausio', N'nuit', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (24, N'fausio', N'nuit', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (25, N'shelda', N'sdfghjk', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (26, N'asdasd', N'asdasdasd', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (27, N'rrrrrrrrr', N'rrrrrrrrrrrr', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (28, N'Léo', N'123423', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (29, N'Fausio test', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (30, N'leo', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (31, N'bbhgb', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (32, N'hcsjdnc', NULL, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 0)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (33, N'jose', N'345', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 345345)
INSERT [dbo].[Client] ([Id], [Name], [Nuit], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code], [Cell]) VALUES (34, N'gfff', N'21321', N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL, 123123123)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Clothing] ON 

INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (2, NULL, 3, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (3, NULL, 12, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (4, NULL, 2312, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (5, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (6, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (7, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (8, NULL, 2312, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (9, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (10, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (11, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (12, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (13, NULL, 12, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (14, NULL, 12, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (15, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (16, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (17, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (18, NULL, 321, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (19, NULL, 1234, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (20, NULL, 321, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (21, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (22, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (23, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (24, NULL, 0, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (25, NULL, 9, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (26, NULL, 5, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (27, NULL, 1212, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (28, NULL, 3, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (29, NULL, 4, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (30, NULL, 123, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (31, NULL, 12, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (32, NULL, 2, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (33, NULL, 12, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
INSERT [dbo].[Clothing] ([Id], [SimpleEntityId], [Quantity], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (34, NULL, 123123, N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Clothing] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (2, 3, CAST(N'2022-04-07T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, N'sapatos air force 1', 0, 3, CAST(5600.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (3, 21, CAST(N'2022-04-07T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, N'asdasd', 0, 21, CAST(123123123.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (6, 7, CAST(N'2022-04-10T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, 7, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (7, 8, CAST(N'2022-04-07T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, N'asdasd', 1, 8, CAST(123123123.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (8, 25, CAST(N'2022-04-10T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-10T19:39:18.7604484' AS DateTime2), 0, N'uih', 0, 25, CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (12, 24, CAST(N'2022-04-10T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-10T19:10:56.8199775' AS DateTime2), 0, N'fffffffffffff', 0, 24, CAST(5345.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (13, 26, CAST(N'2022-04-10T00:00:00.0000000' AS DateTime2), N'adb7ea96-f7cb-47df-a55c-25d4c2ddb63b', 0, NULL, CAST(N'2022-04-10T19:18:35.3656691' AS DateTime2), NULL, 0, N'asdasdasd', 0, 26, CAST(12312.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (14, 27, CAST(N'2022-04-10T00:00:00.0000000' AS DateTime2), N'd35f8d19-9be4-438d-8cfd-c4aad592ad19', 0, NULL, CAST(N'2022-04-10T19:22:03.1671327' AS DateTime2), NULL, 0, NULL, 0, 27, CAST(1212.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (15, 28, CAST(N'2022-04-12T00:00:00.0000000' AS DateTime2), N'3e490a55-ec82-445d-8053-48f3c4147e0c', 0, NULL, CAST(N'2022-04-12T20:15:08.6513527' AS DateTime2), CAST(N'2022-04-12T20:16:42.0599599' AS DateTime2), 0, N'Cena de Nike', 1, 28, CAST(250.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (16, 29, CAST(N'2022-04-28T00:00:00.0000000' AS DateTime2), N'5f29855c-f034-468a-9935-265f1e79de46', 0, NULL, CAST(N'2022-04-28T18:09:14.0768692' AS DateTime2), CAST(N'2022-04-28T18:12:31.4864922' AS DateTime2), 0, N'sapatos adidas', 1, 29, CAST(1212.00 AS Decimal(18, 2)), CAST(1005.96 AS Decimal(18, 2)), NULL, CAST(206.04 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (17, 30, CAST(N'2022-04-28T00:00:00.0000000' AS DateTime2), N'f9ec62c9-95a3-4ae6-82c3-28a8e6b17056', 0, NULL, CAST(N'2022-04-28T18:24:15.4031615' AS DateTime2), NULL, 0, N'etc', 0, 30, CAST(1000.00 AS Decimal(18, 2)), CAST(145.30 AS Decimal(18, 2)), NULL, CAST(854.70 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (18, 31, CAST(N'2022-04-28T00:00:00.0000000' AS DateTime2), N'9902e0c5-09e0-4cbc-9121-3dcdb1737fd9', 0, NULL, CAST(N'2022-04-28T18:30:34.2773927' AS DateTime2), NULL, 0, NULL, 0, 31, CAST(1000.00 AS Decimal(18, 2)), CAST(145.30 AS Decimal(18, 2)), NULL, CAST(854.70 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (20, 33, CAST(N'2022-05-04T00:00:00.0000000' AS DateTime2), N'2c9455b2-2289-4c34-9eb7-24025dcc3dd9', 0, NULL, CAST(N'2022-05-04T09:05:56.7421834' AS DateTime2), NULL, 0, N'12', 0, 33, CAST(500.00 AS Decimal(18, 2)), CAST(427.35 AS Decimal(18, 2)), N'56', CAST(72.65 AS Decimal(18, 2)), N'GL_19')
INSERT [dbo].[Invoice] ([Id], [ClientId], [EntryDate], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [ClothingsId], [Price], [PriceWithIva], [Tiket], [IvaValue], [Code]) VALUES (21, 34, CAST(N'2022-05-04T00:00:00.0000000' AS DateTime2), N'b3925b49-f8a7-4ce7-8c19-9346dbcd8fd0', 0, NULL, CAST(N'2022-05-04T09:18:02.8884532' AS DateTime2), NULL, 0, N'123123', 0, 34, CAST(1000.00 AS Decimal(18, 2)), CAST(854.70 AS Decimal(18, 2)), N'23', CAST(145.30 AS Decimal(18, 2)), N'GL-21')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[SimpleEntity] ON 

INSERT [dbo].[SimpleEntity] ([Id], [Type], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [statusCode], [Code]) VALUES (19, N'Part', N'163c953f-8881-4fec-857a-61dfaef62144', 1, NULL, CAST(N'2022-04-06T12:31:33.2506156' AS DateTime2), NULL, 0, N'Vestuário', 0, 0, NULL)
INSERT [dbo].[SimpleEntity] ([Id], [Type], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [statusCode], [Code]) VALUES (20, N'Part', N'9d4311a3-a629-4515-937c-060f73c1301b', 1, NULL, CAST(N'2022-04-06T12:31:33.2506156' AS DateTime2), NULL, 0, N'Calçado', 0, 0, NULL)
INSERT [dbo].[SimpleEntity] ([Id], [Type], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [statusCode], [Code]) VALUES (21, N'Client', N'91adc2b6-3c48-4907-8223-10679096b9aa', 1, NULL, CAST(N'2022-04-06T12:31:33.2506156' AS DateTime2), NULL, 0, N'Instituição / Empresa', 0, 1, NULL)
INSERT [dbo].[SimpleEntity] ([Id], [Type], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [statusCode], [Code]) VALUES (22, N'Invoice', N'0e05cdb4-dc92-4515-b15b-c4873db4d0c9', 1, NULL, CAST(N'2022-04-06T12:31:33.2506156' AS DateTime2), NULL, 0, N'Processamento', 0, 0, NULL)
INSERT [dbo].[SimpleEntity] ([Id], [Type], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [statusCode], [Code]) VALUES (23, N'Invoice', N'e7ad8df6-b9b2-4f81-a96b-a7efe0f7d9cd', 1, NULL, CAST(N'2022-04-06T12:31:33.2506156' AS DateTime2), NULL, 0, N'Iniciada', 0, 2, NULL)
INSERT [dbo].[SimpleEntity] ([Id], [Type], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [statusCode], [Code]) VALUES (24, N'Invoice', N'f0f727dd-a0dd-470c-b12d-48f1c392104e', 1, NULL, CAST(N'2022-04-06T12:31:33.2506156' AS DateTime2), NULL, 0, N'Finalizada', 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[SimpleEntity] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Initials], [FullName], [Username], [Email], [Password], [Role], [Blocked], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (3, N'Admin', NULL, N'Admin', N'Admin', N'Admin@email.com', N'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=', N'Admin', 0, N'0f3be34f-a7ab-40fb-813e-ed974237a876', 0, NULL, CAST(N'2022-04-12T00:00:00.0000000' AS DateTime2), NULL, 0, N'App admin', 0, NULL)
INSERT [dbo].[User] ([Id], [Name], [Initials], [FullName], [Username], [Email], [Password], [Role], [Blocked], [Guid], [CreatedUserID], [UpdatedUserID], [CreatedDate], [UpdatedDate], [State], [Description], [Status], [Code]) VALUES (4, N'Giraso', NULL, N'Giraso', N'Giraso', N'Admin@email.com', N'VHmYIy4bfsWrz/8X7/7wS7SLyZ/fezvKYr9pwSufaWY=', N'Admin', 0, N'9e9b5768-6485-44cf-9eae-1c3f5ae2963a', 0, NULL, CAST(N'2022-04-12T00:00:00.0000000' AS DateTime2), NULL, 0, N'App normal', 0, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Client] ADD  DEFAULT ((0)) FOR [Cell]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0.0)) FOR [PriceWithIva]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0.0)) FOR [IvaValue]
GO
ALTER TABLE [dbo].[SimpleEntity] ADD  DEFAULT ((0)) FOR [statusCode]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Clothing]  WITH CHECK ADD  CONSTRAINT [FK_Clothing_SimpleEntity_SimpleEntityId] FOREIGN KEY([SimpleEntityId])
REFERENCES [dbo].[SimpleEntity] ([Id])
GO
ALTER TABLE [dbo].[Clothing] CHECK CONSTRAINT [FK_Clothing_SimpleEntity_SimpleEntityId]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Client_ClientId]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Clothing_ClothingsId] FOREIGN KEY([ClothingsId])
REFERENCES [dbo].[Clothing] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Clothing_ClothingsId]
GO
