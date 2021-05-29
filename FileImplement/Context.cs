using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FileImplement
{
    internal class Context
    {
        private static Dictionary<string, Context> dict = new Dictionary<string, Context>();

        public static Context GetInstance(string key)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new Context(key));
            }

            return dict[key];
        }

        private string path;

        private Context(string path)
        {
            this.path = "storage\\" + path + ".json";
            CreateFileIfNeed();
        }

        public List<Excercise> Excercises { get { return Load(); } set { Save(value); } }

        private List<Excercise> Load()
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    List<Excercise> restored = JsonConvert.DeserializeObject<List<Excercise>>(json);
                    return restored ?? new List<Excercise>();
                }
            }
            catch
            {
                return new List<Excercise>();
            }
        }

        private void Save(List<Excercise> list)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                string json = JsonConvert.SerializeObject(list);
                writer.Write(json);
            }
        }

        private void CreateFileIfNeed()
        {
            DirectoryInfo dir = new DirectoryInfo("storage");
            if (!dir.Exists)
            {
                dir.Create();
            }

            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                file.Create().Close();
            }
        }
    }
}
