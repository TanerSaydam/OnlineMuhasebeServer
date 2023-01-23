using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Domain.Roles;

public sealed class RoleList
{
    public static List<AppRole> GetStaticRoles()
    {
        List<AppRole> appRoles= new List<AppRole>
        {
            #region UCAF
            new AppRole(
            title: UCAF,
            code: UCAFCreateCode,
            name: UCAFCreateName),

            new AppRole(
            title: UCAF,
            code: UCAFUpdateCode,
            name: UCAFUpdateName),

            new AppRole(
            title: UCAF,
            code: UCAFRemoveCode,
            name: UCAFRemoveName),

            new AppRole(
            title: UCAF,
            code: UCAFReadCode,
            name: UCAFReadName),
	        #endregion            
        };             

        return appRoles;
    }

    public static List<MainRole> GetStaticMainRoles()
    {
        List<MainRole> mainRoles = new List<MainRole>
        {
            new MainRole(
                Guid.NewGuid().ToString(),
                "Admin",
                true),
            new MainRole(
                Guid.NewGuid().ToString(),
                "Yönetici",
                true),
            new MainRole(
                Guid.NewGuid().ToString(),
                "Kullanıcı",
                true),
        };
        return mainRoles;
    }

    #region RoleTitleNames
    public static string UCAF = "Hesap Planı";
    #endregion

    #region RoleCodeAndNames
    public static string UCAFCreateCode = "UCAF.Create";
    public static string UCAFCreateName = "Hesap Planı Kayıt";

    public static string UCAFUpdateCode = "UCAF.Update";
    public static string UCAFUpdateName = "Hesap Planı Güncelle";

    public static string UCAFRemoveCode = "UCAF.Remove";
    public static string UCAFRemoveName = "Hesap Planı Sil";

    public static string UCAFReadCode = "UCAF.Read";
    public static string UCAFReadName = "Hesap Planı Görüntüle";
    #endregion
}
