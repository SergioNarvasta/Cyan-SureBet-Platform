using System.Data;
using System.Xml;
using System;

namespace IData
{
    public abstract class DAABAbstracFactory : IDisposable
    {

        public abstract int ExecuteNonQuery(ref DAABRequest request);

        public abstract DataSet ExecuteDataset(ref DAABRequest request);

        public abstract void FillDataset(ref DAABRequest request);

        public abstract void UpdateDataSet(ref DAABRequest requestInsert, ref DAABRequest requestUpdate, ref DAABRequest requestDelete);

        public abstract DAABDataReader ExecuteReader(ref DAABRequest repuest);

        public abstract object ExecuteScalar(ref DAABRequest request);

        public abstract void CommitTransaction();

        public abstract void RollBackTransaction();

        public abstract void Dispose();
    }
}
