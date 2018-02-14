﻿using System.Collections.Generic;

namespace Gambon
{
    public interface ISqlExecutor
    {
        IEnumerable<dynamic> ExecuteReader(string sql);
        dynamic ExecuteFirstOrDefault(string sql);
        int ExecuteNonQuery(string sql);
        dynamic ExecuteScalar(string sql);
    }
}
