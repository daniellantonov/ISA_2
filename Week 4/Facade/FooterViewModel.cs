using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class FooterViewModel
    {
        public FooterViewModel(string company)
        {
            SetCompanyName(company);
            SetYear();
        }
        public string CompanyName { get; set; } = "TalTech";
        public string Year { get; set; }

        public void SetCompanyName(string c)
        {
            CompanyName = c;
        }

        internal void SetYear()
        {
            Year = DateTime.Now.Year.ToString();
        }
    }
}