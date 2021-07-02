namespace AdvancedImobiliaria.Services.Factories
{
    public static class UserRoleFactory
    {
        public static string Role(int roleNumber)
        {
            switch(roleNumber)
            {
                case 0:
                    return "Admin";
                
                case 1:
                    return "Employee";

                case 2:
                    return "Client";

                default:
                    throw new System.Exception();
            }
        }
    }
}