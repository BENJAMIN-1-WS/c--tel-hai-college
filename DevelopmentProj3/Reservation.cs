using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProj3
{
    public class Reservation
    {

        public User MadeBy;

        //The following code should be improved!!!!!!!!!
        //The following code should be improved!!!!!!!!!
        // This method returns true if the current reservation can be cancelled by the input user
        // Otherwise- false
        public bool CanBeCancelledByORIG(User user)
        {
            // If the user is Admin- then he should be able to cancel any reservation
            if (user.IsAdmin == true)
            {
                return true;
            }

            // If the user is the one who made the reservation- then he can cancel it
            if (user == MadeBy)
            {
                return true;
            }

            // If the code reach this line- then the reservation cannot be cancelled
            return false;

        }


        public bool CanBeCancelledBy(User user)
        {
            // If the user is Admin OR the if the user is the owner of the current reservation- 
            // then he should be able to cancel any reservation
            // OTHERWISE - if the user is not admin and not the owner- then the reservation cannot be cancelled
            return ((user.IsAdmin) || (user == MadeBy));

        }

    }
}
