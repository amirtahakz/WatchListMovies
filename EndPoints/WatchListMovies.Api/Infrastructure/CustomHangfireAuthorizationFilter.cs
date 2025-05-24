using Hangfire.Dashboard;

namespace WatchListMovies.Api.Infrastructure
{
    public class CustomHangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            return true;

            // Allow all authenticated users to access the dashboard (not recommended for production)
            //return httpContext.User.Identity.IsAuthenticated;

            // Better: Only allow users with specific role/claim
            //return httpContext.User.Identity.IsAuthenticated
            //       && httpContext.User.IsInRole("Admin");

            // Or check for specific claim
            // return httpContext.User.HasClaim("Permission", "CanAccessHangfire");


            // Allow from specific IPs
            //var remoteIp = httpContext.Connection.RemoteIpAddress;
            //var allowedIPs = new[] { "192.168.1.100", "10.0.0.1" };
            //return allowedIPs.Contains(remoteIp.ToString());
        }
    }
}
