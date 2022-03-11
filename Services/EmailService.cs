using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SenderApp.Models;
using SenderApp.Repositories.Interfaces;
using SenderApp.Services.Interfaces;

namespace SenderApp.Services
{
    public class EmailService : CommonService<Email>, IEmailService
    {
        private readonly IGenericRepository<Email> _repository;
        private readonly IConfigService _configService;

        public EmailService(IGenericRepository<Email> repository, IConfigService configService) : base(repository)
        {
            _repository = repository;
            _configService = configService;
        }

        public virtual async Task<bool> StartAsync()
        {
            //Конфиги никуда не выносил, всё написано на коленке
            try
            {
                var emails = _repository.GetAll().Where(x => x.IsSended == false);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("zmsk.robot.sender@gmail.com", "Zmsk1234"),
                    EnableSsl = true
                };

                //Отправляем Emails и проставляем флаг тем, кому уже отправлено
                await Task.Run(() => Parallel.ForEach(emails, email =>
                {
                    MailAddress from = new MailAddress("zmsk.robot.sender@gmail.com", "Zmsk robot");
                    MailAddress to = new MailAddress(email.Address);

                    MailMessage message = new MailMessage(from, to)
                    {
                        Subject = "Sample text",
                        Body = "<b>Sample body text</b>",
                        IsBodyHtml = true
                    };

                    client.SendMailAsync(message);
                    email.IsSended = true;
                    _repository.UpdateAsync(email);
                    _repository.SaveChanges();
                }));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public virtual async Task<bool> StopAsync()
        {
            var config = _configService.GetAll().FirstOrDefault();
            config.IsStarted = false;
            await _configService.UpdateAsync(config);
            return true;
        }
        
    }
}
