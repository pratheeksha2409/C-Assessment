using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Customers
    {
        public Customers(int custID, string custname, string custaddress, long custnumber)
        {
            CustomerID = custID;
            CustomerName = custname;
            CustomerAddress = custaddress;
            CustomerNumber = custnumber;
        }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public long CustomerNumber { get; set; }
    }
    interface ICustomerManager
    {
        bool AddCustomer(Customers cu);
        bool DeleteCustomer(int custid);
        Customers[] FindCustomer(string custname);
        bool UpdateCustomer(int custid);
        bool GetAllCustomers();
    }
    class CustomerManager : ICustomerManager
    {
        HashSet<Customers> cust = new HashSet<Customers>();
        public bool AddCustomer(Customers cu)
        {
            return cust.Add(cu);
        }

        public bool DeleteCustomer(int custid)
        {
            foreach (Customers cu in cust)
            {
                if (cu.CustomerID == custid)
                {
                    cust.Remove(cu);
                    return true;
                }
            }
            return false;
        }

        public Customers[] FindCustomer(string custname)
        {
            List<Customers> findlist = new List<Customers>();
            foreach (Customers cu in cust)
            {
                if (cu.CustomerName.Contains(custname))
                {
                    findlist.Add(cu);
                }
            }
            return findlist.ToArray();
        }

        public bool UpdateCustomer(int custid)
        {
            foreach (Customers cu in cust)
            {
                if (cu.CustomerID == custid)

                {
                    Console.Write("Enter the New Name: ");
                    string newname = Console.ReadLine();
                    Console.Write("Enter the New Address: ");
                    string newaddress = Console.ReadLine();
                    Console.Write("Enter the New Phone Number: ");
                    long newphone = Int32.Parse(Console.ReadLine());
                    cu.CustomerName = newname;
                    cu.CustomerAddress= newaddress;
                    cu.CustomerNumber = newphone;
                    return true;
                }
            }
            return false;
        }
        public bool GetAllCustomers()
        {
            foreach (var cu in cust)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Customer ID: {cu.CustomerID}");
                Console.WriteLine($"Customer Name: {cu.CustomerName}");
                Console.WriteLine($"Customer Address: {cu.CustomerAddress}");
                Console.WriteLine($"Customer Number: {cu.CustomerNumber}");
                Console.WriteLine("-------------------------------");
            }
            return true;
        }
    }

    class CollectionCustomerManager
    {
        static void Main(string[] args)
        {
            Customers cu1 = new Customers(100, "Prathee", "Mysore", 8976543219);
            Customers cu2 = new Customers(101, "Thanu", "Bangalore", 7275643219);
            Customers cu3 = new Customers(102, "Savitha", "Pune", 9987123095);

            CustomerManager mgr = new CustomerManager();
            mgr.AddCustomer(cu1);
            mgr.AddCustomer(cu2);
            mgr.AddCustomer(cu3);
            mgr.GetAllCustomers();
            mgr.UpdateCustomer(100);
            mgr.GetAllCustomers();
            //string c= Console.ReadLine();
            //string del= mgr.DeleteCustomer(c);
            mgr.DeleteCustomer(100);

            string k = Console.ReadLine();
            Customers[] temp = mgr.FindCustomer(k);
            foreach (var item in temp)
            {
                Console.WriteLine(item.CustomerID);
                Console.WriteLine(item.CustomerName);
                Console.WriteLine(item.CustomerAddress);
                Console.WriteLine(item.CustomerNumber);
            }
        }

    }
}