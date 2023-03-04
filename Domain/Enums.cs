using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public enum DataBase
{
    MSSQL = 0,
    PostgreSQL = 1,
    Sqlite = 2,
    MySQL = 3,
}
public enum FoodState
{
    Open = 0,
    Closed = 1,
    Postponed = 2,
    Impossible = 3,
}
