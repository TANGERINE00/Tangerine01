using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M5;

namespace LogicaTangerine.M5
{
    public class LogicaM5
    {
        public Contacto theContact;
        List<Contacto> answer;
        bool answer2;

        public void init()
        {

        }

        /// <summary>
        /// Metodo para consultar contactos de una empresa, sirve para Compania y Cliente Potencial.
        /// </summary>
        /// <param name="typeComp">entero que representa el tipo de empresa a consultar (1 para Compania, 2 para Cliente Potencial)</param>
        /// /// <param name="idComp">entero que representa el id de la empresa a consultar</param>
        /// <returns>Retorna una lista de contactos de la empresa</returns>
        public List<Contacto> GetContacts(int typeComp, int idComp) 
        {
            try
            {
            return BDContacto.ContactCompany(typeComp,idComp); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para agregar una contacto nuevo a la empresa.
        /// </summary>
        /// <param name="contact">objeto de tipo Contacto para agregar a la empresa</param>
        /// <returns>true si fue agregado</returns>
        public bool AddNewContact(Contacto contact)
        {
            try
            {
                return BDContacto.AddContact(contact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para eliminar un contacto de una empresa.
        /// </summary>
        /// <param name="idContact">entero que representa el id del contacto a eliminar de la empresa</param>
        /// <returns>true si fue eliminado</returns>
        public bool DeleteContact(int idContact)
        {
            try
            {
                return BDContacto.DeleteContact(idContact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para consultar toda la informacion de un contacto.
        /// </summary>
        /// <param name="idContact">entero que representa el id del contacto a consultar</param>
        /// <returns>Objeto de tipo contacto con los valores</returns>
        public Contacto SearchContact(int idContact)
        {
            try
            {
                return BDContacto.SingleContact(idContact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
