using System.Data;

namespace IData
{
    public abstract class DAABDataReader
    {
        public abstract IDataReader ReturnDataReader
        {
            get;
            set;
        }
    }
}
