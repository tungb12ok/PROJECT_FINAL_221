using Newtonsoft.Json;
using WEB.Services;
using DataAccess.Models;
using BussinessLogic.Repository;
using WEB.Services;


EmailSender e = new EmailSender();

try
{
    Console.WriteLine("Send successfuly!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}