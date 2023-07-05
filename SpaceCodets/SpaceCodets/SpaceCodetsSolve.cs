﻿using System;
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
 

namespace SpaceCadets;

public class Cadet 
{
    public string name;
    public string group;
    public string discipline;
    public int mark;
}


public class TaskName
{
    [JsonProperty("taskName")]
    public string taskName;

    [JsonProperty("data")]
    public Cadet[] data = new Cadet[]{};
}


public class SpaceCadets 
{
    public static IEnumerable<JObject> GetStudentsWithHighestGPA(TaskName _input)
    {
        var max_mark = _input.data
            .GroupBy(c => c.name)
            .Max(c => c.Average(v => v.mark));

        var studentsWithHighestGPA = _input.data 
            .GroupBy(c => c.name)
            .Where(c => c.Average(v => v.mark) == max_mark)
            .Select(c => new JObject(new JProperty("Cadet", c.Key), new JProperty("GPA", Math.Round(c.Average(v => v.mark), 2))));

        
        return studentsWithHighestGPA;
    }

    public static IEnumerable<JObject> CalculateGPAByDiscipline(TaskName _input)
    {
        var GPAByDiscipline = _input.data
            .GroupBy(c => c.discipline)
            .Select(v => new JObject(new JProperty(v.Key, Math.Round(v.Average(c => c.mark), 2))));

        return GPAByDiscipline;    
    }  

    public static IEnumerable<JObject> GetBestGroupsByDiscipline(TaskName _input)
    {
        var BestGroupsByDiscipline = _input.data
            .GroupBy(c => new {c.discipline, c.group})
            .Select(v => new {Discipline = v.Key.discipline, Group = v.Key.group, Mark = v.Average(c => c.mark)})
            .GroupBy(v => v.Discipline)
            .Select(x => new JObject(x.Key, 
                                //x.Where(y => y.Mark == x.Max(z => z.Mark)).Select(y => y.Group),
                                x.OrderByDescending(c => c.Mark).First().Group,
                                Math.Round(x.Max(c => c.Mark), 2))
                            );
            

            return BestGroupsByDiscipline;
    }

    public static void Main(string[] args)
    {
        string path_input = args[0];
        string path_output = args[1];

        TaskName file_input = JsonConvert.DeserializeObject<TaskName>(File.ReadAllText(path_input));

        if (file_input.taskName == "GetStudentsWithHighestGPA")
        {
            IEnumerable<JObject> CadetsWithHighestGPA =  GetStudentsWithHighestGPA(file_input);
            var result = new JObject(CadetsWithHighestGPA);

            File.WriteAllText(path_output, JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        else if (file_input.taskName == "CalculateGPAByDiscipline")
        {
            IEnumerable<JObject> CalcGPAByDiscipline = CalculateGPAByDiscipline(file_input);
            var result = new JObject(CalcGPAByDiscipline);

            File.WriteAllText(path_output, JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        else if (file_input.taskName == "GetBestGroupsByDiscipline")
        {
            IEnumerable<JObject> BestGroupsByDiscipline = GetBestGroupsByDiscipline(file_input);
            var result = new JObject(BestGroupsByDiscipline);

            File.WriteAllText(path_output, JsonConvert.SerializeObject(result, Formatting.Indented));
        }

    }

}