using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using LatchSDK;

public partial class UserDefinedFunctions
{
    public const string APP_ID = "ArD4WAsBCDTGdC9NmQJG";
    public const string SECRET = "nb7XWyL43dGxFrXTYr2bAezLbbCpJsBPChqLmX8D";
    public const string ACCOUNT_ID = "jyRh63DneDmHe9Dy7ajDU3HTRkrCsxwMTg2C7chie929X38xsdPZh4f64TzVmpm2";
    public const string LOGIN_ID = "MpvyRr7NcUgzh6DR72MP";

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString LatchStatus()
    {
        string status = "";
        Latch latch = new Latch(APP_ID, SECRET);
        LatchResponse statusResponse = latch.OperationStatus(ACCOUNT_ID, LOGIN_ID);
        if (statusResponse.Data != null && statusResponse.Data.ContainsKey("operations"))
        {
            var operations = (Dictionary<string, object>)statusResponse.Data["operations"];
            if (operations.ContainsKey(LOGIN_ID))
            {
                var app = (Dictionary<string, object>)operations[LOGIN_ID];
                if (app.ContainsKey("status"))
                {
                    status = app["status"].ToString().ToLower();
                  
                }

            }

        }

        return new SqlString (status);
    }
}
