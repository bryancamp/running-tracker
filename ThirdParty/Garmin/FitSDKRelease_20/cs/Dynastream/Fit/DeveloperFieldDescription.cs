#region Copyright
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



#endregion

using System;
using System.Globalization;
using System.IO;

namespace Dynastream.Fit
{
    public class DeveloperFieldDescription
    {
        private readonly DeveloperDataIdMesg m_developerDataId;
        private readonly FieldDescriptionMesg m_fieldDescription;

        /// <summary>
        /// Gets the Value of the Application Version for the Field Description
        /// </summary>
        public uint ApplicationVersion
        {
            get { return m_developerDataId.GetApplicationVersion() ?? uint.MaxValue; }
        }

        /// <summary>
        /// Gets the Value of the Application Id for the Field Description
        /// </summary>
        public Guid ApplicationId
        {
            get
            {
                // If the Application Id is not exactly 16 bytes
                // (see size of UUID) return Empty
                if (m_developerDataId.GetNumApplicationId() != 16)
                    return Guid.Empty;

                // Read the App Id
                byte[] appId = new byte[m_developerDataId.GetNumApplicationId()];
                for (int i = 0; i < appId.Length; i++)
                {
                    appId[i] = m_developerDataId.GetApplicationId(i) ?? 0xFF;
                }

                // The SDK Treats these UUIDs in Java format so we need to convert to
                // a CLS Compliant Array where the array is in the form
                // u32, u16, u16, u8, u8, u8, u8, u8, u8, u8, u8 and flipping from big endian to
                // little endian
                byte[] net = new byte[appId.Length];
                for (int i = 8; i < 16; i++)
                {
                    net[i] = appId[i];
                }

                // Flip The endianness of the u32 and u16 values
                net[3] = appId[0];
                net[2] = appId[1];
                net[1] = appId[2];
                net[0] = appId[3];
                net[5] = appId[4];
                net[4] = appId[5];
                net[7] = appId[6];
                net[6] = appId[7];
                return new Guid(net);
            }
        }

        /// <summary>
        /// Gets the Value of the Field Definition Number for thbe Field Description
        /// </summary>
        public byte FieldDefinitionNumber
        {
            get { return m_fieldDescription.GetFieldDefinitionNumber() ?? byte.MaxValue; }
        }

        internal DeveloperFieldDescription(
            DeveloperDataIdMesg developerDataId,
            FieldDescriptionMesg fieldDescription)
        {
            m_developerDataId = developerDataId;
            m_fieldDescription = fieldDescription;
        }
    }
} // namespace
