|-- Liuliu.Blogs
    |-- build.bat
    |-- Dockerfile
    |-- LICENSE
    |-- Liuliu.Blogs.sln
    |-- Liuliu.Blogs.sln.DotSettings.user
    |-- README.md
    |-- src
        |-- Liuliu.Blogs.Core
        |   |-- Liuliu.Blogs.Core.csproj
        |   |-- Common
        |   |   |-- CommonService.cs
        |   |   |-- ICommonContract.cs
        |   |   |-- Dtos
        |   |       |-- ListNode.cs
        |   |       |-- TreeNode.cs
        |   |-- Identity
        |   |   |-- IdentityPack.cs
        |   |   |-- IdentityService.cs
        |   |   |-- IdentityService.UserLogin.cs
        |   |   |-- IdentityService.UserRole.cs
        |   |   |-- IIdentityContract.cs
        |   |   |-- RoleStore.cs
        |   |   |-- UserStore.cs
        |   |   |-- Dtos
        |   |   |   |-- AutoMapperConfiguration.cs
        |   |   |   |-- ChangePasswordDto.cs
        |   |   |   |-- ConfirmEmailDto.cs
        |   |   |   |-- LoginDto.cs
        |   |   |   |-- ProfileEditDto.cs
        |   |   |   |-- RegisterDto.cs
        |   |   |   |-- ResetPasswordDto.cs
        |   |   |   |-- RoleInputDto.cs
        |   |   |   |-- RoleNode.cs
        |   |   |   |-- RoleOutputDto.cs
        |   |   |   |-- RoleOutputDto2.cs
        |   |   |   |-- SendMailDto.cs
        |   |   |   |-- UserInputDto.cs
        |   |   |   |-- UserLoginOutputDto.cs
        |   |   |   |-- UserOutputDto.cs
        |   |   |   |-- UserOutputDto2.cs
        |   |   |   |-- UserRoleInputDto.cs
        |   |   |   |-- UserRoleNode.cs
        |   |   |   |-- UserRoleOutputDto.cs
        |   |   |-- Entities
        |   |   |   |-- LoginLog.cs
        |   |   |   |-- Organization.cs
        |   |   |   |-- Role.cs
        |   |   |   |-- RoleClaim.cs
        |   |   |   |-- User.cs
        |   |   |   |-- UserClaim.cs
        |   |   |   |-- UserDetail.cs
        |   |   |   |-- UserLogin.cs
        |   |   |   |-- UserRole.cs
        |   |   |   |-- UserToken.cs
        |   |   |-- Events
        |   |       |-- LoginEventData.cs
        |   |       |-- Login_LoginLogEventHandler.cs
        |   |       |-- LogoutEventData.cs
        |   |       |-- Logout_LoginLogEventHandler.cs
        |   |       |-- RegisterEventData.cs
        |   |-- Security
        |   |   |-- DataAuthCache.cs
        |   |   |-- FunctionAuthCache.cs
        |   |   |-- ModuleHandler.cs
        |   |   |-- SecurityManager.cs
        |   |   |-- SecurityPack.cs
        |   |   |-- Dtos
        |   |   |   |-- AutoMapperConfiguration.cs
        |   |   |   |-- EntityInfoNode.cs
        |   |   |   |-- EntityInfoOutputDto.cs
        |   |   |   |-- EntityRoleInputDto.cs
        |   |   |   |-- EntityRoleOutputDto.cs
        |   |   |   |-- FunctionOutputDto.cs
        |   |   |   |-- FunctionOutputDto2.cs
        |   |   |   |-- ModuleInputDto.cs
        |   |   |   |-- ModuleOutputDto.cs
        |   |   |   |-- ModuleSetFunctionDto.cs
        |   |   |   |-- RoleSetModuleDto.cs
        |   |   |   |-- UserSetModuleDto.cs
        |   |   |   |-- UserSetRoleDto.cs
        |   |   |-- Entities
        |   |       |-- EntityRole.cs
        |   |       |-- EntityUser.cs
        |   |       |-- Module.cs
        |   |       |-- ModuleFunction.cs
        |   |       |-- ModuleRole.cs
        |   |       |-- ModuleUser.cs
        |   |-- Systems
        |       |-- AuditDatabaseStore.cs
        |       |-- AuditPack.cs
        |       |-- AuditService.cs
        |       |-- IAuditContract.cs
        |       |-- ISystemsContract.cs
        |       |-- SystemsService.cs
        |       |-- Dtos
        |       |   |-- AuditEntityOutputDto.cs
        |       |   |-- AuditOperationOutputDto.cs
        |       |   |-- AuditPropertyOutputDto.cs
        |       |   |-- GenerateCodeInputDto.cs
        |       |   |-- PackOutputDto.cs
        |       |   |-- SystemSetting.cs
        |       |-- Entities
        |           |-- AuditEntity.cs
        |           |-- AuditOperation.cs
        |           |-- AuditProperty.cs
        |-- Liuliu.Blogs.EntityConfiguration
        |   |-- Liuliu.Blogs.EntityConfiguration.csproj
        |   |-- Identity
        |   |   |-- LoginLogConfiguration.cs
        |   |   |-- OrganizationConfiguration.cs
        |   |   |-- RoleClaimConfiguration.cs
        |   |   |-- RoleConfiguration.cs
        |   |   |-- UserClaimConfiguration.cs
        |   |   |-- UserConfiguration.cs
        |   |   |-- UserDetailConfiguration.cs
        |   |   |-- UserLoginConfiguration.cs
        |   |   |-- UserRoleConfiguration.cs
        |   |   |-- UserTokenConfiguration.cs
        |   |-- Security
        |   |   |-- EntityRoleConfiguration.cs
        |   |   |-- EntityUserConfiguration.cs
        |   |   |-- ModuleConfiguration.cs
        |   |   |-- ModuleFunctionConfiguration.cs
        |   |   |-- ModuleRoleConfiguration.cs
        |   |   |-- ModuleUserConfiguration.cs
        |   |-- Systems
        |       |-- AuditEntityConfiguration.cs
        |       |-- AuditOperationConfiguration.cs
        |       |-- AuditPropertyConfiguration.cs
        |       |-- KeyValueConfiguration.cs
        |-- Liuliu.Blogs.Web
        |   |-- appsettings.Development.json
        |   |-- appsettings.json
        |   |-- Dockerfile
        |   |-- Liuliu.Blogs.Web.csproj
        |   |-- log4net.config
        |   |-- Program.cs
        |   |-- Startup.cs
        |   |-- Areas
        |   |   |-- Admin
        |   |       |-- Controllers
        |   |           |-- AdminApiController.cs
        |   |           |-- DashboardController.cs
        |   |           |-- HomeController.cs
        |   |           |-- Identity
        |   |           |   |-- RoleController.cs
        |   |           |   |-- UserController.cs
        |   |           |   |-- UserRoleController.cs
        |   |           |-- Security
        |   |           |   |-- EntityInfoController.cs
        |   |           |   |-- FunctionController.cs
        |   |           |   |-- ModuleController.cs
        |   |           |   |-- RoleEntityController.cs
        |   |           |   |-- RoleFunctionController.cs
        |   |           |   |-- UserFunctionController.cs
        |   |           |-- Systems
        |   |               |-- AuditEntityController.cs
        |   |               |-- AuditOperationController.cs
        |   |               |-- PackController.cs
        |   |               |-- SettingsController.cs
        |   |-- Controllers
        |   |   |-- CommonController.cs
        |   |   |-- IdentityController.cs
        |   |   |-- SecurityController.cs
        |   |   |-- Test2Controller.cs
        |   |   |-- TestController.cs
        |   |-- Hangfire
        |   |   |-- HangfireJobRunner.cs
        |   |-- Migrations
        |   |   |-- 20190430130752_Init.cs
        |   |   |-- 20190430130752_Init.Designer.cs
        |   |   |-- DefaultDbContextModelSnapshot.cs
        |   |-- Properties
        |   |   |-- launchSettings.json
        |   |   |-- PublishProfiles
        |   |       |-- FolderProfile.pubxml
        |   |-- Startups
        |       |-- AspNetCoreMvcPack.cs
        |       |-- CodeGeneratorPack.cs
        |       |-- MySqlDefaultDbContextMigrationPack.cs
        |       |-- MySqlDesignTimeDefaultDbContextFactory.cs
        |       |-- OracleDefaultDbContextMigrationPack.cs
        |       |-- OracleDesignTimeDefaultDbContextFactory.cs
        |       |-- PostgreSqlDefaultDbContextMigrationPack.cs
        |       |-- PostgreSqlDesignTimeDefaultDbContextFactory.cs
        |       |-- SignalrPack.cs
        |       |-- SqliteDefaultDbContextMigrationPack.cs
        |       |-- SqliteDesignTimeDefaultDbContextFactory.cs
        |       |-- SqlServerDefaultDbContextMigrationPack.cs
        |       |-- SqlServerDesignTimeDefaultDbContextFactory.cs
