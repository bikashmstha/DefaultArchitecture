﻿using Domain;
using Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Persistence;
using Security;
using Security.JwtSecurity;

namespace Security.JwtSecurity
{
    public class JwtSecurity : ISecurity<User>
    {
        private UserRepository userRepository;
        public JwtSecurity(DaoContext daoContext)
        {
            userRepository = new UserRepository(daoContext);
        }

        public string Login(User identity)
        {
            var existUser = userRepository.Login(identity.Email, identity.Password);

            if (existUser != null)
            {
                return this.GenerateToken(existUser);
            }
            else return null;
        }

        public string Logout(User identity)
        {
            
            return null;
        }

        private string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "Token"),
                new[] {
                    new Claim("ID", user.ID.ToString())
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = JwtTokenConstants.Issuer,
                Audience = JwtTokenConstants.Audience,
                SigningCredentials = JwtTokenConstants.SigningCredentials,
                Subject = identity,
                Expires = DateTime.Now.Add(JwtTokenConstants.TokenExpirationTime),
                NotBefore = DateTime.Now
            });
            

            return handler.WriteToken(securityToken);
        }


    }
}