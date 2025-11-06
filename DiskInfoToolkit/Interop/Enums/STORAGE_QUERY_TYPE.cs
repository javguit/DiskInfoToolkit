namespace DiskInfoToolkit.Interop.Enums
{
    internal enum STORAGE_QUERY_TYPE
    {
        PropertyStandardQuery = 0,          // Retrieves the descriptor
        PropertyExistsQuery,                // Used to test whether the descriptor is supported
        PropertyMaskQuery,                  // Used to retrieve a mask of writeable fields in the descriptor
        PropertyQueryMaxDefined     // use to validate the value
    }
}
