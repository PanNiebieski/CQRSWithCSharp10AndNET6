using System.Net;

namespace CQRSWithCSharp10AndNET6
{
    public static class HttpExtensions
    {
        public static void NotFound(this HttpContext context)
            => context.Response.StatusCode = 
            (int)HttpStatusCode.NotFound;

    }


}
