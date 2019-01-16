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


#if !defined(FIT_BLOOD_PRESSURE_MESG_HPP)
#define FIT_BLOOD_PRESSURE_MESG_HPP

#include "fit_mesg.hpp"

namespace fit
{

class BloodPressureMesg : public Mesg
{
public:
    class FieldDefNum final
    {
    public:
       static const FIT_UINT8 Timestamp = 253;
       static const FIT_UINT8 SystolicPressure = 0;
       static const FIT_UINT8 DiastolicPressure = 1;
       static const FIT_UINT8 MeanArterialPressure = 2;
       static const FIT_UINT8 Map3SampleMean = 3;
       static const FIT_UINT8 MapMorningValues = 4;
       static const FIT_UINT8 MapEveningValues = 5;
       static const FIT_UINT8 HeartRate = 6;
       static const FIT_UINT8 HeartRateType = 7;
       static const FIT_UINT8 Status = 8;
       static const FIT_UINT8 UserProfileIndex = 9;
       static const FIT_UINT8 Invalid = FIT_FIELD_NUM_INVALID;
    };

    BloodPressureMesg(void) : Mesg(Profile::MESG_BLOOD_PRESSURE)
    {
    }

    BloodPressureMesg(const Mesg &mesg) : Mesg(mesg)
    {
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of timestamp field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsTimestampValid() const
    {
        const Field* field = GetField(253);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns timestamp field
    // Units: s
    ///////////////////////////////////////////////////////////////////////
    FIT_DATE_TIME GetTimestamp(void) const
    {
        return GetFieldUINT32Value(253, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set timestamp field
    // Units: s
    ///////////////////////////////////////////////////////////////////////
    void SetTimestamp(FIT_DATE_TIME timestamp)
    {
        SetFieldUINT32Value(253, timestamp, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of systolic_pressure field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsSystolicPressureValid() const
    {
        const Field* field = GetField(0);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns systolic_pressure field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT16 GetSystolicPressure(void) const
    {
        return GetFieldUINT16Value(0, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set systolic_pressure field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    void SetSystolicPressure(FIT_UINT16 systolicPressure)
    {
        SetFieldUINT16Value(0, systolicPressure, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of diastolic_pressure field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsDiastolicPressureValid() const
    {
        const Field* field = GetField(1);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns diastolic_pressure field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT16 GetDiastolicPressure(void) const
    {
        return GetFieldUINT16Value(1, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set diastolic_pressure field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    void SetDiastolicPressure(FIT_UINT16 diastolicPressure)
    {
        SetFieldUINT16Value(1, diastolicPressure, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of mean_arterial_pressure field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsMeanArterialPressureValid() const
    {
        const Field* field = GetField(2);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns mean_arterial_pressure field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT16 GetMeanArterialPressure(void) const
    {
        return GetFieldUINT16Value(2, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set mean_arterial_pressure field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    void SetMeanArterialPressure(FIT_UINT16 meanArterialPressure)
    {
        SetFieldUINT16Value(2, meanArterialPressure, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of map_3_sample_mean field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsMap3SampleMeanValid() const
    {
        const Field* field = GetField(3);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns map_3_sample_mean field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT16 GetMap3SampleMean(void) const
    {
        return GetFieldUINT16Value(3, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set map_3_sample_mean field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    void SetMap3SampleMean(FIT_UINT16 map3SampleMean)
    {
        SetFieldUINT16Value(3, map3SampleMean, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of map_morning_values field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsMapMorningValuesValid() const
    {
        const Field* field = GetField(4);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns map_morning_values field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT16 GetMapMorningValues(void) const
    {
        return GetFieldUINT16Value(4, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set map_morning_values field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    void SetMapMorningValues(FIT_UINT16 mapMorningValues)
    {
        SetFieldUINT16Value(4, mapMorningValues, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of map_evening_values field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsMapEveningValuesValid() const
    {
        const Field* field = GetField(5);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns map_evening_values field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT16 GetMapEveningValues(void) const
    {
        return GetFieldUINT16Value(5, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set map_evening_values field
    // Units: mmHg
    ///////////////////////////////////////////////////////////////////////
    void SetMapEveningValues(FIT_UINT16 mapEveningValues)
    {
        SetFieldUINT16Value(5, mapEveningValues, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of heart_rate field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsHeartRateValid() const
    {
        const Field* field = GetField(6);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns heart_rate field
    // Units: bpm
    ///////////////////////////////////////////////////////////////////////
    FIT_UINT8 GetHeartRate(void) const
    {
        return GetFieldUINT8Value(6, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set heart_rate field
    // Units: bpm
    ///////////////////////////////////////////////////////////////////////
    void SetHeartRate(FIT_UINT8 heartRate)
    {
        SetFieldUINT8Value(6, heartRate, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of heart_rate_type field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsHeartRateTypeValid() const
    {
        const Field* field = GetField(7);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns heart_rate_type field
    ///////////////////////////////////////////////////////////////////////
    FIT_HR_TYPE GetHeartRateType(void) const
    {
        return GetFieldENUMValue(7, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set heart_rate_type field
    ///////////////////////////////////////////////////////////////////////
    void SetHeartRateType(FIT_HR_TYPE heartRateType)
    {
        SetFieldENUMValue(7, heartRateType, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of status field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsStatusValid() const
    {
        const Field* field = GetField(8);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns status field
    ///////////////////////////////////////////////////////////////////////
    FIT_BP_STATUS GetStatus(void) const
    {
        return GetFieldENUMValue(8, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set status field
    ///////////////////////////////////////////////////////////////////////
    void SetStatus(FIT_BP_STATUS status)
    {
        SetFieldENUMValue(8, status, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Checks the validity of user_profile_index field
    // Returns FIT_TRUE if field is valid
    ///////////////////////////////////////////////////////////////////////
    FIT_BOOL IsUserProfileIndexValid() const
    {
        const Field* field = GetField(9);
        if( FIT_NULL == field )
        {
            return FIT_FALSE;
        }

        return field->IsValueValid();
    }

    ///////////////////////////////////////////////////////////////////////
    // Returns user_profile_index field
    // Comment: Associates this blood pressure message to a user.  This corresponds to the index of the user profile message in the blood pressure file.
    ///////////////////////////////////////////////////////////////////////
    FIT_MESSAGE_INDEX GetUserProfileIndex(void) const
    {
        return GetFieldUINT16Value(9, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

    ///////////////////////////////////////////////////////////////////////
    // Set user_profile_index field
    // Comment: Associates this blood pressure message to a user.  This corresponds to the index of the user profile message in the blood pressure file.
    ///////////////////////////////////////////////////////////////////////
    void SetUserProfileIndex(FIT_MESSAGE_INDEX userProfileIndex)
    {
        SetFieldUINT16Value(9, userProfileIndex, 0, FIT_SUBFIELD_INDEX_MAIN_FIELD);
    }

};

} // namespace fit

#endif // !defined(FIT_BLOOD_PRESSURE_MESG_HPP)
