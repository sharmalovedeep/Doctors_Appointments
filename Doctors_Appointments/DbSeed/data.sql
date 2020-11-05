SET IDENTITY_INSERT [dbo].[Doctor] ON
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (3, N'John Smith', 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (4, N'Linda Right', 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (5, N'Aidan Twiddle', 0)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[Patient] ON
INSERT INTO [dbo].[Patient] ([Id], [Name], [MobileNumber]) VALUES (2, N'Kyle Jones', N'+642569879')
INSERT INTO [dbo].[Patient] ([Id], [Name], [MobileNumber]) VALUES (3, N'Kate Ko', N'+6421356844')
SET IDENTITY_INSERT [dbo].[Patient] OFF
SET IDENTITY_INSERT [dbo].[ReasonForAppointment] ON
INSERT INTO [dbo].[ReasonForAppointment] ([Id], [Reason], [Charge]) VALUES (1, N'Sore Throat', CAST(15.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[ReasonForAppointment] ([Id], [Reason], [Charge]) VALUES (2, N'Muscle aches', CAST(25.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[ReasonForAppointment] ([Id], [Reason], [Charge]) VALUES (3, N'Xray', CAST(32.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[ReasonForAppointment] ([Id], [Reason], [Charge]) VALUES (4, N'Check up', CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ReasonForAppointment] OFF
SET IDENTITY_INSERT [dbo].[Appointment] ON
INSERT INTO [dbo].[Appointment] ([Id], [PatientId], [DoctorId], [ReasonForAppointmentId], [AppointmentTime]) VALUES (1, 2, 4, 2, N'2020-01-04 12:24:00')
INSERT INTO [dbo].[Appointment] ([Id], [PatientId], [DoctorId], [ReasonForAppointmentId], [AppointmentTime]) VALUES (2, 3, 3, 4, N'2020-10-05 02:30:00')
SET IDENTITY_INSERT [dbo].[Appointment] OFF

