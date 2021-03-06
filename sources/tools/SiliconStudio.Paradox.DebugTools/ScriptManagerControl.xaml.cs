﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SiliconStudio.Paradox.Framework.ViewModel;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SiliconStudio.Presentation.Commands;

namespace SiliconStudio.Paradox.DebugTools
{
    /// <summary>
    /// Interaction logic for ScriptManagerControl.xaml
    /// </summary>
    public partial class ScriptManagerControl : UserControl
    {
        public ScriptManagerControl(EngineContext engineContext, Action terminateCommand)
        {
            InitializeComponent();

            if (engineContext == null)
                throw new ArgumentNullException("engineContext");

            if (terminateCommand != null)
                TerminateCommand = new AnonymousCommand(_ => terminateCommand());

            this.Loaded += (s, e) =>
            {
                scriptEditor.Initialize(engineContext);
                scriptMonitor.Initialize(engineContext);
            };

        }

        public ICommand TerminateCommand { get; private set; }
    }
}
