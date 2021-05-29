using Core.Models;
using System.Collections.Generic;

namespace Core
{
    /// <include file='Documentation.xml' path='documentation/members[@name="ILogic"]/ILogic/*'/>
    public interface ILogic
    {
        /// <include file='Documentation.xml' path='documentation/members[@name="ILogic"]/Create/*'/>
        void Create(ExcerciseBinding model);

        /// <include file='Documentation.xml' path='documentation/members[@name="ILogic"]/Read/*'/>
        List<ExcerciseView> Read(ExcerciseBinding model);
    }
}
