using Elasticsearch.Net;
using JiebaNet.Segmenter;
using Nest;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESDemo
{
    public class ESUtil
    {
        private readonly ElasticClient _Es;

        private readonly string KeyPrefix = string.Empty;
        // 
        private readonly string FirstConnectUri = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connection">需以 / 结尾</param>
        /// <param name="prifeix">默认为空</param>
        /// <param name="version">默认为0</param>
        /// 例如：var es = new ElasticSearchHelper("http://192.168.50.233:9200/");
        public ESUtil(string connection, string prifeix = "", int version = 0)
        {
            var uris = connection.Split(';').Select(t => new Uri(t));
            var pool = new StaticConnectionPool(uris);
            var connectionSettings = new ConnectionSettings(pool).DefaultIndex("fafagb");
            _Es = new ElasticClient(connectionSettings);
            FirstConnectUri = uris.First().AbsoluteUri;
            if (!string.IsNullOrWhiteSpace(prifeix) && !prifeix.Equals("test", StringComparison.CurrentCultureIgnoreCase) && version > 0)
            {
                KeyPrefix = (prifeix + "_" + version + "_").ToLower();
            }
        }

        //public static void AddTerms<T>(this List<Func<QueryContainerDescriptor<T>, QueryContainer>> musts, string field,
        //   object[] values) where T : class
        //{
        //    musts.Add(d => d.Terms(tq => tq.Field(field).Terms(values)));
        //}


        public void Get2Arr()
        {
            var result = _Es.Search<gb2>(t => t.Index("fafagb").Query(q => q.Match(m => m.Field(f => f.arr).Query("12737123"))));
        }
    


        public async Task Insert()
        {


            //BulkResponse bulkResponse = await _Es.BulkAsync(bulkDescriptor =>
            //{

            //        bulkDescriptor = bulkDescriptor.Index<gb1>(bulkIndexDescriptor =>
            //        {
            //            return bulkIndexDescriptor.Index("fafagb").Id(10000).Document(new gb1() { name = "term", article = "", arr = new int[] { 888, 333, 987 } });
            //        });


            //    return bulkDescriptor;
            //});

            try
            {
                var gb2 = new gb2() { name = "test", article = "", arr = new List<long[]>{ new long[] { 12737123, 12737123, 34534534 } } };
              //  var gb2 = new gb2() { name = "term", article = "", arr = new long[][] { new long[] { 123, 678, 123 } } };
                _Es.IndexDocument(gb2);

              //  _Es.Create<gb2>(new gb2() { name = "term", article = "", arr = new long[][] { new long[] { 123, 678, 123 } } }, t => t.Index("fafagb1"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
          


            _Es.Create<gb1>(new gb1() { name = "term", article = "", arr = new int[] { 888, 333, 987 } }, t => t.Index("fafagb"));
            //  _Es.CreateDocument(new gb1() { name = "term", article = "", arr = new int[] { 888, 333, 987 } });
        }



        public string Term()
        {
            //  var result = _Es.Search<gb1>(t => t.Index("fafagb").Query(q => q.Terms(t =>
            // t.Name("arr_query")

            //.Field("arr")
            //.Terms(new int[] { 888 }))));

            var result = _Es.Search<gb1>(t => t.Index("exerciseindex1").Query(q => q.Terms(t =>
       t

      .Field("arr")
      .Terms(new long[] { 999 }))));

            return $"max_score={result.MaxScore}  {JsonConvert.SerializeObject(result.Hits)}";
        }






        public string Get1<T>() where T : class
        {
            var result = _Es.Search<ExerciseIndex>(new SearchDescriptor<ExerciseIndex>().Index("exerciseindex").Query(q => q.Bool(b => b.Must(
                 new List<Func<QueryContainerDescriptor<ExerciseIndex>, QueryContainer>>() {
                  l=>l.Match(m=>m.Field(f => f.aliasid).Query("863288426577").Boost(1)),
                    l=>l.Match(m=>m.Field(f => f.difficultlevel).Query("0").Boost(1)),
                    l=>l.Terms(t =>
       t

      .Field("exercisepoolidlist")
      .Terms(new long[] { 3015074761119 }))
                 }
                 ))).From(1).Take(10));


            return $"{JsonConvert.SerializeObject(result.Hits)}";
        }



        public string Get<T>() where T : class
        {




            //通过Boost提升权重来做细粒度查询
            var result = _Es.Search<gb1>(new SearchDescriptor<gb1>().Index("fafagb").Query(q => q.Bool(b => b.Should(
                   new List<Func<QueryContainerDescriptor<gb1>, QueryContainer>>() {
                  l=>l.Match(m=>m.Field(f => f.name).Query("第一章").Boost(1)),
                    l=>l.Match(m=>m.Field(f => f.name).Query("第二章").Boost(1))
                   }
                   ))));


            return $"max_score={result.MaxScore}  {JsonConvert.SerializeObject(result.Hits)}";





            //var result = _Es.Search<gb1>(new SearchDescriptor<gb1>().Index("fafagb").Query(q => q.Bool(b => b.Should(s => s.Term(p => p.Field(f => f.name).Value("第一章").Boost(1))))));


            //var result2 = _Es.Search<T>(new SearchDescriptor<T>().Index("fafagb")
            //           .Query(q => q.Bool(b => b.Should(s => s.Match(t => t.Field(new Field("name", 1.0)).Query("第一章"))
            //           , s => s.Match(t => t.Field(new Field("name", 2.0)).Query("第二章"))
            //            ))));


            ////p => p.Field(f => f.OtherInfo).Value(name1)
            //var result3 = _Es.Search<T>(new SearchDescriptor<T>().Index("fafagb")
            //     .Query(q => q.Bool(b => b.Should(s => s.Term(t => t.Field(new Field("name", 1.0)).Value("第一章"))

            //      ))));



            //},
            //          b=>b.Filter(f=>f.Match(m=>m.Field(f => f.name).Query("第一章").Boost(1)))



        }



        public string phrase()
        {
            var result = _Es.Search<gb1>(new SearchDescriptor<gb1>().Index("fafagb").Query(q => q.MatchPhrase(t => t.Field(f => f.name).Query("第一章"))));


            return $"max_score={result.MaxScore}  {JsonConvert.SerializeObject(result.Hits)}";
        }


        public string constantscore()
        {






            var result = _Es.Search<gb1>(new SearchDescriptor<gb1>().Index("fafagb").Query(q => q.Bool(b => b.Should(
                 new List<Func<QueryContainerDescriptor<gb1>, QueryContainer>>() {
                  l=>l.ConstantScore(s=>s.Filter(f=>f.Match(m=>m.Field(f => f.name).Query("第一章").Boost(2)))),
                    l=>l.ConstantScore(s=>s.Filter(f=>f.Match(m=>m.Field(f => f.name).Query("第二章").Boost(1))))
                 }
                 ))));


            return $"max_score={result.MaxScore}  {JsonConvert.SerializeObject(result.Hits)}";
        }

        public string fs()
        {
            var result = _Es.Search<gb1>(new SearchDescriptor<gb1>().Index("fafagb").Query(q => q.Bool(
             new Func<BoolQueryDescriptor<gb1>, IBoolQuery>(b => b.Should(
               new List<Func<QueryContainerDescriptor<gb1>, QueryContainer>>() {
                  l=>l.Match(m=>m.Field(f => f.name).Query("随便").Boost(1)),

               }
               ).Filter(new List<Func<QueryContainerDescriptor<gb1>, QueryContainer>>() {
                  l=>l.Match(m=>m.Field(f => f.name).Query("第一章").Boost(1)) }
              )))
                ));


            return $"max_score={result.MaxScore}  {JsonConvert.SerializeObject(result.Hits)}";
        }



        public List<T> SearchEs<T>(string key, int lastRow = 0, int takeCnt = 100,
        List<Func<QueryContainerDescriptor<T>, QueryContainer>> matchQuery = null,
        Func<SortDescriptor<T>, IPromise<IList<ISort>>> sort = null) where T : class
        {

            string Key = (KeyPrefix + key).ToLower();

            var result = matchQuery != null ?
                 _Es.Search<T>(x => x
                .Index(Key)
                .Query(q => q.Bool(b => b.Must(matchQuery)))
                .From(lastRow)
                .Size(takeCnt)
                .Sort(sort)) :
                _Es.Search<T>(x => x
                .Index(Key)
                .From(lastRow)
                .Size(takeCnt)
                .Sort(sort))
            ;
            if (result.Documents.Count == 0)
            {
                result = matchQuery != null ?
                 _Es.Search<T>(x => x
                .Index(Key)
                .Query(q => q.Bool(b => b.Should(matchQuery)))
                .From(lastRow)
                .Size(takeCnt)
                .Sort(sort)) :
                _Es.Search<T>(x => x
                .Index(Key)
                .From(lastRow)
                .Size(takeCnt)
                .Sort(sort));
            }

            return result.Documents.ToList();
        }







    }
}
