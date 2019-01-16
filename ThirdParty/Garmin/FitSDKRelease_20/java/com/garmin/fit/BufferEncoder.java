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

import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.util.List;

/**
 * Encodes message objects into a FIT binary file buffer.
 */
public class BufferEncoder implements MesgListener, MesgDefinitionListener {
    private ByteArrayOutputStream byteOutStream;
    private DataOutputStream dataOutStream;
    private MesgDefinition lastMesgDefinition[] = new MesgDefinition[Fit.MAX_LOCAL_MESGS];
    private Validator validator;
    private Fit.ProtocolVersion version;

    /**
     * Constructs a new BufferEncoder. Forces
     * ProtocolVersion.V1_0
     *
     * @deprecated Encoder now supports encoding files of differing protocol
     * versions, use {@link #BufferEncoder(Fit.ProtocolVersion)} to ensure
     * the encoder is validating your files correctly
     */
    @Deprecated
    public BufferEncoder() {
        this.version = Fit.ProtocolVersion.V1_0;
        validator = new ProtocolValidator(version);
        byteOutStream = new ByteArrayOutputStream();
        dataOutStream = new DataOutputStream(byteOutStream);
        open();
    }

    /**
     * Constructs a new File Encoder for specified file.
     *
     * @param version
     *           Fit Protocol Version to use when writing files
     */
    public BufferEncoder(Fit.ProtocolVersion version) {
        this.version = version;
        validator = new ProtocolValidator(version);
        byteOutStream = new ByteArrayOutputStream();
        dataOutStream = new DataOutputStream(byteOutStream);
        open();
    }

    /**
     * Resets the output stream and writes the file header.
     */
    public void open() {
        byteOutStream.reset();
        writeFileHeader();
    }

    /**
     * Writes the file header.
     */
    private void writeFileHeader() {
        byteOutStream.write(Fit.FILE_HDR_SIZE);
        byteOutStream.write(version.getVersion());
        byteOutStream.write(Fit.PROFILE_VERSION & 0xFF);
        byteOutStream.write(Fit.PROFILE_VERSION >> 8);
        byteOutStream.write(0); // Data size.
        byteOutStream.write(0);
        byteOutStream.write(0);
        byteOutStream.write(0);
        byteOutStream.write('.');
        byteOutStream.write('F');
        byteOutStream.write('I');
        byteOutStream.write('T');
        byteOutStream.write(0); // File header CRC.
        byteOutStream.write(0);
    }

    /**
     * MesgListener interface.
     */
    public void onMesg(Mesg mesg) {
        write(mesg);
    }

    /**
     * MesgDefinitionListener interface.
     */
    public void onMesgDefinition(MesgDefinition mesgDefinition) {
        write(mesgDefinition);
    }

    /**
     * Writes a message definition to the buffer.
     *
     * @param mesgDefinition
     *           message definition object to write
     */
    public void write(MesgDefinition mesgDefinition) {
        if(!validator.validateMesgDefn(mesgDefinition)) {
            throw new FitRuntimeException("Incompatible Protocol Features");
        }

        mesgDefinition.write(dataOutStream);
        lastMesgDefinition[mesgDefinition.localNum] = mesgDefinition;
    }

    /**
     * Writes a message to the buffer.
     * Automatically writes message definition if required.
     *
     * @param mesg
     *           message object to write
     */
    public void write(Mesg mesg) {
        if(!validator.validateMesg(mesg)) {
            throw new FitRuntimeException("Incompatible Protocol Features");
        }

        if ((lastMesgDefinition[mesg.localNum] == null) || !lastMesgDefinition[mesg.localNum].supports(mesg)) {
            write(new MesgDefinition(mesg));
        }

        mesg.write(dataOutStream, lastMesgDefinition[mesg.localNum]);
    }

    /**
     * Writes a list of messages to the file.
     *
     * @param mesgs
     *           list message objects to write
     */
    public void write(List<Mesg> mesgs) {
        for (Mesg mesg : mesgs) {
            write(mesg);
        }
    }

    /**
     * Updates the data size in the file header, writes the CRC, and returns the buffer.
     * The output stream buffer is discarded and re-initialized to start encoding a new file.
     *
     * @return file buffer
     */
    public byte[] close() {

        // Write two dummy bytes as place holder for the CRC.
        byteOutStream.write(0);
        byteOutStream.write(0);

        // Get the buffer of the file.
        byte[] buffer = byteOutStream.toByteArray();
        long dataSize = buffer.length - Fit.FILE_HDR_SIZE - 2;

        // Set the data size in the file header.
        buffer[4] = (byte) (dataSize & 0xFF);
        buffer[5] = (byte) ((dataSize >> 8) & 0xFF);
        buffer[6] = (byte) ((dataSize >> 16) & 0xFF);
        buffer[7] = (byte) ((dataSize >> 24) & 0xFF);

        // Compute the CRC of the file header.
        int crc = 0;
        for (int i = 0; i < (Fit.FILE_HDR_SIZE - 2); i++) {
            crc = CRC.get16(crc, buffer[i]);
        }

        // Set the file header CRC in the file buffer.
        buffer[Fit.FILE_HDR_SIZE - 2] = (byte) (crc & 0xFF);
        buffer[Fit.FILE_HDR_SIZE - 1] = (byte) ((crc >> 8) & 0xFF);

        // Compute the CRC of the file.
        crc = 0;
        for (int i = 0; i < (buffer.length - 2); i++) {
            crc = CRC.get16(crc, buffer[i]);
        }

        // Set the file CRC in the file buffer.
        buffer[buffer.length - 2] = (byte) (crc & 0xFF);
        buffer[buffer.length - 1] = (byte) ((crc >> 8) & 0xFF);

        // Discard the output stream and re-initialize.
        open();

        return buffer;
    }
}
