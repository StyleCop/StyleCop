[StructLayout(LayoutKind.Sequential, Pack = 1)]
private unsafe struct LOSSLESS3
{
    public fixed uint RestartOff[4]; //DWORD/* Offset of restart interval from layer 0 */
}

public class DicomFrame
{
    //private RawPixelData rawData;
    private ArraySegment<byte>? loadedData;
}
