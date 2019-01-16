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


public enum DiveBacklightMode {
    AT_DEPTH((short)0),
    ALWAYS_ON((short)1),
    INVALID((short)255);

    protected short value;

    private DiveBacklightMode(short value) {
        this.value = value;
    }

    public static DiveBacklightMode getByValue(final Short value) {
        for (final DiveBacklightMode type : DiveBacklightMode.values()) {
            if (value == type.value)
                return type;
        }

        return DiveBacklightMode.INVALID;
    }

    /**
     * Retrieves the String Representation of the Value
     * @return The string representation of the value
     */
    public static String getStringFromValue( DiveBacklightMode value ) {
        return value.name();
    }

    public short getValue() {
        return value;
    }


}