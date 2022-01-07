using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompProj
{ 
   public class Flight
    {
        private Customer orderedBy_;
        private DateTime flightDate_;
        private bool hasAvailableSeats_;
        private int FlightMaxCapacity_;
        private int FlightCurrentCapacity_;
        private int cost_;

        public Flight(Customer orderedBy, DateTime flightD, bool HasAvailableSeats, int cost)
        {
            this.orderedBy_ = orderedBy;
            this.flightDate_ = flightD;
            this.hasAvailableSeats_ = HasAvailableSeats;
            this.cost_ = cost;
        }
        public Flight(Customer orderedBy, DateTime flightD, bool HasAvailableSeats, int cost,int flightCurrentCapacity, int flightMaxCapacity)
        {
            this.orderedBy_ = orderedBy;
            this.flightDate_ = flightD;
            this.hasAvailableSeats_ = HasAvailableSeats;
            this.cost_ = cost;
            this.FlightCurrentCapacity_ = flightCurrentCapacity;
            this.FlightMaxCapacity_ = flightMaxCapacity;
        }
        public Customer OrderedBy { get { return this.orderedBy_; } set { this.orderedBy_ = value; } }
        public DateTime FlightDate { get { return this.flightDate_; } set { this.flightDate_ = value; } }
        public bool HasAvailableSeats{ get { return this.hasAvailableSeats_; } set { this.hasAvailableSeats_ = value; } }
        public int Cost { get { return this.cost_; } set { this.cost_ = value; } }
        public int FlightMaxCapacity { get { return FlightMaxCapacity_; } set => FlightMaxCapacity_ = value; }
        public int FlightCurrentCapacity { get { return FlightCurrentCapacity_; } set => FlightCurrentCapacity_ = value; }

        public bool CanBeCancelledBy_Customer(Customer CustomerForTest)
        {
            if (CustomerForTest.IsVIP) { return true; }
            if (CustomerForTest == this.OrderedBy) { return true; }
            return false;
        }
        public bool IfFlightFull()
        {
            if(this.FlightCurrentCapacity>=this.FlightMaxCapacity) // 200 >= 300 false
                return false;
            return true;
        }
    }
}
