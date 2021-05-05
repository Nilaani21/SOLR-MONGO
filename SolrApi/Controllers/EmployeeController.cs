using CommonServiceLocator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SolrApi.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolrApi.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            ISolrOperations<Employee> solr = ServiceLocator.Current.GetInstance<ISolrOperations<Employee>>();

            SolrQueryResults<Employee> results = solr.Query(new SolrQueryByField("name", "solr"));

           
            var solr1 = ServiceLocator.Current.GetInstance<ISolrOperations<Dictionary<string, object>>>();
            solr1.Add(new Dictionary<string, object> {
            {"id", "id1234"},
            {"manu", "Asus"},
            {"popularity", 6}});
            solr1.Commit();
            return View();
            //string json = JsonConvert.SerializeObject(solr1);

            //return this.Content(json);

            // solr.Add (results);


            // 
        }
    }
}
