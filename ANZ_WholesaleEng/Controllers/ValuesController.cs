using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Dynamic;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Text;

namespace ANZ_WholesaleEng.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            var AcctListJson = File.ReadAllText("C:/Users/mohan raj/source/repos/ANZ_WholesaleEng/ANZ_WholesaleEng/JSON/AccountList.json");
            var AcctListJObject = JObject.Parse(AcctListJson);
            var Acctlist = "Account Number  Account Name  Account Type  Balance Date  Currency Opening Available Balance " + "<br>";

            foreach (var x in AcctListJObject)
            {
                Acctlist += "<a href='/api/values/"+x.Key+"'>" + x.Key + "</a>" + "    ";
                Acctlist += x.Value["Account Name"].ToString() + "    ";
                Acctlist += x.Value["Account Type"].ToString() + "    ";
                Acctlist += x.Value["Balance Date"].ToString() + "    ";
                Acctlist += x.Value["Currency"].ToString() + "    ";
                Acctlist += x.Value["Opening Available Balance"].ToString();
                Acctlist += "<br>";
            }
            return Acctlist;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var AcctTransactionJson = File.ReadAllText("C:/Users/mohan raj/source/repos/ANZ_WholesaleEng/ANZ_WholesaleEng/JSON/AccountTransaction.json");
            var AcctTransactionJObject = JObject.Parse(AcctTransactionJson);
            var AcctTrans = "Account Number Account Name Value Date Currency Debit Amount Credit Amount Debit/Credit Transaction Narrative" + "<br>";
            foreach(var x in AcctTransactionJObject)
            {
                if (x.Key == id.ToString())
                {
                    
                    foreach (var y in x.Value)
                    {
                        AcctTrans += x.Key + " ";
                        AcctTrans += y["Account Name"].ToString() + "    ";
                        AcctTrans += y["Value Date"].ToString() + "    ";
                        AcctTrans += y["Currency"].ToString() + "    ";
                        AcctTrans += y["Debit Amount"].ToString() + "    ";
                        AcctTrans += y["Credit Amount"].ToString() + "    ";
                        AcctTrans += y["Debit/Credit"].ToString() + "    ";
                        AcctTrans += y["Transaction Narrative"].ToString() + "    ";
                        AcctTrans += "<br>";
                    }
                    break;
                }
            }

            return AcctTrans;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
