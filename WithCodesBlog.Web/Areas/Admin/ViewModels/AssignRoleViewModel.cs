namespace WithCodesBlog.Web.UI.Areas.Admin.ViewModels
{
    public class AssignRoleViewModel
    {
        public int RoleId { get; set; }
        public int AppUserId { get; set; }
        public string RoleName { get; set; }
        public bool Exists { get; set; }
    }
}
