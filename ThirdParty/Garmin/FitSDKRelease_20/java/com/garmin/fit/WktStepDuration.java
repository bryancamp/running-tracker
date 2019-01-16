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


package com.garmin.fit;


public enum WktStepDuration {
    TIME((short)0),
    DISTANCE((short)1),
    HR_LESS_THAN((short)2),
    HR_GREATER_THAN((short)3),
    CALORIES((short)4),
    OPEN((short)5),
    REPEAT_UNTIL_STEPS_CMPLT((short)6),
    REPEAT_UNTIL_TIME((short)7),
    REPEAT_UNTIL_DISTANCE((short)8),
    REPEAT_UNTIL_CALORIES((short)9),
    REPEAT_UNTIL_HR_LESS_THAN((short)10),
    REPEAT_UNTIL_HR_GREATER_THAN((short)11),
    REPEAT_UNTIL_POWER_LESS_THAN((short)12),
    REPEAT_UNTIL_POWER_GREATER_THAN((short)13),
    POWER_LESS_THAN((short)14),
    POWER_GREATER_THAN((short)15),
    TRAINING_PEAKS_TSS((short)16),
    REPEAT_UNTIL_POWER_LAST_LAP_LESS_THAN((short)17),
    REPEAT_UNTIL_MAX_POWER_LAST_LAP_LESS_THAN((short)18),
    POWER_3S_LESS_THAN((short)19),
    POWER_10S_LESS_THAN((short)20),
    POWER_30S_LESS_THAN((short)21),
    POWER_3S_GREATER_THAN((short)22),
    POWER_10S_GREATER_THAN((short)23),
    POWER_30S_GREATER_THAN((short)24),
    POWER_LAP_LESS_THAN((short)25),
    POWER_LAP_GREATER_THAN((short)26),
    REPEAT_UNTIL_TRAINING_PEAKS_TSS((short)27),
    REPETITION_TIME((short)28),
    REPS((short)29),
    INVALID((short)255);

    protected short value;

    private WktStepDuration(short value) {
        this.value = value;
    }

    public static WktStepDuration getByValue(final Short value) {
        for (final WktStepDuration type : WktStepDuration.values()) {
            if (value == type.value)
                return type;
        }

        return WktStepDuration.INVALID;
    }

    /**
     * Retrieves the String Representation of the Value
     * @return The string representation of the value
     */
    public static String getStringFromValue( WktStepDuration value ) {
        return value.name();
    }

    public short getValue() {
        return value;
    }


}
