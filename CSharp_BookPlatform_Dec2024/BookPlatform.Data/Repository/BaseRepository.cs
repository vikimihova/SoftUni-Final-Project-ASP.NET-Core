﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BookPlatform.Data.Repository.Interfaces;

namespace BookPlatform.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly PlatformDbContext context;
        private readonly DbSet<TType> dbSet;

        public BaseRepository(PlatformDbContext _context) // Dependency injection dbContext
        {
            this.context = _context;
            this.dbSet = this.context.Set<TType>();
        }

        // CRUD operations implementation of IRepository

        // Add
        public void Add(TType item)
        {
            this.dbSet.Add(item);
            this.context.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
            await this.dbSet.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        // GET ALL
        public IEnumerable<TType> GetAll()
        {
            return this.dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await this.dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return this.dbSet
                .AsQueryable();
        }


        // GET BY ID
        public TType GetById(TId id)
        {
            return this.dbSet.Find(id);
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            return await this.dbSet.FindAsync(id);
        }


        // GET FIRST OR DEFAULT
        public TType FirstOrDefault(Func<TType, bool> predicate)
        {
            TType? entity = this.dbSet
                .FirstOrDefault(predicate);

            return entity;
        }

        public async Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
        {
            TType? entity = await this.dbSet
                .FirstOrDefaultAsync(predicate);

            return entity;
        }


        // ADD
        public void AddRange(TType[] items)
        {
            this.dbSet.AddRange(items);
            this.context.SaveChanges();
        }

        public async Task AddRangeAsync(TType[] items)
        {
            await this.dbSet.AddRangeAsync(items);
            await this.context.SaveChangesAsync();
        }

        // UPDATE
        public bool Update(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.context.Entry(item).State = EntityState.Modified;
                this.context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }            
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.context.Entry(item).State = EntityState.Modified;
                await this.context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE
        public bool Delete(TType item)
        {
            if (item == null)
            {
                return false;
            }

            this.dbSet.Remove(item);
            this.context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TType item)
        {
            if (item == null)
            {
                return false;
            }

            this.dbSet.Remove(item);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
