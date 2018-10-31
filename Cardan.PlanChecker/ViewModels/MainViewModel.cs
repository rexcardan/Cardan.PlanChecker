using ESAPIX.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Common;
using VMS.TPS.Common.Model.API;
using Prism.Commands;
using System.Windows;
using F = ESAPIX.Facade.API;
using ESAPIX.Extensions;

namespace Cardan.PlanChecker.ViewModels
{
    public class MainViewModel : BindableBase
    {
        AppComThread VMS = AppComThread.Instance;

        public MainViewModel()
        {
            EvaluateCommand = new DelegateCommand(() =>
            {
                var id = VMS.GetValue(sc =>
                {
                    return sc.PlanSetup?.Id;
                });
                MessageBox.Show(id);
            });
        }

        public DelegateCommand EvaluateCommand { get; set; }
    }
}
