////////////////////////////////////////////////////////////////////////////////
// The following FIT Protocol software provided may be used with FIT protocol
// devices only and remains the copyrighted property of Garmin Canada Inc.
// The software is being provided on an "as-is" basis and as an accommodation,
// and therefore all warranties, representations, or guarantees of any kind
// (whether express, implied or statutory) including, without limitation,
// warranties of merchantability, non-infringement, or fitness for a particular
// purpose, are specifically disclaimed.
//
// Copyright 2019 Garmin Canada Inc.
////////////////////////////////////////////////////////////////////////////////
// ****WARNING****  This file is auto-generated!  Do NOT edit this file.
// Profile Version = 20.81Release
// Tag = production/akw/20.81.00-0-gbb85045
////////////////////////////////////////////////////////////////////////////////


#include "fit_date_time.hpp"

namespace fit
{

DateTime::DateTime(time_t timeStamp)
{
   this->timeStamp = (FIT_DATE_TIME) (timeStamp - systemTimeOffset);
   this->fractionalTimeStamp = 0.0;
}

DateTime::DateTime(FIT_DATE_TIME timeStamp)
{
   this->timeStamp = timeStamp;
   this->fractionalTimeStamp = 0.0;
}

DateTime::DateTime(FIT_DATE_TIME timeStamp, FIT_FLOAT64 fractionalTimeStamp)
{
   this->timeStamp = timeStamp + (FIT_DATE_TIME) floor(fractionalTimeStamp);
   this->fractionalTimeStamp = fractionalTimeStamp - (FIT_FLOAT64) floor(fractionalTimeStamp);
}

DateTime::DateTime(const DateTime& dateTime)
{
   timeStamp = dateTime.timeStamp;
   fractionalTimeStamp = dateTime.fractionalTimeStamp;
}

bool DateTime::Equals(DateTime dateTime)
{
   return( ( ( this->timeStamp == dateTime.GetTimeStamp() ) &&  ( this->fractionalTimeStamp == dateTime.GetFractionalTimestamp() ) ) );
}

FIT_DATE_TIME DateTime::GetTimeStamp()
{
   return timeStamp;
}

FIT_FLOAT64 DateTime::GetFractionalTimestamp()
{
   return fractionalTimeStamp;
}

void DateTime::add(DateTime dateTime)
{
    this->timeStamp += dateTime.GetTimeStamp();
    this->fractionalTimeStamp += dateTime.GetFractionalTimestamp();

    // Adjust fractional part to be less that 1
    this->timeStamp += (long)floor(this->fractionalTimeStamp);
    this->fractionalTimeStamp -= (float)floor(this->fractionalTimeStamp);
}

void DateTime::add(FIT_DATE_TIME timestamp)
{
    add(DateTime(timestamp));
}

void DateTime::add(double fractional_timestamp)
{
    add(DateTime(0, fractional_timestamp));
}

time_t DateTime::GetTimeT()
{
   double val;
   if (fractionalTimeStamp >= 0.5)
      val = ceil(fractionalTimeStamp);
   else
      val = 0;
   return (time_t)(timeStamp + systemTimeOffset + val);
}

void DateTime::ConvertSystemTimeToUTC(long offset)
{
   if (timeStamp < FIT_DATE_TIME_MIN)
   {
      timeStamp += offset;
   }
}

//Returns 0 if DateTimes are equal
//Returns -1 if t1 > target object (this)
//Returns 1 if target object (this) > t1
//If timeStamps are equal, fractional timestamps are compared
int DateTime::CompareTo(DateTime t1) {
    // fractional_timestamp is guaranteed to be less that 1 which allows simplified comparison below
    if ( this->timeStamp == t1.GetTimeStamp() ) {
        // Timestamps are equal; must compare fractional part.
        if (this->fractionalTimeStamp < t1.GetFractionalTimestamp())
        {
            return -1;
        }
        else if (this->fractionalTimeStamp > t1.GetFractionalTimestamp())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    else if ( this->timeStamp > t1.GetTimeStamp() ) {
        return 1;
    }
    else {
        return -1;
    }
}

} // namespace fit
