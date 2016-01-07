namespace Connect.Shared
{
    using System.Collections.Generic;

    public static class ConnectRoles
    {
        public const string Admin = "Administrator";
        public const string TachographCentre = "TachographCentre";

        public static string[] AllExceptAdmin
        {
            get { return new[] {TachographCentre}; }
        }

        public static string[] All
        {
            get { return new[] {Admin, TachographCentre}; }
        }

        public static string[] GetHigherRoles(string startingRole)
        {
            var roles = new List<string>();

            switch (startingRole)
            {
                case Admin:
                    roles.AddRange(new[] {TachographCentre});
                    break;
            }

            return roles.ToArray();
        }
    }
}