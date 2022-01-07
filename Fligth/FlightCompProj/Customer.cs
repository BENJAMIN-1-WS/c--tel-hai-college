using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompProj
{
    public class Customer
    {
        private bool IsVIP_;
        private int BudgetForFlight_;
        private float Age_;

        public Customer(bool IsVIP, int BudgetForFlight, float Age)
        {
            this.IsVIP_ = IsVIP;
            this.BudgetForFlight_ = BudgetForFlight;
            this.Age_ = Age;
        }
        public Customer()
        {
            this.IsVIP_ = false;
            this.BudgetForFlight_ = 0;
            this.Age_ = 0;
        }
        public bool IsVIP { set { this.IsVIP_ = value; } get { return this.IsVIP_; } }
        public int BudgetForFlight { set { this.BudgetForFlight_ = value; } get { return this.BudgetForFlight_; } }
        public float Age { set { this.Age_ = value; } get { return this.Age_; } }

    }
}
