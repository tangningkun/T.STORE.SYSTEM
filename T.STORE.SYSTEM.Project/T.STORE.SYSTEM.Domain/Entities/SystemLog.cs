using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class SystemLog : Entity
    {
        [Required,MaxLength(6)]
        public DateTime LogDate { get; set; }

        [Required, MaxLength(50)]
        public string LogLevel { get; set; }

        [Required, MaxLength(50)]
        public string LogType { get; set; }

        [Required, MaxLength(256)]
        public string Logger{get;set;}

        public string Message { get; set; }

        [MaxLength(50)]
        public string MachineName { get; set; }

        [MaxLength(50)]
        public string MachineIp { get; set; }

        [MaxLength(10)]
        public string NetRequestMethod { get; set; }

        [MaxLength(500)]
        public string NetRequestUrl { get; set; }

        [MaxLength(10)]
        public string NetUserIsauthenticated { get; set; }

        [MaxLength(50)]
        public string NetUserAuthtype { get; set; }

        [MaxLength(50)]
        public string NetUserIdentity { get; set; }

        public string Exception { get; set; }

    }
}
