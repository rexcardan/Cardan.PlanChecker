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
using ESAPIX.Constraints.DVH;
using System.Collections.ObjectModel;

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

            CreateConstraints();
        }

        private void CreateConstraints()
        {
            Constraints.AddRange(new PlanConstraint[]
            {
                new PlanConstraint(ConstraintBuilder.Build("PTV", "Max[%] <= 110")),
                new PlanConstraint(ConstraintBuilder.Build("Rectum", "V75Gy[%] <= 15")),
                new PlanConstraint(ConstraintBuilder.Build("Rectum", "V65Gy[%] <= 35")),
                new PlanConstraint(ConstraintBuilder.Build("Bladder", "V80Gy[%] <= 15")),
                //new PlanConstraint(new CTDateConstraint())
            });
        }


        public DelegateCommand EvaluateCommand { get; set; }
        public ObservableCollection<PlanConstraint> Constraints { get; private set; } = new ObservableCollection<PlanConstraint>();
    }
}
