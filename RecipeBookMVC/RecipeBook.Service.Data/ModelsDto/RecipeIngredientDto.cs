using System.Runtime.Serialization;

namespace RecipeBook.Service.Data.ModelsDto
{
    [DataContract]
    public class RecipeIngredientDto
    {
        [DataMember]
        public int RecipeId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        public string IngredientName { get; set; }
        [DataMember]
        public string Weight { get; set; }
    }
}
