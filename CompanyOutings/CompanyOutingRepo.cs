using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class CompanyOutingRepo
    {
        public List<CompanyOuting> _companyOutings = new List<CompanyOuting>();

        public bool AddCompOuting(CompanyOuting outing)
        {
            int startingCount = _companyOutings.Count;
            _companyOutings.Add(outing);
            bool wasAdded = _companyOutings.Count == startingCount + 1;
            return wasAdded;
        }

        public CompanyOuting DiplayCompOutingsByType(EventType type)
        {
            foreach (CompanyOuting outing in _companyOutings)
                if
                    (outing.EventType == type)
                {
                    return outing;
                }
        }

        public double SumAllOutings(CompanyOuting outing)
        {
            double i = 0;
            foreach (CompanyOuting compOuting in _companyOutings)
            {
                i = compOuting.TotalEventCost + i;
            }
            return i;
        }

        public double SumOutingsByType(EventType type)
        {

            double i = 0;
        
             foreach (CompanyOuting outing in _companyOutings)
            {
                if (type == outing.EventType)
                {
                    i = outing.TotalEventCost + i;
                }
               
            }
            return i;
        }
    }
}
