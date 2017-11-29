using System.Runtime.Serialization;

namespace RecipeBook.Service.Data.ModelsDto
{
    [DataContract]
    public class RecipeDetailsDto
    {
        [DataMember]
        public int RecipeId { get; set; }
        [DataMember]
        public string CookingTime { get; set; }
        [DataMember]
        public string CookingTemperature { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Steps { get; set; }
    }
}
