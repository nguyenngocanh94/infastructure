using System;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public partial class Auth
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}