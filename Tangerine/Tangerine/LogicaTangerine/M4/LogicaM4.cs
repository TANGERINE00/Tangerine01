using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M4;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTangerine;

namespace LogicaTangerine.M4
{
    public class LogicaM4
    {
        public Compania theCompany;

        public void init()
        {

        }
        
        public List<Compania> getCompanies()
        { 
             try
            {
                return BDCompania.ConsultCompanies(); 
            }
             catch (ArgumentNullException ex)
             {
                 throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                     LogicResourcesM4.Mensaje, ex);
             }
             catch (SqlException ex)
             {
                 throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                     LogicResourcesM4.Mensaje, ex);
             }
             catch (ExcepcionesTangerine.ExceptionTGConBD ex)
             {
                 throw ex;
             }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool AddNewCompany(Compania company)
        {
            try
            {
                return BDCompania.AddCompany(company);
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangeCompany(Compania company)
        {
            try
            {
                return (BDCompania.ChangeCompany(company));
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compania SearchCompany(int idCompany)
        {
            try
            {
                return BDCompania.ConsultCompany(idCompany);
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EnableCompany(Compania company)
        {
            try
            {
                return(BDCompania.EnableCompany(company));
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DisableCompany(Compania company)
        {
            try
            {
                return (BDCompania.DisableCompany(company));
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LugarDireccion> getPlaces()
        {
            try
            {
                return BDLugarDireccion.ConsultPlaces();
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Recibe un id de un lugar y hace el match con un nombre
        public string MatchNombreLugar(int idLugar)
        {
            try
            {
                string NombreLugar = "";
                foreach (LugarDireccion lugar in BDLugarDireccion.ConsultPlaces())
                {
                    if (idLugar.Equals(lugar.LugId))
                    {
                        NombreLugar = lugar.LugNombre;
                    }
                }

                return NombreLugar;
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Recibe un nombre de un lugar y hace el match con su respectivo id.
        public int MatchIdLugar(string nombreLugar)
        {
            try
            {
                int IdLugar = 0;
                foreach (LugarDireccion lugar in BDLugarDireccion.ConsultPlaces())
                {
                    if (nombreLugar.Equals(lugar.LugNombre))
                    {
                        IdLugar = lugar.LugId;
                    }
                }

                return IdLugar;
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
