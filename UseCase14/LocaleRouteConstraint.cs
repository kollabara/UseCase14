using System.Globalization;

namespace UseCase14;

public class LocaleRouteConstraint : IRouteConstraint
{
    private readonly string[] _supportedLocales = { "en-us", "fr-fr", "ua-ua" };

    public bool Match(
        HttpContext? httpContext, 
        IRouter? route, 
        string routeKey, 
        RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        var rawLocale = values[routeKey]?.ToString()?.ToLower();
        if (string.IsNullOrEmpty(rawLocale) || !_supportedLocales.Contains(rawLocale))
        {
            return false;
        }
        
        var culture = new CultureInfo(rawLocale);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        
        return true;
    }
}