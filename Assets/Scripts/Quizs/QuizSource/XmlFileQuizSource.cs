#nullable enable
using QuizGameCore;
using Uitls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using Quizs.QuizSource;

namespace Quizs.QuizSource
{
    public class XmlFileQuizSource : MonoBehaviour, IQuizSource
    {
        [SerializeField] private TextAsset textAsset = null!;

        public IReadOnlyList<IQuiz> QuizList()
        {
            var raw = textAsset.EnsureNotNull().text;
            var list = DeserializeFromXml<List<QuizData>>(raw).EnsureNotNull();
            return list.Select(q => q.Create()).ToList();
        }

        private T DeserializeFromXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xml);
            return (T)serializer.Deserialize(reader)!;
        }


        public class QuizData
        {
            public string? Question;
            public string? CorrectAnswer;
            public string[]? WrongAnswers;


            public IQuiz Create()
            {
                return new Quiz(
                    Question.EnsureNotNull(),
                    CorrectAnswer.EnsureNotNull(),
                    WrongAnswers.EnsureNotNull()
                );
            }
        }
    }
     
}
