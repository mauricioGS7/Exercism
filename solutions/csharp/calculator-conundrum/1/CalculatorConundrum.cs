public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {        
        try{
            int result = operation switch{
                    "+" => operand1 + operand2,
                    "*" => operand1 * operand2,
                    "/" => operand2 != 0 ? operand1 / operand2 : 
                        throw new DivideByZeroException("Division by zero is not allowed."),
                    _ => operation == null ? throw new ArgumentNullException() : 
                         operation == "" ? throw new ArgumentException() :
                        throw new ArgumentOutOfRangeException("Exception type was not an exact match")
            };
            return $"{operand1} {operation} {operand2} = {result}";
        }catch(DivideByZeroException ex){
            return ex.Message;
        }       
    }
}
