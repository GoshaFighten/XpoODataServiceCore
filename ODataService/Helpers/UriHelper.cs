using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.OData.UriParser;
using ODataService.Models;

namespace ODataService.Helpers
{
    public static class UriHelper
    {
        public static TKey GetKeyFromUri<TKey>(HttpRequest request, Uri uri)
        {
            // if (uri == null)
            // {
            //     throw new ArgumentNullException("uri");
            // }
            // var urlHelper = request.GetUrlHelper();// ?? new UrlHelper(request);
            // var pathHandler = (IODataPathHandler)request.GetRequestContainer().GetService(typeof(IODataPathHandler));
            // string serviceRoot = urlHelper.CreateODataLink(
            //     "request.ODataProperties().RouteName",
            //     pathHandler, new List<ODataPathSegment>());
            // var odataPath = pathHandler.Parse(serviceRoot, uri.LocalPath, request.GetRequestContainer());
            // var keySegment = odataPath.Segments.OfType<KeySegment>().FirstOrDefault();
            // if (keySegment == null)
            // {
            //     throw new InvalidOperationException("The link does not contain a key.");
            // }
            // var value = keySegment.Keys.FirstOrDefault().Value;
            // return (TKey)value;
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            // Calculate root Uri
            var rootPath = uri.AbsoluteUri.Substring(0, uri.AbsoluteUri.LastIndexOf('/') + 1);

            var odataUriParser = new ODataUriParser(SingletonEdmModel.GetEdmModel(), new Uri(rootPath), uri);
            var odataPath = odataUriParser.ParsePath();
            var keySegment = odataPath.LastSegment as KeySegment;
            if (keySegment == null)
            {
                throw new InvalidOperationException("The link does not contain a key.");
            }

            return (TKey)keySegment.Keys.First().Value;
        }
    }
}