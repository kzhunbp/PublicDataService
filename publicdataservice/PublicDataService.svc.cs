using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using progcomp=PublicDataService.ProgramComponents;

namespace PublicDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PublicDataServiceImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PublicDataService.svc or PublicDataService.svc.cs at the Solution Explorer and start debugging.
    public class PublicDataServiceImp : IPublicDataServiceImp
    {

       
            progcomp.mnb mnb = new progcomp.mnb();


            public string[] MnbGetCurrentExchangeRates()
            {

                return mnb.GetCurrentExchangeRates();
            }

            public string[] MnbGetExchangeRates(string startDate, string endDate, string currencyNames)
            {

                return mnb.GetExchangeRates(startDate, endDate,  currencyNames);
            }


        

            public CompositeType GetDataUsingDataContract(CompositeType composite)
            {
                if (composite == null)
                {
                    throw new ArgumentNullException("composite");
                }
                if (composite.BoolValue)
                {
                    composite.StringValue += "Suffix";
                }
                return composite;
            }


        


       

        
    }
}
