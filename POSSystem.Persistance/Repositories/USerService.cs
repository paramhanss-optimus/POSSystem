using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Utilities;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Interfaces;

namespace POSSystem.Persistance.Repositories
{
    public class USerService : IAuth
    {

        private readonly POSSystemDBContext _context;
        private readonly TokenGenerator _tokenGenerator;

        public USerService(POSSystemDBContext context, TokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        public Task<string> AuthenticateUSerAsync(string email, string password)
        {
            var foundUSer = _context.Users.FirstOrDefault(x => x.Email == email);
            if (foundUSer != null)
            {
               
                    bool authenticationRss = EnCryptingService.ValidatePassword(password, foundUSer.Password);
                    if (authenticationRss)
                    {
                        return _tokenGenerator.IssueToken(foundUSer.UserId, foundUSer.Email, foundUSer.Role);
                    }
                    else
                    {
                        throw new Exception("Invalid Password");
                    }
                
            }
            else
            {
                throw new Exception("USer Not Found");
            }
       }
        

            public async Task<string> RegisterUserAsync(UserEntity user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return _tokenGenerator.IssueToken(user.UserId, user.Email, user.Role).Result;
            }
        }
    }
