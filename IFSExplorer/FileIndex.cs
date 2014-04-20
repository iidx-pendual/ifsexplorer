using System.IO;

namespace IFSExplorer
{
    internal class FileIndex {
        private readonly Stream _stream;

        private readonly int _index;
        internal readonly int Size;
        internal readonly int EntryNumber;

        internal FileIndex(Stream stream, int index, int size, int entryNumber)
        {
            _stream = stream;
            EntryNumber = entryNumber;
            Size = size;
            _index = index;
        }

        internal byte[] Read()
        {
            _stream.Seek(_index, SeekOrigin.Begin);
            var r = new byte[Size];
            _stream.Read(r, 0, Size);
            return r;
        }
    }
}
