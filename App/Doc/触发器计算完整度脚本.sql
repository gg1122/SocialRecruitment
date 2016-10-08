--个人信息
if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[Tri_Resume_Account]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger Tri_Resume_Account
GO
Create TRIGGER Tri_Resume_Account ON Account 
FOR INSERT, UPDATE 
AS
BEGIN
	DECLARE @AccountId nvarchar(36)	
	SET @AccountId=''
	SELECT @AccountId=I.Id FROM INSERTED I
	IF(@AccountId IS NOT NULL AND @AccountId<>'')
	BEGIN		
		EXEC Proc_Update_Resume_CompletionPercentage null,@AccountId
	END	
END 
GO
----------------------
--秀才学堂
if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[Tri_Resume_DegreeSchool]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger Tri_Resume_DegreeSchool
GO
Create TRIGGER Tri_Resume_DegreeSchool ON DegreeSchool 
FOR INSERT, UPDATE, Delete
AS
BEGIN
	declare @ResumeId nvarchar(36)	
	set @ResumeId=''
	SELECT @ResumeId=I.ResumeId FROM INSERTED I
	--新增
	if not exists(select 1 from deleted) 
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	--删除 
	if not exists(select 1 from inserted)
	begin
		SELECT @ResumeId=I.ResumeId FROM deleted I
	end
	--修改
	if exists(select 1 from inserted) and exists(select 1 from deleted)
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	IF(@ResumeId IS NOT NULL AND @ResumeId<>'')
	BEGIN		
		EXEC Proc_Update_Resume_CompletionPercentage @ResumeId,null
	END	
END 
GO
---------------------------------
--语言能力
if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[Tri_Resume_LanguageCompetence]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger Tri_Resume_LanguageCompetence
GO
Create TRIGGER Tri_Resume_LanguageCompetence ON LanguageCompetence 
FOR INSERT, UPDATE, Delete
AS
BEGIN
	declare @ResumeId nvarchar(36)	
	set @ResumeId=''
	SELECT @ResumeId=I.ResumeId FROM INSERTED I
	--新增
	if not exists(select 1 from deleted) 
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	--删除 
	if not exists(select 1 from inserted)
	begin
		SELECT @ResumeId=I.ResumeId FROM deleted I
	end
	--修改
	if exists(select 1 from inserted) and exists(select 1 from deleted)
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	IF(@ResumeId IS NOT NULL AND @ResumeId<>'')
	BEGIN		
		EXEC Proc_Update_Resume_CompletionPercentage @ResumeId,null
	END	
END 
GO
---------------------------------
--技能爱好
if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[Tri_Resume_ITAbility]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger Tri_Resume_ITAbility
GO
Create TRIGGER Tri_Resume_ITAbility ON ITAbility 
FOR INSERT, UPDATE, Delete
AS
BEGIN
	declare @ResumeId nvarchar(36)	
	set @ResumeId=''
	SELECT @ResumeId=I.ResumeId FROM INSERTED I
	--新增
	if not exists(select 1 from deleted) 
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	--删除 
	if not exists(select 1 from inserted)
	begin
		SELECT @ResumeId=I.ResumeId FROM deleted I
	end
	--修改
	if exists(select 1 from inserted) and exists(select 1 from deleted)
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	IF(@ResumeId IS NOT NULL AND @ResumeId<>'')
	BEGIN		
		EXEC Proc_Update_Resume_CompletionPercentage @ResumeId,null
	END	
END 
GO
---------------------------------
--项目经验
if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[Tri_Resume_ProjectExperience]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger Tri_Resume_ProjectExperience
GO
Create TRIGGER Tri_Resume_ProjectExperience ON ProjectExperience 
FOR INSERT, UPDATE, Delete
AS
BEGIN
	declare @ResumeId nvarchar(36)	
	set @ResumeId=''
	SELECT @ResumeId=I.ResumeId FROM INSERTED I
	--新增
	if not exists(select 1 from deleted) 
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	--删除 
	if not exists(select 1 from inserted)
	begin
		SELECT @ResumeId=I.ResumeId FROM deleted I
	end
	--修改
	if exists(select 1 from inserted) and exists(select 1 from deleted)
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	IF(@ResumeId IS NOT NULL AND @ResumeId<>'')
	BEGIN		
		EXEC Proc_Update_Resume_CompletionPercentage @ResumeId,null
	END	
END 
GO
---------------------------------
--实习经验
if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[Tri_Resume_InternshipExperience]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger Tri_Resume_InternshipExperience
GO
Create TRIGGER Tri_Resume_InternshipExperience ON InternshipExperience 
FOR INSERT, UPDATE, Delete
AS
BEGIN
	declare @ResumeId nvarchar(36)	
	set @ResumeId=''
	SELECT @ResumeId=I.ResumeId FROM INSERTED I
	--新增
	if not exists(select 1 from deleted) 
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	--删除 
	if not exists(select 1 from inserted)
	begin
		SELECT @ResumeId=I.ResumeId FROM deleted I
	end
	--修改
	if exists(select 1 from inserted) and exists(select 1 from deleted)
	begin
		SELECT @ResumeId=I.ResumeId FROM INSERTED I
	end
	IF(@ResumeId IS NOT NULL AND @ResumeId<>'')
	BEGIN		
		EXEC Proc_Update_Resume_CompletionPercentage @ResumeId,null
	END	
END 
GO
---------------------------------
