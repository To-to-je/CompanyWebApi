using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace CompanyWebApi.Core.Domain
{
    public class Company
    {
        private DateTime? _dateOfClientInitialization;



        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupTypeId { get; set; }
        public virtual GroupType? GroupType { get; set; }
        public DateTime CreationDate { get; }
        public virtual IList<Order>? Orders { get; set; }
        public DateTime? DateOfClientInitialization
        {
            get => _dateOfClientInitialization;
            private set
            {
                if (Orders is {Count: 0})
                {
                    _dateOfClientInitialization = null;
                }
                else
                {
                    _dateOfClientInitialization = DateTime.MaxValue;

                    if (Orders != null)
                        foreach (var order in Orders)
                        {
                            if (DateTime.Compare((DateTime) _dateOfClientInitialization, order.DateOfOrder) > 0)
                            {
                                _dateOfClientInitialization = order.DateOfOrder;
                            }
                        }
                }
            }
        }
        public virtual IList<Appointment>? Appointments { get; set; }



        

        public Company()
        {
            CreationDate = DateTime.Now;
        }
       
    }
}