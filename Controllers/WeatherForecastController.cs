using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;

namespace ESDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        ESUtil helper = new ESUtil("http://192.168.10.113:9200/");


        [HttpGet]
        public void Insert()
        {
            
            
            helper.Insert();


        }
        [HttpGet]
        public string Term()
        {
            return helper.Term();

        }
        [HttpGet]
        public string Get()
        {
            helper.Get2Arr();

               return helper.Get1<ExerciseIndex>();



            //基于boost的细粒度搜索条件权重控制
            //    return helper.Get<gb1>();
















            //var matchQuery = new List<Func<QueryContainerDescriptor<gb1>, QueryContainer>>()
            //          {

            //     must => must.Bool(b => b.Must(m => m.Term(p => p.Field(f => f.name).Value("第一章")))),
            //};
            //  helper.SearchEs<gb1>("fafagb", 0, 100, matchQuery: matchQuery);

        }


        [HttpGet]
        public string fs()
        {
            //当filter和should同级别使用时，shuold只计算分数，不进行文档匹配。
             return  helper.fs();
        }

        [HttpGet]
        public string constantscore()
        {
            //当filter和should同级别使用时，shuold只计算分数，不进行文档匹配。
            return helper.constantscore();
        }

        [HttpGet]
        public string phrase()
        {

            //短语查询
            return helper.phrase();

        }
    }
}
