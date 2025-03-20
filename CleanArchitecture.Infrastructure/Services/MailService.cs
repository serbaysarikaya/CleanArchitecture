using CleanArchitecture.Application.Services;
using GenericEmailService;

using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CleanArchitecture.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(List<string> emails, string body, string subject, List<Attachment> attachments=null)
        {
            var emailConfig = new EmailConfigurations(
          Smtp: "",
          Password: "",
          Port: 587,
          SSL: true,
          Html: true
      );

            var emailModel = new EmailModel<Attachment>(
                Configurations: emailConfig,
                FromEmail: "",
                ToEmails: emails,
                Subject: subject,
                Body: body
            );

          
       //     await EmailService.SendEmailWithNetAsync(emailModel);
        }
    }
}
