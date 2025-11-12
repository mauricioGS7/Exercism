class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision {get;}    
    // TODO: define the 'Weight' property
    private double weight;
    public double Weight {
        get => weight; 
        set{
            if(value < 0)
                throw new ArgumentOutOfRangeException("Throws an ArgumentOutOfRangeException");
            weight = value;
        }
    } 
    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight {
        get{
            double adjustedWeight = Weight - TareAdjustment;
            return $"{adjustedWeight.ToString($"F{Precision}")} kg";
        }
    }
    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment {get; set;} = 5;

    public WeighingMachine (int precision){
        Precision = precision;
    }
}
