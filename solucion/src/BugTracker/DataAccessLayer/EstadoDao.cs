﻿

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using BugTracker.Entities;
using System.Data;

namespace BugTracker.DataAccessLayer
{
    public class EstadoDao
    {
        public IList<Estado> GetAll()
        {
            List<Estado> listadoBugs = new List<Estado>();

            var strSql = "SELECT id_estado, nombre from Estados where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(MappingBug(row));
            }

            return listadoBugs;
        }

        private Estado MappingBug(DataRow row)
        {
            Estado oEstado = new Estado
            {
                IdEstado = Convert.ToInt32(row["id_estado"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oEstado;
        }
    }

}