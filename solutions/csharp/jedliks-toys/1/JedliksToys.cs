class RemoteControlCar
{
    private int _distance;
    private int _batteryPercent = 100;   
    
    public static RemoteControlCar Buy()
    {
       return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {           
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        if(_batteryPercent == 0) 
            return $"Battery empty";
        return $"Battery at {_batteryPercent}%";
    }

    public void Drive()
    {        
        const int distanceDriving = 20;
        const int decreaseBattery = 1;

        if(_batteryPercent > 0) {
            _distance += distanceDriving;
            _batteryPercent -= decreaseBattery;            
        }
    }
}
