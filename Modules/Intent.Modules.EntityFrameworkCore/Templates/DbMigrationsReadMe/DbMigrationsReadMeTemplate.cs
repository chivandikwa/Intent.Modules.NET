// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.EntityFrameworkCore.Templates.DbMigrationsReadMe
{
    using Intent.Modules.Common.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class DbMigrationsReadMeTemplate : IntentTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("Create a new migration:\r\n--------------------------------------------------------" +
                    "--------------------------------------------------------------------------------" +
                    "---------------\r\nAdd-Migration -Name {ChangeName} -StartupProject \"");
            
            #line 6 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StartupProject));
            
            #line default
            #line hidden
            this.Write("\" -Project ");
            
            #line 6 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MigrationProject));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\r\nOverwrite an existing migration:\r\n-----------------------------------------" +
                    "--------------------------------------------------------------------------------" +
                    "------------------------------\r\nAdd-Migration -Name {ChangeName} -StartupProject" +
                    " \"");
            
            #line 11 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StartupProject));
            
            #line default
            #line hidden
            this.Write("\" -Project ");
            
            #line 11 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MigrationProject));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\r\nUpdate schema to the latest version:\r\n-------------------------------------" +
                    "--------------------------------------------------------------------------------" +
                    "----------------------------------\r\nUpdate-Database -StartupProject \"");
            
            #line 16 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StartupProject));
            
            #line default
            #line hidden
            this.Write("\" -Project ");
            
            #line 16 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MigrationProject));
            
            #line default
            #line hidden
            this.Write(@"


Upgrade/downgrade schema to specific version:
-------------------------------------------------------------------------------------------------------------------------------------------------------
Update-Database -Migration {Target} -StartupProject """);
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StartupProject));
            
            #line default
            #line hidden
            this.Write("\" -Project ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MigrationProject));
            
            #line default
            #line hidden
            this.Write(@"


Generate a script which detects the current database schema version and updates it to the latest:
-------------------------------------------------------------------------------------------------------------------------------------------------------
Script-Migration -SourceMigration:$InitialDatabase -Script -StartupProject """);
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StartupProject));
            
            #line default
            #line hidden
            this.Write("\" -Project ");
            
            #line 26 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MigrationProject));
            
            #line default
            #line hidden
            this.Write(@"


Generate a script which upgrades from and to a specific schema version:
-------------------------------------------------------------------------------------------------------------------------------------------------------
Script-Migration -SourceMigration:{Source} -TargetMigration:{Target} -Script -StartupProject """);
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StartupProject));
            
            #line default
            #line hidden
            this.Write("\" -Project ");
            
            #line 31 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MigrationProject));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\r\nDrop all tables in schema:\r\n-----------------------------------------------" +
                    "--------------------------------------------------------------------------------" +
                    "------------------------\r\nDECLARE @SCHEMA AS varchar(max) = \'");
            
            #line 36 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.EntityFrameworkCore\Templates\DbMigrationsReadMe\DbMigrationsReadMeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BoundedContextName));
            
            #line default
            #line hidden
            this.Write(@"'
DECLARE @EXECUTE_STATEMENT AS varchar(max) = (SELECT STUFF((SELECT CHAR(13) + CHAR(10) + [Statement] FROM (
    SELECT 'ALTER TABLE ['+@SCHEMA+'].['+[t].[name]+'] DROP CONSTRAINT ['+[fk].[name]+']' AS [Statement] FROM [sys].[foreign_keys] AS [fk] INNER JOIN [sys].[tables] AS [t] ON [t].[object_id] = [fk].[parent_object_id] INNER JOIN [sys].[schemas] AS [s] ON [s].[schema_id] = [t].[schema_id] WHERE [s].[name] = @SCHEMA
    UNION ALL
    SELECT 'DROP TABLE ['+@SCHEMA+'].['+[t].[name]+']' AS [Statement] FROM [sys].[tables] AS [t] INNER JOIN [sys].[schemas] AS [s] ON [s].[schema_id] = [t].[schema_id] WHERE [s].[name] = @SCHEMA
) A FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, ''))
EXECUTE(@EXECUTE_STATEMENT)
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
