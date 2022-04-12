namespace VaccinationSystem.Data
{
    public static class Roles
    {
        public static class Admin
        {
            public const int Id = -1;
            public const string Name = "Administrator";
        }
        public static class Doctor
        {
            public const int Id = -2;
            public const string Name = "Doctor";
        }
        public static class Patient
        {
            public const int Id = -3;
            public const string Name = "Patient";
        }
    }
}
