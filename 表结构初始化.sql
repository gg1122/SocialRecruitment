/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2016/10/8 9:25:47                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Comment') and o.name = 'FK_COMMENT_REFERENCE_BLOG')
alter table Comment
   drop constraint FK_COMMENT_REFERENCE_BLOG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DegreeSchool') and o.name = 'FK_DEGREESC_REFERENCE_RESUME')
alter table DegreeSchool
   drop constraint FK_DEGREESC_REFERENCE_RESUME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FileUploader') and o.name = 'FK_FILEUPLO_REFERENCE_RESUME')
alter table FileUploader
   drop constraint FK_FILEUPLO_REFERENCE_RESUME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ITAbility') and o.name = 'FK_ITABILIT_REFERENCE_RESUME')
alter table ITAbility
   drop constraint FK_ITABILIT_REFERENCE_RESUME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InternshipExperience') and o.name = 'FK_INTERNSH_REFERENCE_RESUME')
alter table InternshipExperience
   drop constraint FK_INTERNSH_REFERENCE_RESUME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LanguageCompetence') and o.name = 'FK_LANGUAGE_REFERENCE_RESUME')
alter table LanguageCompetence
   drop constraint FK_LANGUAGE_REFERENCE_RESUME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ProjectExperience') and o.name = 'FK_PROJECTE_REFERENCE_RESUME')
alter table ProjectExperience
   drop constraint FK_PROJECTE_REFERENCE_RESUME
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Account')
            and   name  = 'Index_Email'
            and   indid > 0
            and   indid < 255)
   drop index Account.Index_Email
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Account')
            and   name  = 'Index_PhoneNumber'
            and   indid > 0
            and   indid < 255)
   drop index Account.Index_PhoneNumber
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Account')
            and   name  = 'Index_Name'
            and   indid > 0
            and   indid < 255)
   drop index Account.Index_Name
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Account')
            and   type = 'U')
   drop table Account
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Blog')
            and   name  = 'Index_State'
            and   indid > 0
            and   indid < 255)
   drop index Blog.Index_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Blog')
            and   type = 'U')
   drop table Blog
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Comment')
            and   name  = 'Index_BlogId_State'
            and   indid > 0
            and   indid < 255)
   drop index Comment.Index_BlogId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Comment')
            and   type = 'U')
   drop table Comment
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DegreeSchool')
            and   name  = 'Index_ResumeId_State'
            and   indid > 0
            and   indid < 255)
   drop index DegreeSchool.Index_ResumeId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DegreeSchool')
            and   type = 'U')
   drop table DegreeSchool
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FileUploader')
            and   name  = 'Index_ResumeId_State'
            and   indid > 0
            and   indid < 255)
   drop index FileUploader.Index_ResumeId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FileUploader')
            and   type = 'U')
   drop table FileUploader
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ITAbility')
            and   name  = 'Index_ResumeId_State'
            and   indid > 0
            and   indid < 255)
   drop index ITAbility.Index_ResumeId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ITAbility')
            and   type = 'U')
   drop table ITAbility
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('InternshipExperience')
            and   name  = 'Index_ResumeId_State'
            and   indid > 0
            and   indid < 255)
   drop index InternshipExperience.Index_ResumeId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InternshipExperience')
            and   type = 'U')
   drop table InternshipExperience
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Invite')
            and   type = 'U')
   drop table Invite
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LanguageCompetence')
            and   name  = 'Index_ResumeId_State'
            and   indid > 0
            and   indid < 255)
   drop index LanguageCompetence.Index_ResumeId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LanguageCompetence')
            and   type = 'U')
   drop table LanguageCompetence
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ProjectExperience')
            and   name  = 'Index_ResumeId_State'
            and   indid > 0
            and   indid < 255)
   drop index ProjectExperience.Index_ResumeId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProjectExperience')
            and   type = 'U')
   drop table ProjectExperience
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Resume')
            and   name  = 'Index_AccountId_State'
            and   indid > 0
            and   indid < 255)
   drop index Resume.Index_AccountId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Resume')
            and   type = 'U')
   drop table Resume
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SysException')
            and   name  = 'Index_CreateTime'
            and   indid > 0
            and   indid < 255)
   drop index SysException.Index_CreateTime
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysException')
            and   type = 'U')
   drop table SysException
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SysField')
            and   name  = 'Index_MyColums_MyTables'
            and   indid > 0
            and   indid < 255)
   drop index SysField.Index_MyColums_MyTables
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysField')
            and   type = 'U')
   drop table SysField
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SysLog')
            and   name  = 'Index_CreateTime_PersonId'
            and   indid > 0
            and   indid < 255)
   drop index SysLog.Index_CreateTime_PersonId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysLog')
            and   type = 'U')
   drop table SysLog
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SysNotice')
            and   name  = 'Index_AccountId_State'
            and   indid > 0
            and   indid < 255)
   drop index SysNotice.Index_AccountId_State
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SysNotice')
            and   type = 'U')
   drop table SysNotice
go

/*==============================================================*/
/* Table: Account                                               */
/*==============================================================*/
create table Account (
   Id                   nvarchar(36)         not null default newid(),
   Name                 nvarchar(200)        not null,
   Password             nvarchar(200)        null,
   PhoneNumber          nvarchar(200)        null,
   InviteCode           nvarchar(200)        null,
   InviteCodeUser       nvarchar(36)         null,
   InviteCodeDatetime   datetime             null,
   InviteCode2          nvarchar(200)        null,
   InviteCode2User      nvarchar(36)         null,
   InviteCode2Datetime  datetime             null,
   LogonIP              nvarchar(200)        null,
   MyName               nvarchar(50)         null,
   Sex                  nvarchar(200)        null,
   Birthday             datetime             null,
   AnmeldenProvince     nvarchar(200)        null,
   AnmeldenCity         nvarchar(200)        null,
   LiveProvince         nvarchar(200)        null,
   LiveCity             nvarchar(200)        null,
   PersonalAssessment   nvarchar(400)        null,
   Email                nvarchar(400)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_ACCOUNT primary key nonclustered (Id)
         on "PRIMARY",
   constraint AK_KEY_2_ACCOUNT unique (PhoneNumber)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Account') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Account' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '会员', 
   'user', @CurrentUser, 'table', 'Account'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'Account', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'Sex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'RadioButton',
   'user', @CurrentUser, 'table', 'Account', 'column', 'Sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnmeldenProvince')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'AnmeldenProvince'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'Account', 'column', 'AnmeldenProvince'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnmeldenCity')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'AnmeldenCity'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'AnmeldenProvinceCascade',
   'user', @CurrentUser, 'table', 'Account', 'column', 'AnmeldenCity'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LiveProvince')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'LiveProvince'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'Account', 'column', 'LiveProvince'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LiveCity')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'LiveCity'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'LiveProvinceCascade',
   'user', @CurrentUser, 'table', 'Account', 'column', 'LiveCity'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Account', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Account', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_Name                                            */
/*==============================================================*/
create index Index_Name on Account (
Name ASC
)
go

/*==============================================================*/
/* Index: Index_PhoneNumber                                     */
/*==============================================================*/
create index Index_PhoneNumber on Account (
PhoneNumber ASC
)
go

/*==============================================================*/
/* Index: Index_Email                                           */
/*==============================================================*/
create index Index_Email on Account (
Email ASC
)
go

/*==============================================================*/
/* Table: Blog                                                  */
/*==============================================================*/
create table Blog (
   Id                   nvarchar(36)         not null,
   Title                nvarchar(200)        not null,
   Content              nvarchar(4000)       not null,
   Abstract             nvarchar(4000)       null,
   CommentNumber        int                  null default 0,
   ReadNumber           int                  null default 0,
   Picture3             nvarchar(200)        null,
   Picture2             nvarchar(200)        null,
   PictureName          nvarchar(200)        null,
   Picture2Name         nvarchar(200)        null,
   Picture3Name         nvarchar(200)        null,
   Picture              nvarchar(200)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_BLOG primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Blog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Blog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '博客', 
   'user', @CurrentUser, 'table', 'Blog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Blog', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_State                                           */
/*==============================================================*/
create index Index_State on Blog (
State ASC
)
go

/*==============================================================*/
/* Table: Comment                                               */
/*==============================================================*/
create table Comment (
   Id                   nvarchar(36)         not null default newid(),
   BlogId               nvarchar(36)         null,
   Content              nvarchar(4000)       not null,
   AgreeNumber          int                  null default 0,
   MyPicture            nvarchar(200)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePersonId       varchar(200)         null,
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_COMMENT primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Comment') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Comment' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '评论', 
   'user', @CurrentUser, 'table', 'Comment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePersonId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'CreatePersonId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'CreatePersonId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Comment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Comment', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Comment', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_BlogId_State                                    */
/*==============================================================*/
create index Index_BlogId_State on Comment (
BlogId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: DegreeSchool                                          */
/*==============================================================*/
create table DegreeSchool (
   Id                   nvarchar(36)         not null,
   ResumeId             nvarchar(36)         null,
   BeginDate            datetime             not null,
   EndDate              datetime             null,
   IsNow                char(1)              null default 'N',
   SchoolArea           nvarchar(200)        null,
   SchoolName           nvarchar(200)        not null,
   ProfessionalType1    nvarchar(200)        null,
   ProfessionalType2    nvarchar(200)        not null,
   Education            nvarchar(200)        not null,
   SchoolNameRemark     nvarchar(200)        null,
   ProfessionalTypeRemark nvarchar(200)        null,
   Degree               nvarchar(200)        not null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_DEGREESCHOOL primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DegreeSchool') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DegreeSchool' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '学历学校', 
   'user', @CurrentUser, 'table', 'DegreeSchool'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResumeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ResumeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ResumeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsNow')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'IsNow'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'CheckBox',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'IsNow'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SchoolArea')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'SchoolArea'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'SchoolArea'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SchoolName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'SchoolName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'SchoolAreaCascade',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'SchoolName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProfessionalType1')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ProfessionalType1'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ProfessionalType1'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProfessionalType2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ProfessionalType2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ProfessionalType1Cascade',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ProfessionalType2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Education')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Education'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Education'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SchoolNameRemark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'SchoolNameRemark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'SchoolNameRemark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProfessionalTypeRemark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ProfessionalTypeRemark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'ProfessionalTypeRemark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Degree')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Degree'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Degree'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DegreeSchool')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'DegreeSchool', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_ResumeId_State                                  */
/*==============================================================*/
create index Index_ResumeId_State on DegreeSchool (
ResumeId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: FileUploader                                          */
/*==============================================================*/
create table FileUploader (
   Id                   nvarchar(36)         not null default newid(),
   ResumeId             nvarchar(36)         null,
   PictureUrl           nvarchar(400)        null,
   PictureName          nvarchar(400)        null,
   ResumeName           nvarchar(400)        null,
   ResumeUrl            nvarchar(400)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_FILEUPLOADER primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('FileUploader') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'FileUploader' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '上传文件', 
   'user', @CurrentUser, 'table', 'FileUploader'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResumeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'ResumeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'ResumeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('FileUploader')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'FileUploader', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_ResumeId_State                                  */
/*==============================================================*/
create index Index_ResumeId_State on FileUploader (
ResumeId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: ITAbility                                             */
/*==============================================================*/
create table ITAbility (
   Id                   nvarchar(36)         not null,
   ResumeId             nvarchar(36)         null,
   Ability              nvarchar(200)        not null,
   UseTime              nvarchar(200)        null,
   Proficiency          nvarchar(200)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_ITABILITY primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ITAbility') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ITAbility' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'IT技能爱好', 
   'user', @CurrentUser, 'table', 'ITAbility'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResumeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'ResumeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'ResumeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ability')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Ability'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Ability'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UseTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'UseTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'UseTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Proficiency')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Proficiency'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Proficiency'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ITAbility')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ITAbility', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_ResumeId_State                                  */
/*==============================================================*/
create index Index_ResumeId_State on ITAbility (
ResumeId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: InternshipExperience                                  */
/*==============================================================*/
create table InternshipExperience (
   Id                   nvarchar(36)         not null,
   ResumeId             nvarchar(36)         null,
   BeginDate            datetime             not null,
   EndDate              datetime             null,
   IsNow                char(1)              null default 'N',
   CompanyName          nvarchar(200)        not null,
   CompanyNature        nvarchar(200)        not null,
   CompanyScale         nvarchar(200)        not null,
   Job                  nvarchar(200)        null,
   JobType              nvarchar(200)        null,
   JobDescription       nvarchar(4000)       null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_INTERNSHIPEXPERIENCE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InternshipExperience') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InternshipExperience' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '实习经验', 
   'user', @CurrentUser, 'table', 'InternshipExperience'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResumeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'ResumeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'ResumeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsNow')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'IsNow'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'CheckBox',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'IsNow'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CompanyNature')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CompanyNature'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CompanyNature'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CompanyScale')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CompanyScale'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CompanyScale'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JobType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'JobType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'RadioButton',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'JobType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InternshipExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'InternshipExperience', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_ResumeId_State                                  */
/*==============================================================*/
create index Index_ResumeId_State on InternshipExperience (
ResumeId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: Invite                                                */
/*==============================================================*/
create table Invite (
   Id                   nvarchar(36)         not null default newid(),
   Code                 nvarchar(200)        null,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   constraint PK_INVITE primary key (Id)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Invite') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Invite' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '邀请码', 
   'user', @CurrentUser, 'table', 'Invite'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Invite')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Invite', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Invite', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Invite')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Invite', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Invite', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Invite')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Invite', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Invite', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Invite')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Invite', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Invite', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Invite')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Invite', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Invite', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Invite')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Invite', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Invite', 'column', 'UpdatePerson'
go

/*==============================================================*/
/* Table: LanguageCompetence                                    */
/*==============================================================*/
create table LanguageCompetence (
   Id                   nvarchar(36)         not null,
   ResumeId             nvarchar(36)         null,
   Language             nvarchar(200)        null,
   Level                nvarchar(200)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_LANGUAGECOMPETENCE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('LanguageCompetence') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'LanguageCompetence' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '语言能力', 
   'user', @CurrentUser, 'table', 'LanguageCompetence'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResumeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'ResumeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'ResumeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Language')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Language'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Language'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Level')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Level'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Level'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LanguageCompetence')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'LanguageCompetence', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_ResumeId_State                                  */
/*==============================================================*/
create index Index_ResumeId_State on LanguageCompetence (
ResumeId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: ProjectExperience                                     */
/*==============================================================*/
create table ProjectExperience (
   Id                   nvarchar(36)         not null,
   ResumeId             nvarchar(36)         null,
   BeginDate            datetime             not null,
   EndDate              datetime             null,
   IsNow                char(1)              null default 'N',
   ProjectName          nvarchar(200)        not null,
   Job                  nvarchar(200)        null,
   ProjectDescription   nvarchar(4000)       null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_PROJECTEXPERIENCE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ProjectExperience') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ProjectExperience' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '项目经验', 
   'user', @CurrentUser, 'table', 'ProjectExperience'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResumeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'ResumeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'ResumeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsNow')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'IsNow'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'CheckBox',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'IsNow'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ProjectExperience')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'ProjectExperience', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_ResumeId_State                                  */
/*==============================================================*/
create index Index_ResumeId_State on ProjectExperience (
ResumeId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: Resume                                                */
/*==============================================================*/
create table Resume (
   Id                   nvarchar(36)         not null,
   AccountId            nvarchar(36)         null,
   Name                 nvarchar(50)         null,
   CompletionPercentage int                  null,
   Remark               nvarchar(400)        null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_RESUME primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'AccountId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'AccountId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Resume')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Resume', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'Resume', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_AccountId_State                                 */
/*==============================================================*/
create index Index_AccountId_State on Resume (
AccountId ASC,
State ASC
)
go

/*==============================================================*/
/* Table: SysException                                          */
/*==============================================================*/
create table SysException (
   Id                   nvarchar(36)         not null,
   LeiXing              nvarchar(200)        null,
   Message              nvarchar(4000)       null,
   Result               nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_SYSEXCEPTION primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysException') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysException' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '异常处理', 
   'user', @CurrentUser, 'table', 'SysException'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysException')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysException', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysException', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_CreateTime                                      */
/*==============================================================*/
create index Index_CreateTime on SysException (
CreateTime DESC
)
go

/*==============================================================*/
/* Table: SysField                                              */
/*==============================================================*/
create table SysField (
   Id                   nvarchar(36)         not null,
   ParentId             nvarchar(36)         null default '0',
   MyTexts              nvarchar(200)        not null,
   MyTables             nvarchar(200)        null,
   MyColums             nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_SYSFIELD primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysField') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysField' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '数据字典', 
   'user', @CurrentUser, 'table', 'SysField'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ParentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'ParentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父节点',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'ParentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysField')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysField', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysField', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_MyColums_MyTables                               */
/*==============================================================*/
create index Index_MyColums_MyTables on SysField (
MyColums ASC,
MyTables ASC
)
go

/*==============================================================*/
/* Table: SysLog                                                */
/*==============================================================*/
create table SysLog (
   Id                   nvarchar(36)         not null,
   PersonId             nvarchar(36)         null,
   Message              nvarchar(4000)       null,
   Result               nvarchar(200)        null,
   MenuId               nvarchar(36)         null,
   Ip                   nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_SYSLOG primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '日志', 
   'user', @CurrentUser, 'table', 'SysLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysLog', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_CreateTime_PersonId                             */
/*==============================================================*/
create index Index_CreateTime_PersonId on SysLog (
CreateTime DESC,
PersonId ASC
)
go

/*==============================================================*/
/* Table: SysNotice                                             */
/*==============================================================*/
create table SysNotice (
   Id                   nvarchar(36)         not null,
   AccountId            nvarchar(36)         null,
   Message              nvarchar(4000)       null,
   LostTime             datetime             null,
   Remark               nvarchar(4000)       null,
   Sort                 int                  null default 0,
   State                varchar(200)         null default '启用',
   CreateTime           datetime             null default getdate(),
   CreatePerson         varchar(200)         null,
   UpdateTime           datetime             null default getdate(),
   UpdatePerson         varchar(200)         null,
   Version              timestamp            null,
   constraint PK_SYSNOTICE primary key nonclustered (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysNotice') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysNotice' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '通知中心', 
   'user', @CurrentUser, 'table', 'SysNotice'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'AccountId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Equal',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'AccountId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'CreatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'CreatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdatePerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'UpdatePerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'UpdatePerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SysNotice')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'Version'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NotDisplay',
   'user', @CurrentUser, 'table', 'SysNotice', 'column', 'Version'
go

/*==============================================================*/
/* Index: Index_AccountId_State                                 */
/*==============================================================*/
create index Index_AccountId_State on SysNotice (
AccountId ASC,
State ASC
)
go

alter table Comment
   add constraint FK_COMMENT_REFERENCE_BLOG foreign key (BlogId)
      references Blog (Id)
go

alter table DegreeSchool
   add constraint FK_DEGREESC_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go

alter table FileUploader
   add constraint FK_FILEUPLO_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go

alter table ITAbility
   add constraint FK_ITABILIT_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go

alter table InternshipExperience
   add constraint FK_INTERNSH_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go

alter table LanguageCompetence
   add constraint FK_LANGUAGE_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go

alter table ProjectExperience
   add constraint FK_PROJECTE_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go

