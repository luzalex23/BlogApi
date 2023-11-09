﻿using Domain.Entities;
using Domain.Repositories;
using Infrastrutura.Data;
using Infrastrutura.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void addUser(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUserId(int userId)
        {
            return _context.Usuarios.Find(userId);
         

        }

        public Usuario GetUserName(string userName)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Nome == userName);
        }

        public void removeUser(Usuario usuario)
        {
            var user = _context.Usuarios.Find(usuario.Id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
            }
        }

        public void upadateUser(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}
