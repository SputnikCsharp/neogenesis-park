public class Dinosaur
{
    private string dinoName { get; set; } // assigned name
    private string dinoLastName { get; set; } // specie
    private int dinoId { get; set; } // unique identifier of the specimen
    private string dinoRegisterKey { get; set; } // specie
    public Dinosaur(string dinoName, string dinoLastName, int dinoId, string dinoRegisterKey)
    {
        this.dinoName = dinoName;
        this.dinoLastName = dinoLastName;
        this.dinoId = dinoId;
        this.dinoRegisterKey = dinoRegisterKey;
    }
    
}