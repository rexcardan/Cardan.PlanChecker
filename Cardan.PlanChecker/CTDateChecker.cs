using ESAPIX.Constraints;
using ESAPIX.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using F = ESAPIX.Facade.API;
namespace Cardan.PlanChecker
{
    public class CTDateConstraint : IConstraint
    {
        public string Name => "CT Date Checker";
        public string FullName => "CT Date < 60 Days";

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var pq = new PQAsserter(pi);
            return pq.HasImage().CumulativeResult;
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            var image = pi.GetImage();
            return Constrain(new F.Image(image));
        }

        public ConstraintResult Constrain(F.Image image)
        {
            var diffDays = (DateTime.Now - image.CreationDateTime).Value.TotalDays;
            var msg = $"CT is {diffDays} days old";

            if (diffDays <= 60)
            {
                return new ConstraintResult(this, ResultType.PASSED, msg);
            }
            else
            {
                return new ConstraintResult(this, ResultType.ACTION_LEVEL_3, msg);
            }
        }
    }
}
