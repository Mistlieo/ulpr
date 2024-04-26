using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace lab_8_1
{
    [RunInstaller(true)]
    public partial class ClassDiagram : System.Configuration.Install.Installer
    {
        public ClassDiagram()
        {
            InitializeComponent();
        }
    }
}
