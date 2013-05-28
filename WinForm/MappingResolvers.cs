using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace WinForm
{
    class MappingResolvers
    {
    }

    public class GenderResolver : ValueResolver<bool, string>
    {
        protected override string ResolveCore(bool source)
        {
            return source ? "Male" : "Female";
        }
    }

    public class GradeResolver : ValueResolver<List<Grade>, decimal>
    {
        protected override decimal ResolveCore(List<Grade> grades)
        {
            return grades.Average(t => t.Score);
        }
    }

    public class DateFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            return ((DateTime)context.SourceValue).ToShortDateString();
        }
    }
}
