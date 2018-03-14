using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core.Response
{
    public class CodeListItem
    {
        public CodeListItem(String market, String code, String name, String code_display)
        {
            this.market = market;
            this.code = code;
            this.name = name;
            this.code_display = code_display;
        }
        public CodeListItem(String market, String code, String name, String code_display, string market_display)
        {
            this.market = market;
            this.code = code;
            this.name = name;
            this.code_display = code_display;
            this.market_display = market_display;
        }
        public override bool Equals(object obj)
        {
            var rhs = obj as CodeListItem;
            if (rhs == null) return false;
            return market.Equals(rhs.market) && code.Equals(rhs.code);
        }
        public String market { get; private set; }
        public String code { get; private set; }
        public String name { get; private set; }
        public String market_display { get; private set; }
        public String code_display { get; private set; }
    }
    public class CodeListViewModel
    {
        public List<CodeListItem> items;
    }
}
