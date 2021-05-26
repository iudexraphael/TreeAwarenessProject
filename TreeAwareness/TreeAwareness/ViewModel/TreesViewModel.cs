using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreeAwareness.Model;

namespace TreeAwareness.ViewModel
{
    public class TreesViewModel
    {
        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        public async Task<List<TreeInfo>> GetAllTrees()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Trees.ToListAsync();
            return res;

        }
        public async Task<int> UpdateTrees(TreeInfo obj)
        {
            var _dbContext = getContext();
            _dbContext.Trees.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertTree(TreeInfo obj)
        {
            var _dbContext = getContext();
            _dbContext.Trees.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteTree(TreeInfo obj)
        {
            var _dbContext = getContext();
            _dbContext.Trees.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
     

    }
}
