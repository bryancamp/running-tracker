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

import java.io.OutputStream;

public class DeveloperFieldDefinition extends FieldDefinitionBase {
    private FieldDescriptionMesg fieldDescriptionMesg;
    private DeveloperDataIdMesg developerDataIdMesg;
    private int size;
    private int type;
    private short num;

    public DeveloperFieldDefinition() {
        fieldDescriptionMesg = null;
        type = (int) FitBaseType.UINT8;
    }

    public DeveloperFieldDefinition(FieldDescriptionMesg mesg, DeveloperDataIdMesg developerDataIdMesg) {
        setFieldDescription(mesg);
        this.developerDataIdMesg = developerDataIdMesg;
    }

    public DeveloperFieldDefinition(DeveloperField field) {
        this(field.getFieldDefinition());
        this.size = field.getSize();
    }

    public DeveloperFieldDefinition(final DeveloperFieldDefinition other) {
        setFieldDescription(other.fieldDescriptionMesg);
        this.developerDataIdMesg = other.developerDataIdMesg;
        size = other.getSize();
    }

    public long getAppVersion() {
        Long val = null;

        if (isDefined()) {
            val = developerDataIdMesg.getApplicationVersion();
        }

        if( null == val ) {
            return Fit.UINT32_INVALID;
        }

        return (long)val;
    }

    public Byte[] getAppId() {
        if (isDefined()) {
            return developerDataIdMesg.getApplicationId();
        }

        return null;
    }

    public short getDeveloperDataIndex() {
        Short val = null;
        if (isDefined()) {
            val = fieldDescriptionMesg.getDeveloperDataIndex();
        }

        if( null == val ) {
            return Fit.UINT8_INVALID;
        }

        return (short)val;
    }

    public boolean isDefined() {
        return (fieldDescriptionMesg != null) && (developerDataIdMesg != null);
    }

    public String getFieldName() {
        if (isDefined()) {
            return fieldDescriptionMesg.getFieldName(0);
        }

        return null;
    }

    public short getScale() {
        if (isDefined() &&
             (fieldDescriptionMesg.getScale() != null) &&
             (!fieldDescriptionMesg.getScale().equals(Fit.UINT8_INVALID))) {
            return fieldDescriptionMesg.getScale();
        }

        return (short) Fit.FIELD_DEFAULT_SCALE;
    }

    public short getOffset() {
        if (isDefined() &&
             (fieldDescriptionMesg.getOffset() != null) &&
             (!fieldDescriptionMesg.getOffset().equals(Fit.SINT8_INVALID))) {
            return fieldDescriptionMesg.getOffset();
        }

        return (short) Fit.FIELD_DEFAULT_OFFSET;
    }

    public String getUnits() {
        if (isDefined()) {
            return fieldDescriptionMesg.getUnits(0);
        }

        return null;
    }

    public DeveloperField getDefaultField() {
        return new DeveloperField(this);
    }

    protected void write(OutputStream out) {
        try {
            out.write(fieldDescriptionMesg.getFieldDefinitionNumber());
            out.write(size);
            out.write(fieldDescriptionMesg.getDeveloperDataIndex());
        } catch (java.io.IOException e) {
            throw new FitRuntimeException(e);
        }
    }

    public short getNum() {
        return num;
    }

    public void setNum(short num) {
        this.num = num;
    }

    @Override
    public int getSize() {
        return size;
    }

    @Override
    public void setSize(int size) {
        this.size = size;
    }

    public int getType() {
        return type;
    }

    /**
     * Retrieve the Overridden Native Field Number
     *
     * @return Overridden field number if field overrides a value, {@link Fit#UINT8_INVALID} otherwise.
     */
    public short getNativeOverride() {
        if (isDefined()) {
            Short nativeNum = fieldDescriptionMesg.getNativeFieldNum();
            if (null != nativeNum) {
                return nativeNum;
            }
        }

        return Fit.UINT8_INVALID;
    }

    void setFieldDescription(FieldDescriptionMesg description) {
        this.fieldDescriptionMesg = description;
        this.num = fieldDescriptionMesg.getFieldDefinitionNumber();
        this.type = fieldDescriptionMesg.getFitBaseTypeId();
    }

    void setDeveloperDataIdMesg(DeveloperDataIdMesg developerDataIdMesg) {
        this.developerDataIdMesg = developerDataIdMesg;
    }
}
