using System;

namespace HtmlTable.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited = false)]
    public sealed class DisplayTableAttribute: Attribute
    {
        public bool HasHeading { get; set; }

        public bool AllowOrderBy { get; set; }

        public DisplayTableAttribute()
        {
            HasHeading = true;
            AllowOrderBy = true;
        }
    }
}