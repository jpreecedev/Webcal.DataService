namespace Connect.Shared
{
    using System.Collections.Generic;

    public static class ConnectRoles
    {
        public const string Admin = "Administrator";
        public const string TachographCentre = "TachographCentre";
        public const string Operator = "Operator";

        public static string[] AllExceptAdmin
        {
            get { return new[] {TachographCentre, Operator}; }
        }

        public static string[] All
        {
            get { return new[] {Admin, TachographCentre, Operator}; }
        }

        public static string[] GetHigherRoles(string startingRole)
        {
            var roles = new List<string>();

            switch (startingRole)
            {
                case Admin:
                    roles.AddRange(new[] {TachographCentre, Operator});
                    break;

                case TachographCentre:
                    roles.Add(Operator);
                    break;
            }

            return roles.ToArray();
        }
    }
}