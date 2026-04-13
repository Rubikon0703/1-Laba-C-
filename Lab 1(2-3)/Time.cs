namespace nickEnv
{
    internal class Time
    {
        private byte _hours;
        private byte _minutes;

        public Time()
        {
            _hours = 0;
            _minutes = 0;
        }

        public Time(byte hours, byte minutes)
        {
            _hours = hours;
            _minutes = minutes;
            Normalize();
        }

        public Time(Time obj)
        {
            _hours = obj._hours;
            _minutes = obj._minutes;
        }

        public byte Hours
        {
            get => _hours;
            set { _hours = value; Normalize(); }
        }

        public byte Minutes
        {
            get => _minutes;
            set { _minutes = value; Normalize(); }
        }

        private void Normalize()
        {
            int total = _hours * 60 + _minutes;
            total %= 24 * 60;
            if (total < 0) total += 24 * 60;
            _hours = (byte)(total / 60);
            _minutes = (byte)(total % 60);
        }

        public Time AddMinutes(uint minutes)
        {
            int total = _hours * 60 + _minutes + (int)minutes;
            total %= 24 * 60;
            if (total < 0) total += 24 * 60;
            return new Time((byte)(total / 60), (byte)(total % 60));
        }

        public static Time operator ++(Time t)
        {
            return new Time(t._hours, (byte)(t._minutes + 1));
        }

        public static Time operator --(Time t)
        {
            return new Time(t._hours, (byte)(t._minutes - 1));
        }

        public static explicit operator byte(Time t)
        {
            return t._hours;
        }
        public static implicit operator bool(Time t)
        {
            return  t._hours != 0 || t._minutes != 0;
        }
        public static Time operator + (Time t, uint minutes)
        {
            return t.AddMinutes(minutes);
        } 
        public static Time operator + (uint minutes, Time t)
        {
            return t.AddMinutes(minutes);
        }
        public static Time operator -(Time t, uint minutes)
        {
            return t.AddMinutes((uint)-(int)minutes);
        }
        public static Time operator -(uint minutes, Time t)
        {
            int total = (int)minutes - (t._hours * 60 + t._minutes);
            total %= 24 * 60;
            if (total < 0) total += 24 * 60;
            return new Time((byte)(total / 60), (byte)(total % 60));
        }

        public override string ToString()
        {
            return $"{_hours:D2}:{_minutes:D2}";
        }
    }
}