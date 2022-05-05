using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibDataVerF;

namespace LibNegVerF
{
    public class Amigo
    {
        #region atributos
        private string _rut, _nombre, _apPaterno, _apMaterno, _direccion, _fono, _email;
        private string _mensaje;
        private int _id, _edad;

        private DataSet _ds = new DataSet();
        private bool _esExito = false;
        #endregion

        #region propiedades
        public string Rut { get => _rut; set => _rut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string ApPaterno { get => _apPaterno; set => _apPaterno = value; }
        public string ApMaterno { get => _apMaterno; set => _apMaterno = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Fono { get => _fono; set => _fono = value; }
        public string Email { get => _email; set => _email = value; }
        public int Id { get => _id; set => _id = value; }
        public int Edad { get => _edad; set => _edad = value; }
        public DataSet Ds { get => _ds; set => _ds = value; }
        public bool EsExito { get => _esExito; set => _esExito = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }

        #endregion

        #region operaciones
        public Amigo ingresar(Amigo objAmigo)
        {
            BaseDato objDB = new BaseDato();
            objAmigo = objDB.ingresar(objAmigo);
            return objAmigo;
        }// fin ingresar

        public Amigo mostrar(Amigo objAmigo)
        {
            BaseDato objDB = new BaseDato();
            objAmigo = objDB.mostrar(objAmigo);
            return objAmigo;
        }// fin mostrar

        public Amigo eliminar(Amigo objAmigo)
        {
            BaseDato objDB = new BaseDato();
            objAmigo = objDB.eliminar(objAmigo);
            return objAmigo;
        }// fin eliminar

        public Amigo modificar(Amigo objAmigo)
        {
            BaseDato objDB = new BaseDato();
           objAmigo = objDB.modificar(objAmigo);
            return objAmigo;
        }// fin modificar

        #endregion


    }// Fin Class
}// Fin namesapace
