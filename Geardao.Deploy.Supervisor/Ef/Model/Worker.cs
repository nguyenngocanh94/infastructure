using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        public string Ip { get; set; }

        public string PrivateKey { get; set; }

        public int InstanceInPool { get; set; }

        public int MaxInstanceInPool { get; set; }
        
        public int Healthy { get; set; }
    }
}