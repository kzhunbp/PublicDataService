using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PublicDataService.ProgramComponents
{
    public class mnb
    {

        public class helpers
        {

            public struct CurrentExchangeRate
            {

                public string Day;
                public string Curr;
                public string Rate;

            }


        }


        public string[] GetExchangeRates(string startDate,string endDate, string currencyNames)
        {
            srv.mnb.MNBArfolyamServiceSoapImpl mnbSrv = new srv.mnb.MNBArfolyamServiceSoapImpl();
            srv.mnb.GetExchangeRatesRequestBody reqBody = new srv.mnb.GetExchangeRatesRequestBody();            

            reqBody.startDate = startDate;
            reqBody.endDate = endDate;
            reqBody.currencyNames = currencyNames;

            srv.mnb.GetExchangeRatesResponseBody resBody = mnbSrv.GetExchangeRates(reqBody);


            List<string> ExchRatesList = new List<string>();
            XDocument doc = XDocument.Parse(resBody.GetExchangeRatesResult);

            var query = (IEnumerable)doc.XPathEvaluate("/MNBExchangeRates/Day/Rate");


            foreach (var x in query.Cast<XElement>())
            {
                helpers.CurrentExchangeRate currRate = new helpers.CurrentExchangeRate();

                currRate.Day = x.Parent.Attribute("date").Value;
                currRate.Curr = x.Attribute("curr").Value;
                currRate.Rate = x.Value;
                ExchRatesList.Add(currRate.Day + ';' + currRate.Curr + ';' + currRate.Rate);

            }

            return ExchRatesList.ToArray();

        }



        public string[] GetCurrentExchangeRates()
        {
            srv.mnb.MNBArfolyamServiceSoapImpl mnbSrv = new srv.mnb.MNBArfolyamServiceSoapImpl();
            srv.mnb.GetCurrentExchangeRatesRequestBody reqBody = new srv.mnb.GetCurrentExchangeRatesRequestBody();
            srv.mnb.GetCurrentExchangeRatesResponseBody resBody = mnbSrv.GetCurrentExchangeRates(reqBody);
            
            List<string> ExchRatesList = new List<string>();
            XDocument doc = XDocument.Parse(resBody.GetCurrentExchangeRatesResult);

            var query = (IEnumerable)doc.XPathEvaluate("/MNBCurrentExchangeRates/Day/Rate");


            foreach (var x in query.Cast<XElement>())
            {
                helpers.CurrentExchangeRate currRate = new helpers.CurrentExchangeRate();

                currRate.Day = x.Parent.Attribute("date").Value;
                currRate.Curr = x.Attribute("curr").Value;
                currRate.Rate = x.Value;
                ExchRatesList.Add(currRate.Day + ';' + currRate.Curr + ';' +  currRate.Rate);

            }

            return ExchRatesList.ToArray();

        }



    }
}