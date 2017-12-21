using System.Runtime.Serialization;

namespace RecipeBook.Service.Data.ModelsDto
{
    [DataContract]
    public class IngredientDto
    {
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        public string IngredientName { get; set; }
    }
}
