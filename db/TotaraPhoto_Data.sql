USE [TotaraPhoto]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discount]) VALUES (N'079A2F8C-58F4-4BFF-AE25-93960535E1A5', N'admin', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discount]) VALUES (N'41DAEF31-0AA9-4D90-9A0D-300447A50DDD', N'expired', CAST(0.00 AS Decimal(4, 2)))
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discount]) VALUES (N'73A015A8-0D32-44CE-BA6C-3CFDF584DFB2', N'inactive', CAST(0.00 AS Decimal(4, 2)))
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discount]) VALUES (N'8FD2062B-0705-47AA-8131-67777A271DAF', N'full', CAST(0.85 AS Decimal(4, 2)))
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discount]) VALUES (N'9B81EC2E-B867-485E-8AB4-577D1BBD96CD', N'associate', CAST(0.90 AS Decimal(4, 2)))
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02bca8db-6b18-4f14-82cc-64dde20bd0f0', N'vince@example.com', 0, N'AJWKyf21J0Vl/f9CiTkbUFMM81UL+aKziuEKjSRRQJnWb/ri8dPu2JE+81fGpy7IJw==', N'0d1118aa-48d1-4c00-8cb4-92d6b13712c1', NULL, 0, 0, NULL, 1, 0, N'vince@example.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d8c182f-cb10-4121-85c5-aeb45048f722', N'conan@example.com', 0, N'AOgVXSwZOG5cNu4PGrSwef1bx501x5vWCywaEhSZcgyunWsLuz7F7VFO6sFSLyfQng==', N'a3ce6e85-d9ad-4af5-ba27-dedf55e633ad', NULL, 0, 0, NULL, 1, 0, N'conan@example.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'591253b3-2549-42e2-9215-4d7d26842876', N'aaron@example.com', 0, N'ADlLJfd/NeRpUnObKRZ6tyQeRB4TgpyJrpud5H0G/pc4t18hLfjl2ErafN6SIeV4qA==', N'30389c3e-ec8b-43a4-8fac-e086c233d0be', NULL, 0, 0, NULL, 1, 0, N'aaron@example.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69b2193e-f445-4ce4-8341-a4b1b73c8813', N'lusie@example.com', 0, N'AFNMsE9ozG+Ik8kpxknQ4D8Au/4Ns5KbtghbA5nRD77BmH4iVfTnN+RTM0d3iF85Qg==', N'30687469-9f90-479d-9f0d-9e8da24dbc84', NULL, 0, 0, NULL, 1, 0, N'lusie@example.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a2ce4bfb-4e59-45a1-96f4-9a09db207ce8', N'daisy@example.com', 0, N'ADBDmk1e1y469yos6xseiu/IbihEwWGZdGT85FsUi8e5tgf97C6PYclLe+FNXmpBiw==', N'8675c764-7805-49e6-b353-bd433a415c79', NULL, 0, 0, NULL, 1, 0, N'daisy@example.com')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [ExpiryDate]) VALUES (N'02bca8db-6b18-4f14-82cc-64dde20bd0f0', N'079A2F8C-58F4-4BFF-AE25-93960535E1A5', CAST(N'2016-10-01 14:00:00.000' AS DateTime))
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [ExpiryDate]) VALUES (N'1d8c182f-cb10-4121-85c5-aeb45048f722', N'9B81EC2E-B867-485E-8AB4-577D1BBD96CD', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [ExpiryDate]) VALUES (N'591253b3-2549-42e2-9215-4d7d26842876', N'41DAEF31-0AA9-4D90-9A0D-300447A50DDD', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [ExpiryDate]) VALUES (N'69b2193e-f445-4ce4-8341-a4b1b73c8813', N'73A015A8-0D32-44CE-BA6C-3CFDF584DFB2', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [ExpiryDate]) VALUES (N'a2ce4bfb-4e59-45a1-96f4-9a09db207ce8', N'8FD2062B-0705-47AA-8131-67777A271DAF', CAST(N'2017-10-01 14:00:00.000' AS DateTime))
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201609131229395_InitialCreate', N'TotaraPhotographyAssociation.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D05376E1B47CD919CC1ADD099CB69D35767CC1B427C8DB802DB1DBC2489422518E8D45BE2C0FF9A4FCC216254A2DF12251DDEA8B8301062D913C552C1E92C552D17FFEFEC7F8FB9730B09E7192FA1199D827A363DBC2C48D3C9F2C27764617DF7EB0BFFFEEEF7F1B5F79E18BF55359EF8CD58396249DD84F94C6E78E93BA4F3844E928F4DD244AA3051DB951E8202F724E8F8FFFED9C9C3818206CC0B2ACF1A78C503FC4F9033C4E23E2E2986628B88D3C1CA4FC3D94CC7254EB0E85388D918B27F6634451821E9E221A2D13143FBD5EA469E4FA888262A3A2B96D5D043E02D5663858D8162204DAB0F2F3CF299ED12422CB590C2F50F0F81A63A8B740418A7987CE57D54DFB767CCAFAE6AC1A96506E96D228EC097872C68DE588CDD732B95D1913CC790566A7AFACD7B94927F68D87F3579FA2000C200A3C9F0609AB3CB16F2B1117697C87E9A86C382A20AF1380FB354ABE8EEA88479671BBA38A5CA7A363F6EFC89A6601CD123C2138A3090A8EAC876C1EF8EE7FF1EB63F41593C9D9C97C71F6E1DD7BE49DBDFF173E7B57EF29F415EA355EC0AB87248A7102BAE145D57FDB729AED1CB161D5ACD6A6B00A7009E6896DDDA2978F982CE913CCA0D30FB675EDBF60AF7CC3C9F599F830ADA0114D3278BCCB8200CD035C953BAD32D9FF2D524FDFBD1F44EA1D7AF697F9D00BF261E22430AF3EE1202F4D9FFCB8985E8DF1FEC2AB5D2751C89E9BFC2A4ABFCCA22C715967226D9547942C316D6A377656E435A234831A9ED625EAE1539B692AD35B599575689D99508AD8F56C28F5DDAE5C63C65DC4310C5E4E2D669136C219EC5E2301EEC86A6BB422D78929B90874FAAFBC565E85C80F06582C0DA480E3B2F0931057BDFC21026A22D25BE70794A6B05678FF41E9538BEAF07300D567D8CD12A0F08CA230DEBA34E02DC177593867336377B2061B9AC75FA36BE4D228B922ACD5C6781F23F76B94D12BE25D228A3F53B704648F8F7E680E30883A17AE8BD3F41AC88CBD69047E79097843E8D9696F38B662EDDB599906C80FD5DE8AB0B67E29ABAE3C16750DC96BD15453792E6DAA7E8C963E3153B5ACAA57B5A8D1A92AAFD657550666A629AFA95734AFD0A967516B305F301FA1E19DC11CF6F0BDC1CD366FDD5A5033E30C5648FC2326388165CC7B4094E284AC46C064DDD887B3900F1F13BAF5BD2997F4130AB2A145AD351BF24560F8D990C31EFE6CC8D584D7CFBEC7BC128323525919E08DEAAB4F5FDD734ED06CD7D3A1D1CD5D0BDFCD1AA09B2EB543952238C6431B4DFDC187B3BAE31C456FC45809740C88EEB32D0FDE40DF6C9154F7E412079862EBC22D82875394BAC893CD081DF27A2856EEA80AC5563193A672FF946402D371C21A2176084A61A6FA84CAD3C227AE1FA3A0D34A424BC32D8CF5BD9221965CE2181326B0D31226C2D52112A640254718942E0B8D9D1AE3DA89A8F15A7563DEE5C2AEC65D8A5CEC84931DBEB38697DC7FDB0A31DB2DB60372B69BC444016DB86F1F04E5671553028807974323A87062D21094BB543B2168D3627B2068D3246F8EA0C511D574FC85F3EAA1D1B37950DEFDB6DE6AAE3D70B3618F03A366E17B421B0A2D7022D3F372CE0AF10B551CCE404F7E3E4BB9AB2B528481CF306D866C56FEAED20F75DA414412B501AE88D601CA3F144A40D284EAA15C19CB6BD58E7B113D60CBB85B2B2C5FFB05D81A0764ECFA07D35A45FD6755919C46A78FAA67151B24921B1D166A380A42888B57B3E30646D1C56565C398F8C27DBCE15AC7F860B418A8C373D518A9ECCCE0562AA9D96D259543D6C725DBC84A82FBA4B152D999C1ADC439DA6D248553D0C32DD8C844CD2D7CA0C956463AAADDA62A1B3B4562157F3176341958E35B14C73E59D632B2F81B6B56A4634DBF9DF54F4B0A0B0CC74D15D94995B695241A2568898552100D9A5EFB494A2F114573C4E23C532F94AA29F756CDF25F8AAC6F9FF22096FB40599BFDE6DF0A0D3EEF37365FD93BE1A0D7D0E590B938795C5D410875738BA5CCA100258A50FE340AB290E83D2E7DEBE2835EBD7DF14646183B82FE924725994FF27B9B63613452F22CD9D6A8551ECEFA23A787D0D9BFF44FEB23A0F359F5286508AB8EA20B6BED6D2475AECE66A327BA95FD07AF13613B338FE7B2D401F8AB9E18B5740809AC56668EDACC58A963364BCC1185B4943AA450D443CB7AF24943C97AC15A781A8BAA6B984B90D34DEAE872A939B222F1A40EAD285E035BA1B358668EAAC84DA9032B8ACDB157892AE2AA7AC07B9BF6B033DCE6561C9037DBDD3418DB592287D91C6B790075A0DAEB9E58FC4BBF04C6DF1F24BDB4A7C4E1E855044A36A3970643BF36353EA93797A6D63C003D66E33B7963F96FCB13D0E3F523F156A9229D1AC52A95F4EAF4289C12C7FCC4D67D99473AC215556CAB34236CFDAF29C5E1885518CD7E09A6818FD9425F56B845C45FE09416B921F6E9F1C9A970FDE770AEE23869EA058A13AFEE3E4E73CC7690E6459E51E23EA1444EBAD8E0BACA0A548A67DF100FBF4CECFFE5ADCEF3D008FB95BF3EB26ED2CFC4FF258382C724C3D66F7212E930E9FBEDE7B203BD6C616ED59B9FBF144D8FACFB0466CCB9752CD8729D116E5EC1E8A54DD174036DD6BE98F1762754E34E8312559810EB5F6198FB7490EB0BA596DF84E8E51F7D55535E51D80851710D6128BC414CA8BB66B00E96F68A81078F34BF62D0AFB3EA2B07EBA8A6BD6EE093FE60E26503F365A86CB9C7AD467148DAC59294DBB933597BA3CCCD7DEF4D524EF746135DCEDBEE01B7416EF61ACC786369CD83ED8E8AACE5C1B0F749EDADA72A1F4A76F22A6F64BF49C9BBCC436EF992F4974A3F3E8084394502D0FE938C77CD355D60F7C03335FBA5121F18D9785AD8FE1386774D365D98F7C0C9D62B2DF8C0B8B6AFFD73CF4C33DE42F79EE42BE72B693ED0A862C15D49BC45E01C4EF8F30848507894C5DD4B75D6585BC66B87C05515BD507DBA9A28589A38925CA946BBD87E7DE51B7E6B67799D76B19A24CF36D97CFD6F95CDEBB4CBD6A44EEE23FD5899BCA84A09EF58C7DAF2A6DE52BA71A3271DD9ED5D3E6BEBD7F6B7945D3C88511AB347F38DF8ED24130F629221A74E8FE461F9732FEC9DB5BFF008FB77EA2F5710ECEF3D12EC3676CDAACE0D5944E5E62D685456112234B798220FB6D48B84FA0BE452286631E6FCF2781EB7635F3AE6D8BB21F7198D330A5DC6E13C6804BC9813D0263FCF906EEA3CBE8FD9533A4417404D9FC5E6EFC90F991F7895DED78A9890068279173CA2CBC692B2C8EEF2B542BA8B882110375FE5143DE2300E002CBD2733F48CD7D10DE8F7112F91FBBA8A00EA40BA07A269F6F1A58F96090A538EB16A0F8FC0612F7CF9EEFFACFAA874E8540000, N'6.1.3-40302')
GO

INSERT [dbo].[Product] ([Id], [Name], [PhotoFilePath], [Price], [Description], [IsDeleted], [BigPhotoFilePath]) VALUES (N'CAN-5D-4-NSOL', N'Canon EOS 5D Mark IV', N'eos5d.jpg', CAST(1.00 AS Decimal(18, 2)), N'The Canon EOS 5D Mark IV boasts a huge array of high end features, including a 30 megapixel full frame CMOS imaging sensor and Canon''s latest AF system, for a significantly lower price than Canon''s current 1-Series model. This value and versatility, as with all EOS 5-Series models before it, launched the Canon EOS 5D Mark IV to great fanfare and a strong demand.', 0, N'Canon_EOS_5D_Mark_III.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [PhotoFilePath], [Price], [Description], [IsDeleted], [BigPhotoFilePath]) VALUES (N'HAS-X-1D-GNCV', N'Hasselblad X1D-50c 4116 Edition', N'hass.jpg', CAST(1.00 AS Decimal(18, 2)), N'Determined to shake up the photographic industry, Hasselblad has unleashed a world''s first in the form of the X1D-50c Medium Format Mirrorless Digital Camera. This camera takes the well-regarded 50MP 43.8 x 32.9mm CMOS sensor found in numerous medium format systems and incorporates it into a revolutionary mirrorless camera body. Designed and handmade in Sweden, this camera is a precision tool with exceptional ergonomics and a compact size that even rivals smaller format systems. Taking this system above and beyond the rest is a large sensor that works hand-in-hand with the Hasselblad Natural Color Solution to create phenomenal raw images with smooth tonal gradations thanks to 16-bit color depth and 14 stops of dynamic range.', 0, N'x1d-hero.png')
GO
INSERT [dbo].[Product] ([Id], [Name], [PhotoFilePath], [Price], [Description], [IsDeleted], [BigPhotoFilePath]) VALUES (N'PHS-XF-VTLW', N'Phase One XF', N'phase.jpg', CAST(38990.00 AS Decimal(18, 2)), N'Phase One has announced its new medium format XF camera system, the XF. The XF system features a new ''Honeybee'' autofocus platform (created in-house) and ''Flexible One Touch UI'' interface that the company says is based on ''clean Scandinavian design''. Phase One states that the user interface is highly customizable and can ''evolve in accordance with customer needs and feedback''. The XF supports modular viewfinders, including 90 degree prism and waist-level models. The body supports both IQ1 and the new IQ3 digital backs.', 0, N'phaseone__28mm1.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [PhotoFilePath], [Price], [Description], [IsDeleted], [BigPhotoFilePath]) VALUES (N'SOY-ALP-A6000-EVGD', N'Sony Alpha a6000 Mirrorless', N'sony.jpg', CAST(698.00 AS Decimal(18, 2)), N'The black Sony Alpha a6000 Mirrorless Digital Camera is a versatile and advanced mirrorless camera featuring a 24.3MP APS-C-sized Exmor APS HD CMOS sensor and BIONZ X image processor to produce high-resolution still images and full HD movies with marked low-light quality and sensitivity to ISO 25600. Beyond notable imaging traits, the image processor also lends itself to continuous shooting up to 11 fps and an intelligent Fast Hybrid AF system that uses both phase- and contrast-detection methods to quickly and accurately acquire focus.', 0, N'Z-sony-a6000-beauty.jpg')
GO
SET IDENTITY_INSERT [dbo].[Resource] ON 

GO
INSERT [dbo].[Resource] ([Id], [FileName], [Title]) VALUES (1, N'Clendons_NZPhotography.pdf', N'The Clendons Guide to NZ Law Relating to Photography')
GO
INSERT [dbo].[Resource] ([Id], [FileName], [Title]) VALUES (2, N'BauerContractReview_Feb2015.pdf', N'Bauer Media Contract Review')
GO
INSERT [dbo].[Resource] ([Id], [FileName], [Title]) VALUES (3, N'TangibleContractReview.pdf', N'angible Media Contract Review (with cover note)')
GO
INSERT [dbo].[Resource] ([Id], [FileName], [Title]) VALUES (4, N'updig_quickguide_v4.pdf', N'Universal Photographic Digital Imaging Guidelines: Quick Guide')
GO
SET IDENTITY_INSERT [dbo].[Resource] OFF
GO
SET IDENTITY_INSERT [dbo].[SysParam] ON 

GO
INSERT [dbo].[SysParam] ([Id], [ParaName], [ParaVal]) VALUES (1, N'about', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. ')
GO
SET IDENTITY_INSERT [dbo].[SysParam] OFF
GO
