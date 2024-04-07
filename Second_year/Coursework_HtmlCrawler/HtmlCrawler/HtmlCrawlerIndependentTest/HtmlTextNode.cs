using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawlerIndependentTest
{
    public class HtmlTextNode : HtmlNode
    {
        private string _text;
        public HtmlTextNode(HtmlDocument ownerDocument, int index) : base(HtmlNodeType.Text, ownerDocument, index)
        {
        
        }
        public override string InnerHtml
        {
            get { return OuterHtml; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or Sets the object and its content in HTML.
        /// </summary>
        public override string OuterHtml
        {
            get
            {
                if (_text == null)
                {
                    return base.OuterHtml;
                }

                return _text;
            }
        }
        public string Text 
        {
            get
            {
                if (this._text == null)
                    return base.OuterHtml;
                return this._text;
            }
            set
            {
                _text= value;
                SetChanged();
            }
        }
    }
}
