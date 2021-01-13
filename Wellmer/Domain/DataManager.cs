using Wellmer.Domain.Repositories.Abstract;

namespace Wellmer.Domain
{
    public class DataManager    //Pagalbine klase darbui su DB
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
        }

    }
}
