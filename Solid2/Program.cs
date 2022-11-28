using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

//Який принцип S.O.L.I.D. порушено? Виправте!

/*Зверніть увагу на клас EmailSender. Крім того, що за допомогою методу Send, він відправляє повідомлення, 
він ще і вирішує як буде вестися лог. В даному прикладі лог ведеться через консоль.
Якщо трапиться так, що нам доведеться міняти спосіб логування, то ми будемо змушені внести правки в клас EmailSender.
Хоча, здавалося б, ці правки не стосуються відправки повідомлень. Очевидно, EmailSender виконує кілька обов'язків і, 
щоб клас ні прив'язаний тільки до одного способу вести лог, потрібно винести вибір балки з цього класу.*/

/* Порушено Принцип відкритості/закритості (OCP)
 * Для вирішення цієї задачі визначимо інтерфейс ISendFormatter. Класи, які реалізують цей інтерфес
 * будуть відповідати за форматування звіту до певного вигляду.*/
class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}
class EmailSender
{
    public void Send(Email email, ILogFormatter logFormatter)
    {
        // ... sending...
        //Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
        logFormatter.FormatReport(email);
    }
}
interface ILogFormatter
{
    void FormatReport(Email email);
}
class FileFormatter : ILogFormatter
{
    public void FormatReport(Email email) 
    {
        Console.WriteLine("Added to file: Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}
class ConsoleFormatter : ILogFormatter
{
    public void FormatReport(Email email) 
    {
        Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        EmailSender es = new EmailSender();
        ILogFormatter cf = new ConsoleFormatter();
        ILogFormatter ff = new FileFormatter();

        es.Send(e1, cf);
        es.Send(e2, cf);
        es.Send(e3, cf);
        es.Send(e4, ff);
        es.Send(e5, ff);
        es.Send(e6, ff);

        Console.ReadKey();
    }
}