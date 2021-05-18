using System.Collections.Generic;

namespace WebAppCB.DataAccess
{
    public interface IConnection
    {
        IList<string[]> ExecuteQuery(string query);

        int ExecuteNonQuery(string nonQuery);

        string CleanValue(string val);
    }
}
