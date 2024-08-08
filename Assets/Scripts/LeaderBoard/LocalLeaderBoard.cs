using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace LeaderBoard
{
    public class LocalLeaderBoard : MonoBehaviour, ILeaderBoard
    {
        public async Task Note(string name, float time)
        {
            var record = new Record
            {
                Name = name,
                Time = time
            };

            var fileStream = new FileStream(Application.persistentDataPath + "/LeaderBoard.json",
                FileMode.Append);

            var streamWriter = new StreamWriter(fileStream);
            await streamWriter.WriteAsync(JsonConvert.SerializeObject(record, Formatting.Indented));
            streamWriter.Close();
            fileStream.Close();
        }

        public async Task<IReadOnlyList<Record>> Leaders()
        {
            throw new NotImplementedException();
        }
    }
}