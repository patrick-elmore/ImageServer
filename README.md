# ImageServer
Application providing image compression and processing, accessible RESTful web API.  This service provides a RESTful interface to build support for various image processing services and/or techniques.  The services provided by this application at this point a fairly limited.

The only support at this point is for Kraken.io, but can easily be expanded upon by integrating other services.  The IImageService is the key interface when integrating new services.  It can be expanded to support specific functionality you may want to take advantage of for the provider you choose to integrate.
