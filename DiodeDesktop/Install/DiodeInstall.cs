using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace DiodeDesktop.Install
{
    [RunInstaller(true)]
    public partial class DiodeInstall : System.Configuration.Install.Installer
    {
        public DiodeInstall()
        {
            InitializeComponent();
        }
    }
}
