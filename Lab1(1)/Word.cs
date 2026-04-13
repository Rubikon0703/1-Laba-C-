namespace nickEnv
{
    internal class Word
    {
        private string _text;

        public Word()
        {
            this._text = "";
        }

        public Word(string text)
        {
            this._text = text;
        }

        public Word(Word obj)
        {
            this._text = obj._text;
        }

        public string Text
        {
            get { return this._text; }
            set { this._text = value; }
        }

        public string FirstLast()
        {
            if (string.IsNullOrEmpty(this._text))
                return "";
            return this._text[0].ToString() + this._text[this._text.Length - 1].ToString();
        }

        public override string ToString()
        {
            return "Строка = " + this._text;
        }
    }
}