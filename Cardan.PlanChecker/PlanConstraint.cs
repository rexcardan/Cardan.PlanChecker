using ESAPIX.Constraints;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardan.PlanChecker
{
    public class PlanConstraint : BindableBase
    {
        public PlanConstraint(IConstraint con)
        {
            this.Constraint = con;
        }


        private IConstraint _constraint;

        public IConstraint Constraint
        {
            get { return _constraint; }
            set { SetProperty(ref _constraint, value); }
        }

        private ConstraintResult _result;

        public ConstraintResult Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }
    }
}