using System;
using System.Collections.Generic;
using Substrate.Source.Nbt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Substrate.Nbt.Tests
{
    [TestClass]
    public class SchemaBuilderTests
    {
        [TestMethod]
        public void FromClassTest()
        {
            SchemaNodeCompound _schema = SchemaBuilder.FromClass(typeof(Villages));

            string formatted = SchemaBuilder.FormatTree(_schema);

            System.Diagnostics.Debug.Write(formatted);
        }
    }
}
