using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace ViewModel.Helpers
{
    public static class ViewEmailMapper
    {
        public static EmailDto ToEmailDto(this ViewEmailDto viewEmailDto)
        {
            return new EmailDto
            {
                Subject = viewEmailDto.Subject,
                Body = viewEmailDto.Body,
                From = viewEmailDto.From,
                To = viewEmailDto.To,
                IsSent = viewEmailDto.IsSent,
            };
        }

        public static ViewEmailDto ToViewEmailDto(this EmailDto emailDto)
        {
            return new ViewEmailDto
            {
                Subject = emailDto.Subject,
                Body = emailDto.Body,
                From = emailDto.From,
                To = emailDto.To,
                IsSent = emailDto.IsSent,
            };
        }
    }
}
