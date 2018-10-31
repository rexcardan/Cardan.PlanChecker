using ESAPIX.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Common;
using VMS.TPS.Common.Model.API;

namespace Cardan.PlanChecker.ViewModels
{
    public class MainViewModel : BindableBase
    {
        AppComThread VMS = AppComThread.Instance;

        public MainViewModel()
        {
            //Example data bind
            OnPlanChanged(VMS.GetValue(sc => sc.PlanSetup));
            //Handle plan changes
            VMS.Execute(sc =>
            {
                sc.PlanSetupChanged += OnPlanChanged;
            });
        }

        public void OnPlanChanged(PlanSetup ps)
        {
            VMS.Execute(sc =>
            {
                Id = ps?.Id;
                UID = ps?.UID;
                IsDoseCalculated = ps?.Dose != null;
                NBeams = ps?.Beams.Count();
            });
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string uid;

        public string UID
        {
            get { return uid; }
            set { SetProperty(ref uid, value); }
        }

        private int? nBeams;

        public int? NBeams
        {
            get { return nBeams; }
            set { SetProperty(ref nBeams, value); }
        }

        private bool isDoseCalculated;

        public bool IsDoseCalculated
        {
            get { return isDoseCalculated; }
            set { SetProperty(ref isDoseCalculated, value); }
        }
    }
}
