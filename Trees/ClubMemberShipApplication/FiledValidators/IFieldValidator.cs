using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.ClubMemberShipApplication.FiledValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
    public interface IFieldValidator
    {
        void initialiseValidatorDelegate();
        string[] fieldArray { get; }
        FieldValidatorDel fieldValidatorDel { get; }

    }
}
