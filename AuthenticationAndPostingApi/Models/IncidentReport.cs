using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAndPostingApi.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Incident { get; set; }
        public string IncidentDescription { get; set; }
        public ObservableCollection<Comments> Comments { get; set; }
        public DateTime DateTime { get; set; }
        public int Votes { get; set; }
        public int Reports { get; set; }
        public string UserId { get; set; }
    }
}
