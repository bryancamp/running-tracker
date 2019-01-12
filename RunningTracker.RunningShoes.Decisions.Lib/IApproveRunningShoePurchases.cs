using System;
using System.Collections.Generic;
using RunningTracker.Running;

namespace RunningTracker.RunningShoes.Decisions
{
    public interface IApproveRunningShoePurchases
    {
        bool ShouldPurchase(IEnumerable<Run> runs);
    }

    public class RunningShoePurchaseDecisionMaker : IApproveRunningShoePurchases
    {
        public bool ShouldPurchase(IEnumerable<Run> runs)
        {
            foreach(var run in runs)
            {
            }

            return false;
        }
    }
}