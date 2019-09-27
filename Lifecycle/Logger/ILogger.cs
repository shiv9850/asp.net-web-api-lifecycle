using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lifecycle.Logger
{
     public interface ILogger<T> where  T : class
    {
         void Trace(string message);

         void Debug(string message);

         void Info(string message);

         void Error(string message);
        

         void Warn(string message);

         void Trace(HttpRequestMessage request);

         void Debug(HttpRequestMessage request);

         void Info(HttpRequestMessage request);
         void Error(HttpRequestMessage request);

         void Warn(HttpRequestMessage request);
         void Exception(Exception exception, string message = "");
        
    }
}
