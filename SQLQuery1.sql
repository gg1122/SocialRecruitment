if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DegreeSchool') and o.name = 'FK_DEGREESC_REFERENCE_RESUME')
alter table DegreeSchool
   drop constraint FK_DEGREESC_REFERENCE_RESUME
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

alter table DegreeSchool
   add constraint FK_DEGREESC_REFERENCE_RESUME foreign key (ResumeId)
      references Resume (Id)
go
