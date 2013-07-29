using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ionic.Zlib;
using Substrate.Nbt;

namespace Substrate.Core
{
    public enum CompressionType
    {
        None,
        Zlib,
        Deflate,
        GZip,
    }

    public class NBTFile
    {
        private string _filename;

        public NBTFile (string path)
        {
            _filename = path;
        }

        public string FileName
        {
            get { return _filename; }
            protected set { _filename = value; }
        }

        public bool Exists ()
        {
            return File.Exists(_filename);
        }

        public void Delete ()
        {
            File.Delete(_filename);
        }

        public int GetModifiedTime ()
        {
            return Timestamp(File.GetLastWriteTime(_filename));
        }

        public Stream GetDataInputStream ()
        {
            return GetDataInputStream(CompressionType.GZip);
        }

        public virtual Stream GetDataInputStream (CompressionType compression)
        {
            try {
                switch (compression)
                {
                    case CompressionType.None:
                        using (FileStream fstr = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            long length = fstr.Seek(0, SeekOrigin.End);
                            fstr.Seek(0, SeekOrigin.Begin);

                            byte[] data = new byte[length];
                            fstr.Read(data, 0, data.Length);

                            return new MemoryStream(data);
                        }
                    case CompressionType.GZip:
                        Stream stream1 = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        return new GZipStream(stream1, CompressionMode.Decompress);
                    case CompressionType.Zlib:
                        Stream stream2 = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        return new ZlibStream(stream2, CompressionMode.Decompress);
                    case CompressionType.Deflate:
                        Stream stream3 = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        return new DeflateStream(stream3, CompressionMode.Decompress);
                    default:
                        throw new ArgumentException("Invalid CompressionType specified", "compression");
                }
            }
            catch (Exception ex) {
                throw new NbtIOException("Failed to open compressed NBT data stream for input.", ex);
            }
        }

        public Stream GetDataOutputStream ()
        {
            return GetDataOutputStream(CompressionType.GZip);
        }

        public virtual Stream GetDataOutputStream (CompressionType compression)
        {
            try {
                switch (compression) {
                    case CompressionType.None:
                        return new NBTBuffer(this);
                    case CompressionType.GZip:
                        return new GZipStream(new NBTBuffer(this), CompressionMode.Compress);
                    case CompressionType.Zlib:
                        return new ZlibStream(new NBTBuffer(this), CompressionMode.Compress);
                    case CompressionType.Deflate:
                        return new DeflateStream(new NBTBuffer(this), CompressionMode.Compress);
                    default:
                        throw new ArgumentException("Invalid CompressionType specified", "compression");
                }
            }
            catch (Exception ex) {
                throw new NbtIOException("Failed to initialize compressed NBT data stream for output.", ex);
            }
        }

        class NBTBuffer : MemoryStream
        {
            private NBTFile file;

            public NBTBuffer (NBTFile c)
                : base(8096)
            {
                this.file = c;
            }

            public override void Close ()
            {
                try
                {
                    using (Stream fstr = new FileStream(file._filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        try
                        {
                            fstr.Write(this.GetBuffer(), 0, (int)this.Length);
                        }
                        catch (Exception ex)
                        {
                            throw new NbtIOException("Failed to write out NBT data stream.", ex);
                        }
                    }
                }
                catch (NbtIOException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new NbtIOException("Failed to open NBT data stream for output.", ex);
                }
            }
        }

        private int Timestamp (DateTime time)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (int)((time - epoch).Ticks / (10000L * 1000L));
        }
    }
}
