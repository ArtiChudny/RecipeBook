using System.Runtime.Serialization;

namespace RecipeBook.Service.Data.ModelsDto
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }
}
