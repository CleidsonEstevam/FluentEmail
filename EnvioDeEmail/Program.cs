using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EnvioDeEmail
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Testando FluentEmail");
            Console.ReadKey();

            var sender = new SmtpSender(() => new System.Net.Mail.SmtpClient("localHost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\Email"
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From("cleidsonestevamdasilva@hotmail.com")
                .To("cleidsonestevamdasilva@hotmail.com")
                .Subject("Testando")
                .Body("Testando o fluentValidation")
                .SendAsync();

            if (email.Successful) 
            {
                Console.WriteLine("E-mail enviado.");
            }
        }
    }
}
