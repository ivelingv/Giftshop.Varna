using Giftshop.Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Giftshop.Application.Extensions
{
    public static class CommonViewModelExtensions
    {

        public static IEnumerable<SelectListItem> ToSelect(this CommonViewModel source)
        {
            yield return new SelectListItem
            {
                Selected = true,
                Text = source.Description,
                Value = source.Id.ToString()
            };
        }

        public static IEnumerable<SelectListItem> ToSelect(this IEnumerable<CommonViewModel> source, object selectedValue = default)
        {
            return source.Select(e => new SelectListItem
            {
                Selected = e.Id.ToString() == selectedValue?.ToString(),
                Text = e.Description,
                Value = e.Id.ToString()
            }).ToArray() ;
        }
    }
}
