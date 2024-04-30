using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class GetUsersByNameCU 
    {
        private IRepositorioUsuarios _repositorioUsuarios;

        public GetUsersByNameCU(IRepositorioUsuarios _repositorioUsuarios)
        {
            this._repositorioUsuarios = _repositorioUsuarios;
        }

     //   public IEnumerable<UsuarioDTO> GetUsersByName(string name)
     //   {
     //       IEnumerable<UsuarioDTO> toreturn = _repositorioUsuarios
     //. (name)
     //        .Select(team => TeamDTOMapper.ToDTO(team));
     //       return toreturn;
     //   }
    }
}
