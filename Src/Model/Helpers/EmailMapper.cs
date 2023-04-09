using Model.Dtos;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Helpers
{
    public static class EmailMapper
    {
        public static Email ToEmail(this EmailDto emailDto)
        {
            return new Email
            {
                Subject = emailDto.Subject,
                Body = emailDto.Body,
                From = emailDto.From,
                To = emailDto.To,
                IsSent = emailDto.IsSent,
            };
        }

        public static EmailDto ToDto(this Email email)
        {
            return new EmailDto
            {
                Subject = email.Subject,
                Body = email.Body!,
                From = email.From!,
                To = email.To!,
                IsSent = email.IsSent
            };
        }
    }
}
