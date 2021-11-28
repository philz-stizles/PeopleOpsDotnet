using Dapper;
using System;
using System.Collections.Generic;

namespace PeopleOps.Application.Contracts.Repositories
{
    public interface IStoredProcedureCall: IDisposable
    {
        IEnumerable<T> ExecuteThenReturnList<T>(string procedureName, DynamicParameters param = null);
        void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);
        T ExecuteThenReturnEntity<T>(string procedureName, DynamicParameters param = null);
    }
}
