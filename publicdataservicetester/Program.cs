using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace PublicDataServiceTester
{
    class Program
    {

       


        static void Main(string[] args)
        {
            

            pubdatasrv.PublicDataServiceImp srv = new pubdatasrv.PublicDataServiceImp();
            
            
            string[]  valami = srv.MnbGetExchangeRates("2015.01.01","2015.02.01","AUD,USD");
            Console.ReadLine();
            


        }
    }
}
