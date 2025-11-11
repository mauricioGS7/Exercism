public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try{            
            long result = checked(@base * multiplier);
            return result.ToString();
        }catch(OverflowException ex){
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float result = @base * multiplier;
        if(float.IsInfinity(result) || float.IsNaN(result)){
            return "*** Too Big ***";
        }
        return result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try{            
            decimal result = checked(salaryBase * multiplier);
            return result.ToString();
        }catch(OverflowException ex){
            return "*** Much Too Big ***";
        }
    }
}
