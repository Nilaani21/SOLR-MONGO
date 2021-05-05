using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolrApi.Models;
using SolrNet;
using CommonServiceLocator;
using LinqToSolr.Data;
using LinqToSolr.Services;
using Newtonsoft.Json;
using SolrNet.Commands.Parameters;

namespace SolrApi.Controllers
{
    [ApiController]   
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("{First_Name ?}/{Dept ?}")]

        public IEnumerable<int> Get(string First_Name = null, string Dept = null)

        {
            string strQuery = string.Empty;
           // SolrNet.Startup.Init<Employee>("http://localhost:8983/solr/Sample");

            ISolrOperations<Employee> _solr = ServiceLocator.Current.GetInstance<ISolrOperations<Employee>>();
            if (!string.IsNullOrWhiteSpace(First_Name))
            {
                strQuery = "First_Name:" + First_Name;
            }
            if(!string.IsNullOrWhiteSpace(strQuery) && !string.IsNullOrWhiteSpace(Dept))
            {
                strQuery += " AND " + "Dept:" + Dept;
            }
            else if (!string.IsNullOrWhiteSpace(Dept) && string.IsNullOrWhiteSpace(strQuery))
            {
                strQuery += "Dept:" + Dept;
            }
            if (string.IsNullOrWhiteSpace(strQuery))
            {
                strQuery += "*:*";
            }
            //string strQuery = (("First_Name:" + First_Name));

            var query = new SolrQuery(strQuery);
            SortOrder sortOrder = new SortOrder("First_Name");
            var solrQueryResult = _solr.Query(query, new QueryOptions
            {
                Rows = 5000, //Max Rows returned
                Start = 0,
                OrderBy = new[] { sortOrder },
                Fields = new[] { "Emp_ID" }
            });
            var list = solrQueryResult.ToList();
            //if (list.Count != 0)
            //{
            //   return (IEnumerable<Employee>)NotFound();
            //}
            //else
            //{
            //   return list;
            //}

          return list.Select(x => x.Emp_ID);

        }
       // [HttpGet("search/{First_Name}/{Dept}")]

        //public IEnumerable<Employee> GetEmpId(string First_Name, string Dept)

        //{
        //    SolrNet.Startup.Init<Employee>("http://localhost:8983/solr/Sample");
        //    ISolrOperations<Employee> _solr = ServiceLocator.Current.GetInstance<ISolrOperations<Employee>>();
        //   string strQuery = ("First_Name:" + First_Name)  "AND" ("Dept": Dept)
        //    //string strQuery = ("First_Name:" First_Name)  AND  ("Dept:" Dept);
        //    string strQuery = "(First_Name:" + F) AND (Dept: " Dept);
        //    //string strQuery = (("First_Name:" + First_Name));

        //    var query = new SolrQuery(strQuery);
        //    SortOrder sortOrder = new SortOrder("First_Name");
        //    var solrQueryResult = _solr.Query(query, new QueryOptions
        //    {
        //        Rows = 100, //Max Rows returned
        //        Start = 0,
        //        OrderBy = new[] { sortOrder },
        //        Fields = new[] { "Emp_ID" }
        //    });
        //    var list = solrQueryResult.ToList();

        //    return list;

        //}
        //}
    }

}
    

