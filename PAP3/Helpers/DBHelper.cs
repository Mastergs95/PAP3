using PAP3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAP3.Data;

namespace PAP3.Helpers
{
    public class DBHelper
    {

        static public IEnumerable<SelectListItem> FillCategorias(ApplicationDbContext context)
        {
            //https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/
            // Fill Categorias List
            IEnumerable<SelectListItem> listaCategorias = context.Categorias
                .OrderBy(c => c.Nome)
                .Select(c =>
                    new SelectListItem
                    {
                        Value = Convert.ToString(c.Id),
                        Text = c.Nome
                    }).ToList();
            return listaCategorias;
        }
    }
}
