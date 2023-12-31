﻿using Domain.Entities;
using Domain.Enuns;
using Domain.Repositories;
using Domain.Repositories.InterfaceServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuario _usuario;
        public UsuarioService(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public async Task AddUser(Usuario usuario)
        {
            if(usuario.Tipo == TipoUser.Admin)
            {           
                usuario.Tipo = TipoUser.Admin;
                usuario.Email = usuario.Email;
                usuario.Nome= usuario.Nome;
                await _usuario.Add(usuario);
                
            }
            else if(usuario.Tipo == TipoUser.Autor)
            {
                usuario.Tipo = TipoUser.Autor;
                usuario.Email = usuario.Email;
                usuario.Nome = usuario.Nome;
                await _usuario.Add(usuario);

            }
            throw new Exception("Tipo de usuário inválido.");

        }

        public async Task DeleteUser(Usuario usuario)
        {
            if(usuario.Tipo == TipoUser.Admin)
            {
                await _usuario.Delete(usuario);
            }
            else
            {
                throw new Exception("Usuário não autorizado para excluir outros usuários.");
            }
        }


        public async Task UpdateUser(Usuario usuario)
        {
            if(usuario.Tipo == TipoUser.Admin)
            {
                // Administradores podem editar qualquer usuário.
                usuario.Tipo = usuario.Tipo;
                usuario.Email = usuario.Email;
                usuario.Nome = usuario.Nome;
                await _usuario.Update(usuario);

            }
            else
            {
                throw new Exception("Usuário não autorizado para editar outros usuários.");
            }
        }
    }
}
