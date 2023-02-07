using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESDemo
{
    public class Computer
    {
        public int Id { get; set; }
        public string name { get; set; }


        public string article { get; set; }

        public string OtherInfo { get; set; }
    }

    public class gb2
    {

        public string name { get; set; }


        public string article { get; set; }


        public List<long[]> arr { get; set; }


    }


    public class gb1
    {

        public string name { get; set; }


        public string article { get; set; }


        public int[]  arr {get;set;}

 
    }






    public class ExerciseIndex 
    {
        public long exerciseid { get; set; }

        [Text(Analyzer = "ik_max_word")] //ik_max_word表示最大
        public string subject { get; set; }

        [Text(Analyzer = "ik_max_word")]
        public string subjectex { get; set; }

        public int difficultlevel { get; set; }

        public float score { get; set; }
        [Text(Analyzer = "ik_max_word")]
        public string exercisepoolidlist { get; set; }
        [Text(Analyzer = "ik_max_word")]
        public string echapteridlist { get; set; }
        public string keypointidlist { get; set; }
        public long aliasid { get; set; }
        public string aliasname { get; set; }
        public string typeename { get; set; }
        public Int16 page { get; set; }
        public int index { get; set; }
        public string number { get; set; }
        public bool ischildonly { get; set; }
        public bool isvalid { get; set; }
        public DateTime createtime { get; set; }
        public DateTime lastupdatetime { get; set; }
        public long parentid { get; set; }



        /// <summary>
        ///   选择题-选项
        /// </summary>

        public string answersoptionlist2 { get; set; }

    }




    public enum DifficultLevel
    {
        One,
        Two,
        Three,
        Four,
        Five,
    }


}
