using System;

namespace Substrate.Nbt
{
    /// <summary>
    /// Defines methods for loading or extracting an NBT tree.
    /// </summary>
    public interface INbtObject2
    {
        /// <summary>
        /// Attempt to load an NBT tree into the object without validation.
        /// </summary>
        /// <param name="tree">The root node of an NBT tree.</param>
        /// <returns></returns>
        void LoadTree(TagNode tree);

        /// <summary>
        /// Builds an NBT tree from the object's data.
        /// </summary>
        /// <returns>The root node of an NBT tree representing the object's data.</returns>
        TagNode BuildTree();
    }
}
