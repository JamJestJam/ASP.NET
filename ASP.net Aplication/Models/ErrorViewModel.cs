using System;

namespace ASP.net_Aplication.Models {
    public class ErrorViewModel {
        public String RequestId { get; set; }

        public Boolean ShowRequestId => !String.IsNullOrEmpty(this.RequestId);
    }
}
