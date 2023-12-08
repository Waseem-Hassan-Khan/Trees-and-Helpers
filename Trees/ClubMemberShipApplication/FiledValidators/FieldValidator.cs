using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Trees.ClubMemberShipApplication.FiledValidators.FieldConstants;

namespace Trees.ClubMemberShipApplication.FiledValidators
{
    public class FieldValidator : IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 50;
        const int LasttName_Min_Length = 2;
        const int LastName_Max_Length = 50;
        delegate bool EmailExistInSystem(string email);

        FieldValidatorDel _fieldValidatorDel = null;
        
        RequiredValidDel _requiredValidDel = null;
        StringLengthReqDel _stringLengthReqDel = null;
        DateValDel _dateValDel = null;
        PatternMatchDel _patternMatchDel = null;
        CompairFieldValDel _compairfieldValDel = null;

        EmailExistInSystem _emailExistInSystem = null;
        string[] _fieldArray = null;

        public string[] FiledArray { get
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                return _fieldArray;
            } }

        public FieldValidatorDel fieldValidatorDel => _fieldValidatorDel;

        public string[] fieldArray => throw new NotImplementedException();

        public void initialiseValidatorDelegate()
        {
            _requiredValidDel = CommonFieldValidatorFunction.requiredValidDel;
            _stringLengthReqDel = CommonFieldValidatorFunction.stringLengthReqDel;
            _dateValDel = CommonFieldValidatorFunction.dateFieldValid;
            _patternMatchDel = CommonFieldValidatorFunction.patternMatchDel;
            _compairfieldValDel = CommonFieldValidatorFunction.compairFieldValDel;
        }

        private bool validField(int fieldIndex,string fieldValue,string[] fieldArray, out string fieldInvalidMessage) 
        {
            fieldInvalidMessage = "";

            FieldConstants.UserRegistrationField userRegField = (FieldConstants.UserRegistrationField)fieldIndex;
            switch (userRegField) {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage =
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: " +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField),
                        userRegField)}{Environment.NewLine}" : "";

                    fieldInvalidMessage = 
                        (fieldInvalidMessage==""&& !_patternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns
                        .Email_Address_RegEx_Pattern))? $"You must enter a valid email address {Environment.NewLine}" : 
                        fieldInvalidMessage;

                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistInSystem(fieldValue))
                        ? $"The email address is already registered {Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";

                    fieldInvalidMessage = 
                        (fieldInvalidMessage == "" && !_stringLengthReqDel
                        (fieldValue, LasttName_Min_Length, LastName_Max_Length)) ? $"The length for field: " +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $" must be between {LastName_Max_Length} and {LastName_Max_Length}{Environment.NewLine}"
                        : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";

                    fieldInvalidMessage = 
                        (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue,
                        CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern))
                        ? $"Your password must contain at least 1 small-case letter, 1 capital letter," +
                        $" 1 special character and the length should be between 6 - 10 characters" +
                        $"{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.PasswordCompaired:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";

                    fieldInvalidMessage = 
                        (fieldInvalidMessage == "" && !_compairfieldValDel(fieldValue, fieldArray[(int)
                        FieldConstants.UserRegistrationField.Password])) ? $"Your entry did not match " +
                        $"your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) 
                        ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField),
                        userRegField)}{Environment.NewLine}" : "";

                    fieldInvalidMessage = 
                        (fieldInvalidMessage == "" && !_dateValDel(fieldValue, out DateTime validDateTime))
                        ? $"You did not enter a valid date" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}{Environment.NewLine}"
                        : "";
                    fieldInvalidMessage = 
                        (fieldInvalidMessage == "" && !_patternMatchDel
                        (fieldValue, CommonRegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern)) 
                        ? $"You did not enter a valid UK phone number{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";
                    break;

                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";
                    break;

                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";
                    break;

                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = 
                        (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:" +
                        $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegField)}" +
                        $"{Environment.NewLine}" : "";

                    fieldInvalidMessage = 
                        (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue, 
                        CommonRegularExpressionValidationPatterns.Uk_Post_Code_RegEx_Pattern)) 
                        ? $"You did not enter a valid UK post code{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                default:
                    throw new ArgumentException("This field does not exists");

            }


            return (fieldInvalidMessage == "");
        }
    }
}
