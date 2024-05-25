

// if(total < 10){
//     tax = total * 0.2m;
// }
// else if(total >= 10 && total < 100){
//     tax = total * 0.1m;
// }
// else if (total >= 100 && total < 1000){
//     discount = total * 0.2m;
// } 
// else
// {
//     discount = total * 0.3m;
// }

// switch(total)
// {
//     case decimal t when t < 10:
//     tax = total * 0.2m;
//     break;
//     case decimal t when t >= 10 && t < 100:
//     tax = total * 0.1m;
//     break;
//     case decimal t when t >= 100 && t < 1000:
//     discount = total * 0.2m;
//     break;
//     default:
//     discount = total * 0.3m;
//     break;
// }
// var actions = new Dictionary<Predicate<decimal>, Action>
// {
//     { t => t < 10, () => tax = total * 0.2m },
//     { t => t >= 10 && t < 100, () => tax = total * 0.1m },
//     { t => t >= 100 && t < 1000, () => discount = total * 0.2m },
//     { t => t >= 1000, () => discount = total * 0.3m }
// };
// foreach (var action in actions)
// {
//     if (action.Key(total))
//     {
//         action.Value();
//         break;
//     }
// }
decimal total = 1000;
decimal discount = 0;
decimal tax = 0;

var action = new Dictionary<Predicate<decimal>, IOperation>
{
    { t => t < 10, new Operation1() },
    { t => t >= 10 && t < 100, new Operation2() },
    { t => t >= 100 && t < 1000, new Operation3() },
    { t => t >= 1000, new Operation4() }

};

foreach (var entry in action)
        {
            if (entry.Key(total))
            {
                entry.Value.Operation(total, ref tax, ref discount);
                break;
            }
        }

        Console.WriteLine($"Total: {total}, Tax: {tax}, Discount: {discount}");
        Console.WriteLine($"Final Amount: {total + tax - discount}");

public interface IOperation
{
    void Operation(decimal total, ref decimal tax, ref decimal discount);
}
public class Operation1 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount)
    =>tax = total * 0.2m;
}
public class Operation2 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount)
    =>tax = total * 0.1m;
}
public class Operation3 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount)
    =>discount = total * 0.2m;
}
public class Operation4 : IOperation
{
    public void Operation(decimal total, ref decimal tax, ref decimal discount)
    =>discount = total * 0.3m;
}
