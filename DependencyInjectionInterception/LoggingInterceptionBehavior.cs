using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInterception
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //The logged in user happens to be Danny all the time. ;-)
            string identity = "Danny";

            //Before: You can write a message to the log before the next behavior in the chain/intended target gets called.
            WriteLog(String.Format(
              "{0}: User {1} {2}. Technical details: Before invoking method {3}",
              DateTime.Now.ToLongTimeString(),
              identity,
              (input.MethodBase.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute)?.Description,
              input.MethodBase));

            //Actual call to the next behavior in the chain or the intended target.
            var result = getNext()(input, getNext);

            //After: And you can write a message to the log after the call returns.
            if (result.Exception != null)
            {
                //You can for instance write to the log if an exception has occured.
                WriteLog(String.Format(
                  "{0}: Method {1} threw exception: {2}",
                  DateTime.Now.ToLongTimeString(),
                  input.MethodBase,
                  result.Exception.Message));
            }
            else
            {
                //Or you can write more useful information.
                WriteLog(String.Format(
                  "{0} User {1} {2}: {3}. Technical details: After invoking {4}",
                  DateTime.Now.ToLongTimeString(),
                  identity,
                  (input.MethodBase.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute)?.Description,
                  result.ReturnValue,
                  input.MethodBase));
            }

            return result;
        }

        private void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
