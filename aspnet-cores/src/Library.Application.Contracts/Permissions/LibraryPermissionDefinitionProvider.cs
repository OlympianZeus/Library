using Library.Localization;
//using Library.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Library.Permissions;

public class LibraryPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var LibraryGroup = context.AddGroup(LibraryPermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = LibraryGroup.AddPermission(LibraryPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(LibraryPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(LibraryPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(LibraryPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = LibraryGroup.AddPermission(
            LibraryPermissions.Authors.Default, L("Permission: Authors"));
        authorsPermission.AddChild(LibraryPermissions.Authors.Create, L("Permission: Authors.Create"));
        authorsPermission.AddChild(LibraryPermissions.Authors.Edit, L("Permission: Authors.Edit"));
        authorsPermission.AddChild(LibraryPermissions.Authors.Delete, L("Permission: Authors.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LibraryResource>(name);
    }
}
