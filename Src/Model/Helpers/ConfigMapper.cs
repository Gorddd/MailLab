using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace Model.Helpers
{
    public static class ConfigMapper
    {
        public static Config ToConfig(this ConfigDto configDto)
        {
            return new Config
            {
                Email = configDto.Email,
                SmtpServer = configDto.SmtpServer,
                SmtpPort = configDto.SmtpPort,
                ImapServer = configDto.ImapServer,
                ImapPort = configDto.ImapPort
            };
        }

        public static ConfigDto ToDto(this Config config) 
        {
            return new ConfigDto
            {
                Email = config.Email,
                SmtpServer = config.SmtpServer,
                SmtpPort = config.SmtpPort,
                ImapServer = config.ImapServer,
                ImapPort = config.ImapPort,
            };
        }
    }
}
