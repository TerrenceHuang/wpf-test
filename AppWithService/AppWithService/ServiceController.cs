using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithService {

    class ServiceController {
        
        #region Properties

        string directory {
            get { return this.servicesDirectory + ServiceController.path; }
        }

        #endregion

        #region Fields

        readonly string servicesDirectory = Environment.CurrentDirectory;

        const string path = "path\\";
        const string fileName = "fileName.exe";
        const string args = "-arg";

        Process process;

        #endregion

        #region Constructors

        public ServiceController() {

            this.process = new Process();

            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            // process setup
            processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = this.directory;
            processStartInfo.FileName = ServiceController.fileName;
            processStartInfo.Arguments = ServiceController.args;
            this.process.StartInfo = processStartInfo;
        }

        ~ServiceController() {

            process.CloseMainWindow();
        }

        #endregion

        #region Methods

        public void start() {
            
            this.process.Start();
        }

        #endregion
    }
}
