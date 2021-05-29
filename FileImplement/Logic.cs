using Core;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace FileImplement
{
    /// <include file='Documentation.xml' path='documentation/members[@name="Logic"]/Logic/*'/>
    public class Logic : ILogic
    {
        private Context context;

        /// <include file='Documentation.xml' path='documentation/members[@name="Logic"]/Constructor/*'/>
        public Logic(string key)
        {
            context = Context.GetInstance(key);
        }

        public void Create(ExcerciseBinding model)
        {
            List<Excercise> list = context.Excercises;

            list.Add(
                new Excercise
                {
                    Id = list.Count > 0 ? list.Max(rec => rec.Id) + 1 : 1,
                    Title = model.Title,
                    Question = model.Question,
                    Answrer = model.Answrer
                });

            context.Excercises = list;
        }

        public List<ExcerciseView> Read(ExcerciseBinding model)
        {
            return
                context.Excercises
                .Select(rec => new ExcerciseView
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Question = rec.Question,
                    Answrer = rec.Answrer
                })
                .ToList();
        }
    }
}
