using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaymentMethod banktrsnsfer = new BankTransfer
            {
                AccountNo = "123456789"
            };

            PaymentMethod paypal = new Paypal()
            {
                Email = "abcd@123gmail.com",
                Password = "199522"
            };

            PaymentMethod creditcard = new CreditCard()
            {
                CardNo = "1244-2222-8495-6636",
                ExpDate = "12/24"
            };

            PaymentService ps = new PaymentService();
            ps.ExecutePayment(banktrsnsfer, 200m);
            ps.ExecutePayment(paypal, 2200m);
            ps.ExecutePayment(creditcard, 11200m);

        }

    }

    public class PaymentService
    {
        public void ExecutePayment(PaymentMethod pm, decimal amount)
        {
            if (pm.ValidateInfo())
            {
                pm.ProcessPayment(amount);
                Console.WriteLine("Payment is Successful.");
            }
            else
            {
                Console.WriteLine("Payment is Fail.");
            }
        }
    }


    public abstract class PaymentMethod
    {
        public abstract bool ValidateInfo();

        public abstract void ProcessPayment(decimal amount);
    }

    public interface IPaymentMethod
    {
        bool ValidateInfo();

        void ProcessPayment(decimal amount);
    }


    class BankTransfer : PaymentMethod
    {
        public string AccountNo { get; set; }

        public override bool ValidateInfo()
        {
            if (string.IsNullOrWhiteSpace(AccountNo))
            {
                Console.WriteLine("Account Number is missing");
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Paymemt Complete with Bank Transfer.");
        }
    }

    class Paypal : PaymentMethod
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public override bool ValidateInfo()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                Console.WriteLine("Credential Info is missing");
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Paymemt Complete with Paypal Transfer.");

        }
    }

    class CreditCard : PaymentMethod
    {
        public string CardNo { get; set; }

        public string ExpDate { get; set; }

        public override bool ValidateInfo()
        {
            if (string.IsNullOrWhiteSpace(CardNo) || string.IsNullOrWhiteSpace(ExpDate))
            {
                Console.WriteLine("Credential Info is missing");
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Paymemt Complete with credit card Transfer.");
        }
    }
    
}
