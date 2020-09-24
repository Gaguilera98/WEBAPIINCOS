using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegUsuario
    {
        private Usuario _usuario;
        public NegUsuario()
        {
            this._usuario = new Usuario();
        }
        public int Registrar(UsuarioTR param)
        {
            _usuario.item.codigo = param.codigo;
            _usuario.item.usuario = param.usuario;
            _usuario.item.nombre = param.nombre;
            _usuario.item.apellido_paterno = param.apellido_paterno;
            _usuario.item.apellido_materno = param.apellido_materno;
            _usuario.item.contrasena = param.contrasena;
            _usuario.item.estado = param.estado;
            return _usuario.Guardar();
        }

        public UsuarioTR Login(string nusuario, string ncontrasena)
        {
            _usuario.item.usuario = nusuario;
            _usuario.item.contrasena = ncontrasena;
            _usuario.Obtenerlogin(nusuario,ncontrasena);
            return _usuario.item;
        }
    }
}