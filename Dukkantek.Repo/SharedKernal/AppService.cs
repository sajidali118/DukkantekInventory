namespace Dukkantek.Repo.SharedKernal
{
    public abstract class AppService
    {
        public virtual bool IsPermissionGranted(string permissionName)
        {
            ///implementation for check if current user Has Specified Permission
            return true;
        }
        public virtual bool IsRoleGranted(string roleName)
        {
            ///implementation for check if current user Has Specified Permission
            return true;
        }
    }
}
