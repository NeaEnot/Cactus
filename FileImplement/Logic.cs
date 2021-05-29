using Core;
using Core.Models;
using System.Collections.Generic;

namespace FileImplement
{
    /// <include file='Documentation.xml' path='documentation/members[@name="Logic"]/Logic/*'/>
    public class Logic : ILogic
    {
        /// <include file='Documentation.xml' path='documentation/members[@name="Logic"]/Constructor/*'/>
        public Logic(string key)
        { }

        public List<ExcerciseView> Read(ExcerciseBinding model)
        {
            return new List<ExcerciseView>();
        }
    }
}
