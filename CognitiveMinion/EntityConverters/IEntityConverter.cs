namespace CognitiveMinion.EntityConverters
{
    interface IEntityConverter
    {
        /// <summary>
        /// Checks if the current converter supports converting from the detected type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CanConvertType(string type);

        /// <summary>
        /// Converts into simple type
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Simplify(object data);
    }
}
