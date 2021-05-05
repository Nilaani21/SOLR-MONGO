using Newtonsoft.Json;
using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolrApi.Models
{
    public class Employee
	{ 
	

		
		[SolrUniqueKey("Emp_ID")]
		public int Emp_ID { get; set; }
		//[SolrField("First_Name")]
		//public string First_Name { get; set; }
		//[SolrField("Gender")]
		//public string Gender { get; set; }
		//[SolrField("Dept")]
		
		//public string Dept { get; set; }
		
	}
}
