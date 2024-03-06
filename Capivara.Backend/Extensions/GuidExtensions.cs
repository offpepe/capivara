using System.Collections.Concurrent;

namespace Capivara.Backend.Extensions;

public static class GuidExtensions
{
    public static int[] AwaitResponse(this System.Guid id, ConcurrentDictionary<System.Guid, int[]> results)
    {
        var finished = false;
        int[]? result = null;
        while (!finished)
        {
            finished = results.Remove(id, out result);
            if (result != null) break;
        }
        return result!;
    }
}