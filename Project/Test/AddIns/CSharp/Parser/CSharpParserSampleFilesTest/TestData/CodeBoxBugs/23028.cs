unsafe class Class1
{
    private byte* _chunkPointer;

    public byte** ChunkAddress
    {
        get
        {
            fixed (byte** addr = &_chunkPointer)
            {
                return addr;
            }
        }
    }
}
