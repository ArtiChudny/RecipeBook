using System.Runtime.Serialization;

namespace RecipeBook.Service.Data.ModelsDto
{
    [DataContract]
    public class RecipeDto
    {
        [DataMember]
        public int RecipeId { get; set; }
        [DataMember]
        public string RecipeName { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public RecipeDetailsDto Details { get; set; }
    }
}
