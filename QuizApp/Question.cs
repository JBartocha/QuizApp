using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public struct Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionTitle { get; set; }
        public List<String> Answers { get; set; }
        public int CorrentAnswer { get; set; }
        public string? QuestionPictureName { get; set; }
        public string? QuestionPictureDescription { get; set; }
        public int QuestionDifficulty { get; set; }
        public string QuestionLink { get; set; }
        public List<String> QuestionCathegories { get; set; }
    }
}
