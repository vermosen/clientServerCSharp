﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace tcpMainService
{
    [RunInstaller(true)]
    public partial class projectInstaller : System.Configuration.Install.Installer
    {
        public projectInstaller()
        {
            InitializeComponent();
        }

        private void tcpProcessInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
