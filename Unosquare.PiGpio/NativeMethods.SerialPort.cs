﻿namespace Unosquare.PiGpio
{
    using System.Runtime.InteropServices;

    public static partial class NativeMethods
    {
        /// <summary>
        /// This function opens a serial device at a specified baud rate
        /// and with specified flags.  The device name must start with
        /// /dev/tty or /dev/serial.
        ///
        /// The baud rate must be one of 50, 75, 110, 134, 150,
        /// 200, 300, 600, 1200, 1800, 2400, 4800, 9600, 19200,
        /// 38400, 57600, 115200, or 230400.
        ///
        /// No flags are currently defined.  This parameter should be set to zero.
        /// </summary>
        /// <param name="sertty">the serial device to open</param>
        /// <param name="baud">the baud rate in bits per second, see below</param>
        /// <param name="serFlags">0</param>
        /// <returns>Returns a handle (&gt;=0) if OK, otherwise PI_NO_HANDLE, or PI_SER_OPEN_FAILED.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serOpen")]
        public static extern int SerOpen(string sertty, uint baud, uint serFlags);

        /// <summary>
        /// This function closes the serial device associated with handle.
        ///
        /// </summary>
        /// <param name="handle">&gt;=0, as returned by a call to [*serOpen*]</param>
        /// <returns>Returns 0 if OK, otherwise PI_BAD_HANDLE.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serClose")]
        public static extern int SerClose(uint handle);

        /// <summary>
        /// This function reads a byte from the serial port associated with handle.
        ///
        /// If no data is ready PI_SER_READ_NO_DATA is returned.
        /// </summary>
        /// <param name="handle">&gt;=0, as returned by a call to [*serOpen*]</param>
        /// <returns>Returns the read byte (&gt;=0) if OK, otherwise PI_BAD_HANDLE, PI_SER_READ_NO_DATA, or PI_SER_READ_FAILED.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serReadByte")]
        public static extern int SerReadByte(uint handle);

        /// <summary>
        /// This function writes bVal to the serial port associated with handle.
        ///
        /// PI_SER_WRITE_FAILED.
        /// </summary>
        /// <param name="handle">&gt;=0, as returned by a call to [*serOpen*]</param>
        /// <returns>Returns 0 if OK, otherwise PI_BAD_HANDLE, PI_BAD_PARAM, or PI_SER_WRITE_FAILED.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serWriteByte")]
        public static extern int SerWriteByte(uint handle, uint bVal);

        /// <summary>
        /// This function reads up count bytes from the the serial port
        /// associated with handle and writes them to buf.
        ///
        /// If no data is ready zero is returned.
        /// </summary>
        /// <param name="handle">&gt;=0, as returned by a call to [*serOpen*]</param>
        /// <param name="buf">an array to receive the read data</param>
        /// <param name="count">the maximum number of bytes to read</param>
        /// <returns>Returns the number of bytes read (&gt;0=) if OK, otherwise PI_BAD_HANDLE, PI_BAD_PARAM, or PI_SER_READ_NO_DATA.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serRead")]
        public static extern int SerRead(uint handle, byte[] buf, uint count);

        /// <summary>
        /// This function writes count bytes from buf to the the serial port
        /// associated with handle.
        ///
        /// PI_SER_WRITE_FAILED.
        /// </summary>
        /// <param name="handle">&gt;=0, as returned by a call to [*serOpen*]</param>
        /// <param name="buf">the array of bytes to write</param>
        /// <param name="count">the number of bytes to write</param>
        /// <returns>Returns 0 if OK, otherwise PI_BAD_HANDLE, PI_BAD_PARAM, or PI_SER_WRITE_FAILED.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serWrite")]
        public static extern int SerWrite(uint handle, byte[] buf, uint count);

        /// <summary>
        /// This function returns the number of bytes available
        /// to be read from the device associated with handle.
        ///
        /// otherwise PI_BAD_HANDLE.
        /// </summary>
        /// <param name="handle">&gt;=0, as returned by a call to [*serOpen*]</param>
        /// <returns>Returns the number of bytes of data available (&gt;=0) if OK, otherwise PI_BAD_HANDLE.</returns>
        [DllImport(Constants.PiGpioLibrary, EntryPoint = "serDataAvailable")]
        public static extern int SerDataAvailable(uint handle);
    }
}
