using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections;
using System;

namespace IData
{
    public class DAABSQLFactory : DAABAbstracFactory
    {
        //private string m_conSql; 
        private SqlConnection m_conecSQL;
        private SqlTransaction m_TranSQL;

        private void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if ((command == null))
            {
                throw new ArgumentNullException("command");
            }
            if ((!(commandParameters == null)))
            {

                foreach (SqlParameter p in commandParameters)
                {
                    if ((!(p == null)))
                    {
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && p.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        private void AssignParameterValues(SqlParameter[] commandParameters, DataRow dataRow)
        {
            if (commandParameters == null || dataRow == null)
            {
                return;
            }

            int i = 0;
            foreach (SqlParameter commandParameter in commandParameters)
            {
                if ((commandParameter.ParameterName == null || commandParameter.ParameterName.Length <= 1))
                {
                    throw new Exception(string.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: ' {1}' .", i, commandParameter.ParameterName));
                }
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName) != -1)
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName];
                }
                i++;
            }
        }

        private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            int j;
            if ((commandParameters == null) && (parameterValues == null))
            {
                return;
            }
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }
            j = commandParameters.Length - 1;
            for (int i = 0; i <= j; i++)
            {
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = ((IDbDataParameter)(parameterValues[i]));
                    if ((paramInstance.Value == null))
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if ((parameterValues[i] == null))
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        private void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, ref bool mustCloseConnection)
        {
            if ((command == null))
            {
                throw new ArgumentNullException("command");
            }
            if ((commandText == null || commandText.Length == 0))
            {
                throw new ArgumentNullException("commandText");
            }
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                mustCloseConnection = true;
            }
            else
            {
                mustCloseConnection = false;
            }
            command.Connection = connection;
            command.CommandText = commandText;
            if (!((transaction == null)))
            {
                if (transaction.Connection == null)
                {
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                }
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (!((commandParameters == null)))
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        private SqlParameter[] DevuelveParametros(CommandType commandType, ref ArrayList parametros)
        {
            if (!(parametros == null && parametros.Count > 0))
            {
                SqlParameter[] aParam = new SqlParameter[parametros.Count];

                for (int i = 0; i <= parametros.Count - 1; i++)
                {
                    if (parametros[i] is SqlParameter)
                    {
                        aParam[i] = (SqlParameter)parametros[i];
                    }
                    else
                    {
                        aParam[i] = CreaParametro(((IDbDataParameter)(parametros[i])));
                    }
                    SqlParameter ParAux = CreaParametro(((IDbDataParameter)(parametros[i]))); ;
                    if (ParAux.Direction != ParameterDirection.Input)
                    {
                        parametros[i] = aParam[i];
                    }
                }
                return aParam;
            }
            else
            {
                return null;
            }
        }

        private SqlParameter CreaParametro(IDbDataParameter parametro)
        {
            SqlParameter oParam = new SqlParameter();
            oParam.Direction = parametro.Direction;
            oParam.ParameterName = parametro.ParameterName;
            if (parametro.Value == null)
            {
                oParam.Value = DBNull.Value;
            }
            else
            {
                oParam.Value = parametro.Value;
            }
            oParam.SourceColumn = parametro.SourceColumn;
            oParam.SourceVersion = parametro.SourceVersion;
            if (parametro.DbType == DbType.Currency)
            {
                oParam.SqlDbType = SqlDbType.Money;
            }
            else if (parametro.DbType == DbType.Double || parametro.DbType == DbType.Single)
            {
                oParam.SqlDbType = SqlDbType.Decimal;
            }
            else if (parametro.DbType == DbType.Decimal || parametro.DbType == DbType.VarNumeric)
            {
                oParam.SqlDbType = SqlDbType.Decimal;
                if (parametro.Size > 0)
                {
                    oParam.Size = parametro.Size;
                }
                oParam.Scale = parametro.Scale;
                oParam.Precision = parametro.Precision;
            }
            else if (parametro.DbType == DbType.Byte)
            {
                oParam.SqlDbType = SqlDbType.Bit;
            }
            else if (parametro.DbType == DbType.AnsiString)
            {
                oParam.SqlDbType = SqlDbType.NVarChar;
                if (parametro.Size > 0)
                {
                    oParam.Size = parametro.Size;
                }
                else
                {
                    oParam.Size = 50;
                }
            }
            else if (parametro.DbType == DbType.AnsiStringFixedLength)
            {
                oParam.SqlDbType = SqlDbType.Char;
                if (parametro.Size > 0)
                {
                    oParam.Size = parametro.Size;
                }
                else
                {
                    oParam.Size = 50;
                }
            }
            else if (parametro.DbType == DbType.Binary)
            {
                oParam.SqlDbType = SqlDbType.Binary;
            }
            else if (parametro.DbType == DbType.Boolean)
            {
                oParam.SqlDbType = SqlDbType.Bit;
            }
            else if (parametro.DbType == DbType.Date)
            {
                oParam.SqlDbType = SqlDbType.DateTime;
            }
            else if (parametro.DbType == DbType.DateTime)
            {
                oParam.SqlDbType = SqlDbType.DateTime;
            }
            else if (parametro.DbType == DbType.Guid)
            {
                oParam.SqlDbType = SqlDbType.UniqueIdentifier;
            }
            else if (parametro.DbType == DbType.SByte || parametro.DbType == DbType.Int16 || parametro.DbType == DbType.UInt16)
            {
                oParam.SqlDbType = SqlDbType.Int;
            }
            else if (parametro.DbType == DbType.Int32 || parametro.DbType == DbType.UInt32)
            {
                oParam.SqlDbType = SqlDbType.Int;
            }
            else if (parametro.DbType == DbType.Int64 || parametro.DbType == DbType.UInt64)
            {
                oParam.SqlDbType = SqlDbType.Int;
            }
            else if (parametro.DbType == DbType.Object)
            {
                oParam.SqlDbType = SqlDbType.Variant;
            }
            else if (parametro.DbType == DbType.String)
            {
                oParam.SqlDbType = SqlDbType.VarChar;
                if (parametro.Size > 0)
                {
                    oParam.Size = parametro.Size;
                }
                else
                {
                    oParam.Size = 50;
                }
            }
            else if (parametro.DbType == DbType.StringFixedLength)
            {
                oParam.SqlDbType = SqlDbType.Char;
                if (parametro.Size > 0)
                {
                    oParam.Size = parametro.Size;
                }
                else
                {
                    oParam.Size = 50;
                }
            }
            else if (parametro.DbType == DbType.Time)
            {
                oParam.SqlDbType = SqlDbType.DateTime;
            }
            return oParam;
        }

        private bool estableceConexion(bool pb_transaccional, string pc_cadConexion)
        {
            if (m_conecSQL == null || m_conecSQL.State != ConnectionState.Open)
            {
                m_conecSQL = new SqlConnection(pc_cadConexion);
                m_conecSQL.Open();
            }
            if (pb_transaccional && m_TranSQL == null)
            {
                m_TranSQL = m_conecSQL.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            return true;
        }

        public override DataSet ExecuteDataset(ref DAABRequest request)
        {
            string connectionString = request.ConnectionString;
            if ((connectionString == null || connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((request.Command == null || request.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.");
            }
            try
            {
                ArrayList lista = request.Parameters;
                estableceConexion(request.Transactional, connectionString);
                SqlParameter[] aparam = DevuelveParametros(request.CommandType, ref lista);
                if (request.Transactional)
                {
                    return ExecuteDatasets(m_TranSQL, request.CommandType, request.Command, aparam, request.TableNames);
                }
                else
                {
                    return ExecuteDatasets(m_conecSQL, request.CommandType, request.Command, aparam, request.TableNames);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!(request.Transactional) & !(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
            }
        }

        private DataSet ExecuteDatasets(SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters, string[] tableNames)
        {
            if ((connection == null))
            {
                throw new ArgumentNullException("connection");
            }
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdatpter = new SqlDataAdapter();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters, ref mustCloseConnection);
            try
            {
                dataAdatpter = new SqlDataAdapter(cmd);
                if (tableNames == null)
                {
                    dataAdatpter.Fill(ds);
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        ds.Tables[0].TableName = "Tabla" + i.ToString();
                        ds.AcceptChanges();
                    }
                }
                else if (!(tableNames == null && tableNames.Length > 0))
                {
                    dataAdatpter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        //string tableName = "Table"; 					
                        for (int index = 0; index < tableNames.Length; index++)
                        {
                            if ((tableNames[index] == null || tableNames[index].Length == 0))
                            {
                                throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                            }
                            //dataAdatpter.TableMappings.Add(tableName, tableNames[index]); 
                            //tableName = tableName + (index + 1).ToString(); 
                            ds.Tables[index].TableName = tableNames[index];
                        }
                    }
                }
                cmd.Parameters.Clear();
            }
            finally
            {
                if (dataAdatpter != null)
                {
                    dataAdatpter.Dispose();
                }
            }
            if ((mustCloseConnection))
            {
                connection.Close();
            }
            return ds;
        }

        private DataSet ExecuteDatasets(SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, string[] tableNames)
        {
            if ((transaction == null))
            {
                throw new ArgumentNullException("transaction");
            }
            if (!((transaction == null)) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdatpter = new SqlDataAdapter();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection);
            try
            {
                dataAdatpter = new SqlDataAdapter(cmd);
                if (!(tableNames == null && tableNames.Length > 0))
                {
                    string tableName = "Table";

                    for (int index = 0; index <= tableNames.Length - 1; index++)
                    {
                        if ((tableNames[index] == null || tableNames[index].Length == 0))
                        {
                            throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        }
                        dataAdatpter.TableMappings.Add(tableName, tableNames[index]);
                        tableName = tableName + (index + 1).ToString();
                    }
                }
                dataAdatpter.Fill(ds);
                cmd.Parameters.Clear();
            }
            finally
            {
                if ((!(dataAdatpter == null)))
                {
                    dataAdatpter.Dispose();
                }
            }
            return ds;
        }

        public override int ExecuteNonQuery(ref DAABRequest request)
        {
            string connectionString = request.ConnectionString;
            if ((connectionString == null || connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((request.Command == null || request.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.");
            }
            try
            {
                ArrayList lista = request.Parameters;
                SqlParameter[] aparam = DevuelveParametros(request.CommandType, ref lista);
                estableceConexion(request.Transactional, connectionString);
                int iretval;
                if (request.Transactional)
                {
                    iretval = ExecuteNonQuerys(m_TranSQL, request.CommandType, request.Command, aparam);
                }
                else
                {
                    iretval = ExecuteNonQuerys(m_conecSQL, request.CommandType, request.Command, aparam);
                }
                return iretval;
            }
            finally
            {
                if (!(request.Transactional) & !(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
            }
        }

        private int ExecuteNonQuerys(SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if ((connection == null))
            {
                throw new ArgumentNullException("connection");
            }
            SqlCommand cmd = new SqlCommand();
            int retval;
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, ((SqlTransaction)(null)), commandType, commandText, commandParameters, ref mustCloseConnection);
            retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if ((mustCloseConnection))
            {
                connection.Close();
            }
            return retval;
        }

        private int ExecuteNonQuerys(SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if ((transaction == null))
            {
                throw new ArgumentNullException("transaction");
            }
            if (!((transaction == null)) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            SqlCommand cmd = new SqlCommand();
            int retval;
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection);
            retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return retval;
        }

        public override object ExecuteScalar(ref DAABRequest Request)
        {
            string connectionString = Request.ConnectionString;
            if ((connectionString == null || connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((Request.Command == null || Request.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.");
            }
            try
            {
                ArrayList lista = Request.Parameters;
                estableceConexion(Request.Transactional, connectionString);
                SqlParameter[] aparam = DevuelveParametros(Request.CommandType, ref lista);
                if (Request.Transactional)
                {
                    return ExecuteScalares(m_TranSQL, Request.CommandType, Request.Command, aparam);
                }
                else
                {
                    return ExecuteScalares(m_conecSQL, Request.CommandType, Request.Command, aparam);
                }
            }
            finally
            {
                if (!(Request.Transactional) & !(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
            }
        }

        private object ExecuteScalares(SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if ((connection == null))
            {
                throw new ArgumentNullException("connection");
            }
            SqlCommand cmd = new SqlCommand();
            object retval;
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, ((SqlTransaction)(null)), commandType, commandText, commandParameters, ref mustCloseConnection);
            retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if ((mustCloseConnection))
            {
                connection.Close();
            }
            return retval;
        }

        private object ExecuteScalares(SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if ((transaction == null))
            {
                throw new ArgumentNullException("transaction");
            }
            if (!((transaction == null)) && (transaction.Connection == null))
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            SqlCommand cmd = new SqlCommand();
            object retval;
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection);
            retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }

        public override DAABDataReader ExecuteReader(ref DAABRequest Request)
        {
            DAABSQLDataReader oDataReaderSQL;

            string connectionString = Request.ConnectionString;
            if ((connectionString == null || connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            try
            {
                ArrayList lista = Request.Parameters;
                SqlParameter[] aparam = DevuelveParametros(Request.CommandType, ref lista);
                estableceConexion(false, connectionString);
                SqlDataReader drSQL;

                drSQL = ExecuteReaders(m_conecSQL, ((SqlTransaction)(null)), Request.CommandType, Request.Command, aparam);
                oDataReaderSQL = new DAABSQLDataReader();
                oDataReaderSQL.ReturnDataReader = drSQL;
                return oDataReaderSQL;
            }
            catch (SqlException ex1)
            {
                if (!(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
                Request.Exception = ex1;
                throw ex1;
                //return null; 
            }
            catch (Exception ex1)
            {
                Request.Exception = ex1;
                if (!(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
                throw;
                //return null; 
            }
        }

        private SqlDataReader ExecuteReaders(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if ((connection == null))
            {
                throw new ArgumentNullException("connection");
            }
            bool mustCloseConnection = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlDataReader dataReader;
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection);
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bool canClear = true;
                foreach (SqlParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                    {
                        canClear = false;
                    }
                }
                if ((canClear))
                {
                    cmd.Parameters.Clear();
                }
                return dataReader;
            }
            catch
            {
                if ((mustCloseConnection))
                {
                    connection.Close();
                }
                throw;
            }
        }

        public override void FillDataset(ref DAABRequest request)
        {
            string connectionString = request.ConnectionString;
            if ((connectionString == null || connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((request.Command == null || request.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.");
            }
            if ((request.RequestDataSet == null))
            {
                throw new ArgumentNullException("RequestDataSet");
            }
            try
            {
                ArrayList lista = request.Parameters;
                estableceConexion(request.Transactional, connectionString);
                SqlParameter[] aparam = DevuelveParametros(request.CommandType, ref lista);
                if (request.Transactional)
                {
                    FillDatasets(m_conecSQL, m_TranSQL, request.CommandType, request.Command, request.RequestDataSet, request.TableNames, aparam);
                }
                else
                {
                    FillDatasets(m_conecSQL, ((SqlTransaction)(null)), request.CommandType, request.Command, request.RequestDataSet, request.TableNames, aparam);
                }
            }
            catch (Exception ex1)
            {
                request.Exception = ex1;
                throw ex1;
            }
            finally
            {
                if (!(request.Transactional) & !(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
            }
        }

        private void FillDatasets(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, SqlParameter[] commandParameters)
        {
            if ((connection == null))
            {
                throw new ArgumentNullException("connection");
            }
            if ((dataSet == null))
            {
                throw new ArgumentNullException("dataSet");
            }
            SqlCommand command = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            try
            {
                if (!(tableNames == null && tableNames.Length > 0))
                {
                    string tableName = "Table";
                    int index = 0;
                    for (index = 0; index <= tableNames.Length - 1; index++)
                    {
                        if ((tableNames[index] == null || tableNames[index].Length == 0))
                        {
                            throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        }
                        dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                        tableName = tableName + (index + 1).ToString();
                    }
                }
                dataAdapter.Fill(dataSet);
                command.Parameters.Clear();
            }
            finally
            {
                if ((!(dataAdapter == null)))
                {
                    dataAdapter.Dispose();
                }
            }
            if ((mustCloseConnection))
            {
                connection.Close();
            }
        }

        public override void UpdateDataSet(ref DAABRequest RequestInsert, ref DAABRequest RequestUpdate, ref DAABRequest RequestDelete)
        {
            string connectionString = RequestInsert.ConnectionString;
            SqlCommand cmdCommandInsert;
            SqlCommand cmdCommandUpdate;
            SqlCommand cmdCommandDelete;
            if ((connectionString == null || connectionString.Length == 0))
            {
                throw new ArgumentNullException("connectionString");
            }
            if ((RequestInsert.Command == null || RequestInsert.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.RequestInsert");
            }
            if ((RequestUpdate.Command == null || RequestUpdate.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.RequestUpdate");
            }
            if ((RequestDelete.Command == null || RequestDelete.Command.Length == 0))
            {
                throw new ArgumentNullException("No ha ingresado el commando a ejecutar.RequestDelete");
            }
            if ((RequestInsert.RequestDataSet == null))
            {
                throw new ArgumentNullException("RequestDataSet:RequestInsert");
            }
            if (RequestInsert.TableNames == null)
            {
                throw new ArgumentNullException("Falta especificar el nombre de la tabla a actualizar");
            }
            try
            {
                bool cerrarCn = false;
                ArrayList lista = RequestInsert.Parameters;
                estableceConexion(RequestInsert.Transactional, connectionString);
                cmdCommandInsert = new SqlCommand();
                SqlParameter[] aparamInsert = DevuelveParametros(RequestInsert.CommandType, ref lista);
                PrepareCommand(cmdCommandInsert, m_conecSQL, m_TranSQL, RequestInsert.CommandType, RequestInsert.Command, aparamInsert, ref cerrarCn);
                cmdCommandUpdate = new SqlCommand();
                SqlParameter[] aparamUpdate = DevuelveParametros(RequestUpdate.CommandType, ref lista);
                PrepareCommand(cmdCommandUpdate, m_conecSQL, m_TranSQL, RequestUpdate.CommandType, RequestUpdate.Command, aparamUpdate, ref cerrarCn);
                cmdCommandDelete = new SqlCommand();
                SqlParameter[] aparamDelete = DevuelveParametros(RequestDelete.CommandType, ref lista);
                PrepareCommand(cmdCommandDelete, m_conecSQL, m_TranSQL, RequestDelete.CommandType, RequestDelete.Command, aparamDelete, ref cerrarCn);
                UpdateDatasets(cmdCommandInsert, cmdCommandDelete, cmdCommandUpdate, RequestInsert.RequestDataSet, RequestInsert.TableNames[0]);
            }
            catch (Exception ex1)
            {
                RequestInsert.Exception = ex1;
                RequestDelete.Exception = ex1;
                RequestUpdate.Exception = ex1;
                throw ex1;
            }
            finally
            {
                if (!(RequestInsert.Transactional) & !(m_conecSQL == null))
                {
                    m_conecSQL.Dispose();
                }
            }
        }

        public void UpdateDatasets(SqlCommand insertCommand, SqlCommand deleteCommand, SqlCommand updateCommand, DataSet dataSet, string tableName)
        {
            if ((insertCommand == null))
            {
                throw new ArgumentNullException("insertCommand");
            }
            if ((deleteCommand == null))
            {
                throw new ArgumentNullException("deleteCommand");
            }
            if ((updateCommand == null))
            {
                throw new ArgumentNullException("updateCommand");
            }
            if ((dataSet == null))
            {
                throw new ArgumentNullException("dataSet");
            }
            if ((tableName == null || tableName.Length == 0))
            {
                throw new ArgumentNullException("tableName");
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            try
            {
                dataAdapter.UpdateCommand = updateCommand;
                dataAdapter.InsertCommand = insertCommand;
                dataAdapter.DeleteCommand = deleteCommand;
                dataAdapter.Update(dataSet, tableName);
                dataSet.AcceptChanges();
            }
            finally
            {
                if ((!(dataAdapter == null)))
                {
                    dataAdapter.Dispose();
                }
            }
        }

        protected void Finalize()
        {
            if (!(m_conecSQL == null))
            {
                if (!((m_conecSQL.State == ConnectionState.Closed)) | !((m_conecSQL.State == ConnectionState.Broken)))
                {
                    m_conecSQL.Close();
                }
            }
            //base.Finalize(); 
        }

        public override void CommitTransaction()
        {
            if (!(m_conecSQL == null && m_conecSQL.State == ConnectionState.Open && !(m_TranSQL == null)))
            {
                m_TranSQL.Commit();
                m_TranSQL = null;
                Dispose();
            }
        }

        public override void RollBackTransaction()
        {
            if (!(m_conecSQL == null && m_conecSQL.State == ConnectionState.Open && !(m_TranSQL == null)))
            {
                m_TranSQL.Rollback();
                m_TranSQL = null;
                Dispose();
            }
        }

        public override void Dispose()
        {
            if (!(m_conecSQL == null && (!((m_conecSQL.State == ConnectionState.Closed)) | !((m_conecSQL.State == ConnectionState.Broken)))))
            {
                if (m_conecSQL.State == ConnectionState.Open && !(m_TranSQL == null))
                {
                    m_TranSQL.Commit();
                    m_TranSQL = null;
                }
                m_conecSQL.Dispose();
            }
        }
    }
}
