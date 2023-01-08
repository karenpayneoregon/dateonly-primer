using Microsoft.EntityFrameworkCore;

namespace DateOnlyApp.Extensions;
public static class DbContexts
{
    /// <summary>
    /// Test connection with exception handling
    /// </summary>
    /// <param name="context"><see cref="DbContext"/></param>
    /// <returns></returns>
    public static async Task<bool> CanConnectAsync(this DbContext context, CancellationToken ct)
    {
        try
        {
            var result = await Task.Run(async () => await context.Database.CanConnectAsync(ct));
            return result;
        }
        catch
        {
            return false;
        }
    }

}
