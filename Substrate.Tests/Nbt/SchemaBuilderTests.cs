using System;
using System.Collections.Generic;
using Substrate.Source.Nbt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Substrate.Nbt.Tests
{
    [TestClass]
    public class SchemaBuilderTests
    {
        [TestMethod]
        public void ItemTest()
        {
            SchemaNodeCompound _schemaManual = Item.Schema;

            SchemaNodeCompound _schemaBuilt = SchemaBuilder.FromClass(typeof(Item));

            string formattedManual = SchemaBuilder.FormatTree(_schemaManual);

            string formattedBuilt = SchemaBuilder.FormatTree(_schemaBuilt);

            Debug.WriteLine("Manual:");
            Debug.WriteLine(formattedManual);
            Debug.WriteLine("Built:");
            Debug.WriteLine(formattedBuilt);
        }

        [TestMethod]
        public void PlayerTest()
        {
            SchemaNodeCompound _schemaManual = Player.Schema;

            SchemaNodeCompound _schemaBuilt = SchemaBuilder.FromClass(typeof(Player));

            string formattedManual = SchemaBuilder.FormatTree(_schemaManual);

            string formattedBuilt = SchemaBuilder.FormatTree(_schemaBuilt);

            Debug.WriteLine("Manual:");
            Debug.WriteLine(formattedManual);
            Debug.WriteLine("Built:");
            Debug.WriteLine(formattedBuilt);
        }
    }
}
