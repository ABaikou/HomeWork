using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace BillingCompanyProject
{
    class BillingCompany
    {
        private List<Client> clients;
        
        public string CompanyName { get; private set; }
        public void AddClient(Client client) 
        {
            if(!clients.Any(user => user.Phone.Number == client.Phone.Number))
            {
                clients.Add(client);
            }
            
        }
        public List<Client> GetClientList()
        {
            return clients;
        }


        public BillingCompany(string companyName)
        {
            CompanyName = companyName;
            clients = new List<Client>();
        }



    }
}
