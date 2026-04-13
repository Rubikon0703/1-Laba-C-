namespace nickEnv
{
    internal class Password : Word
    {
        private int _failedAttempts;

        public Password() : base()
        {
            this._failedAttempts = 0;
        }

        public Password(string password, int failedAttempts) : base(password)
        {
            this._failedAttempts = failedAttempts;
        }

        public Password(Password obj) : base(obj.Text)
        {
            this._failedAttempts = obj._failedAttempts;
        }

        public int FailedAttempts
        {
            get { return this._failedAttempts; }
        }

       
        public string CheckStrength()
        {
            if (string.IsNullOrEmpty(this.Text))
                return "Очень слабый";

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in this.Text)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
            }

            if (this.Text.Length >= 8 && hasUpper && hasLower && hasDigit)
                return "Сильный";
            if (this.Text.Length >= 6 && (hasUpper || hasLower) && hasDigit)
                return "Средний";
            return "Слабый";
        }

    
        public void SetPassword(string newPassword, int failedAttempts)
        {
            this.Text = newPassword;
            this._failedAttempts = failedAttempts;
        }

      
        public void Mask()
        {
            if (string.IsNullOrEmpty(this.Text)) return;
            string masked = "";
            for (int i = 0; i < this.Text.Length; i++)
            {
                masked = masked + "*";
            }
            Console.WriteLine("Маскированный пароль: " + masked);
        }

        public void Verify(string inputPassword)
        {
            if (this.Text == inputPassword)
            {
                Console.WriteLine("Пароль верный!");
                this._failedAttempts = 0;
            }
            else
            {
                this._failedAttempts++;
                Console.WriteLine("Неверный пароль! Неудачных попыток: " + this._failedAttempts);
            }
        }

        public static void CompareStrength(Password p1, Password p2)
        {
            string s1 = p1.CheckStrength();
            string s2 = p2.CheckStrength();

            int r1 = 0;
            int r2 = 0;

            if (s1 == "Сильный") r1 = 3;
            if (s1 == "Средний") r1 = 2;
            if (s1 == "Слабый") r1 = 1;
            if (s1 == "Очень слабый") r1 = 0;

            if (s2 == "Сильный") r2 = 3;
            if (s2 == "Средний") r2 = 2;
            if (s2 == "Слабый") r2 = 1;
            if (s2 == "Очень слабый") r2 = 0;

            if (r1 > r2)
                Console.WriteLine("Первый пароль сильнее (" + s1 + " > " + s2 + ")");
            else if (r1 < r2)
                Console.WriteLine("Второй пароль сильнее (" + s2 + " > " + s1 + ")");
            else
                Console.WriteLine("Пароли одинаковой сложности (" + s1 + ")");
        }

        public override string ToString()
        {
            return "Пароль = [СКРЫТ], сложность = " + CheckStrength() + ", неудачных попыток = " + this._failedAttempts;
        }
    }
}