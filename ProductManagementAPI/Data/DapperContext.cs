using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ProductManagementAPI.Data;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new OracleConnection(
            _configuration.GetConnectionString("OracleConnection")
        );
    }
}