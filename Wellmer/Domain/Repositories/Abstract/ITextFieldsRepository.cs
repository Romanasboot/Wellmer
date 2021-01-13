using System;
using System.Linq;
using Wellmer.Domain.Entities;

namespace Wellmer.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository          //Puslapiu CRUD operacijos
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldbyId(Guid id);
        TextField GetTextFieldbyCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id); 
    }
}
