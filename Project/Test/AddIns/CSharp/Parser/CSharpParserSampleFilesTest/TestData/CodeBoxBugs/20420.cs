public abstract class ARecord
{
protected Field<T> GetField<T, TTypeSerializer>(FieldID fieldID)
where TTypeSerializer : struct, ITypeSerializer<T>
{
T item = default(T);
var reader = new ByteReader();
default(TTypeSerializer).Decode(reader, ref item);
throw new NotImplementedException();
}
}
 
public interface ITypeSerializer<T>
{
ByteReader Decode(ByteReader r, ref T item);
}
