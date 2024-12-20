﻿namespace BookPlatform.Common
{
    public static class ErrorMessages
    {
        public static class Roles
        {
            public const string ErrorWhileCreatingRole = "Error occurred while creating the {0} role!";
            public const string ErrorWhileAddingUserToRole = "Error occurred while adding the user {0} to the {1} role!";
        }

        public static class Services
        {
            public const string ErrorTryingToObtainService = "Service for {0} cannot be obtained!";
        }

        public static class UserCreation
        {
            public const string ErrorWhileRegisteringUser = "Error occurred while registering {0} user!";
        }
    }
}
