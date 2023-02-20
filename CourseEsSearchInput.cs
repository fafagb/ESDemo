using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESDemo
{

    [ElasticsearchType(IdProperty = "Id")]
    public class ExerciseStructIndex 
    {

        /// <summary>
        /// 小题
        /// </summary>
        [Text(Analyzer = "ik_max_word")]
        public string SubExercise { get; set; }





        /// <summary>
        /// 学校Id
        /// </summary>
        public long SchoolId { get; set; }



        public long ExerciseId { get; set; }


        /// <summary>
        /// 题型别名Id
        /// </summary>

        public long ExerciseTypeAliasId { get; set; }

        /// <summary>
        /// 基础题型Id
        /// </summary>

        public Int64 ExerciseTypeId { get; set; }
        /// <summary>
        /// 标签题干
        /// </summary>
        [Text(Analyzer = "ik_max_word")]
        public string ExerciseSubject { get; set; }
        /// <summary>
        /// 原始题干
        /// </summary>
        /// <value></value>
        [Text(Analyzer = "ik_max_word")]
        public string ExerciseSubjectContent { get; set; }

        /// <summary>
        /// 选项
        /// </summary>
        public string Option { get; set; }


        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }


        /// <summary>
        /// 代码片段
        /// </summary>
        public string CodeSnippet { get; set; }

        /// <summary>
        /// 父题ID
        /// </summary>
        public Int64 ParentID { get; set; }
        /// <summary>
        /// 小题顺序
        /// </summary>
        public Int16 QuestionItemID { get; set; }

        //[Keyword(Index = true)]

        /// <summary>
        /// 章节Id
        /// </summary>
   
        public List<long[]> CharpterIds { get; set; }



        // <summary>
        /// 错误率
        /// </summary>
        public float Error { get; set; }


        /// <summary>
        /// 难度
        /// </summary>
        public int Difficult { get; set; }


        /// <summary>
        /// 使用人数
        /// </summary>
        public Int32 UsePeopleNum { get; set; }

        /// <summary>
        /// 教师Id
        /// </summary>
        public List<long> TearcherIds { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [Date]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Date]
        public DateTime LastUpdateTime { get; set; }

        public bool IsValid { get; set; }
        ///// <summary>
        ///// 来源 0未知 ，1教辅选题  ，2智慧作业
        ///// </summary>
        //public int Source { get; set; }



    }



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
