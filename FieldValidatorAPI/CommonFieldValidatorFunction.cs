using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthReqDel(string fieldVal, int min, int max);
    public delegate bool DateValDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompairFieldValDel(string fieldVal, string fieldValCompare);
    public class CommonFieldValidatorFunction
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthReqDel _stringLengthReqDel = null;
        private static DateValDel _dateValDel = null;
        private static PatternMatchDel _patternMatchDel = null;
        private static CompairFieldValDel _compairfieldValDel = null;

        public static RequiredValidDel requiredValidDel
        {
            get
            { 
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(requiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthReqDel stringLengthReqDel
        {
            get
            {
                if (_stringLengthReqDel == null)
                    _stringLengthReqDel = new StringLengthReqDel(StringLengthValid);

                return _stringLengthReqDel;
            }
        }

        public static DateValDel dateFieldValid
        {
            get
            {
                if (_dateValDel == null)
                    _dateValDel = new DateValDel(DateFieldValid);

                return _dateValDel;
            }
        }

        public static PatternMatchDel patternMatchDel
        {
            get
            {
                if (_patternMatchDel == null)
                    _patternMatchDel = new PatternMatchDel(PatternMatchValid);

                return _patternMatchDel;
            }
        }

        public static CompairFieldValDel compairFieldValDel
        {
            get
            {
                if (_compairfieldValDel == null)
                    _compairfieldValDel = new CompairFieldValDel(CompairFieldValidator);

                return _compairfieldValDel;
            }
        }

        private static bool requiredFieldValid(string fieldVal)
        {
            if (string.IsNullOrEmpty(fieldVal))
                return false;

            return true;
        }

        private static bool StringLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;

            return false;
        }

        private static bool DateFieldValid(string dateTime, out DateTime validDate)
        {
            if (DateTime.TryParse(dateTime, out validDate))
                return true;

            return false;
        }

        private static bool PatternMatchValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            if (regex.IsMatch(fieldVal))
                return true;
            return false;
        }

        private static bool CompairFieldValidator(string fieldVal, string fieldValCompare)
        { 
            if(fieldVal.Equals(fieldValCompare)) 
                return true;
            return false;
        }

    }
}
