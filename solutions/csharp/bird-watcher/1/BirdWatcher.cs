class BirdCount
{
    private int[] birdsPerDay;
    private static int[] birdsLastWeek;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        birdsLastWeek = new int[] {0, 2, 5, 3, 7, 8, 4};
        return birdsLastWeek;
    }

    public int Today()
        => birdsPerDay.Length > 0 ? birdsPerDay[birdsPerDay.Length - 1] : 0;    

    public void IncrementTodaysCount()
    {
        if(birdsPerDay.Length > 0)
            birdsPerDay[birdsPerDay.Length -1]++;
    }

    public bool HasDayWithoutBirds()
    {
        bool hasDayWithoutBirds = false;
        for(int i=0; i<birdsPerDay.Length; i++){
            if(birdsPerDay[i] == 0){
                hasDayWithoutBirds = true;
            }
        }
        return hasDayWithoutBirds;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int countBirdsForFirstDays = 0;
        for(int i=0; i<numberOfDays; i++){
            countBirdsForFirstDays += birdsPerDay[i];
        }
        return countBirdsForFirstDays;    
    }

    public int BusyDays()
    {
        int countBusyDays = 0;
        for(int i=0; i<birdsPerDay.Length; i++){
            if(birdsPerDay[i] >= 5){
                countBusyDays++;
            }
        }
        return countBusyDays;
    }
}
