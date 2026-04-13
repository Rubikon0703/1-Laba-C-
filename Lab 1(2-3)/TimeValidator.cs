namespace nickEnv
{
    internal static class TimeValidator
    {
        public static bool ValidateHours(byte hours, out string error)
        {
            if (hours > 23)
            {
                error = "Ошибка: часы должны быть в диапазоне 0-23";
                return false;
            }
            error = "";
            return true;
        }

        public static bool ValidateHours(string input, out byte hours, out string error)
        {
            hours = 0;
            error = "";
            if (!byte.TryParse(input, out hours))
            {
                error = "Ошибка: введите целое число для часов";
                return false;
            }
            return ValidateHours(hours, out error);
        }

        public static bool ValidateMinutes(byte minutes, out string error)
        {
            if (minutes > 59)
            {
                error = "Ошибка: минуты должны быть в диапазоне 0-59";
                return false;
            }
            error = "";
            return true;
        }

        public static bool ValidateMinutes(string input, out byte minutes, out string error)
        {
            minutes = 0;
            error = "";
            if (!byte.TryParse(input, out minutes))
            {
                error = "Ошибка: введите целое число для минут";
                return false;
            }
            return ValidateMinutes(minutes, out error);
        }
    }
}