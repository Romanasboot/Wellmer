using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wellmer.Domain.Entities;
using Wellmer.Domain.Repositories.Abstract;

namespace Wellmer.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository     //Realizuojamas Puslapiu CRUD interfeisas, naudojant EF.
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public TextField GetTextFieldbyId(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextFieldbyCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}
