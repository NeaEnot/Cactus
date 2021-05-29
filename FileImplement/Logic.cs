using Core;
using Core.Models;
using System;
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

            if (list.Count(rec => rec.Title == model.Title) > 0)
            {
                throw new Exception("Such title was exist");
            }

            list.Add(
                new Excercise
                {
                    Id = list.Count > 0 ? list.Max(rec => rec.Id) + 1 : 1,
                    Title = model.Title,
                    Question = model.Question,
                    Answer = model.Answer
                });

            context.Excercises = list;
        }

        public List<ExcerciseView> Read(ExcerciseBinding model)
        {
            return
                context.Excercises
                .Where(rec => model == null || rec.Id == model.Id || model.Title != null && rec.Title.StartsWith(model.Title))
                .Select(rec => new ExcerciseView
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Question = rec.Question,
                    Answer = rec.Answer
                })
                .ToList();
        }

        public void Update(ExcerciseBinding model)
        {
            List<Excercise> list = context.Excercises;

            Excercise excercise = list.FirstOrDefault(rec => rec.Id == model.Id);

            excercise.Title = model.Title;
            excercise.Question = model.Question;
            excercise.Answer = model.Answer;

            context.Excercises = list;
        }

        public void Delete(ExcerciseBinding model)
        {
            List<Excercise> list = context.Excercises;

            list.RemoveAll(rec => model == null || rec.Id == model.Id);

            context.Excercises = list;
        }
    }
}
