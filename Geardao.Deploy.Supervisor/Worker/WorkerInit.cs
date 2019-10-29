using System;
using System.IO;
using Geardao.Deploy.Supervisor.Ef;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using WorkerDb = Geardao.Deploy.Supervisor.Ef.Model.Worker;

namespace Geardao.Deploy.Supervisor.Worker
{
    public class WorkerInit
    {
        private WorkerDb Worker { get;}
        private ILogger<WorkerInit> _logger;
        
        public WorkerInit(WorkerDb worker, ILogger<WorkerInit> logger)
        {
            Worker = worker;
            _logger = logger;
            if (worker.State==0)
            {
                SetUpClient();
            }
        }


        private bool SetUpClient()
        {
            using (var sftp = new SftpClient(GetSshConnection()))
            {
                try
                {
                    sftp.Connect();
                    _logger.LogInformation("Worker "+Worker.Id+" with Ip: "+Worker.Ip+" is connected");
                    sftp.CreateDirectory("~/Geardao.Deploy.Worker");
                    _logger.LogInformation("Create folder ~/Geardao.Deploy.Worker");
                    sftp.ChangeDirectory("~/Geardao.Deploy.Worker");
                    _logger.LogInformation("Change directory to ~/Geardao.Deploy.Worker");
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    return false;
                    throw;
                }
                var listFile = Directory.GetFiles("../Client");
                foreach (var file in listFile)
                {
                    using (var fileStream = new FileStream(file, FileMode.Open))
                    {
                        _logger.LogInformation("Uploading {0} ({1:N0} bytes)", file, fileStream.Length);
                        sftp.BufferSize = 4 * 1024;
                        sftp.UploadFile(fileStream, Path.GetFileName(file));
                    }
                }
            }

            return true;
        }

        private ConnectionInfo GetSshConnection()
        {
           return  new ConnectionInfo(Worker.Ip, Worker.Username,
                new PasswordAuthenticationMethod(Worker.Username, Worker.Password));
        }
    }
}