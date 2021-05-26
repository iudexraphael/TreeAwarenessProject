using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreeAwareness.Model;
namespace TreeAwareness.ViewModel
{
   public class MessageViewModel
    {
        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        public async Task<List<UserMessages>> GetAllMessages()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Messages.ToListAsync();
            return res;

        }
        public async Task<int> UpdateMessages(UserMessages obj)
        {
            var _dbContext = getContext();
            _dbContext.Messages.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertMessage(UserMessages obj)
        {
            var _dbContext = getContext();
            _dbContext.Messages.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteMessage(UserMessages obj)
        {
            var _dbContext = getContext();
            _dbContext.Messages.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }


    }
}
