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


#import <Foundation/Foundation.h>
#import "FitField.h"

@interface FitField ()

@end

@implementation FitField

- (FIT_UINT8) Write:(FILE*) file forField:(const fit::FieldBase *)field
{
    FIT_UINT8 byte;

    FIT_UINT8 size = field->GetSize();
    for (FIT_UINT8 valueIndex = 0; valueIndex < size; valueIndex++)
    {
        byte = field->GetValuesBYTE(valueIndex);
        fwrite(&byte, 1, 1, file);
    }

    return size;
}

@end
