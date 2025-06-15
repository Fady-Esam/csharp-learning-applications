using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TempratureChagedEventArgs : EventArgs
{
    public int OldTemp { get; }
    public int NewTemp { get; }
    public int Diff { get; }
    public TempratureChagedEventArgs(int OldTemp,int NewTemp)
    {
        this.OldTemp = OldTemp;
        this.NewTemp = NewTemp;
        Diff = NewTemp - OldTemp;
    }

}
public class Thermostat
{
    public event EventHandler<TempratureChagedEventArgs> OnTempChaged;

    public int OldTemp { get; set; }
    public int NewTemp { get; set; }


    public void ChangeTemperature(int newTemp)
    {
        if (OldTemp != newTemp)
        {
            TempChanged(OldTemp, newTemp);
            OldTemp = newTemp;
        }
    }

    private void TempChanged(int OldTemp, int NewTemp)
    {
        TempChanged(new TempratureChagedEventArgs(OldTemp, NewTemp));
    }

    protected virtual void TempChanged(TempratureChagedEventArgs e)
    {
        OnTempChaged?.Invoke(this, e);
    }

}

public class Display
{
    public void Subscribe(Thermostat t)
    {
        t.OnTempChaged += Print;
    }

    private void Print(object sender, TempratureChagedEventArgs e)
    {
        Console.WriteLine(e.NewTemp);
    }
}



// Publisher Subscriber Design Pattern





public class OrderModel
{
    public int OrderID { get; }
    public double OrderTotalPrice { get;}
    public OrderModel(int orderID, double orderTotalPrice)
    {
        OrderID = orderID;
        OrderTotalPrice = orderTotalPrice;
    }
}




public class Order
{
    public event EventHandler<OrderModel> OnNewOrder;

    public void MakeNewOrder(OrderModel order)
    {
        NewOrder(order);
    }


    protected virtual void NewOrder(OrderModel order)
    {
        OnNewOrder?.Invoke(this, order);
    }
}


public class EmailService
{
    public void Subscribe(Order order)
    {
        order.OnNewOrder += SendEmail;
    }

    public void SendEmail(object sender, OrderModel order)
    {
        Console.WriteLine("Emial Service");
    }
}
public class SMSService
{
    public void Subscribe(Order order)
    {
        order.OnNewOrder += SendSms;
    }

    public void SendSms(object sender, OrderModel order)
    {
        Console.WriteLine("Sms Service");

    }
}

public class ShippingService
{
    public void Subscribe(Order order)
    {
        order.OnNewOrder += MakeShipping;
    }

    public void MakeShipping(object sender, OrderModel order)
    {
        Console.WriteLine("Shapping");

    }
}






internal class Program
{
    static void Main(string[] args)
    {
        EmailService ems = new EmailService();
        SMSService sms = new SMSService();
        ShippingService shi = new ShippingService();

        var ord = new OrderModel(1, 465.65);
        Order newOrder = new Order();
        ems.Subscribe(newOrder);
        sms.Subscribe(newOrder);
        shi.Subscribe(newOrder);

        newOrder.MakeNewOrder(ord);
        newOrder.MakeNewOrder(ord);

        //Thermostat t = new Thermostat();
        //Display display = new Display();
        //display.Subscribe(t);
        //t.ChangeTemperature(15);
        //t.ChangeTemperature(96);
        //t.ChangeTemperature(150);
        //t.ChangeTemperature(800);
        //t.ChangeTemperature(1000);


        Console.ReadKey();
    }
}

