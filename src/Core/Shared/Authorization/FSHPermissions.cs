using System.Collections.ObjectModel;

namespace GAO.WebApi.Shared.Authorization;

public static class GAOAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class GAOResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
}

public static class GAOPermissions
{
    private static readonly GAOPermission[] _all = new GAOPermission[]
    {
        new("View Dashboard", GAOAction.View, GAOResource.Dashboard),
        new("View Hangfire", GAOAction.View, GAOResource.Hangfire),
        new("View Users", GAOAction.View, GAOResource.Users),
        new("Search Users", GAOAction.Search, GAOResource.Users),
        new("Create Users", GAOAction.Create, GAOResource.Users),
        new("Update Users", GAOAction.Update, GAOResource.Users),
        new("Delete Users", GAOAction.Delete, GAOResource.Users),
        new("Export Users", GAOAction.Export, GAOResource.Users),
        new("View UserRoles", GAOAction.View, GAOResource.UserRoles),
        new("Update UserRoles", GAOAction.Update, GAOResource.UserRoles),
        new("View Roles", GAOAction.View, GAOResource.Roles),
        new("Create Roles", GAOAction.Create, GAOResource.Roles),
        new("Update Roles", GAOAction.Update, GAOResource.Roles),
        new("Delete Roles", GAOAction.Delete, GAOResource.Roles),
        new("View RoleClaims", GAOAction.View, GAOResource.RoleClaims),
        new("Update RoleClaims", GAOAction.Update, GAOResource.RoleClaims),
        new("View Products", GAOAction.View, GAOResource.Products, IsBasic: true),
        new("Search Products", GAOAction.Search, GAOResource.Products, IsBasic: true),
        new("Create Products", GAOAction.Create, GAOResource.Products),
        new("Update Products", GAOAction.Update, GAOResource.Products),
        new("Delete Products", GAOAction.Delete, GAOResource.Products),
        new("Export Products", GAOAction.Export, GAOResource.Products),
        new("View Brands", GAOAction.View, GAOResource.Brands, IsBasic: true),
        new("Search Brands", GAOAction.Search, GAOResource.Brands, IsBasic: true),
        new("Create Brands", GAOAction.Create, GAOResource.Brands),
        new("Update Brands", GAOAction.Update, GAOResource.Brands),
        new("Delete Brands", GAOAction.Delete, GAOResource.Brands),
        new("Generate Brands", GAOAction.Generate, GAOResource.Brands),
        new("Clean Brands", GAOAction.Clean, GAOResource.Brands),
        new("View Tenants", GAOAction.View, GAOResource.Tenants, IsRoot: true),
        new("Create Tenants", GAOAction.Create, GAOResource.Tenants, IsRoot: true),
        new("Update Tenants", GAOAction.Update, GAOResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", GAOAction.UpgradeSubscription, GAOResource.Tenants, IsRoot: true)
    };

    public static IReadOnlyList<GAOPermission> All { get; } = new ReadOnlyCollection<GAOPermission>(_all);
    public static IReadOnlyList<GAOPermission> Root { get; } = new ReadOnlyCollection<GAOPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<GAOPermission> Admin { get; } = new ReadOnlyCollection<GAOPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<GAOPermission> Basic { get; } = new ReadOnlyCollection<GAOPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record GAOPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
