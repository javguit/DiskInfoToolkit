using DiskInfoToolkit.Interop.Enums;

namespace DiskInfoToolkit.Interop.Structures
{
    internal struct TStoragePropertyQuery
    {
        public STORAGE_PROPERTY_ID PropertyId;
        public STORAGE_QUERY_TYPE QueryType;
    }
}
