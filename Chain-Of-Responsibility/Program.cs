﻿class Receiver {
    public bool BankTransfer { get; set; }
    public bool MoneyTransfer { get; set; }
    public bool PayPalTransfer { get; set; }

    public Receiver(bool bt, bool mt, bool ppt) {
        BankTransfer = bt;
        MoneyTransfer = mt;
        PayPalTransfer = ppt;
    }
}

abstract class PaymentHandler {
    public PaymentHandler Successor { get; set; }
    public abstract void Handle(Receiver receiver);
}

class BankPaymentHandler : PaymentHandler {
    public override void Handle(Receiver receiver) {
        if (receiver.BankTransfer == true) {
            Console.WriteLine("Выполняем банковский перевод");
        } else if (Successor != null) {
            Successor.Handle(receiver);
        }
    }
}

class MoneyPaymentHandler : PaymentHandler {
    public override void Handle(Receiver receiver) {
        if (receiver.MoneyTransfer == true) {
            Console.WriteLine("Выполняем перевод через системы денежных переводов");
        } else if (Successor != null) {
            Successor.Handle(receiver);
        }
    }
}

class PayPalPaymentHandler : PaymentHandler {
    public override void Handle(Receiver receiver) {
        if (receiver.PayPalTransfer == true) {
            Console.WriteLine("Выполняем перевод через PayPal");
        } else if (Successor != null) {
            Successor.Handle(receiver);
        }
    }
}

class Program {
    static void Main(string[] args) {
        Receiver receiver = new Receiver(false, true, true);

        PaymentHandler bankPaymentHandler = new BankPaymentHandler();
        PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();
        PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();

        bankPaymentHandler.Successor = paypalPaymentHandler;
        paypalPaymentHandler.Successor = moneyPaymentHandler;

        bankPaymentHandler.Handle(receiver);

        Receiver receiver2 = new Receiver(true, true, true);
        moneyPaymentHandler.Successor = paypalPaymentHandler;
        paypalPaymentHandler.Successor = bankPaymentHandler;

        moneyPaymentHandler.Handle(receiver2);
    }
}